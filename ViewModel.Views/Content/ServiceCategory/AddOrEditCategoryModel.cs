using Microsoft.AspNetCore.Http;

namespace ViewModel.Views.Content.ServiceCategory
{
    public class AddOrEditCategoryModel
    {

        public long ID { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string PhotoUrl { get; set; }
        public long? ParentCategoryID { get; set; }

        public IFormFile Photo { get; set; }
    }
}
