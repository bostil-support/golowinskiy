#pragma checksum "C:\Users\RSamuseu\Documents\mk\Golowinskiy-NewBostil\Golowinskiy-NewBostil\Views\Admin\AdminPanel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "632e7cdcd4b4dc663d52460c4d476b873f590d4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AdminPanel), @"mvc.1.0.view", @"/Views/Admin/AdminPanel.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/AdminPanel.cshtml", typeof(AspNetCore.Views_Admin_AdminPanel))]
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
#line 1 "C:\Users\RSamuseu\Documents\mk\Golowinskiy-NewBostil\Golowinskiy-NewBostil\Views\_ViewImports.cshtml"
using Golowinskiy_NewBostil;

#line default
#line hidden
#line 2 "C:\Users\RSamuseu\Documents\mk\Golowinskiy-NewBostil\Golowinskiy-NewBostil\Views\_ViewImports.cshtml"
using Golowinskiy_NewBostil.Models;

#line default
#line hidden
#line 1 "C:\Users\RSamuseu\Documents\mk\Golowinskiy-NewBostil\Golowinskiy-NewBostil\Views\Admin\AdminPanel.cshtml"
using Golowinskiy_NewBostil.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"632e7cdcd4b4dc663d52460c4d476b873f590d4d", @"/Views/Admin/AdminPanel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88ec89dec51b920472d14d63a7c183d381f06afa", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AdminPanel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dictionary<User, int>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/admin.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/admin.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(70, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\RSamuseu\Documents\mk\Golowinskiy-NewBostil\Golowinskiy-NewBostil\Views\Admin\AdminPanel.cshtml"
  
    ViewData["Title"] = "AdminPanel";

#line default
#line hidden
            BeginContext(118, 76, true);
            WriteLiteral("\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n");
            EndContext();
            BeginContext(194, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "632e7cdcd4b4dc663d52460c4d476b873f590d4d4947", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(242, 164, true);
            WriteLiteral("\r\n\r\n<div class=\"showSpinner\">\r\n    <i class=\"fa fa-spinner fa-spin\"></i>\r\n</div>\r\n<div class=\"dropdownUL\">\r\n<h4>Список пользователей</h4>\r\n<ul class=\"list-group\">\r\n");
            EndContext();
#line 17 "C:\Users\RSamuseu\Documents\mk\Golowinskiy-NewBostil\Golowinskiy-NewBostil\Views\Admin\AdminPanel.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(447, 35, true);
            WriteLiteral("        <li class=\"list-group-item\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 482, "\"", 523, 3);
            WriteAttributeValue("", 492, "GetUserProducts(\'", 492, 17, true);
#line 19 "C:\Users\RSamuseu\Documents\mk\Golowinskiy-NewBostil\Golowinskiy-NewBostil\Views\Admin\AdminPanel.cshtml"
WriteAttributeValue("", 509, item.Key.Id, 509, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 521, "\')", 521, 2, true);
            EndWriteAttribute();
            BeginContext(524, 46, true);
            WriteLiteral("><i class=\"fa fa-user\" aria-hidden=\"true\"></i>");
            EndContext();
            BeginContext(571, 17, false);
#line 19 "C:\Users\RSamuseu\Documents\mk\Golowinskiy-NewBostil\Golowinskiy-NewBostil\Views\Admin\AdminPanel.cshtml"
                                                                                                                      Write(item.Key.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(588, 2, true);
            WriteLiteral(" (");
            EndContext();
            BeginContext(591, 10, false);
#line 19 "C:\Users\RSamuseu\Documents\mk\Golowinskiy-NewBostil\Golowinskiy-NewBostil\Views\Admin\AdminPanel.cshtml"
                                                                                                                                          Write(item.Value);

#line default
#line hidden
            EndContext();
            BeginContext(601, 8, true);
            WriteLiteral(")</li>\r\n");
            EndContext();
#line 20 "C:\Users\RSamuseu\Documents\mk\Golowinskiy-NewBostil\Golowinskiy-NewBostil\Views\Admin\AdminPanel.cshtml"
    }

#line default
#line hidden
            BeginContext(616, 19, true);
            WriteLiteral("</ul>\r\n    </div>\r\n");
            EndContext();
            BeginContext(635, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "632e7cdcd4b4dc663d52460c4d476b873f590d4d8553", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(672, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dictionary<User, int>> Html { get; private set; }
    }
}
#pragma warning restore 1591
