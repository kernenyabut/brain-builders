#pragma checksum "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0691e10aa9a4c8200e5182153ccd0e39d0813c52"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profiles_Details), @"mvc.1.0.view", @"/Views/Profiles/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Profiles/Details.cshtml", typeof(AspNetCore.Views_Profiles_Details))]
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
#line 2 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0691e10aa9a4c8200e5182153ccd0e39d0813c52", @"/Views/Profiles/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d92d36833b649b1a4c112d498bdf7f730a3c7c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Profiles_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BrainBuilder.Models.Profiles>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("imgMembershipPlusBadge"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/vip.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Membership+ Activated"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("25"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("imgMembershipPlusBadgeInactive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("subscriptionInactive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("btnEditProfile"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Profiles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("btnManageUser"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Identity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Account/Manage/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Manage"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
  
    string avatarLink = "https://avatars.dicebear.com/api/identicon/" + ViewData["Avatar"] + ".svg";
    ViewData["Title"] = ViewData["Name"] + "'s Profile";
    string membership = ViewData["subscription"].ToString();
    string isActive = ViewData["isActive"].ToString();

#line default
#line hidden
            BeginContext(360, 86, true);
            WriteLiteral("\r\n<header class=\"py-5\"></header>\r\n<section>\r\n    <div class=\"container\">\r\n        <h1>");
            EndContext();
            BeginContext(447, 17, false);
#line 13 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
       Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(464, 325, true);
            WriteLiteral(@"</h1>
        <div class=""row gutters-sm"">
            <div class=""col-md-4 mb-3"">
                <div id=""cardProfileHeader"" class=""profileCard"">
                    <div class=""profileCard-body"">
                        <div class=""d-flex flex-column align-items-center text-center"">
                            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 789, "\"", 806, 1);
