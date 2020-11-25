using Business.Service.Infrastructure;
using Common.Helpers;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure.Interface;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Views;
using ViewModel.Views.Content.ServiceCategory;
using static Common.Helpers.Enum;

namespace Business.Service
{
    public class ContentService : IContentService
    {
        IServiceCategoryRepository _scRepo;
        IServiceCategoryPropertyRepository _scpRepo;
        IFileService _fileService;
        ICountryRepository _countryRepo;
        ICityRepository _cityRepo;
        IQuerableRepository _queryRepo;
        public ContentService(IServiceCategoryPropertyRepository scpRepo, IServiceCategoryRepository scRepo, IFileService fileService, ICountryRepository countryRepo, ICityRepository cityRepo, IQuerableRepository queryRepo)
        {
            _scRepo = scRepo;
            _scpRepo = scpRepo;
            _fileService = fileService;
            _countryRepo = countryRepo;
            _cityRepo = cityRepo;
            _queryRepo = queryRepo;
        }
        public CommonResult AddCategory(ServiceCategory item)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            item.IsActive = true;
            result.Data = _scRepo.Add(item);
            return result;
        }
        public CommonResult AddCategoryProperty(ServiceCategoryProperty item)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            item.IsActive = true;
            result.Data = _scpRepo.Add(item);
            return result;
        }
        public CommonResult GetCategory(long category_id)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            var item = _scRepo.Get(x => x.ID == category_id);
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
            var list = _scRepo.GetList(x => x.IsActive && x.ParentServiceCategory == null);
            resultList = list.Select(x => new CategoryListModel { ID = x.ID, Name = x.Name, Url = x.Url }).ToList();
            result.Data = resultList;
            return result;
        }
        public CommonResult GetCategoryPropertyList(long category_id)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            result.Data = _scpRepo.GetList(x => x.IsActive && x.ServiceCategory.ID == category_id);
            return result;
        }
        public CommonResult RemoveCategory(ServiceCategory item)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            item.IsActive = false;
            _scRepo.Update(item);
            result.Data = item;
            return result;
        }
        public CommonResult RemoveCategoryProperty(long item_id)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            var exist = _scpRepo.Get(x => x.ID == item_id);
            exist.IsActive = false;
            result.Data = _scpRepo.Update(exist);
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
            result.Data = _scRepo.Update(item);
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
            result.Data = _scpRepo.Update(exist);
            return result;
        }
        public CommonResult GetCountries()
        {
            CommonResult result = new CommonResult();
            result.Data = _countryRepo.GetList(x => x.IsActive == true);
            result.IsSuccess = true;
            return result;
        }
        public CommonResult GetCities(long country_id)
        {
            CommonResult result = new CommonResult();
            result.Data = _cityRepo.GetList(x => x.IsActive == true && x.CountryID == country_id);
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
                            Name as value from servicecategories WHERE name like @Search";
             result = _queryRepo.GetList<CategoryAutoCompleteModel>(query, new SearchAutoCmpleteModel { Search = like });
            return result;
        }
    }
}
