#pragma checksum "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01ea865e289296c936c55d11ce6eea09f52d3e23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_GetUserList), @"mvc.1.0.view", @"/Views/User/GetUserList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01ea865e289296c936c55d11ce6eea09f52d3e23", @"/Views/User/GetUserList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"107b284f0b9298a46861638556c2b90a8c8fa378", @"/Views/_ViewImports.cshtml")]
    public class Views_User_GetUserList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewModel.Views.CommonResult>
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
#line 4 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
  
    var userList = Model.Data as List<ViewModel.Views.User.UserListModel>;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-header\">\r\n        <h3 class=\"card-title\">User  List - Total : ");
#nullable restore
#line 11 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
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
                    <th scope=""col"">Phone</th>
                    <th scope=""col"">FirstName</th>
                    <th scope=""col"">LastName</th>
                    <th scope=""col"">IsMailApprove</th>
                    <th scope=""col"">IsMobileApprove</th>
                    <th scope=""col""></th>
                </tr>
            </thead>
            <tbody>

");
#nullable restore
#line 30 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                 if (userList != null && userList.Count > 0)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                     foreach (var item in userList)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 35 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                           Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 36 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                           Write(item.CreateDate.ToString("dd.MM.yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 37 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                           Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 38 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                           Write(item.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 39 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                           Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 40 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                           Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 41 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                           Write(item.IsMailActivated);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 42 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                           Write(item.IsMobileActivated);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01ea865e289296c936c55d11ce6eea09f52d3e237621", async() => {
                WriteLiteral("<i class=\"fa fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1594, "~/User/UserDetail?user_id=", 1594, 26, true);
#nullable restore
#line 43 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
AddHtmlAttributeValue("", 1620, item.ID, 1620, 8, false);

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
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 45 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                     

                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr col=\"9\">Data not found!</tr>\r\n");
#nullable restore
#line 51 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n\r\n    <div class=\"card-footer clearfix\">\r\n        <ul class=\"pagination pagination-sm m-0 float-right\">\r\n");
#nullable restore
#line 58 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
             for (int i = 1; i < Model.PageCount.Value + 1; i++)
            {
                if (Model.SelectedPage == (i - 1))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"active page-item\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2213, "\"", 2242, 3);
            WriteAttributeValue("", 2223, "filterUsers(", 2223, 12, true);
#nullable restore
#line 62 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
WriteAttributeValue("", 2235, i-1, 2235, 6, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2241, ")", 2241, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2243, "\"", 2262, 2);
            WriteAttributeValue("", 2248, "page_id_", 2248, 8, true);
#nullable restore
#line 62 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
WriteAttributeValue("", 2256, i-1, 2256, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a class=\"page-link\" href=\"#\">");
#nullable restore
#line 62 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                                                                                                                             Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 63 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\" page-item\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2411, "\"", 2440, 3);
            WriteAttributeValue("", 2421, "filterUsers(", 2421, 12, true);
#nullable restore
#line 66 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
WriteAttributeValue("", 2433, i-1, 2433, 6, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2439, ")", 2439, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2441, "\"", 2460, 2);
            WriteAttributeValue("", 2446, "page_id_", 2446, 8, true);
#nullable restore
#line 66 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
WriteAttributeValue("", 2454, i-1, 2454, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a class=\"page-link\" href=\"#\">");
#nullable restore
#line 66 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                                                                                                                       Write(i );

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 67 "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderPanel\Views\User\GetUserList.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n</div>\r\n\r\n");
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
