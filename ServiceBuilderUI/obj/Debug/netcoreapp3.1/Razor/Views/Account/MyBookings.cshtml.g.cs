#pragma checksum "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Account\MyBookings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9cb7a4e10b3f9e90e29b5757d4e1eb9016af82f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_MyBookings), @"mvc.1.0.view", @"/Views/Account/MyBookings.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\_ViewImports.cshtml"
using ServiceBuilderUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\_ViewImports.cshtml"
using ServiceBuilderUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9cb7a4e10b3f9e90e29b5757d4e1eb9016af82f", @"/Views/Account/MyBookings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22c83b204d8066dd7c72ebd1a0b939a93ab28a11", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_MyBookings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewModel.Views.CommonResult>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Account\MyBookings.cshtml"
  
    ViewBag.Title = lexiconHelper.GetTextValue("_my_booking_page_title", 20);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"content\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            ");
#nullable restore
#line 11 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Account\MyBookings.cshtml"
       Write(await Html.PartialAsync("_GetUserMenu", new ViewDataDictionary(ViewData)
                                {
                                    { @"menu", @"service" }
                                }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-xl-9 col-md-8\">\r\n                ");
#nullable restore
#line 16 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Account\MyBookings.cshtml"
           Write(await Html.PartialAsync("../Booking/_GetRequestList", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Business.Service.Infrastructure.ISecurityService securityHelper { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Business.Service.Infrastructure.ILexiconService lexiconHelper { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ViewModel.Views.CommonResult> Html { get; private set; }
    }
}
#pragma warning restore 1591
