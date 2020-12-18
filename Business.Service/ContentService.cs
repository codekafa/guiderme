using Business.Service.Infrastructure;
using Common.Helpers;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure.Interface;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using ViewModel.Views;
using ViewModel.Views.Content;
using ViewModel.Views.Content.ServiceCategory;
using static Common.Helpers.Enum;

namespace Business.Service
{
    public class ContentService : IContentService
    {
        IServiceCategoryPropertyRepository _scpRepo;
        IFileService _fileService;
        IQuerableRepository _queryRepo;
        IUnitOfWork _uow;
        public ContentService(IFileService fileService, IQuerableRepository queryRepo, IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _fileService = fileService;
            _queryRepo = queryRepo;
        }
        public CommonResult AddCategory(ServiceCategory item)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            item.IsActive = true;
            var category = _uow.ServiceCategoryRepository.Add(item);
            _uow.SaveChanges();
            result.Data = category;
            return result;
        }
        public CommonResult AddCategoryProperty(ServiceCategoryProperty item)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            item.IsActive = true;
            var ctProp = _uow.ServiceCategoryPropertyRepository.Add(item);
            _uow.SaveChanges();
            result.Data = ctProp;
            return result;
        }
        public CommonResult GetCategory(long category_id)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            var item = _uow.ServiceCategoryRepository.Get(x => x.ID == category_id);
            result.Data = item;
            return result;
        }
        public CommonResult GetCategoryList()
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;

            string query = @"select 
                            se.ID,
                            se.Name,
                            se.Url,
                            se.ParentServiceCategoryID as ParentCategoryID,
                            (select COUNT(s.ID) from services s where  s.ServiceCategoryID = se.ID ) as ServiceCount
                             from servicecategories se 
                             where se.IsActive = 1";

            var list = _queryRepo.GetList<CategoryListModel>(query, null);


            foreach (var item in list)
            {

                if (item.ParentCategoryID.HasValue)
                {
                    var parentItem = list.Where(x => x.ID == item.ParentCategoryID.Value).FirstOrDefault();
                    item.ParentCategoryID = parentItem.ID;
                    item.ParentCategoryName = parentItem.Name;
                    item.ParentCategoryUrl = parentItem.Url;
                }
            }
            result.Data = list;
            return result;
        }
        public CommonResult GetParentCategoryList()
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            List<CategoryListModel> resultList = new List<CategoryListModel>();
            var list = _uow.ServiceCategoryRepository.GetList(x => x.IsActive && x.ParentServiceCategory == null);
            resultList = list.Select(x => new CategoryListModel { ID = x.ID, Name = x.Name, Url = x.Url }).ToList();
            result.Data = resultList;
            return result;
        }
        public CommonResult GetCategoryPropertyList(long category_id)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            result.Data = _uow.ServiceCategoryPropertyRepository.GetList(x => x.IsActive && x.ServiceCategory.ID == category_id);
            return result;
        }
        public CommonResult RemoveCategory(ServiceCategory item)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            item.IsActive = false;
            _uow.ServiceCategoryRepository.Update(item);
            _uow.SaveChanges();
            result.Data = item;
            return result;
        }
        public CommonResult RemoveCategoryProperty(long item_id)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            var exist = _uow.ServiceCategoryPropertyRepository.Get(x => x.ID == item_id);
            exist.IsActive = false;
            _uow.ServiceCategoryPropertyRepository.Update(exist);
            _uow.SaveChanges();
            result.Data = exist;
            return result;
        }
        public CommonResult AddOrEditCategory(AddOrEditCategoryModel category)
        {
            var result = new CommonResult();
            var existSC = new ServiceCategory();

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                result.IsSuccess = false;
                result.Message = "Name is requeired!";
                return result;
            }

            existSC.ID = category.ID;
            existSC.ParentServiceCategoryID = category.ParentCategoryID;

            if (category.Photo != null && !string.IsNullOrWhiteSpace(category.Name))
            {
                string path = _fileService.SaveImage(category.Photo, FileTypes.ServiceCategoryFiles).Data.ToString();
                existSC.CategoryPhoto = path;
            }
            else
            {
                existSC.CategoryPhoto = category.PhotoUrl;
            }

            if (string.IsNullOrWhiteSpace(category.Url))
                existSC.Url = HelperUtility.MakeUrlCompatible(category.Name).ToLower();
            else
                existSC.Url = category.Url;

            existSC.Name = category.Name;
            existSC.MetaDescription = category.MetaDescription;
            existSC.MetaTitle = category.MetaTitle;
            existSC.CategoryPhotoAltTag = category.PhotoAltTag;
            existSC.Description = category.Description;
            existSC.IsMainCategory = category.IsMainCategory;
            if (category.ID > 0)
                result = UpdateCategory(existSC);
            else
                result = AddCategory(existSC);

            result.IsSuccess = true;
            return result;
        }
        public CommonResult UpdateCategory(ServiceCategory item)
        {
            CommonResult result = new CommonResult();
            item.IsActive = true;
            result.IsSuccess = true;
            result.Data = _uow.ServiceCategoryRepository.Update(item);
            _uow.SaveChanges();
            return result;
        }
        public CommonResult UpdateCategoryProperty(ServiceCategoryProperty item)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            item.IsActive = true;
            var exist = _scpRepo.Get(x => x.ID == item.ID);
            exist.Name = item.Name;
            exist.IsActive = true;
            exist.RowNumber = item.RowNumber;
            result.Data = _uow.ServiceCategoryPropertyRepository.Update(exist);
            _uow.SaveChanges();
            return result;
        }
        public CommonResult GetCountries()
        {
            CommonResult result = new CommonResult();
            result.Data = _uow.CountryRepository.GetList(x => x.IsActive == true);
            result.IsSuccess = true;
            return result;
        }
        public CommonResult GetCities(long country_id)
        {
            CommonResult result = new CommonResult();
            result.Data = _uow.CityRepository.GetList(x => x.IsActive == true && x.CountryID == country_id);
            result.IsSuccess = true;
            return result;
        }
        public CommonResult GetCategoryList(CategorySearchModel search)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;

            string query = @"select 
                            se.ID,
                            se.Name,
                            se.Url,
                            se.CategoryPhoto,
                            (select COUNT(s.ID) from services s where  s.ServiceCategoryID = se.ID and s.IsActive = 1 ) as ServiceCount
                            from servicecategories se 
                            where se.IsActive = 1";

            query += " LIMIT " + search.PageIndex * search.TakeRow + "," + search.TakeRow;
            var list = _queryRepo.GetList<CategoryListModel>(query, null);
            result.Data = list;
            result.DataCount = list.Count;
            return result;
        }

        public List<CategoryAutoCompleteModel> GetCategoryAutoCompleteList(string keys)
        {
            List<CategoryAutoCompleteModel> result = new List<CategoryAutoCompleteModel>();

            string like = "%" + keys + "%";

            string query = @"select 
                            Id as data,
                            Name as value from servicecategories WHERE   ParentServiceCategoryID  > 0 and  name like @Search";
            result = _queryRepo.GetList<CategoryAutoCompleteModel>(query, new SearchAutoCmpleteModel { Search = like });
            return result;
        }

        public List<SelectViewModel> GetCategorySelectViewModel()
        {
            List<SelectViewModel> result = new List<SelectViewModel>();

            string query = @"select 
                            Id as ID,
                            Name as Name from servicecategories WHERE IsActive = 1 and ParentServiceCategoryID  > 0";
            result = _queryRepo.GetList<SelectViewModel>(query, null);
            return result;
        }

        public List<SelectViewModel> GetCountriesSelectViewModel()
        {
            List<SelectViewModel> result = new List<SelectViewModel>();

            string query = @"select 
                            Id as ID,
                            Name as Name from countries where IsActive = 1";
            result = _queryRepo.GetList<SelectViewModel>(query, null);
            return result;
        }
        public List<SelectViewModel> GetCitiesSelectViewModel(long country_id)
        {
            List<SelectViewModel> result = new List<SelectViewModel>();

            string query = @"select 
                            Id as ID,
                            Name as Name from cities where IsActive = 1 and  CountryID = @p0";
            result = _queryRepo.GetList<SelectViewModel>(query, new BaseParamModel { p0 = country_id });
            return result;
        }

        public CommonResult GetLexiconList(LexiconSearchModel search)
        {
            CommonResult result = new CommonResult();

            string query = @"select * from lexicons where IsActive = 1 and PageCode = @PageCode ";

            if (!string.IsNullOrWhiteSpace(search.SearchKey))
            {
                string like = "%" + search.SearchKey + "%";
                search.SearchKey = like;
                query += " and (KeyValue like @SearchKey or  TextValue like @SearchKey)";
            }

            query += " LIMIT " + search.PageIndex * 20 + ",20";


            var list = _queryRepo.GetList<LexiconListModel>(query, search);


            result.IsSuccess = true;
            result.Data = list;
            result.DataCount = GetLexiconListCount(search);
            result.SelectedPage = search.PageIndex;

            long k = result.DataCount.Value % 10;

            if (k > 0)
                result.PageCount = (result.DataCount / 20) + 1;
            else
                result.PageCount = result.DataCount;

            return result;

        }

        public long GetLexiconListCount(LexiconSearchModel search)
        {
            string query = @"select COUNT(*) from lexicons where IsActive = 1 and PageCode = @PageCode ";

            if (!string.IsNullOrWhiteSpace(search.SearchKey))
            {
                string like = "%" + search.SearchKey + "%";
                search.SearchKey = like;
                query += " and (KeyValue like @SearchKey or  TextValue like @SearchKey)";
            }

            var count = _queryRepo.GetSingle<long>(query, search);

            return count;
        }
    }
}
