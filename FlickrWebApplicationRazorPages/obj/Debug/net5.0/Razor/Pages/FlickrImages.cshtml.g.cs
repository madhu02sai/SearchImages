#pragma checksum "C:\Users\mvemulam.ORADEV\source\repos\FlickrWebApplicationRazorPages\FlickrWebApplicationRazorPages\Pages\FlickrImages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f78c6f6f343a9eb54cb541fa5c0e6a77e3703ed3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(FlickrWebApplicationRazorPages.Pages.Pages_FlickrImages), @"mvc.1.0.razor-page", @"/Pages/FlickrImages.cshtml")]
namespace FlickrWebApplicationRazorPages.Pages
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
#line 1 "C:\Users\mvemulam.ORADEV\source\repos\FlickrWebApplicationRazorPages\FlickrWebApplicationRazorPages\Pages\_ViewImports.cshtml"
using FlickrWebApplicationRazorPages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f78c6f6f343a9eb54cb541fa5c0e6a77e3703ed3", @"/Pages/FlickrImages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f8d9951d12958f1be1e3f9f391007350cd142da", @"/Pages/_ViewImports.cshtml")]
    public class Pages_FlickrImages : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/masonry.pkgd.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<p>Images for ");
#nullable restore
#line 10 "C:\Users\mvemulam.ORADEV\source\repos\FlickrWebApplicationRazorPages\FlickrWebApplicationRazorPages\Pages\FlickrImages.cshtml"
         Write(Model.Tag);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<br/>\r\n\r\n<div class=\"row\">\r\n");
#nullable restore
#line 14 "C:\Users\mvemulam.ORADEV\source\repos\FlickrWebApplicationRazorPages\FlickrWebApplicationRazorPages\Pages\FlickrImages.cshtml"
     foreach (var url in Model.urls)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-2 border border-white\"> <img");
            BeginWriteAttribute("src", " src=\"", 316, "\"", 326, 1);
#nullable restore
#line 16 "C:\Users\mvemulam.ORADEV\source\repos\FlickrWebApplicationRazorPages\FlickrWebApplicationRazorPages\Pages\FlickrImages.cshtml"
WriteAttributeValue("", 322, url, 322, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> </div>\r\n");
#nullable restore
#line 19 "C:\Users\mvemulam.ORADEV\source\repos\FlickrWebApplicationRazorPages\FlickrWebApplicationRazorPages\Pages\FlickrImages.cshtml"
                
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f78c6f6f343a9eb54cb541fa5c0e6a77e3703ed34824", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FlickrWebApplicationRazorPages.Pages.FlickrImagesModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<FlickrWebApplicationRazorPages.Pages.FlickrImagesModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<FlickrWebApplicationRazorPages.Pages.FlickrImagesModel>)PageContext?.ViewData;
        public FlickrWebApplicationRazorPages.Pages.FlickrImagesModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
