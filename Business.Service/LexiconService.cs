using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Repository.Base;
using static Common.Helpers.Enum;

namespace Business.Service
{
    public class LexiconService : ILexiconService
    {
        IUnitOfWork _uow;
        public LexiconService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public string GetAlertSring(string key, string culture = null)
        {
            culture = "en-EN";
            var item = _uow.LexiconRepository.Get(x => x.KeyValue == key && x.LaunguageCode == culture);

            if (item == null)
            {
                _uow.LexiconRepository.Add(new Lexicon { IsActive = true, KeyValue = key, LaunguageCode = culture, TextValue = key, Type = (int)LexiconTypes.Alert });
                _uow.SaveChanges();
                return key;
            }

            return item.TextValue;
        }

        public string GetTextValue(string key, int page_code)
        {
            string culture = "en-EN";
            var item = _uow.LexiconRepository.Get(x => x.KeyValue == key && x.LaunguageCode == culture && x.PageCode == page_code);

            if (item == null)
            {
                _uow.LexiconRepository.Add(new Lexicon { IsActive = true, KeyValue = key, LaunguageCode = culture, TextValue = key, PageCode = page_code, Type = (int)LexiconTypes.Dictionary });
                _uow.SaveChanges();
                return key;
            }

            return item.TextValue;
        }

    }
}
