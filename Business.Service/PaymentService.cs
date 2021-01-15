using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using ViewModel.Views.Payment;
using static Common.Helpers.Enum;

namespace Business.Service
{
    public class PaymentService : IPaymentService
    {
        IUnitOfWork _uow;
        IFileService _fileService;
        ILexiconService _lexService;
        IExceptionManager _exM;
        public PaymentService(IUnitOfWork unitOfWork, IFileService fileService, ILexiconService lexiconService, IExceptionManager exceptionManager)
        {
            _uow = unitOfWork;
            _fileService = fileService;
            _lexService = lexiconService;
            _exM = exceptionManager;
        }
        public CommonResult AddNewOrderPaymentRequest(AddNewOrderPaymentRequestModel requestModel)
        {
            CommonResult result = new CommonResult();

            var strategy = _uow.CreateExecuteStrategy();
            strategy.Execute(() =>
            {
                using (var ts = _uow.BeginTransaction())
                {
                    try
                    {
                        var imgResult = _fileService.SaveImage(requestModel.DocumentPhoto, FileTypes.OrderDocument);

                        if (imgResult.IsSuccess)
                        {
                            var newOrderRequest = new OrderPaymentRequest();
                            var newPaymentTransaction = new PaymentTransaction();
                            newPaymentTransaction.IsActive = true;
                            newPaymentTransaction.Status = (int)PaymentTransactionStatus.Waiting;
                            newPaymentTransaction.PaymentTotal = requestModel.OrderAmount + (requestModel.OrderAmount * (0.10M));
                            newPaymentTransaction.PaymentTaxTotal = (newPaymentTransaction.PaymentTotal - newPaymentTransaction.PaymentTotal * 1.18M);
                            newPaymentTransaction.TransactionType = (int)PaymentTransactionTypes.Order;
                            newPaymentTransaction.ProcessType = (int)PaymentTransactionProcessType.Input;
                            newPaymentTransaction.UserID = requestModel.UserID;
                            newPaymentTransaction = _uow.PaymentTransactionRepository.Add(newPaymentTransaction);
                            newOrderRequest.IsActive = true;
                            newOrderRequest.RequestDocumentUrl = imgResult.Data.ToString();
                            newOrderRequest.Status = (int)OrderRequestStatus.Waiting;
                            newOrderRequest.UserID = requestModel.UserID;
                            newOrderRequest.RequestPaymentTotal = requestModel.OrderAmount;
                            newOrderRequest.RequestPaymentDiscount = 10;
                            newOrderRequest.PaymentTransactionID = newPaymentTransaction.ID;
                            _uow.OrderPaymentRequestRepository.Add(newOrderRequest);
                            _uow.SaveChanges();
                            _uow.Commit();

                            result.IsSuccess = true;
                            result.Message = _lexService.GetAlertSring("_added_new_order_request_payment_successfuly", null);
                            return result;
                        }
                        else
                        {
                            result.IsSuccess = false;
                            result.Message = imgResult.Message;
                            return result;
                        }
                    }
                    catch (Exception ex)
                    {
                        _uow.Rollback();
                        _exM.HandleException(ex);

                        result.IsSuccess = false;
                        result.Message = ex.Message;
                        return result;

                    }
                }
            });

            return result;

        }
    }
}
