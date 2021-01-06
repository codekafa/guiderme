using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Repository.Base;
using System.Collections.Generic;
using System.Linq;
using static Common.Helpers.Enum;

namespace Business.Service
{
    public class LexiconService : ILexiconService
    {
        IUnitOfWork _uow;
        ICacheService _cacheService;
        public LexiconService(IUnitOfWork unitOfWork, ICacheService cacheService)
        {
            _uow = unitOfWork;
            _cacheService = cacheService;
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

            var cacheList = _cacheService.Get<List<Lexicon>>("lexiconTextList_CacheList");

            if (cacheList != null)
            {
                var cacheItem = cacheList.Where(x => x.KeyValue == key && x.LaunguageCode == culture && x.PageCode == page_code).FirstOrDefault();

                if (cacheItem != null)
                    return cacheItem.TextValue;
            }

            var listDb = _uow.LexiconRepository.GetList();

            var item = listDb.Where(x => x.KeyValue == key && x.LaunguageCode == culture && x.PageCode == page_code).FirstOrDefault();

            if (item == null)
            {
                _uow.LexiconRepository.Add(new Lexicon { IsActive = true, KeyValue = key, LaunguageCode = culture, TextValue = key, PageCode = page_code, Type = (int)LexiconTypes.Dictionary });
                _uow.SaveChanges();
                return key;
            }

            _cacheService.Set("lexiconTextList_CacheList", listDb, 60);
            return item.TextValue;


        }

    }
}
