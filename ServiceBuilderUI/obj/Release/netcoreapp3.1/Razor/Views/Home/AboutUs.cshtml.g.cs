#pragma checksum "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25dbe8862f035a084dee8c3ad951e472b18e61fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AboutUs), @"mvc.1.0.view", @"/Views/Home/AboutUs.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25dbe8862f035a084dee8c3ad951e472b18e61fc", @"/Views/Home/AboutUs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22c83b204d8066dd7c72ebd1a0b939a93ab28a11", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AboutUs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/icon-1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/icon-2.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/icon-3.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
  
    ViewBag.Title = lexiconHelper.GetTextValue("_about_us_page_title", 4);
    ViewBag.AboutUsSelect = "active";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 10 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
  
    var page = pageService.GetPageByCode(4).Data as DataModel.BaseEntities.Page;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"about-us\">\r\n    <div class=\"content\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-6\">\r\n                    <div class=\"about-blk-content\">\r\n                        ");
#nullable restore
#line 20 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
                   Write(Html.Raw(page.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-md-6\">\r\n                    <div class=\"about-blk-image\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 835, "\"", 896, 1);
#nullable restore
#line 25 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
WriteAttributeValue("", 841, lexiconHelper.GetTextValue("_about_us_page_image", 97), 841, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 915, "\"", 921, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n<section class=\"call-us\"");
            BeginWriteAttribute("style", " style=\"", 1063, "\"", 1155, 3);
            WriteAttributeValue("", 1071, "background-image:url(\'", 1071, 22, true);
#nullable restore
#line 33 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
WriteAttributeValue("", 1093, lexiconHelper.GetTextValue("_about_us_page_image_long", 97), 1093, 60, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1153, "\')", 1153, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-6\">\r\n                <span>");
#nullable restore
#line 37 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
                 Write(lexiconHelper.GetTextValue("_free_consultation_title", 4));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <h2>");
#nullable restore
#line 38 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
               Write(lexiconHelper.GetTextValue("_free_consultation_title_ex", 4));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <p>");
#nullable restore
#line 39 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
              Write(lexiconHelper.GetTextValue("_free_consultation_description", 4));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"col-6 call-us-btn\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1597, "\"", 1667, 1);
#nullable restore
#line 42 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
WriteAttributeValue("", 1604, lexiconHelper.GetTextValue("_free_consultation_button_url", 4), 1604, 63, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-call-us\">");
#nullable restore
#line 42 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
                                                                                                             Write(lexiconHelper.GetTextValue("_free_consultation_button_text", 4));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
            </div>
        </div>
    </div>
</section>

<section class=""how-work"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""heading howitworks"">
                    <h2>");
#nullable restore
#line 53 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
                   Write(lexiconHelper.GetTextValue("_how_it_works", 3));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <span>");
#nullable restore
#line 54 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
                     Write(lexiconHelper.GetTextValue("_how_it_works_description", 3));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </div>
                <div class=""howworksec"">
                    <div class=""row"">
                        <div class=""col-lg-4"">
                            <div class=""howwork"">
                                <div class=""iconround"">
                                    <div class=""steps"">01</div>
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "25dbe8862f035a084dee8c3ad951e472b18e61fc10430", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                                <h3>");
#nullable restore
#line 64 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
                               Write(lexiconHelper.GetTextValue("_how_it_works_section_1", 3));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                <p>");
#nullable restore
#line 65 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
                              Write(lexiconHelper.GetTextValue("_how_it_works_section_1_description", 3));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                        </div>
                        <div class=""col-lg-4"">
                            <div class=""howwork"">
                                <div class=""iconround"">
                                    <div class=""steps"">02</div>
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "25dbe8862f035a084dee8c3ad951e472b18e61fc12614", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                                <h3>");
#nullable restore
#line 74 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
                               Write(lexiconHelper.GetTextValue("_how_it_works_section_2", 3));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                <p>");
#nullable restore
#line 75 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
                              Write(lexiconHelper.GetTextValue("_how_it_works_section_2_description", 3));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                        </div>
                        <div class=""col-lg-4"">
                            <div class=""howwork"">
                                <div class=""iconround"">
                                    <div class=""steps"">03</div>
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "25dbe8862f035a084dee8c3ad951e472b18e61fc14798", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                                <h3>");
#nullable restore
#line 84 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
                               Write(lexiconHelper.GetTextValue("_how_it_works_section_3", 3));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                <p>");
#nullable restore
#line 85 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\AboutUs.cshtml"
                              Write(lexiconHelper.GetTextValue("_how_it_works_section_3_description", 3));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
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
