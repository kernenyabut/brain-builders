#pragma checksum "C:\Users\Minec\source\repos\Brain Builders Games\BrainBuilder\BrainBuilder\Views\Subscriptions\Deactivate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "661079f97647e5e2ae94ba46779f5e2163ca1cf0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subscriptions_Deactivate), @"mvc.1.0.view", @"/Views/Subscriptions/Deactivate.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Subscriptions/Deactivate.cshtml", typeof(AspNetCore.Views_Subscriptions_Deactivate))]
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
#line 1 "C:\Users\Minec\source\repos\Brain Builders Games\BrainBuilder\BrainBuilder\Views\_ViewImports.cshtml"
using BrainBuilder;

#line default
#line hidden
#line 2 "C:\Users\Minec\source\repos\Brain Builders Games\BrainBuilder\BrainBuilder\Views\_ViewImports.cshtml"
using BrainBuilder.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"661079f97647e5e2ae94ba46779f5e2163ca1cf0", @"/Views/Subscriptions/Deactivate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d92d36833b649b1a4c112d498bdf7f730a3c7c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Subscriptions_Deactivate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BrainBuilder.Controllers.SubscriptionsController.InputModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frmDeactivate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Deactivate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("btnReturntoSubscription"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-style-1 btn-secondary btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(68, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Minec\source\repos\Brain Builders Games\BrainBuilder\BrainBuilder\Views\Subscriptions\Deactivate.cshtml"
  
    ViewData["Title"] = "Deactivate";

#line default
#line hidden
            BeginContext(116, 98, true);
            WriteLiteral("\r\n<header class=\"py-5 \"></header>\r\n<section>\r\n    <div class=\"container  pb-5 mb-2\">\r\n        <h1>");
            EndContext();
            BeginContext(215, 17, false);
#line 10 "C:\Users\Minec\source\repos\Brain Builders Games\BrainBuilder\BrainBuilder\Views\Subscriptions\Deactivate.cshtml"
       Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(232, 171, true);
            WriteLiteral("</h1>\r\n        <div id=\"cardPurchase\" class=\"d-md-flex justify-content-between cart-item\">\r\n            <div class=\"px-3 my-3\">\r\n                <h4>\r\n                    ");
            EndContext();
            BeginContext(404, 48, false);
#line 14 "C:\Users\Minec\source\repos\Brain Builders Games\BrainBuilder\BrainBuilder\Views\Subscriptions\Deactivate.cshtml"
               Write(Html.DisplayFor(model => model.SubscriptionName));

#line default
#line hidden
            EndContext();
            BeginContext(452, 223, true);
            WriteLiteral("\r\n                </h4>\r\n            </div>\r\n            <div class=\"px-3 my-3 text-center\">\r\n                <div class=\"cart-item-label\"><b>Account Name</b></div>\r\n                <span class=\"text-xl font-weight-medium\">");
            EndContext();
            BeginContext(676, 48, false);
#line 19 "C:\Users\Minec\source\repos\Brain Builders Games\BrainBuilder\BrainBuilder\Views\Subscriptions\Deactivate.cshtml"
                                                    Write(Html.DisplayFor(model => model.Account.Username));

#line default
#line hidden
            EndContext();
            BeginContext(724, 207, true);
            WriteLiteral("</span>\r\n            </div>\r\n            <div class=\"px-3 my-3 text-center\">\r\n                <div class=\"cart-item-label\"><b>Billing Type</b></div>\r\n                <span class=\"text-xl font-weight-medium\">");
            EndContext();
            BeginContext(932, 47, false);
#line 23 "C:\Users\Minec\source\repos\Brain Builders Games\BrainBuilder\BrainBuilder\Views\Subscriptions\Deactivate.cshtml"
                                                    Write(Html.DisplayFor(model => model.BillingTypeName));

#line default
#line hidden
            EndContext();
            BeginContext(979, 183, true);
            WriteLiteral("</span>\r\n            </div>\r\n            <div class=\"px-3 my-3 text-center\">\r\n                <div class=\"cart-item-label\"><b>Price</b></div><span class=\"text-xl font-weight-medium\">$");
            EndContext();
            BeginContext(1163, 37, false);
#line 26 "C:\Users\Minec\source\repos\Brain Builders Games\BrainBuilder\BrainBuilder\Views\Subscriptions\Deactivate.cshtml"
                                                                                                    Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1200, 53, true);
            WriteLiteral("</span>\r\n            </div>\r\n        </div>\r\n        ");
            EndContext();
            BeginContext(1253, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "661079f97647e5e2ae94ba46779f5e2163ca1cf08777", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1309, 128, true);
            WriteLiteral("\r\n        <hr class=\"my-2\">\r\n        <div class=\"row pt-3 pb-5 mb-2\">\r\n            <div class=\"col-sm-6 mb-3\">\r\n                ");
            EndContext();
            BeginContext(1437, 125, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "661079f97647e5e2ae94ba46779f5e2163ca1cf010533", async() => {
                BeginContext(1536, 22, true);
                WriteLiteral("Return to Subscription");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1562, 265, true);
            WriteLiteral(@"
            </div>
            <div class=""col-sm-6 mb-3""><input id=""btnDeactivate"" class=""btn btn-style-1 btn-primary btn-block"" type=""submit"" name=""submitButton"" form=""frmDeactivate"" value=""Deactivate"" /></div>

        </div>
    </div>
</section>



");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BrainBuilder.Controllers.SubscriptionsController.InputModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
