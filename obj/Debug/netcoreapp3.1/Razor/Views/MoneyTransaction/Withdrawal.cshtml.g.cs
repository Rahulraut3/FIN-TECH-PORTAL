#pragma checksum "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\MoneyTransaction\Withdrawal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a942c6ef158ff3f181a98b09c0428f02e6e4755"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MoneyTransaction_Withdrawal), @"mvc.1.0.view", @"/Views/MoneyTransaction/Withdrawal.cshtml")]
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
#line 1 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\_ViewImports.cshtml"
using IBS_UILayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\_ViewImports.cshtml"
using IBS_RSLayer;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a942c6ef158ff3f181a98b09c0428f02e6e4755", @"/Views/MoneyTransaction/Withdrawal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12343469ae6713ea9610fdee5c0b1f806ba19b7e", @"/Views/_ViewImports.cshtml")]
    public class Views_MoneyTransaction_Withdrawal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IBS_DALayer.Models.AccountDetail>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("Withdrawal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\MoneyTransaction\Withdrawal.cshtml"
  
    ViewData["Title"] = "Withdrawal";
    Layout = "~/Views/Shared/_CustomerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h5 style=\"color:red;\">");
#nullable restore
#line 9 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\MoneyTransaction\Withdrawal.cshtml"
                  Write(ViewBag.ExcError);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<hr />  \r\n<div class=\"row\">\r\n    <div class=\"col-md-4 offset-xl-1\">\r\n        <h4 style=\"color:red;\">\r\n            ");
#nullable restore
#line 14 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\MoneyTransaction\Withdrawal.cshtml"
       Write(ViewBag.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </h4>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a942c6ef158ff3f181a98b09c0428f02e6e47554932", async() => {
                WriteLiteral(@"
            
           <div class=""form-outline mb-4"">
              <label class=""form-label"">Withdrawal Amount</label>
            <input type=""number"" id=""Balance"" name=""Amount"" class=""form-control form-control-lg""
              placeholder=""Enter here"" />
          </div>
          <div class=""text-center text-lg-start mt-4 pt-2"">
            <input type=""submit"" class=""btn btn-primary btn-lg"" value=""Withdrawal""
              style=""padding-left: 2.5rem; padding-right: 2.5rem;""/>
          </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <br/>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IBS_DALayer.Models.AccountDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591
