using Core.Infrastructure;
using ViewModel.Core;

namespace Core.Locator
{
    public class ServiceWebContext : IWebContext
    {
        public WebContext Intance { get; set; }
    }
}
