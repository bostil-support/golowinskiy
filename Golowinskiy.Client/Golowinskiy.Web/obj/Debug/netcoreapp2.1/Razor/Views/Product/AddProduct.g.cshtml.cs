#pragma checksum "C:\Users\RSamuseu\Desktop\golowinskiy-client\Golowinskiy.Client\Golowinskiy.Web\Views\Product\AddProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6d1d2c15f73dbe667f95ccf98f5f8b2daa58859"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_AddProduct), @"mvc.1.0.view", @"/Views/Product/AddProduct.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/AddProduct.cshtml", typeof(AspNetCore.Views_Product_AddProduct))]
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
#line 1 "C:\Users\RSamuseu\Desktop\golowinskiy-client\Golowinskiy.Client\Golowinskiy.Web\Views\_ViewImports.cshtml"
using Golowinskiy.Web.Models.Category;

#line default
#line hidden
#line 2 "C:\Users\RSamuseu\Desktop\golowinskiy-client\Golowinskiy.Client\Golowinskiy.Web\Views\_ViewImports.cshtml"
using Golowinskiy.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6d1d2c15f73dbe667f95ccf98f5f8b2daa58859", @"/Views/Product/AddProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba0944a8f0fcbdb31626b64d5fce052b85bb45e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_AddProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Golowinskiy.Web.Models.Product.AddProductViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/add-product-components.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/product.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\RSamuseu\Desktop\golowinskiy-client\Golowinskiy.Client\Golowinskiy.Web\Views\Product\AddProduct.cshtml"
  
    ViewData["Title"] = "AddProduct";
    Layout = null;

