using DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.BaseEntities
{
    public class ServiceCategory : BaseEntity
    {

        public string Name { get; set; }

        public string Url { get; set; }

        public string CategoryPhoto { get; set; }

        public ServiceCategory ParentServiceCategory { get; set; }

        public List<ServiceCategoryProperty> ServiceCategoryProperty { get; set; }
    }
}
