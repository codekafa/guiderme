#pragma checksum "C:\Users\tayfu\source\repos\guiderme\guiderme\ServiceBuilderUI\Views\Template\EmailOtp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ba7a675e53f565dd4dcfea2f389607db0338ced"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Template_EmailOtp), @"mvc.1.0.view", @"/Views/Template/EmailOtp.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ba7a675e53f565dd4dcfea2f389607db0338ced", @"/Views/Template/EmailOtp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22c83b204d8066dd7c72ebd1a0b939a93ab28a11", @"/Views/_ViewImports.cshtml")]
    public class Views_Template_EmailOtp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ba7a675e53f565dd4dcfea2f389607db0338ced3316", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ba7a675e53f565dd4dcfea2f389607db0338ced4347", async() => {
                WriteLiteral(@"
    <div>
        <table style=""width: 900px; margin: 0px auto;background:#fff;"" bgcolor=""#ffffff"" class=""voucher-templates"">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td height='34 ' width='50' valign='center' align='center' class='center' cellspacing='0' cellpadding='0' border='0'>
                    <img style=""height: 70px;"" src=""https://res.cloudinary.com/servicebuilder/image/upload/v1606401917/logo2.png"" />
                </td>
            </tr>
            <tr>

                <td style=""padding:0 15px;"">
                    <br />
                    <span style=""font-family:Calibri;font-size: 20px"">$$register_dear_text$$</span><span style=""font-family:Calibri;font-size: 20px"">$$register_dear$$</span>&nbsp;
                    <span>
                        <br />
                        <br />
                        <span style=""font-family:Calibri;font-size: 18px;"">$$register_description$$</span>
                        <b");
                WriteLiteral(@"r />
                        <h1>$$otp_ode$$</h1>
                    </span>
                </td>

            </tr>
            <tr>
                <td height='15'>&nbsp;</td>
            </tr>
            <tr>

                <td class='font_fix' style='font-size:15px; color:#5a5a5a;text-align:center; font-weight:bold; font-family: Arial, Helvetica, sans-serif;' align='left'>$$follow_us$$</td>


            </tr>
            <tr>

                <td height='15'>&nbsp;</td>
            </tr>
            <tr>
                <td height='34 ' width='50' valign='center' align='center' class='center' cellspacing='0' cellpadding='0' border='0'>
                    <a style='text-decoration: none; border:0;border-radius: 100px; color:#fff;' href='$$facebook$$'>
                        <img style=""border-radius: 100px"" src='https://res.cloudinary.com/servicebuilder/image/upload/v1606402096/static/facebook_v4jxap.png' width='50' height='50' alt='facebook' />
                    </a>
    ");
                WriteLiteral(@"                <a style='text-decoration: none; border:0;border-radius: 100px;color:#fff;' href='$$instagram$$ '>
                        <img style=""border-radius: 100px"" src='https://res.cloudinary.com/servicebuilder/image/upload/v1606402097/static/instagram_g5tngt.png' width='50' height='50' alt='instagram' />
                    </a>
                </td>


            </tr>
            <tr>
                <td height='15'>&nbsp;</td>
            </tr>
            <tr>

                <td class='font_fix' style='font-family: Arial, Helvetica, sans-serif; font-size:28px;mso-line-height-rule:exactly; line-height:28px; font-weight:bold; color:#5a5a5a;text-decoration:none !important; ' align='center'>&nbsp;$$contact_phone$$</td>


            </tr>
            <tr>

                <td class='font_fix' style='font-size:12px; font-family: Arial, Helvetica, sans-serif; line-height:14px; color:#5a5a5a; font-weight:bold; padding-top:5px' align='center'><a href='#' style='color:#5a5a5a;text-dec");
                WriteLiteral(@"oration:none !important;'>$$contact_email$$</a> - <a href='#' style='color:#5a5a5a;text-decoration:none !important; '>$$domain_name$$</a></td>
            </tr>
            <tr>
                <td align='center' valign='middle' style='font-family: Arial, Helvetica, sans-serif;font-size:11px; font-weight:normal; color:#bbb; padding-top:10px; padding-bottom:10px'>
                    <strong>&#169; Copyright $$service_here$$</strong><br />
            </tr>
        </table>
    </div>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
