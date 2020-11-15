using Business.Service.Infrastructure;
using Common.Helpers;
using DataModel.BaseEntities;
using Repository.Base;
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
        public ContentService(IServiceCategoryPropertyRepository scpRepo, IServiceCategoryRepository scRepo, IFileService fileService)
        {
            _scRepo = scRepo;
            _scpRepo = scpRepo;
            _fileService = fileService;
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
            List<CategoryListModel> resultList = new List<CategoryListModel>();
            var list = _scRepo.GetList(x => x.IsActive);

            foreach (var item in list)
            {
                CategoryListModel addItem = new CategoryListModel();
                addItem.ID = item.ID;
                addItem.Name = item.Name;
                addItem.Url = item.Url;

                if (item.ParentServiceCategory != null)
                {
                    addItem.ParentCategoryID = item.ParentServiceCategory.ID;
                    addItem.ParentCategoryName = item.ParentServiceCategory.Name;
                    addItem.ParentCategoryUrl = item.ParentServiceCategory.Url;
                }
                resultList.Add(addItem);
            }
            result.Data = resultList;
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
            existSC.Url = HelperUtility.MakeUrlCompatible(category.Name).ToLower();
            existSC.Name = category.Name;
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
            var exist = _scpRepo.Get(x=>x.ID == item.ID);
            exist.Name = item.Name;
            exist.IsActive = true;
            result.Data = _scpRepo.Update(exist);
            return result;
        }
    }
}
