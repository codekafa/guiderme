#pragma checksum "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Security\ApproveEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "502d175412443d1ebdbd67f301ea190ffc749387"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Security_ApproveEmail), @"mvc.1.0.view", @"/Views/Security/ApproveEmail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"502d175412443d1ebdbd67f301ea190ffc749387", @"/Views/Security/ApproveEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22c83b204d8066dd7c72ebd1a0b939a93ab28a11", @"/Views/_ViewImports.cshtml")]
    public class Views_Security_ApproveEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("approvePageForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Security\ApproveEmail.cshtml"
  
    ViewBag.Title = lexiconHelper.GetTextValue("_approve_email_page_title", 13);
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"content\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-6 offset-md-3\">\r\n                <div class=\"login-header\">\r\n                    <h3><span>");
#nullable restore
#line 13 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Security\ApproveEmail.cshtml"
                         Write(lexiconHelper.GetTextValue("_approve_email_title", 13));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h3>\r\n                </div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "502d175412443d1ebdbd67f301ea190ffc7493874550", async() => {
                WriteLiteral("\r\n                    <div class=\"form-group form-focus\">\r\n                        <label class=\"focus-label\">");
#nullable restore
#line 17 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Security\ApproveEmail.cshtml"
                                              Write(lexiconHelper.GetTextValue("_approve_otp_code", 2));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</label>
                        <input type=""text"" class=""form-control"" id=""OtpCode"" name=""OtpCode"" >
                    </div>
                    <div class=""text-right"">
                    </div>
                    <button class=""btn btn-primary btn-block btn-lg login-btn"" type=""submit"">");
#nullable restore
#line 22 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Security\ApproveEmail.cshtml"
                                                                                        Write(lexiconHelper.GetTextValue("_approve_email", 2));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</button>
                    <div class=""login-or"">
                        <span class=""or-line""></span>
                        <span class=""span-or"">or</span>
                    </div>
                    <div class=""text-center dont-have"">
                        ");
#nullable restore
#line 28 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Security\ApproveEmail.cshtml"
                   Write(lexiconHelper.GetTextValue("_dont_have_an_account", 2));

#line default
#line hidden
#nullable disable
                WriteLiteral(" <a href=\"#\">");
#nullable restore
#line 28 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Security\ApproveEmail.cshtml"
                                                                                       Write(lexiconHelper.GetTextValue("_register", 2));

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n                    </div>\r\n                ");
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
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
           $(document).ready(function () {
               $(""#approvePageForm"").validate({
                rules: {
                       OtpCode: {
                        required: true
                    }
                },
               messages: {
                   OtpCode: """);
#nullable restore
#line 48 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Security\ApproveEmail.cshtml"
                        Write(lexiconHelper.GetTextValue("_otp_code_required",99));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"""
                },
                   submitHandler: function () {
                       var obj = new Object();
                       obj.OtpCode = $('#OtpCode').val();
                       obj.OtpType = 2;
                $.ajax({
                    type: ""POST"",
                    url: ""/security/ApproveOtp"",
                    data: obj,
                    content:""application/json"",
					timeout: 600000,
                    success: function (e) {
                          if (e.isSuccess == true) {
                             location.href = ""login"";
                        } else {

                        }
                    },
                    error: function (jqXHR, exception) {
                        var msg = '';
                        if (jqXHR.status === 0) {
                            msg = 'Not connect.\n Verify Network.';
                        } else if (jqXHR.status == 404) {
                            msg = 'Requested page not found. [404]';
  ");
                WriteLiteral(@"                      } else if (jqXHR.status == 500) {
                            msg = 'Internal Server Error [500].';
                        } else if (exception === 'parsererror') {
                            msg = 'Requested JSON parse failed.';
                        } else if (exception === 'timeout') {
                            msg = 'Time out error.';
                        } else if (exception === 'abort') {
                            msg = 'Ajax request aborted.';
                        } else {
                            msg = 'Uncaught Error.\n' + jqXHR.responseText;
                        }
                    }
                });
            }

            });
        });
    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
