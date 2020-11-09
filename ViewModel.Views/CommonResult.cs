using System;

namespace ViewModel.Views
{
    [Serializable]
    public class CommonResult
    {
        public CommonResult()
        {

        }
        public CommonResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public CommonResult(bool isSuccess, string message, string actipnCode)
        {
            IsSuccess = isSuccess;
            Message = message;
            ActionCode = actipnCode;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string ActionCode { get; set; }
    }
}