#line default
#line hidden
            BeginContext(127, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(129, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3dd73af30cfb4551a99192149dd272c7", async() => {
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
            BeginContext(194, 1200, true);
            WriteLiteral(@"
<link rel='stylesheet' href='https://use.fontawesome.com/releases/v5.7.0/css/all.css'
      integrity='sha384-lZN37f5QGtY3VHgisS14W3ExzMWZxybE1SJSEsQp9S+oqd12jhcu+A56Ebc1zFSJ' crossorigin='anonymous'>
<section class=""advertisement"">
    <div class=""container"">
        <div class=""showSpinner"">
            <i class=""fa fa-spinner fa-spin""></i>
        </div>

        <h3 class=""text-center mt-4 mb-4"">Разместить объявление</h3>
        <div class=""row justify-content-md-center"">
            <div class=""col-lg-8 col-xs-12 back text-right mt-4 mb-2"">
                <a onclick=""location.href='../Home/Index'"">ВЕРНУТЬСЯ к КАТАЛОГУ</a>
            </div>
        </div>
        <div class=""row justify-content-md-center"">
            <div class=""col-lg-8 col-xs-12 back text-right mb-4"">
                <a onclick=""location.href='../Cabinet/Cabinet'"">ВЕРНУТЬСЯ в ЛИЧНЫЙ КАБИНЕТ</a>
            </div>
        </div>

        <div class=""row mb-3 justify-content-md-center"">
            <div class=""c");
            WriteLiteral("ol-lg-8 col-xs-12 text-right\">\r\n                <div class=\"contact pt-2 pb-2 pr-2\">\r\n                    <h5>Контактная информация</h5>\r\n                    <input id=\"userId\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1394, "\"", 1415, 1);
#line 33 "C:\Users\RSamuseu\Desktop\golowinskiy-client\Golowinskiy.Client\Golowinskiy.Web\Views\Product\AddProduct.cshtml"
WriteAttributeValue("", 1402, Model.UserId, 1402, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1416, 165, true);
            WriteLiteral(" type=\"hidden\" />\r\n                    <div class=\"row\">\r\n                        <div class=\"col-lg-12 col-xs-12\">\r\n                            <span id=\"userName\">");
            EndContext();
            BeginContext(1582, 14, false);
#line 36 "C:\Users\RSamuseu\Desktop\golowinskiy-client\Golowinskiy.Client\Golowinskiy.Web\Views\Product\AddProduct.cshtml"
                                           Write(Model.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1596, 212, true);
            WriteLiteral("</span>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"row\">\r\n                        <div class=\"col-lg-12 col-xs-12\">\r\n                            <span id=\"email\">");
            EndContext();
            BeginContext(1809, 11, false);
#line 41 "C:\Users\RSamuseu\Desktop\golowinskiy-client\Golowinskiy.Client\Golowinskiy.Web\Views\Product\AddProduct.cshtml"
                                        Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1820, 7467, true);
            WriteLiteral(@"</span>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-lg-12 col-xs-12"">
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div id=""categories"" class=""categories"">
            <div class=""ps-widget__header"">
                <h5>Выберите раздел каталога</h5>
            </div>
        </div>

        <div class=""row justify-content-md-center choosed"">
            <div class=""col-lg-8 col-xs-12 no-padding"">
                Вы выбрали раздел
                <div id=""breadcrumbs"" class=""breadcrumbs_container"">
                </div>
            </div>
        </div>
        <div class=""row justify-content-md-center choosed"">
            <div class=""col-lg-8 col-xs-12 no-padding"">

            </div>
        </div>

        <div class=""showMessage"">
            <div class=""alert"">
            </div>
        </div>

    ");
            WriteLiteral(@"    <div class=""form"">
            <div class=""form-group""
                 style=""display: none;"">
                <div class=""row justify-content-md-center"">
                    <div class=""col-lg-4"">
                        <label>Наименование категории</label>
                    </div>
                    <div class=""col-lg-4"">
                        <input type=""text"" id=""Categories"">
                    </div>
                </div>
            </div>

            <div class=""form-group"">
                <div class=""row justify-content-md-center"">
                    <div class=""col-lg-4"">
                        <label>Наименование товара, услуги *</label>
                    </div>
                    <div class=""col-lg-4"">
                        <input type=""text"" id=""TName"" onblur=""isEmptyTName()"" onkeyup=""isEmptyTName()"" onchange=""checkFilledRequiredFields()"">
                        <span class=""form-help-text"">
                            <span>
                          ");
            WriteLiteral(@"      Заполните наименование товара, услуги
                            </span>
                        </span>
                    </div>
                </div>
            </div>

            <div class=""form-group"">
                <div class=""row justify-content-md-center"">
                    <div class=""col-lg-4"">
                        <label>Описание товара, услуги</label>
                    </div>
                    <div class=""col-lg-4"">
                        <textarea type=""textarea"" id=""TDescription"" onchange=""checkFilledRequiredFields()""></textarea>
                    </div>
                </div>
            </div>

            <div class=""form-group"">
                <div class=""row justify-content-md-center"">
                    <div class=""col-lg-4"">
                        <label>Цена</label>
                    </div>
                    <div class=""col-lg-4"">
                        <input type=""text"" id=""TCost"" onkeypress=""return /[0-9.]/i.test(event.key)"" on");
            WriteLiteral(@"change=""checkFilledRequiredFields()"">
                    </div>
                </div>
            </div>

            <div class=""mb-3"">
                <div class=""row justify-content-md-center"">
                    <div class=""col-lg-4"">
                        <label>Основная фотография</label>
                    </div>
                    <div class=""col-lg-4"">
                        <div class=""upload btn-file"" id=""DMP"">
                            <input type=""file"" id=""mainImage"" onchange=""attachMainImage(this)"">
                            <img id=""mainImg"" style=""width:100px; height:70px"" alt="""">
                            <i class=""fa fa-upload arrow"" aria-hidden=""true""></i>
                            <i class=""fa fa-rotate-right""></i>
                        </div>
                    </div>
                </div>
            </div>

            <div class=""mb-3"">
                <div class=""row justify-content-md-center"">
                    <div class=""col-lg-4 col-xs");
            WriteLiteral(@"-12"">
                        <label>Доп. фотографии</label>
                    </div>
                    <div class=""col-lg-4 col-xs-12"">
                        <div class=""upload-images"" id=""addt-imgs"">
                            <div class=""upload btn-file"" id=""additional-div-img1"">
                                <input id=""additionalImage1"" type=""file"" onchange=""attachAdditImage(this)"" disabled>
                                <img id=""addtImg1"" style=""width:100px; height:70px"" alt="""">
                                <i class=""fa fa-upload arrow disabled"" aria-hidden=""true""></i>
                            </div>
                            <i class=""fa fa-times delete"" id=""removeImg1"" style=""visibility:hidden"" onclick=""removeAdditionalImage(this, 1)""></i>
                        </div>
                    </div>
                </div>
                <div class=""row justify-content-md-center"">
                    <div class=""col col-lg-4 mb-3 hover_btn""
                         id=""s");
            WriteLiteral(@"ubmit-area"">
                        <button type=""button"" class=""btn btn-block btn-primary"" id=""btn-sbmt"" name=""submitButton"" onclick=""saveProduct()"">
                            Разместить объявление
                        </button>

                    </div>
                </div>

                <div class=""row other_fields"">
                    <div class=""col-lg-4"">
                        <p id=""pp"">Необязательные поля</p>
                    </div>
                </div>

                <div class=""form-group"">

                    <div class=""row justify-content-md-center"">
                        <div class=""col-lg-4"">
                            <label>Ссылка на видео</label>
                        </div>
                        <div class=""col-lg-4"">
                            <input type=""text"" id=""youtube"">
                        </div>
                    </div>

                </div>

                <div class=""form-group"">

                    <div class=");
            WriteLiteral(@"""row justify-content-md-center"">
                        <div class=""col-lg-4"">
                            <label>Тип изделия</label>
                        </div>
                        <div class=""col-lg-4"">
                            <input type=""text"" id=""TypeProd"">
                        </div>
                    </div>

                </div>

                <div class=""form-group"">
                    <div class=""row justify-content-md-center"">
                        <div class=""col-lg-4"">
                            <label>Артикул товара</label>
                        </div>
                        <div class=""col-lg-4"">
                            <input type=""text"" id=""Article"">
                        </div>
                    </div>

                </div>


                <div class=""form-group"">

                    <div class=""row justify-content-md-center"">
                        <div class=""col-lg-4"">
                            <label>Механизм трансфор");
            WriteLiteral(@"мации</label>
                        </div>
                        <div class=""col-lg-4"">
                            <input type=""text"" id=""TransformMech"">
                        </div>
                    </div>
                </div>
            </div>

        </div>
</section>

");
            EndContext();
            BeginContext(9287, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "665c33b5067046d890ae742c279cc033", async() => {
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
            BeginContext(9338, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(9340, 39, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e56653e84f9478ea3a5be4ea2ac89fd", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(9379, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Golowinskiy.Web.Models.Product.AddProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
