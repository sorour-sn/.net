#pragma checksum "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Issuing\IssuedBook.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9d5231e4bb6d3eb1d8fac3dbaa16744d4b0bc00"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Issuing_IssuedBook), @"mvc.1.0.view", @"/Views/Issuing/IssuedBook.cshtml")]
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
#line 1 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\_ViewImports.cshtml"
using LMS2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\_ViewImports.cshtml"
using LMS2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Issuing\IssuedBook.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9d5231e4bb6d3eb1d8fac3dbaa16744d4b0bc00", @"/Views/Issuing/IssuedBook.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73be68236721325d58c5a2d4db6f4a64171295e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Issuing_IssuedBook : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LMS2.Models.BookIssue>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Issuing\IssuedBook.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\nuser: ");
#nullable restore
#line 8 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Issuing\IssuedBook.cshtml"
 Write(HttpContextAccessor.HttpContext.Session.GetString("_Username"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Issued Books</h1>\r\n\r\n");
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n");
            WriteLiteral("                ");
#nullable restore
#line 19 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Issuing\IssuedBook.cshtml"
           Write(Html.DisplayNameFor(model => model.BookName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 20 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Issuing\IssuedBook.cshtml"
           Write(Html.DisplayNameFor(model => model.Issue_Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 21 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Issuing\IssuedBook.cshtml"
           Write(Html.DisplayNameFor(model => model.Due_Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 29 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Issuing\IssuedBook.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <!--<td>-->\r\n");
            WriteLiteral("                <!--<img src=\"~/Image/\" height=\"40\" width=\"40\" asp-append-version=\"true\" />\r\n                </td>-->\r\n                <td>\r\n                    ");
#nullable restore
#line 37 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Issuing\IssuedBook.cshtml"
               Write(Html.DisplayFor(modelItem => item.BookName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 38 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Issuing\IssuedBook.cshtml"
               Write(Html.DisplayFor(modelItem => item.Issue_Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 39 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Issuing\IssuedBook.cshtml"
               Write(Html.DisplayFor(modelItem => item.Due_Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 45 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Issuing\IssuedBook.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LMS2.Models.BookIssue>> Html { get; private set; }
    }
}
#pragma warning restore 1591