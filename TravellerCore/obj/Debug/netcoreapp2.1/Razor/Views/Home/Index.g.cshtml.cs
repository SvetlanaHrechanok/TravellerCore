#pragma checksum "D:\УЧЕБА\Epam\ProjectCore\TravellerCore\TravellerCore\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e509fdc80de4acb8830689f6ccf57e5daaccc4b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "D:\УЧЕБА\Epam\ProjectCore\TravellerCore\TravellerCore\Views\_ViewImports.cshtml"
using TravellerCore;

#line default
#line hidden
#line 2 "D:\УЧЕБА\Epam\ProjectCore\TravellerCore\TravellerCore\Views\_ViewImports.cshtml"
using TravellerCore.Models;

#line default
#line hidden
#line 1 "D:\УЧЕБА\Epam\ProjectCore\TravellerCore\TravellerCore\Views\Home\Index.cshtml"
using TravellerCore.App_code;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e509fdc80de4acb8830689f6ccf57e5daaccc4b3", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c21c6a0b00f87f6afa274a4a9feac138aa60f23", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(31, 1230, true);
            WriteLiteral(@"
<nav class=""navbar navbar-default"">
    <div class=""container-fluid"">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class=""navbar-header"">
            <button type=""button"" class=""navbar-toggle collapsed"" data-toggle=""collapse"" data-target=""#bs-example-navbar-collapse-1"" aria-expanded=""false"">
                <span class=""sr-only"">Toggle navigation</span>
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
            </button>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class=""collapse navbar-collapse"" id=""bs-example-navbar-collapse-1"">
            <ul class=""nav navbar-nav"">
                <li class=""active""><a href=""/Home/Index"">HOME <span class=""sr-only"">(current)</span></a></li>
                <li><a href=""/Home/About"">ABOUT </a></li>
                <li><a href=""/Home/Contact"">CONTACT </a></li>");
            WriteLiteral("\n            </ul>\r\n\r\n        </div><!-- /.navbar-collapse -->\r\n    </div><!-- /.container-fluid -->\r\n</nav>\r\n\r\n<div class=\"buttons\">\r\n    <a href=\"/Home/Add\" class=\"btn btn-info\">Add tour</a>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            BeginContext(1262, 19, false);
#line 32 "D:\УЧЕБА\Epam\ProjectCore\TravellerCore\TravellerCore\Views\Home\Index.cshtml"
Write(Html.GetCountries());

#line default
#line hidden
            EndContext();
            BeginContext(1281, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
