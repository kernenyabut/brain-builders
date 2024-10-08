#pragma checksum "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Admin\ListUsersInRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eddb1e3f71fe7f796a9e69964e66ee94f7d84716"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ListUsersInRole), @"mvc.1.0.view", @"/Views/Admin/ListUsersInRole.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/ListUsersInRole.cshtml", typeof(AspNetCore.Views_Admin_ListUsersInRole))]
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
#line 1 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\_ViewImports.cshtml"
using BrainBuilder;

#line default
#line hidden
#line 2 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\_ViewImports.cshtml"
using BrainBuilder.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eddb1e3f71fe7f796a9e69964e66ee94f7d84716", @"/Views/Admin/ListUsersInRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d92d36833b649b1a4c112d498bdf7f730a3c7c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ListUsersInRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EditRole>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditUserInRole", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Identity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Account/Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Admin\ListUsersInRole.cshtml"
  
    ViewData["Title"] = "Users in " + ViewBag.RoleName;

#line default
#line hidden
            BeginContext(81, 475, true);
            WriteLiteral(@"<header class=""py-5""></header>
<section>
    <div class=""container"">
        <table class=""table"">
            <thead>
                <tr>
                    <th>
                        User Name
                    </th>
                    <th>
                        Email
                    </th>
                    <th>
                        Phone Number
                    </th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 23 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Admin\ListUsersInRole.cshtml"
                 if (Model.Users.Any())
                {
                    foreach (var user in Model.Users)
                    {

#line default
#line hidden
            BeginContext(694, 96, true);
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(791, 13, false);
#line 29 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Admin\ListUsersInRole.cshtml"
                           Write(user.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(804, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(908, 10, false);
#line 32 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Admin\ListUsersInRole.cshtml"
                           Write(user.Email);

#line default
#line hidden
            EndContext();
            BeginContext(918, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1022, 16, false);
#line 35 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Admin\ListUsersInRole.cshtml"
                           Write(user.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1038, 68, true);
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 38 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Admin\ListUsersInRole.cshtml"
                    }
                }
                else
                {

#line default
#line hidden
            BeginContext(1189, 183, true);
            WriteLiteral("                    <tr>\r\n                        <td colspan=\"3\">\r\n                            No Users Here At The Moment\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 47 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Admin\ListUsersInRole.cshtml"
                }

#line default
#line hidden
            BeginContext(1391, 40, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
            EndContext();
#line 50 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Admin\ListUsersInRole.cshtml"
         if (Model.RoleName == "Employee" && User.IsInRole("Admin"))
        {

#line default
#line hidden
            BeginContext(1512, 55, true);
            WriteLiteral("            <div class=\"card-footer\">\r\n                ");
            EndContext();
            BeginContext(1567, 155, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eddb1e3f71fe7f796a9e69964e66ee94f7d847168736", async() => {
                BeginContext(1694, 24, true);
                WriteLiteral("Change Employment Status");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-roleId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 53 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Admin\ListUsersInRole.cshtml"
                                                                            WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["roleId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-roleId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["roleId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1722, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1740, 96, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eddb1e3f71fe7f796a9e69964e66ee94f7d8471611473", async() => {
                BeginContext(1816, 16, true);
                WriteLiteral("Add New Employee");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1836, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 57 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Admin\ListUsersInRole.cshtml"
        }

#line default
#line hidden
            BeginContext(1869, 24, true);
            WriteLiteral("    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EditRole> Html { get; private set; }
    }
}
#pragma warning restore 1591
