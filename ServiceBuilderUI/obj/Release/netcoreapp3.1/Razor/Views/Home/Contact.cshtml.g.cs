#pragma checksum "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0692e2d88e5e4e7e2c769b422d1c582d9fde76c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contact), @"mvc.1.0.view", @"/Views/Home/Contact.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0692e2d88e5e4e7e2c769b422d1c582d9fde76c2", @"/Views/Home/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22c83b204d8066dd7c72ebd1a0b939a93ab28a11", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("contactForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
  
    ViewBag.Title = lexiconHelper.GetTextValue("_contact_page_title", 5);
    ViewBag.ContactSelect = "active";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"contact-us\">\r\n    <div class=\"content\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"col-8\">\r\n                    <div class=\"contact-queries\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0692e2d88e5e4e7e2c769b422d1c582d9fde76c24872", async() => {
                WriteLiteral("\r\n                            <h4 class=\"mb-4\">");
#nullable restore
#line 16 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                                        Write(lexiconHelper.GetTextValue("_contact_form_title", 5));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n                            <div class=\"row\">\r\n                                <div class=\"form-group col-xl-6\">\r\n                                    <label class=\"mr-sm-2\">");
#nullable restore
#line 19 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                                                      Write(lexiconHelper.GetTextValue("_first_name", 5));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</label>
                                    <input class=""form-control"" type=""text"" id=""FirstName"" name=""FirstName"" />
                                </div>
                                <div class=""form-group col-xl-6"">
                                    <label class=""mr-sm-2"">");
#nullable restore
#line 23 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                                                      Write(lexiconHelper.GetTextValue("_last_name", 5));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</label>
                                    <input class=""form-control"" type=""text""  id=""LastName"" name=""LastName"" />
                                </div>
                                <div class=""form-group col-xl-6"">
                                    <label class=""mr-sm-2"">");
#nullable restore
#line 27 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                                                      Write(lexiconHelper.GetTextValue("_email", 5));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</label>
                                    <input class=""form-control"" type=""email""  id=""Email"" name=""Email"" />
                                </div>
                                <div class=""form-group col-xl-6"">
                                    <label class=""mr-sm-2"">");
#nullable restore
#line 31 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                                                      Write(lexiconHelper.GetTextValue("_phone", 5));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</label>
                                    <input class=""form-control"" type=""text"" id=""Phone"" name=""Phone"" />
                                </div>
                                <div class=""form-group col-xl-12"">
                                    <label class=""mr-sm-2"">");
#nullable restore
#line 35 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                                                      Write(lexiconHelper.GetTextValue("_message", 5));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</label>
                                    <textarea class=""form-control"" rows=""5""  id=""Message"" name=""Message"" ></textarea>
                                </div>
                                <div class=""col-xl-12 mt-4"">
                                    <button class=""btn btn-primary btn-lg pl-5 pr-5"" type=""submit"">");
#nullable restore
#line 39 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                                                                                              Write(lexiconHelper.GetTextValue("_send", 5));

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                </div>
                <div class=""col-4"">
                    <div class=""contact-details"">
                        <div class=""contact-info"">
                            <i class=""fas fa-map-marker-alt""></i>
                            <div class=""contact-data"">
                                <h4>");
#nullable restore
#line 50 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                               Write(lexiconHelper.GetTextValue("_address", 5));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                <p>");
#nullable restore
#line 51 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                              Write(lexiconHelper.GetTextValue("_address_text", 5));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                        </div>
                        <hr>
                        <div class=""contact-info"">
                            <i class=""fas fa-phone-alt""></i>
                            <div class=""contact-data"">
                                <h4>");
#nullable restore
#line 58 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                               Write(lexiconHelper.GetTextValue("_phone", 5));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                <p>");
#nullable restore
#line 59 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                              Write(lexiconHelper.GetTextValue("_phone_one", 5));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                        </div>
                        <hr>
                        <div class=""contact-info"">
                            <i class=""far fa-envelope""></i>
                            <div class=""contact-data"">
                                <h4>");
#nullable restore
#line 66 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                               Write(lexiconHelper.GetTextValue("_email", 5));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                <p>");
#nullable restore
#line 67 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                              Write(lexiconHelper.GetTextValue("_email_address", 5));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script type=""text/javascript"">
        $(""#contactForm"").validate({
                rules: {
                    FirstName: {
                        required: true
                    },
                    LastName: {
                            required: true
                        },
                    Email: {
                        required: true
                    },
                    Message: {
                        required: true
                }
                },
               messages: {
                   FirstName: """);
#nullable restore
#line 99 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                          Write(lexiconHelper.GetTextValue("_first_name_required",99));

#line default
#line hidden
#nullable disable
                WriteLiteral("\",\r\n                   LastName: \"");
#nullable restore
#line 100 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                         Write(lexiconHelper.GetTextValue("_last_name_required", 99));

#line default
#line hidden
#nullable disable
                WriteLiteral("\",\r\n                   Email: \"");
#nullable restore
#line 101 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                      Write(lexiconHelper.GetTextValue("_email_required",99));

#line default
#line hidden
#nullable disable
                WriteLiteral("\",\r\n                   Message: \"");
#nullable restore
#line 102 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Home\Contact.cshtml"
                        Write(lexiconHelper.GetTextValue("_message_required",99));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
  
                },
               submitHandler: function () {

                   var form = $('#contactForm')[0];
                   var data = new FormData(form);

                       $.ajax({
                           type: ""POST"",
                           url: ""/Home/SendContact"",
                           data: data,
                           processData: false,
                           contentType: false,
                            success: function (e) {
                                if (e.isSuccess == true) {
                                    toastrSuccess(e.message);
                                } else {
                                    toastrDanger(e.message);
                                }
                            },
                            error: function (jqXHR, exception) {
                                var msg = '';
                                if (jqXHR.status === 0) {
                                    msg = 'Not connect.\n V");
                WriteLiteral(@"erify Network.';
                                } else if (jqXHR.status == 404) {
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

        ");
                WriteLiteral("    });\r\n\r\n    </script>\r\n\r\n");
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
