#pragma checksum "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19af3ab426c4657ac319464cb579aad47ff6359f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Security_Login), @"mvc.1.0.view", @"/Views/Security/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19af3ab426c4657ac319464cb579aad47ff6359f", @"/Views/Security/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22c83b204d8066dd7c72ebd1a0b939a93ab28a11", @"/Views/_ViewImports.cshtml")]
    public class Views_Security_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("loginPageForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
  
    ViewData["Title"] = "Login";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"content\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-6 offset-md-3\">\r\n                <div class=\"login-header\">\r\n                    <h3>");
#nullable restore
#line 12 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
                   Write(lexiconHelper.GetTextValue("_login", 2));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span>");
#nullable restore
#line 12 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
                                                                  Write(lexiconHelper.GetTextValue("_login_service_here", 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h3>\r\n                </div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "19af3ab426c4657ac319464cb579aad47ff6359f4740", async() => {
                WriteLiteral("\r\n                    <div class=\"form-group form-focus\">\r\n                        <label class=\"focus-label\">");
#nullable restore
#line 16 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
                                              Write(lexiconHelper.GetTextValue("_email_join", 2));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                        <input type=\"email\" class=\"form-control\" id=\"EmailOrPhoneLogin\" name=\"EmailOrPhoneLogin\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 813, "\"", 880, 1);
#nullable restore
#line 17 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
WriteAttributeValue("", 827, lexiconHelper.GetTextValue("_place_holder_email", 2), 827, 53, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                    </div>\r\n                    <div class=\"form-group form-focus\">\r\n                        <label class=\"focus-label\">");
#nullable restore
#line 20 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
                                              Write(lexiconHelper.GetTextValue("_password_join", 2));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                        <input type=\"password\" class=\"form-control\" id=\"PasswordLogin\" name=\"PasswordLogin\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1185, "\"", 1254, 1);
#nullable restore
#line 21 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
WriteAttributeValue("", 1199, lexiconHelper.GetTextValue("_placeholder_password", 2), 1199, 55, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                    </div>\r\n                    <div class=\"text-right\">\r\n                    </div>\r\n                    <button class=\"btn btn-primary btn-block btn-lg login-btn\" type=\"submit\">");
#nullable restore
#line 25 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
                                                                                        Write(lexiconHelper.GetTextValue("_login", 2));

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
#line 31 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
                   Write(lexiconHelper.GetTextValue("_forgot_you_password_text", 2));

#line default
#line hidden
#nullable disable
                WriteLiteral(" <a href=\"/forgot-password\">");
#nullable restore
#line 31 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
                                                                                                          Write(lexiconHelper.GetTextValue("_forgot_you_password_link_text", 2));

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n                    </div>\r\n                    <div class=\"text-center dont-have\">\r\n                        ");
#nullable restore
#line 34 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
                   Write(lexiconHelper.GetTextValue("_dont_have_an_account", 2));

#line default
#line hidden
#nullable disable
                WriteLiteral(" <a href=\"#\">");
#nullable restore
#line 34 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
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
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
           $(document).ready(function () {
               $(""#loginPageForm"").validate({
                rules: {
                       EmailOrPhoneLogin: {
                        required: true
                    },
                       PasswordLogin: {
                        required: true
                    }
                },
               messages: {
                   EmailOrPhoneLogin: """);
#nullable restore
#line 56 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
                                  Write(lexiconHelper.GetTextValue("_email_or_phone_required",99));

#line default
#line hidden
#nullable disable
                WriteLiteral("\",\r\n                   PasswordLogin: \"");
#nullable restore
#line 57 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderUI\Views\Security\Login.cshtml"
                              Write(lexiconHelper.GetTextValue("_password_required",99));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"""
                },
                   submitHandler: function () {


                       var obj = new Object();
                       obj.EmailOrPhone = $('#EmailOrPhoneLogin').val();
                       obj.Password = $('#PasswordLogin').val();

                $.ajax({
                    type: ""POST"",
                    url: ""/security/login"",
                    data: obj,
                    content:""application/json"",
					timeout: 600000,
                    success: function (e) {
                          if (e.isSuccess == true) {
                             location.href = ""my-profile"";
                          } else {
                              toastrDanger(e.message);
                        }
                    },
                    error: function (jqXHR, exception) {
                        var msg = '';
                        if (jqXHR.status === 0) {
                            msg = 'Not connect.\n Verify Network.';
                        } els");
                WriteLiteral(@"e if (jqXHR.status == 404) {
                            msg = 'Requested page not found. [404]';
                        } else if (jqXHR.status == 500) {
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

                        toastrDanger(msg);
                    }
                });
            }

            });
           });
    </script>
");
            }
            );
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
