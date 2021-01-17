using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Infrastructure.Interface;
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
        IQuerableRepository _queryRepo;
        public PaymentService(IUnitOfWork unitOfWork, IFileService fileService, ILexiconService lexiconService, IExceptionManager exceptionManager, IQuerableRepository querableRepository)
        {
            _uow = unitOfWork;
            _fileService = fileService;
            _lexService = lexiconService;
            _exM = exceptionManager;
            _queryRepo = querableRepository;
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
        public CommonResult GetOrderRequestList(OrderRequestPaymentSearchModel search)
        {
            CommonResult result = new CommonResult();

            string query = @"SELECT u.FirstName,
                        u.LastName,
                        u.ID as UserID,
                        u.Email,
                        op.ID as OrderRequestID,
                        op.CreateDate ,
                        op.Status,
                        op.RequestPaymentTotal as Amount,
                        op.RequestPaymentDiscount as Discount,
                        op.RequestDocumentUrl as DocumentUrl
                        FROM orderpaymentrequests op
                        inner join users u on u.ID = op.UserID
                        where  op.IsActive = 1 ";


            if (search.Status.HasValue)
            {
                query += " and op.Status = " + search.Status.ToString();
            }

            if (search.CurrentUserId > 0)
            {
                query += "and op.UserID = " + search.CurrentUserId.ToString();
            }

            if (search.StartDate.HasValue)
            {
                query += " and op.CreateDate > @StartDate";
            }

            if (search.FinishDate.HasValue)
            {
                query += " and op.CreateDate < @FinishDate";
            }

            if (search.p0 != null)
            {
                query += " and op.ID = @p0";
            }

            query += " ORDER BY  op.CreateDate DESC";
            query += " LIMIT  " + search.PageIndex * search.TakeRow + "," + search.TakeRow;




            var resultList = _queryRepo.GetList<OrderPaymentRequestListModel>(query, search);

            string queryCount = @"SELECT COUNT(*)
                        FROM orderpaymentrequests op
                        inner join users u on u.ID = op.UserID
                        where  op.IsActive = 1 ";

            if (search.Status.HasValue)
            {
                queryCount += " and op.Status = " + search.Status.ToString();
            }

            if (search.CurrentUserId > 0)
            {
                queryCount += "and op.UserID = " + search.CurrentUserId.ToString();
            }

            if (search.StartDate.HasValue)
            {
                queryCount += " and op.CreateDate > @StartDate";
            }

            if (search.FinishDate.HasValue)
            {
                queryCount += " and op.CreateDate < @FinishDate";
            }

            if (search.p0 != null)
            {
                queryCount += " and op.ID = @p0";
            }

            long count = _queryRepo.GetSingle<long>(queryCount, search);

            result.DataCount = count;

            long k = count % 10;

            if (k > 0)
                count = (count / 10) + 1;
            result.IsSuccess = true;
            result.Data = resultList;
            result.PageCount = count;
            result.SelectedPage = search.PageIndex;
            return result;
        }



        public CommonResult ApproveOrderRequest(long order_reqeust_id)
        {
            CommonResult result = new CommonResult();
            var request = _uow.OrderPaymentRequestRepository.Get(x => x.ID == order_reqeust_id);
            request.Status = (int)OrderRequestStatus.Appleyed;
            _uow.OrderPaymentRequestRepository.Update(request);
            _uow.SaveChanges();
            var transaction = _uow.PaymentTransactionRepository.Get(x => x.ID == request.PaymentTransactionID.Value);
            transaction.Status = (int)PaymentTransactionStatus.Appleyed;
            _uow.PaymentTransactionRepository.Update(transaction);
            _uow.SaveChanges();
            UpdateUserBalanceWithNofitication(request.UserID, request.RequestPaymentTotal);
            result.IsSuccess = true;
            return result;
        }


        public CommonResult UpdateUserBalanceWithNofitication(long user_id, decimal topup)
        {
            CommonResult result = new CommonResult();
            var user = _uow.UserRepository.Get(x => x.ID == user_id);
            user.Balance = user.Balance + topup;
            _uow.UserRepository.Update(user);
            _uow.SaveChanges();

            result.IsSuccess = true;
            return result;
        }

    }
}
