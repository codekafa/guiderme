using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Repository.Base;
using static Common.Helpers.Enum;

namespace Business.Service
{
    public class LexiconService : ILexiconService
    {
        ILexiconRepository _lexPreo;
        public LexiconService(ILexiconRepository lexRepo)
        {
            _lexPreo = lexRepo;
        }
        public string GetAlertSring(string key, string culture = null)
        {
            culture = "en-EN";
            var item = _lexPreo.Get(x => x.Key == key && x.LaunguageCode == culture);

            if (item == null)
            {
                _lexPreo.Add(new Lexicon { IsActive = true, Key = key, LaunguageCode = culture, Value = key, Type = (int)LexiconTypes.Alert });
                return key;
            }

            return item.Value;
        }

        public string GetTextValue(string key, int page_code)
        {
            string culture = "en-EN";
            var item = _lexPreo.Get(x => x.Key == key && x.LaunguageCode == culture && x.PageCode == page_code);

            if (item == null)
            {
                _lexPreo.Add(new Lexicon { IsActive = true, Key = key, LaunguageCode = culture, Value = key, PageCode = page_code, Type = (int)LexiconTypes.Dictionary });
                return key;
            }

            return item.Value;
        }

    }
}
