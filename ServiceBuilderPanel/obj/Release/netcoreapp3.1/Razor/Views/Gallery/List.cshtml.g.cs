#pragma checksum "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\Gallery\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0356114fbbf0f116795f658b8399ff3e236308fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Gallery_List), @"mvc.1.0.view", @"/Views/Gallery/List.cshtml")]
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
#line 1 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\_ViewImports.cshtml"
using ServiceBuilderPanel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\_ViewImports.cshtml"
using ServiceBuilderPanel.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0356114fbbf0f116795f658b8399ff3e236308fc", @"/Views/Gallery/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"107b284f0b9298a46861638556c2b90a8c8fa378", @"/Views/_ViewImports.cshtml")]
    public class Views_Gallery_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewModel.Views.CommonResult>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("galleryForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("GalleryUpload"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("novalidate", new global::Microsoft.AspNetCore.Html.HtmlString("novalidate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\Gallery\List.cshtml"
  
    ViewData["Title"] = "Gallery List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\Gallery\List.cshtml"
  

    var list = Model.Data as List<DataModel.BaseEntities.Gallery>;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"card card-info\">\r\n    <div class=\"card-header\">\r\n        <h3 class=\"card-title\">Gallery</h3>\r\n    </div>\r\n    <div class=\"card-body\">\r\n        <div class=\"row\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0356114fbbf0f116795f658b8399ff3e236308fc6181", async() => {
                WriteLiteral("\r\n                <div class=\"col-md-12\">\r\n                    <div class=\"input-group mb-3\">\r\n                        <input type=\"file\" class=\"form-control\" id=\"Photo\" required=\"required\" name=\"Photo\"");
                BeginWriteAttribute("value", " value=\"", 735, "\"", 743, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                    </div>
                </div>
                <div class=""col-md-3"">
                    <div class=""input-group mb-3"">
                        <button type=""submit"" class=""btn btn-primary btn-sm"">Upload</button>
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-header\">\r\n        <h3 class=\"card-title\">Gallery  List - Total : ");
#nullable restore
#line 40 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\Gallery\List.cshtml"
                                                  Write(Model.DataCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    </div>\r\n    <div class=\"card-body\">\r\n\r\n        <div class=\"col-md-12\">\r\n");
#nullable restore
#line 45 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\Gallery\List.cshtml"
             if (list != null && list.Count > 0)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\Gallery\List.cshtml"
                 foreach (var item in list)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-3\" style=\"max-height:300px;max-width:300px\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 1543, "\"", 1563, 1);
#nullable restore
#line 50 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\Gallery\List.cshtml"
WriteAttributeValue("", 1549, item.PhotoUrl, 1549, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"max-height:300px;max-width:300px\" />\r\n                        <label>");
#nullable restore
#line 51 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\Gallery\List.cshtml"
                          Write(item.PhotoName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                        <button class=\"btn btn-primary\" type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1735, "\"", 1766, 3);
            WriteAttributeValue("", 1745, "generateUri(", 1745, 12, true);
#nullable restore
#line 52 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\Gallery\List.cshtml"
WriteAttributeValue("", 1757, item.ID, 1757, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1765, ")", 1765, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Generate Uri</button>\r\n                    </div>\r\n");
#nullable restore
#line 54 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\Gallery\List.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\Gallery\List.cshtml"
                 
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span col=\"9\">Data not found!</span>\r\n");
#nullable restore
#line 59 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\Gallery\List.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
    </div>
</div>


<div class=""modal fade"" id=""uriModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"" data-backdrop=""static"" data-keyboard=""false"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <input type=""hidden"" id=""pageId"" name=""pageId"" value=""0"" />
                <input type=""hidden"" id=""categoryId"" name=""categoryId""");
            BeginWriteAttribute("value", " value=\"", 2405, "\"", 2413, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                <h5 class=""modal-title"" id=""requestModalTitle""></h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div>
                    <input type=""hidden"" id=""galleryId"" name=""galleryId"" />
                    <div class=""col-md-12"">
                        <span>Width:</span>
                        <input class=""form-control"" id=""Width"" name=""Width"" />
                    </div>
                    <div class=""col-md-12"">
                        <span>Heigth:</span>
                        <input class=""form-control"" id=""Heigth"" name=""Heigth"" />
                    </div>

                    <div class=""col-md-12"">
                        <span>Url:</span>
                        <input class=""form-control"" id=""Url"" name=""Url"" />
                    </div>
                ");
            WriteLiteral(@"</div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-success "" onclick=""generateUrlFormat()"">Generate</button>
                <button type=""button"" class=""btn btn-danger "" data-dismiss=""modal"">Cancel</button>
            </div>
        </div>
    </div>
</div>﻿







");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script type=""text/javascript"">
        $(document).ready(function () {
            $.validator.setDefaults({
                submitHandler: function () {
                    $('#galleryForm').submit();
                }
            });
            $('#function').validate({
                rules: {
                    Photo: {
                        required: true,
                    }
                },
                messages: {
                    Photo: {
                        required: ""Please enter a file!"",
                    },
                },
                errorElement: 'span',
                errorPlacement: function (error, element) {
                    error.addClass('invalid-feedback');
                    element.closest('.form-group').append(error);
                },
                highlight: function (element, errorClass, validClass) {
                    $(element).addClass('is-invalid');
                },
                unhighlight: function ");
                WriteLiteral(@"(element, errorClass, validClass) {
                    $(element).removeClass('is-invalid');
                }
            });
        });

        function generateUri(id) {
            $('#Width').val("""");
            $('#Heigth').val("""");
            $('#Url').val("""");
            $('#galleryId').val(id);
            $('#uriModal').modal();
        }


        function generateUrlFormat() {

            var id = $('#galleryId').val();

            $.ajax({
                type: ""GET"",
                url: ""/Gallery/GenerateUri?Width="" + $('#Width').val() + ""&Heigth="" + $('#Heigth').val()+""&gallery_id="" + id,
                success: function (e) {
                    $('#Url').val(e.data);
                }
            });
        }

    </script>

");
            }
            );
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
