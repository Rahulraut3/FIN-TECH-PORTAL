#pragma checksum "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19f8744622a71c96bbbbcf715a6fb87aa17096d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CustomerDetail_CustomerDetailByAccNo), @"mvc.1.0.view", @"/Views/CustomerDetail/CustomerDetailByAccNo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19f8744622a71c96bbbbcf715a6fb87aa17096d8", @"/Views/CustomerDetail/CustomerDetailByAccNo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12343469ae6713ea9610fdee5c0b1f806ba19b7e", @"/Views/_ViewImports.cshtml")]
    public class Views_CustomerDetail_CustomerDetailByAccNo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IBS_DALayer.Models.CustomerAllDetail>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CustomerDetailByAccNoForAdmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
  
    ViewData["Title"] = "CustomerDetailByAccNo";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h5 style=\"color:red;\">");
#nullable restore
#line 7 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
                  Write(ViewBag.ExcError);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<h1>CustomerDetailByAccNo</h1>\r\n\r\n<div>\r\n    <h4>CustomerAllDetail</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.BranchName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.BranchName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.IFSCCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.IFSCCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.AccountType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.AccountType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.AccountBalance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.AccountBalance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.AccountCreationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.AccountCreationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.CustomerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.CustomerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.DOB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.DOB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.PAN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.PAN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 75 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.Aadhar));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 78 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.Aadhar));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 81 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 84 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 87 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.NomineeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 90 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.NomineeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 93 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.Relation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 96 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.Relation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 99 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.NomPhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 102 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.NomPhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 105 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.NomineeAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 108 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.NomineeAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 111 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayNameFor(model => model.AccountNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 114 "D:\Final Proj Assembly\InternetBankingSystem\IBS_UILayer\Views\CustomerDetail\CustomerDetailByAccNo.cshtml"
       Write(Html.DisplayFor(model => model.AccountNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "19f8744622a71c96bbbbcf715a6fb87aa17096d816253", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IBS_DALayer.Models.CustomerAllDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591
