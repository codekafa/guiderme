#pragma checksum "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Payment\CreditPayment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed83179b56df27ab2469063bdc86ea10b626d12d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payment_CreditPayment), @"mvc.1.0.view", @"/Views/Payment/CreditPayment.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed83179b56df27ab2469063bdc86ea10b626d12d", @"/Views/Payment/CreditPayment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22c83b204d8066dd7c72ebd1a0b939a93ab28a11", @"/Views/_ViewImports.cshtml")]
    public class Views_Payment_CreditPayment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Payment\CreditPayment.cshtml"
  
    ViewBag.Title = lexiconHelper.GetTextValue("_payment_credit_page_title", 26);
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\"content\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n\r\n            ");
#nullable restore
#line 14 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Payment\CreditPayment.cshtml"
       Write(await Html.PartialAsync("../Account/_GetUserMenu", new ViewDataDictionary(ViewData)
                                {
                                    { @"menu", @"payment" }
                                }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-xl-9 col-md-8\">\r\n\r\n                <ul class=\"nav nav-tabs menu-tabs\">\r\n                    <li class=\"nav-item active\">\r\n                        <a class=\"nav-link\" href=\"/credit-payment\">");
#nullable restore
#line 22 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Payment\CreditPayment.cshtml"
                                                              Write(lexiconHelper.GetTextValue("_add_new_credit_payment_page_title", 26));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </li>\r\n                    <li class=\"nav-item \">\r\n                        <a class=\"nav-link\" href=\"/my-payment-transactions\">");
#nullable restore
#line 25 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Payment\CreditPayment.cshtml"
                                                                       Write(lexiconHelper.GetTextValue("_payment_history", 26));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </a>
                    </li>
                </ul>

                <div class=""row"">
                    <div class=""col-xl-6 col-lg-6 col-md-6"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <h4 class=""card-title"">Wallet</h4>
                                <div class=""wallet-details"">
                                    <span>Wallet Balance</span>
                                    <h3>$3885</h3>
                                    <div class=""d-flex justify-content-between my-4"">
                                        <div>
                                            <p class=""mb-1"">Total Credit</p>
                                            <h4>$5314</h4>
                                        </div>
                                        <div>
                                            <p class=""mb-1"">Total Debit</p>
                                            <h4>$1431</h4>
                    ");
            WriteLiteral(@"                    </div>
                                    </div>
                                    <div class=""wallet-progress-chart"">
                                        <div class=""d-flex justify-content-between"">
                                            <span>$1431</span>
                                            <span>$5,314.00</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-xl-6 col-lg-6 col-md-6"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <h4 class=""card-title"">Withdraw</h4>
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed83179b56df27ab2469063bdc86ea10b626d12d7585", async() => {
                WriteLiteral(@"
                                    <div class=""form-group"">
                                        <div class=""input-group mb-3"">
                                            <div class=""input-group-prepend"">
                                                <label class=""input-group-text display-5"">$</label>
                                            </div>
                                            <input type=""text"" maxlength=""4"" class=""form-control"" placeholder=""00.00"">
                                        </div>
                                    </div>
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                <div class=""text-center mb-3"">
                                    <h5 class=""mb-3"">OR</h5>
                                    <ul class=""list-inline mb-0"">
                                        <li class=""line-inline-item mb-0 d-inline-block"">
                                            <a href=""javascript:;"" class=""updatebtn"">$50</a>
                                        </li>
                                        <li class=""line-inline-item mb-0 d-inline-block"">
                                            <a href=""javascript:;"" class=""updatebtn"">$100</a>
                                        </li>
                                        <li class=""line-inline-item mb-0 d-inline-block"">
                                            <a href=""javascript:;"" class=""updatebtn"">$150</a>
                                        </li>
                                    </ul>
                                </div>
                                <a href=""javascr");
            WriteLiteral(@"ipt:void(0);"" class=""btn btn-primary btn-block withdraw-btn"">Withdraw</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>



");
        }
        #pragma warning restore 1998
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
