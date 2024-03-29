#pragma checksum "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8834e08c3e5e5a1923bfd5ac20322fc631109ce2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Service_GetServiceList), @"mvc.1.0.view", @"/Views/Shared/Service/GetServiceList.cshtml")]
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
#line 1 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\_ViewImports.cshtml"
using ServiceBuilderPanel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\_ViewImports.cshtml"
using ServiceBuilderPanel.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8834e08c3e5e5a1923bfd5ac20322fc631109ce2", @"/Views/Shared/Service/GetServiceList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"107b284f0b9298a46861638556c2b90a8c8fa378", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Service_GetServiceList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewModel.Views.CommonResult>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
  
    var serviceList = Model.Data as List<ViewModel.Views.Service.ServiceListModel>;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            <h3 class=\"card-title\">Service  List - Total : ");
#nullable restore
#line 11 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                                                      Write(Model.DataCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
        </div>
        <div class=""card-body"">
            <table class=""table table-bordered"">
                <thead>
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">CreateDate</th>
                        <th scope=""col"">Email</th>
                        <th scope=""col"">Name</th>
                        <th scope=""col"">ServiceCategory</th>
                        <th scope=""col"">Country/City</th>
                        <th scope=""col"">ServiceStartYear</th>
                        <th scope=""col"">Longitude/Latitude</th>
                        <th scope=""col""></th>
                    </tr>
                </thead>
                <tbody>

");
#nullable restore
#line 30 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                     if (serviceList != null && serviceList.Count > 0)
                    {
                        foreach (var item in serviceList)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 35 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                               Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 36 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                               Write(item.CreateDate.ToString("dd.MM.yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 37 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                               Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 38 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 39 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                               Write(item.ServiceCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 40 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                               Write(item.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 40 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                                             Write(item.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 41 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                               Write(item.ServiceStartYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 42 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                               Write(item.Longitude);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 42 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                                               Write(item.Latitude);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8834e08c3e5e5a1923bfd5ac20322fc631109ce28367", async() => {
                WriteLiteral("<i class=\"fa fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1788, "~/Service/ServiceDetail?service_id=", 1788, 35, true);
#nullable restore
#line 43 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
AddHtmlAttributeValue("", 1823, item.ID, 1823, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 45 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                        }

                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr col=\"8\">Data not found!</tr>\r\n");
#nullable restore
#line 51 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n\r\n        <div class=\"card-footer clearfix\">\r\n            <ul class=\"pagination pagination-sm m-0 float-right\">\r\n");
#nullable restore
#line 58 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                 for (int i = 1; i < Model.PageCount.Value + 1; i++)
                {
                    if (Model.SelectedPage == (i - 1))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"active page-item\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2484, "\"", 2516, 3);
            WriteAttributeValue("", 2494, "filterServices(", 2494, 15, true);
#nullable restore
#line 62 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
WriteAttributeValue("", 2509, i-1, 2509, 6, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2515, ")", 2515, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2517, "\"", 2536, 2);
            WriteAttributeValue("", 2522, "page_id_", 2522, 8, true);
#nullable restore
#line 62 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
WriteAttributeValue("", 2530, i-1, 2530, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a class=\"page-link\" href=\"#\">");
#nullable restore
#line 62 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                                                                                                                                    Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 63 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\" page-item\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2701, "\"", 2733, 3);
            WriteAttributeValue("", 2711, "filterServices(", 2711, 15, true);
#nullable restore
#line 66 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
WriteAttributeValue("", 2726, i-1, 2726, 6, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2732, ")", 2732, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2734, "\"", 2753, 2);
            WriteAttributeValue("", 2739, "page_id_", 2739, 8, true);
#nullable restore
#line 66 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
WriteAttributeValue("", 2747, i-1, 2747, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a class=\"page-link\" href=\"#\">");
#nullable restore
#line 66 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                                                                                                                              Write(i );

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 67 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Shared\Service\GetServiceList.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </div>\r\n    </div>\r\n\r\n");
        }
        #pragma warning restore 1998
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
