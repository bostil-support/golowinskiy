#pragma checksum "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Admin\UserProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c11ff3ac424f0fdb307f47c1c855ca7d81adfaf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UserProducts), @"mvc.1.0.view", @"/Views/Admin/UserProducts.cshtml")]
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
#line 1 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\_ViewImports.cshtml"
using Golowinskiy_NewBostil;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\_ViewImports.cshtml"
using Golowinskiy_NewBostil.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c11ff3ac424f0fdb307f47c1c855ca7d81adfaf", @"/Views/Admin/UserProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88ec89dec51b920472d14d63a7c183d381f06afa", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_UserProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Golowinskiy_NewBostil.Models.Product.ProductCategoryViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/admin.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/admin.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Admin\UserProducts.cshtml"
  
    ViewData["Title"] = "UserProducts";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9c11ff3ac424f0fdb307f47c1c855ca7d81adfaf4835", async() => {
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
            WriteLiteral("\r\n<div class=\"showSpinner\">\r\n    <i class=\"fa fa-spinner fa-spin\"></i>\r\n</div>\r\n<div class=\"dropdownULUser\">\r\n    <h4><i class=\"fa fa-user\" aria-hidden=\"true\"></i> ");
#nullable restore
#line 14 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Admin\UserProducts.cshtml"
                                                 Write(ViewBag.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral(", всего объявлений ");
#nullable restore
#line 14 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Admin\UserProducts.cshtml"
                                                                                     Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <div class=\"products_list\">\r\n");
#nullable restore
#line 16 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Admin\UserProducts.cshtml"
         foreach (var product in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 631, "\"", 650, 1);
#nullable restore
#line 18 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Admin\UserProducts.cshtml"
WriteAttributeValue("", 639, product.Id, 639, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n            <div class=\"products_list_item\"");
            BeginWriteAttribute("onclick", " onclick=\"", 699, "\"", 741, 4);
            WriteAttributeValue("", 709, "showDetails(this,", 709, 17, true);
            WriteAttributeValue(" ", 726, "\'", 727, 2, true);
#nullable restore
#line 19 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Admin\UserProducts.cshtml"
WriteAttributeValue("", 728, product.Id, 728, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 739, "\')", 739, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"products_list_item_main\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 824, "\"", 852, 1);
#nullable restore
#line 21 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Admin\UserProducts.cshtml"
WriteAttributeValue("", 830, product.MainImageLink, 830, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n                <div class=\"products_list_item_footer\">\r\n                    <h4>");
#nullable restore
#line 24 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Admin\UserProducts.cshtml"
                   Write(product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    <div class=\"price\">\r\n                        <p>");
#nullable restore
#line 26 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Admin\UserProducts.cshtml"
                      Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" руб.</p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 30 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Admin\UserProducts.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c11ff3ac424f0fdb307f47c1c855ca7d81adfaf9972", async() => {
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
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Golowinskiy_NewBostil.Models.Product.ProductCategoryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
