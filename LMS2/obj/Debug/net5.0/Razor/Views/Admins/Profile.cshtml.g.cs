#pragma checksum "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Admins\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b19cd864b3f668bcfb1decb1ee1ea16516055864"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admins_Profile), @"mvc.1.0.view", @"/Views/Admins/Profile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b19cd864b3f668bcfb1decb1ee1ea16516055864", @"/Views/Admins/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73be68236721325d58c5a2d4db6f4a64171295e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Admins_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Admins\Profile.cshtml"
  
    ViewData["Title"] = "Profile";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Profile</h1>\r\n\r\n<h4>admin</h4>\r\n<hr />\r\n\r\n<nav class=\"navbar navbar-default\">\r\n    <nav class=\"navbar navbar-expand-lg navbar-light\">\r\n");
            WriteLiteral(@"
        <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navbarSupportedContent"" aria-controls=""navbarSupportedContent"" aria-expanded=""false"" aria-label=""Toggle navigation"">
            <span class=""navbar-toggler-icon""></span>
        </button>

        <div class=""collapse navbar-collapse"" id=""navbarSupportedContent"">
            <ul class=""navbar-nav mr-auto"">
                <li class=""nav-item active"">
                    ");
#nullable restore
#line 23 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Admins\Profile.cshtml"
               Write(Html.ActionLink("Home", "Index", "Home", null, new { @class = "nav-link" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </li>
                <li class=""nav-item active"">
                    <a class=""nav-link"" href=""#"">About Us</a>
                </li>
            </ul>
        </div>
        <ul class=""navbar-nav"">
            <li class=""nav-item active"">
                ");
#nullable restore
#line 32 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Admins\Profile.cshtml"
           Write(Html.ActionLink("View Books", "ViewBook", "User", null, new { @class = "nav-link" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </li>\r\n            <li class=\"nav-item active\">\r\n                ");
#nullable restore
#line 35 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Admins\Profile.cshtml"
           Write(Html.ActionLink("Add Book", "Add", "BookManagement", null, new { @class = "nav-link" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </li>\r\n            <li class=\"nav-item active\">\r\n                ");
#nullable restore
#line 38 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Admins\Profile.cshtml"
           Write(Html.ActionLink("Admin Login", "Index", "Admins", null, new { @class = "nav-link" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </li>\r\n            <li class=\"nav-item active\">\r\n                ");
#nullable restore
#line 41 "C:\Users\lenovo\source\repos\LMS2\LMS2\Views\Admins\Profile.cshtml"
           Write(Html.ActionLink("jdfvbgalijfsubvlzidhfb Login", "UserLogin", "Users", null, new { @class = "nav-link" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </li>\r\n        </ul>\r\n    </nav>\r\n</nav>\r\n");
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