#line 19 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
WriteAttributeValue("", 795, avatarLink, 795, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 807, "\"", 857, 1);
#line 19 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
WriteAttributeValue("", 813, Html.DisplayFor(model => model.DisplayName), 813, 44, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(858, 94, true);
            WriteLiteral(" class=\"rounded profilePicture\" width=\"150\">\r\n                            <div class=\"mt-3\">\r\n");
            EndContext();
#line 21 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                                 if (membership == "MembershipPlus")
                                {
                                    if (isActive == "T")
                                    {

#line default
#line hidden
            BeginContext(1154, 40, true);
            WriteLiteral("                                        ");
            EndContext();
            BeginContext(1194, 92, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0691e10aa9a4c8200e5182153ccd0e39d0813c5211332", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1286, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 26 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(1408, 40, true);
            WriteLiteral("                                        ");
            EndContext();
            BeginContext(1448, 129, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0691e10aa9a4c8200e5182153ccd0e39d0813c5213163", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1577, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 30 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                                    }

                                }

#line default
#line hidden
            BeginContext(1655, 49, true);
            WriteLiteral("                                <h4 id=\"lblName\">");
            EndContext();
            BeginContext(1705, 43, false);
#line 33 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                                            Write(Html.DisplayFor(model => model.DisplayName));

#line default
#line hidden
            EndContext();
            BeginContext(1748, 88, true);
            WriteLiteral("</h4>\r\n                                <p id=\"lblMotto\" class=\"text-muted font-size-sm\">");
            EndContext();
            BeginContext(1837, 37, false);
#line 34 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                                                                            Write(Html.DisplayFor(model => model.Motto));

#line default
#line hidden
            EndContext();
            BeginContext(1874, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 35 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                                 if (User.Identity.Name == ViewData["Name"].ToString())
                                {

#line default
#line hidden
            BeginContext(2004, 36, true);
            WriteLiteral("                                    ");
            EndContext();
            BeginContext(2040, 134, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0691e10aa9a4c8200e5182153ccd0e39d0813c5216414", async() => {
                BeginContext(2158, 12, true);
                WriteLiteral("Edit Profile");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 37 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                                                                                                         WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2174, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(2212, 134, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0691e10aa9a4c8200e5182153ccd0e39d0813c5219252", async() => {
                BeginContext(2326, 16, true);
                WriteLiteral("Profile Settings");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_13.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2346, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 39 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                                }

#line default
#line hidden
            BeginContext(2383, 1112, true);
            WriteLiteral(@"                            </div>
                        </div>
                    </div>
                </div>
                <div id=""cardAchievements ""class=""profileCard mt-3"">
                    <div class=""d-flex flex-column align-items-center text-center"">
                        <div class=""mt-3"">
                            <h2>Achievements</h2>
                        </div>
                        <hr />
                        <ul class=""list-group list-group-flush"">
                            Insert something here
                        </ul>
                    </div>
                </div>
            </div>
            <div class=""col-md-8"">
                <div id=""cardProfileInformation"" class=""profileCard mb-3"">
                    <div class=""profileCard-body"">
                        <div class=""row"">
                            <div class=""col-sm-3"">
                                <h6 class=""mb-0"">Nickname</h6>
                            </div>
           ");
            WriteLiteral("                 <div class=\"col-sm-9 text-secondary\">\r\n                                ");
            EndContext();
            BeginContext(3496, 43, false);
#line 64 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                           Write(Html.DisplayFor(model => model.DisplayName));

#line default
#line hidden
            EndContext();
            BeginContext(3539, 389, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <hr>
                        <div class=""row"">
                            <div class=""col-sm-3"">
                                <h6 class=""mb-0"">Bio</h6>
                            </div>
                            <div class=""col-sm-9 text-secondary"">
                                ");
            EndContext();
            BeginContext(3929, 35, false);
#line 73 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                           Write(Html.DisplayFor(model => model.Bio));

#line default
#line hidden
            EndContext();
            BeginContext(3964, 391, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <hr>
                        <div class=""row"">
                            <div class=""col-sm-3"">
                                <h6 class=""mb-0"">Email</h6>
                            </div>
                            <div class=""col-sm-9 text-secondary"">
                                ");
            EndContext();
            BeginContext(4356, 50, false);
#line 82 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                           Write(Html.DisplayFor(model => model.IdNavigation.Email));

#line default
#line hidden
            EndContext();
            BeginContext(4406, 394, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <hr>
                        <div class=""row"">
                            <div class=""col-sm-3"">
                                <h6 class=""mb-0"">Province</h6>
                            </div>
                            <div class=""col-sm-9 text-secondary"">
                                ");
            EndContext();
            BeginContext(4801, 67, false);
#line 91 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                           Write(Html.DisplayFor(model => model.ProvinceCodeNavigation.ProvinceName));

#line default
#line hidden
            EndContext();
            BeginContext(4868, 389, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <hr>
                        <div class=""row"">
                            <div class=""col-sm-3"">
                                <h6 class=""mb-0"">Age</h6>
                            </div>
                            <div class=""col-sm-9 text-secondary"">
                                ");
            EndContext();
            BeginContext(5258, 15, false);
#line 100 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                           Write(ViewData["age"]);

#line default
#line hidden
            EndContext();
            BeginContext(5273, 588, true);
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-md-8"">
                    <div class=""profileCard mb-3"">
                        <div class=""profileCard-body"">
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <h6 class=""mb-0"">Nickname</h6>
                                </div>
                                <div class=""col-sm-9 text-secondary"">
                                    ");
            EndContext();
            BeginContext(5862, 43, false);
#line 113 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                               Write(Html.DisplayFor(model => model.DisplayName));

#line default
#line hidden
            EndContext();
            BeginContext(5905, 425, true);
            WriteLiteral(@"
                                </div>
                            </div>
                            <hr>
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <h6 class=""mb-0"">Bio</h6>
                                </div>
                                <div class=""col-sm-9 text-secondary"">
                                    ");
            EndContext();
            BeginContext(6331, 35, false);
#line 122 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                               Write(Html.DisplayFor(model => model.Bio));

#line default
#line hidden
            EndContext();
            BeginContext(6366, 427, true);
            WriteLiteral(@"
                                </div>
                            </div>
                            <hr>
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <h6 class=""mb-0"">Email</h6>
                                </div>
                                <div class=""col-sm-9 text-secondary"">
                                    ");
            EndContext();
            BeginContext(6794, 50, false);
#line 131 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                               Write(Html.DisplayFor(model => model.IdNavigation.Email));

#line default
#line hidden
            EndContext();
            BeginContext(6844, 430, true);
            WriteLiteral(@"
                                </div>
                            </div>
                            <hr>
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <h6 class=""mb-0"">Province</h6>
                                </div>
                                <div class=""col-sm-9 text-secondary"">
                                    ");
            EndContext();
            BeginContext(7275, 67, false);
#line 140 "C:\Users\jamie\Source\Repos\brain-builders-games\BrainBuilder\BrainBuilder\Views\Profiles\Details.cshtml"
                               Write(Html.DisplayFor(model => model.ProvinceCodeNavigation.ProvinceName));

#line default
#line hidden
            EndContext();
            BeginContext(7342, 254, true);
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                            <hr>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BrainBuilder.Models.Profiles> Html { get; private set; }
    }
}
#pragma warning restore 1591