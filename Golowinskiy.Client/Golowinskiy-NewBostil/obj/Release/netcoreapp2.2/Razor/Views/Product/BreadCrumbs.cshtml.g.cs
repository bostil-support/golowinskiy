#pragma checksum "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Product\BreadCrumbs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eeeb3bec578b4a41b4ecab9cdbb600514c6265b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_BreadCrumbs), @"mvc.1.0.view", @"/Views/Product/BreadCrumbs.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/BreadCrumbs.cshtml", typeof(AspNetCore.Views_Product_BreadCrumbs))]
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
#line 1 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\_ViewImports.cshtml"
using Golowinskiy_NewBostil;

#line default
#line hidden
#line 2 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\_ViewImports.cshtml"
using Golowinskiy_NewBostil.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eeeb3bec578b4a41b4ecab9cdbb600514c6265b1", @"/Views/Product/BreadCrumbs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88ec89dec51b920472d14d63a7c183d381f06afa", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_BreadCrumbs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Golowinskiy_NewBostil.Models.Category.BreadCrumbViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(72, 34, true);
            WriteLiteral("\r\n<div class=\"breadcrumbs_list\">\r\n");
            EndContext();
#line 4 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Product\BreadCrumbs.cshtml"
     for (int i = 0; i < Model.Count - 1; i++)
    {

#line default
#line hidden
            BeginContext(161, 42, true);
            WriteLiteral("        <div class=\"breadcrumbs_list_item\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 203, "\"", 239, 3);
            WriteAttributeValue("", 213, "goToCategory(", 213, 13, true);
#line 6 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Product\BreadCrumbs.cshtml"
WriteAttributeValue("", 226, Model[i].Id, 226, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 238, ")", 238, 1, true);
            EndWriteAttribute();
            BeginContext(240, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(242, 13, false);
#line 6 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Product\BreadCrumbs.cshtml"
                                                                           Write(Model[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(255, 41, true);
            WriteLiteral("<i class=\"fa fa-angle-right\"></i></div>\r\n");
            EndContext();
#line 7 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Product\BreadCrumbs.cshtml"
    }

#line default
#line hidden
            BeginContext(303, 38, true);
            WriteLiteral("    <div class=\"breadcrumbs_list_item\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 341, "\"", 391, 3);
            WriteAttributeValue("", 351, "goToCategory(", 351, 13, true);
#line 8 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Product\BreadCrumbs.cshtml"
WriteAttributeValue("", 364, Model[Model.Count - 1].Id, 364, 26, false);

#line default
#line hidden
            WriteAttributeValue("", 390, ")", 390, 1, true);
            EndWriteAttribute();
            BeginContext(392, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(394, 27, false);
#line 8 "C:\Users\RSamuseu\Documents\golowinskiy-client-tmp\golowinskiy\Golowinskiy.Client\Golowinskiy-NewBostil\Views\Product\BreadCrumbs.cshtml"
                                                                                     Write(Model[Model.Count - 1].Name);

#line default
#line hidden
            EndContext();
            BeginContext(421, 14, true);
            WriteLiteral("</div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Golowinskiy_NewBostil.Models.Category.BreadCrumbViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
