#pragma checksum "C:\Nicat\codeacademy\backend\Bauen\Bauen\Areas\Admin\Views\Projects\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ab7300ff60a3b7b7d8ce3859eeec925c5f5c3fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Projects_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/Projects/Details.cshtml")]
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
#line 1 "C:\Nicat\codeacademy\backend\Bauen\Bauen\Areas\Admin\Views\_ViewImports.cshtml"
using Bauen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Nicat\codeacademy\backend\Bauen\Bauen\Areas\Admin\Views\_ViewImports.cshtml"
using Bauen.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Nicat\codeacademy\backend\Bauen\Bauen\Areas\Admin\Views\_ViewImports.cshtml"
using Bauen.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ab7300ff60a3b7b7d8ce3859eeec925c5f5c3fa", @"/Areas/Admin/Views/Projects/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28a04f39909fd575f288ac354321a9f6b290f478", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Projects_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Project>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-md-8\">\r\n        <h4>Name: <b>");
#nullable restore
#line 4 "C:\Nicat\codeacademy\backend\Bauen\Bauen\Areas\Admin\Views\Projects\Details.cshtml"
                Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h4>\r\n        <h4>Company: <b>");
#nullable restore
#line 5 "C:\Nicat\codeacademy\backend\Bauen\Bauen\Areas\Admin\Views\Projects\Details.cshtml"
                   Write(Model.Company);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h4>\r\n        <h4>Location: <b>");
#nullable restore
#line 6 "C:\Nicat\codeacademy\backend\Bauen\Bauen\Areas\Admin\Views\Projects\Details.cshtml"
                    Write(Model.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h4>\r\n        <h4>Year: <b>");
#nullable restore
#line 7 "C:\Nicat\codeacademy\backend\Bauen\Bauen\Areas\Admin\Views\Projects\Details.cshtml"
                Write(Model.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h4>\r\n        <h4>Title: <b>");
#nullable restore
#line 8 "C:\Nicat\codeacademy\backend\Bauen\Bauen\Areas\Admin\Views\Projects\Details.cshtml"
                 Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h4>\r\n        <h4>DetailedText: <b>");
#nullable restore
#line 9 "C:\Nicat\codeacademy\backend\Bauen\Bauen\Areas\Admin\Views\Projects\Details.cshtml"
                        Write(Model.DetailedText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h4>\r\n\r\n");
#nullable restore
#line 11 "C:\Nicat\codeacademy\backend\Bauen\Bauen\Areas\Admin\Views\Projects\Details.cshtml"
         foreach (ProjectImage item in Model.ProjectImages)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <img");
            BeginWriteAttribute("src", " src=\"", 443, "\"", 472, 2);
            WriteAttributeValue("", 449, "/img/projects/", 449, 14, true);
#nullable restore
#line 13 "C:\Nicat\codeacademy\backend\Bauen\Bauen\Areas\Admin\Views\Projects\Details.cshtml"
WriteAttributeValue("", 463, item.Img, 463, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:200px\" class=\"rounded d-block mb-3\" />\r\n");
#nullable restore
#line 14 "C:\Nicat\codeacademy\backend\Bauen\Bauen\Areas\Admin\Views\Projects\Details.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ab7300ff60a3b7b7d8ce3859eeec925c5f5c3fa6663", async() => {
                WriteLiteral("Go Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Project> Html { get; private set; }
    }
}
#pragma warning restore 1591
