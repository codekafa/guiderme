using System;
using ViewModel.Core;

namespace Core.Infrastructure
{
    public interface IWebContext
    {
        WebContext Intance { get; set; }
    }
}
