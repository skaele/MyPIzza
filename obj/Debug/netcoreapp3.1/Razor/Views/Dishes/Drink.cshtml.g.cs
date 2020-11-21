#pragma checksum "C:\Users\skael\source\repos\MyPizza\MyPizza\Views\Dishes\Drink.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de9d102cb287fa81add65bd9b0634ee4cde3af44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dishes_Drink), @"mvc.1.0.view", @"/Views/Dishes/Drink.cshtml")]
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
#line 1 "C:\Users\skael\source\repos\MyPizza\MyPizza\Views\_ViewImports.cshtml"
using MyPizza;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\skael\source\repos\MyPizza\MyPizza\Views\_ViewImports.cshtml"
using MyPizza.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\skael\source\repos\MyPizza\MyPizza\Views\_ViewImports.cshtml"
using MyPizza.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\skael\source\repos\MyPizza\MyPizza\Views\_ViewImports.cshtml"
using MyPizza.Abstractions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de9d102cb287fa81add65bd9b0634ee4cde3af44", @"/Views/Dishes/Drink.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed6673676eb67be3bd3c9d9bc8214358d9aef57d", @"/Views/_ViewImports.cshtml")]
    public class Views_Dishes_Drink : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Drink>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 4 "C:\Users\skael\source\repos\MyPizza\MyPizza\Views\Dishes\Drink.cshtml"
         foreach (Drink drink in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-3 dish_card\"");
            BeginWriteAttribute("id", " id=\"", 160, "\"", 180, 2);
            WriteAttributeValue("", 165, "drink_", 165, 6, true);
#nullable restore
#line 6 "C:\Users\skael\source\repos\MyPizza\MyPizza\Views\Dishes\Drink.cshtml"
WriteAttributeValue("", 171, drink.Id, 171, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <h2 class=\"up_h2\">");
#nullable restore
#line 7 "C:\Users\skael\source\repos\MyPizza\MyPizza\Views\Dishes\Drink.cshtml"
                             Write(drink.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <div class=\"dish_price\">от ");
#nullable restore
#line 8 "C:\Users\skael\source\repos\MyPizza\MyPizza\Views\Dishes\Drink.cshtml"
                                      Write(drink.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" руб.</div>\r\n                <div class=\"imgBox\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 366, "\"", 420, 1);
#nullable restore
#line 10 "C:\Users\skael\source\repos\MyPizza\MyPizza\Views\Dishes\Drink.cshtml"
WriteAttributeValue("", 372, Url.Content($"~/img/Drink/{drink.ImageId}.png"), 372, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=", 421, "", 440, 1);
#nullable restore
#line 10 "C:\Users\skael\source\repos\MyPizza\MyPizza\Views\Dishes\Drink.cshtml"
WriteAttributeValue("", 426, drink.ImageId, 426, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("srcset", " srcset=\"", 440, "\"", 449, 0);
            EndWriteAttribute();
            WriteLiteral(" width=\"270\"\r\n                        height=\"270\">\r\n                </div>\r\n                <div class=\"content\">\r\n                    <h2 class=\"down_h2\">");
#nullable restore
#line 14 "C:\Users\skael\source\repos\MyPizza\MyPizza\Views\Dishes\Drink.cshtml"
                                   Write(drink.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <button class=\"to_basket\" onclick=\"addToBasketSingle(this)\">\r\n                        <i class=\"fas fa-shopping-basket\"></i>\r\n                    </button>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 20 "C:\Users\skael\source\repos\MyPizza\MyPizza\Views\Dishes\Drink.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Drink>> Html { get; private set; }
    }
}
#pragma warning restore 1591
