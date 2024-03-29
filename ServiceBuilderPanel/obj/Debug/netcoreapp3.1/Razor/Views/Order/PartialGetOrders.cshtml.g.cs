#pragma checksum "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d584492a44f33c091a319755b1498d6cec1d2f1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_PartialGetOrders), @"mvc.1.0.view", @"/Views/Order/PartialGetOrders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d584492a44f33c091a319755b1498d6cec1d2f1a", @"/Views/Order/PartialGetOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"107b284f0b9298a46861638556c2b90a8c8fa378", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_PartialGetOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewModel.Views.CommonResult>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
  
    var list = Model.Data as List<ViewModel.Views.Payment.OrderPaymentRequestListModel>;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h4 class=\"mb-4\">Recent Payment Orders</h4>\r\n\r\n<div class=\"card transaction-table mb-0\">\r\n    <div class=\"card-header\">\r\n        <h3 class=\"card-title\">Order  List - Total : ");
#nullable restore
#line 13 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                                                Write(Model.DataCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
    </div>
    <div class=""card-body"">
        <div class=""table-responsive"">
            <table class=""table table-center mb-0"">
                <thead>
                    <tr>
                        <th>User</th>
                        <th>Date</th>
                        <th>Amount</th>
                        <th>Discount</th>
                        <th>Total</th>
                        <th>Status</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>

");
#nullable restore
#line 31 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                     if (list != null && list.Count > 0)
                    {

                        foreach (var item in list)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 37 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                               Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 37 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                                               Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" -  ");
#nullable restore
#line 37 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                                                                 Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 38 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                               Write(item.CreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 39 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                               Write(item.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 40 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                               Write(item.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 41 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                               Write(item.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n\r\n");
#nullable restore
#line 44 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                                     switch (item.Status)
                                    {
                                        case 1:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"badge bg-warning-light\">Waiting</span>\r\n");
#nullable restore
#line 48 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                                            break;
                                        case 2:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"badge bg-error-light\">Rejected</span>\r\n");
#nullable restore
#line 51 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                                            break;
                                        case 3:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"badge bg-success-light\">Applyed</span>\r\n");
#nullable restore
#line 54 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                                            break;
                                        default:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"badge bg-default-light\">None</span>\r\n");
#nullable restore
#line 57 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                                            break;
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                                <td>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 2478, "\"", 2533, 2);
            WriteAttributeValue("", 2485, "/Order/OrderDetail?order_id=", 2485, 28, true);
#nullable restore
#line 61 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
WriteAttributeValue("", 2513, item.OrderRequestID, 2513, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\" class=\"btn btn-xs btn-primary\">Details</a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 64 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                        }


                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td colspan=\"5\">Data not found!</td>\r\n                        </tr>\r\n");
#nullable restore
#line 73 "C:\Users\tayfu\source\repos\ServiceBuilder\ServiceBuilderPanel\Views\Order\PartialGetOrders.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
