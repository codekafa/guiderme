using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Content.ServiceCategory
{
    public class CategoryListModel
    {

        public long ID { get; set; }


        public string Name { get; set; }


        public string Url { get; set; }


        public long? ParentCategoryID { get; set; }


        public string ParentCategoryName { get; set; }


        public string ParentCategoryUrl { get; set; }


        public int ServiceCount { get; set; }

    }
}
