using Repository.Base;
using ViewModel.Views;

namespace Business.Service
{
    public class CommonResultHelper
    {
        static ILexiconRepository _lexRepo;
        public CommonResultHelper(ILexiconRepository lexRepo)
        {
            _lexRepo = lexRepo;
        }


        public CommonResult GetAlertResult(bool isSuccess, string key, string culture)
        {
            var item = _lexRepo.Get(x => x.Key == key && x.LaunguageCode == culture);

            return new CommonResult { IsSuccess = isSuccess, Message = key };

        }

    }
}
