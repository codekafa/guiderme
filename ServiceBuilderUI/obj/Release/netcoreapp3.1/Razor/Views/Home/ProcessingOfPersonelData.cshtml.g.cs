#pragma checksum "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\ProcessingOfPersonelData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e129535b3a76783380967e2ce7dd789f40be100"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ProcessingOfPersonelData), @"mvc.1.0.view", @"/Views/Home/ProcessingOfPersonelData.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e129535b3a76783380967e2ce7dd789f40be100", @"/Views/Home/ProcessingOfPersonelData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22c83b204d8066dd7c72ebd1a0b939a93ab28a11", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ProcessingOfPersonelData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\ProcessingOfPersonelData.cshtml"
  
    ViewBag.Title = lexiconHelper.GetTextValue("_process_personel_data_page_title", 8);
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\ProcessingOfPersonelData.cshtml"
  
    var page = pageService.GetPageByCode(4).Data as DataModel.BaseEntities.Page;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"faq-card\">\r\n    <div class=\"content\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12\">\r\n                    <div class=\"about-blk-content\">\r\n                        ");
#nullable restore
#line 19 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\ProcessingOfPersonelData.cshtml"
                   Write(Html.Raw(page.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Business.Service.Infrastructure.IPageService pageService { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
