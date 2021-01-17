#pragma checksum "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1dc23cd204009aa56d3fa6f8aba8f8412910d4cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Booking_AvaibleRequest), @"mvc.1.0.view", @"/Views/Booking/AvaibleRequest.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dc23cd204009aa56d3fa6f8aba8f8412910d4cb", @"/Views/Booking/AvaibleRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22c83b204d8066dd7c72ebd1a0b939a93ab28a11", @"/Views/_ViewImports.cshtml")]
    public class Views_Booking_AvaibleRequest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewModel.Views.CommonResult>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
  
    ViewBag.Title = lexiconHelper.GetTextValue("_avaible_booking_page_title", 25);
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
  
    var requests = Model.Data as List<ViewModel.Views.Request.AvaibleRequestListModel>;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"content\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            ");
#nullable restore
#line 19 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
       Write(await Html.PartialAsync("../Account/_GetUserMenu", new ViewDataDictionary(ViewData)
                                {
                                    { @"menu", @"avaible" }
                                }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-xl-9 col-md-8\">\r\n                <div class=\"row\">\r\n");
#nullable restore
#line 25 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                     foreach (var request in requests)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""col-lg-12 col-md-12"">
                            <div class=""bookings"">
                                <div class=""booking-list"">
                                    <div class=""booking-widget"">
                                        <div class=""booking-det-info"">
                                            <h3>
                                                <a");
            BeginWriteAttribute("class", " class=\"", 1374, "\"", 1382, 0);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1383, "\"", 1415, 2);
            WriteAttributeValue("", 1390, "/booking-view/", 1390, 14, true);
#nullable restore
#line 33 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
WriteAttributeValue("", 1404, request.ID, 1404, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 33 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                                                                        Write(request.ServiceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                            </h3>\r\n                                            <ul class=\"booking-details\">\r\n                                                <li><span>");
#nullable restore
#line 36 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                                     Write(lexiconHelper.GetTextValue("_location", 99));

#line default
#line hidden
#nullable disable
            WriteLiteral(" :</span> ");
#nullable restore
#line 36 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                                                                                           Write(request.CityName);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 36 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                                                                                                              Write(request.CountryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                                <li><span>");
#nullable restore
#line 37 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                                     Write(lexiconHelper.GetTextValue("_user_name_request", 25));

#line default
#line hidden
#nullable disable
            WriteLiteral(" :</span> ");
#nullable restore
#line 37 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                                                                                                    Write(request.RequestUserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                                <li>\r\n                                                    <span>");
#nullable restore
#line 39 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                                     Write(lexiconHelper.GetTextValue("_finish_booking_date", 25));

#line default
#line hidden
#nullable disable
            WriteLiteral(" :</span> ");
#nullable restore
#line 39 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                                                                                                            if (request.FinishDate != null)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <label>");
#nullable restore
#line 41 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                                          Write(request.FinishDate.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n");
#nullable restore
#line 42 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class=""booking-action"">
                                        <a");
            BeginWriteAttribute("href", " href=\"", 2608, "\"", 2640, 2);
            WriteAttributeValue("", 2615, "/booking-view/", 2615, 14, true);
#nullable restore
#line 48 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
WriteAttributeValue("", 2629, request.ID, 2629, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm bg-info-light\"><i class=\"far fa-eye\"></i> ");
#nullable restore
#line 48 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                                                                                                                   Write(lexiconHelper.GetTextValue("_view_request", 25));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n\r\n                        </div>\r\n");
#nullable restore
#line 54 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n\r\n                <div class=\"pagination\">\r\n                    <ul>\r\n\r\n");
#nullable restore
#line 60 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                         if (Model.DataCount.HasValue)
                        {

                            for (int i = 0; i < Model.PageCount; i++)
                            {
                                if (i == ViewBag.Page)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"active\">\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 3406, "\"", 3433, 2);
            WriteAttributeValue("", 3413, "/avaible-bookings/", 3413, 18, true);
#nullable restore
#line 68 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
WriteAttributeValue("", 3431, i, 3431, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 68 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                                                   Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </li>\r\n");
#nullable restore
#line 70 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li");
            BeginWriteAttribute("class", " class=\"", 3639, "\"", 3647, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 3693, "\"", 3720, 2);
            WriteAttributeValue("", 3700, "/avaible-bookings/", 3700, 18, true);
#nullable restore
#line 74 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
WriteAttributeValue("", 3718, i, 3718, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 74 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                                                   Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </li>\r\n");
#nullable restore
#line 76 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Booking\AvaibleRequest.cshtml"
                                }
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
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
