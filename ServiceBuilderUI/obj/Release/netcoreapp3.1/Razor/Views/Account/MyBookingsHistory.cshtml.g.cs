#pragma checksum "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Account\MyBookingsHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "294ced452d56ac62211290711e62ce796c735318"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_MyBookingsHistory), @"mvc.1.0.view", @"/Views/Account/MyBookingsHistory.cshtml")]
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
#line 1 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\_ViewImports.cshtml"
using ServiceBuilderUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\_ViewImports.cshtml"
using ServiceBuilderUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"294ced452d56ac62211290711e62ce796c735318", @"/Views/Account/MyBookingsHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22c83b204d8066dd7c72ebd1a0b939a93ab28a11", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_MyBookingsHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewModel.Views.CommonResult>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Account\MyBookingsHistory.cshtml"
  
    ViewBag.Title = lexiconHelper.GetTextValue("_my_booking_history_page_title", 20);
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"content\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            ");
#nullable restore
#line 13 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Account\MyBookingsHistory.cshtml"
       Write(await Html.PartialAsync("_GetUserMenu", new ViewDataDictionary(ViewData)
                                {
                                    { @"menu", @"booking" }
                                }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-xl-9 col-md-8\">\r\n                ");
#nullable restore
#line 18 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Account\MyBookingsHistory.cshtml"
           Write(await Html.PartialAsync("../Booking/_GetRequestList", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <div class=\"pagination\">\r\n                    <ul>\r\n\r\n");
#nullable restore
#line 23 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Account\MyBookingsHistory.cshtml"
                         if (Model.DataCount.HasValue)
                        {
                            var count = Model.DataCount.Value;

                            long k = count % 10;

                            long page = 0;

                            if (k > 0)
                            {
                                page = (count / 10) + 1;
                            }
                            else
                            {
                                page = (count / 10);
                            }

                            for (int i = 0; i < page; i++)
                            {
                                if (i == ViewBag.Page)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"active\">\r\n                                        <a");
            BeginWriteAttribute("href", "  href=\"", 1732, "\"", 1763, 2);
            WriteAttributeValue("", 1740, "/my-bookings-history/", 1740, 21, true);
#nullable restore
#line 45 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Account\MyBookingsHistory.cshtml"
WriteAttributeValue("", 1761, i, 1761, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 45 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Account\MyBookingsHistory.cshtml"
                                                                       Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </li>\r\n");
#nullable restore
#line 47 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Account\MyBookingsHistory.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li");
            BeginWriteAttribute("class", " class=\"", 1969, "\"", 1977, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 2023, "\"", 2053, 2);
            WriteAttributeValue("", 2030, "/my-bookings-history/", 2030, 21, true);
#nullable restore
#line 51 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Account\MyBookingsHistory.cshtml"
WriteAttributeValue("", 2051, i, 2051, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 51 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Account\MyBookingsHistory.cshtml"
                                                                      Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </li>\r\n");
#nullable restore
#line 53 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Account\MyBookingsHistory.cshtml"
                                }
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </ul>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Business.Service.Infrastructure.IContentService contentHelper { get; private set; }
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
