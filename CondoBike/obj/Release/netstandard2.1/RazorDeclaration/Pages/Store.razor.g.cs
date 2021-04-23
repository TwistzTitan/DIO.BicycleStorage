#pragma checksum "C:\projects\csharp\CondoBike.Project.DIO\CondoBike\Pages\Store.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb67c34a8b18d8bc4afe0e795b3590354f20a441"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace CondoBike.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\projects\csharp\CondoBike.Project.DIO\CondoBike\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\projects\csharp\CondoBike.Project.DIO\CondoBike\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\projects\csharp\CondoBike.Project.DIO\CondoBike\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\projects\csharp\CondoBike.Project.DIO\CondoBike\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\projects\csharp\CondoBike.Project.DIO\CondoBike\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\projects\csharp\CondoBike.Project.DIO\CondoBike\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\projects\csharp\CondoBike.Project.DIO\CondoBike\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\projects\csharp\CondoBike.Project.DIO\CondoBike\Pages\Store.razor"
using CondoBike.Model;

#line default
#line hidden
#nullable disable
    public partial class Store : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 44 "C:\projects\csharp\CondoBike.Project.DIO\CondoBike\Pages\Store.razor"
 
    private Owner OwnerModel;
    private Bicycle BicycleModel;
    private int apartament;
    private int block;
    private EditContext editContextOwner;
    private EditContext editContextBicycle;
    public String log {get ; set;}

    protected override void OnInitialized()
        {
            BicycleModel = new Bicycle();
            OwnerModel = new Owner();
            editContextOwner = new EditContext(OwnerModel);
            editContextBicycle = new EditContext(BicycleModel);
        }
    
    public void HandleValidSubmit()
    {
       if( editContextOwner.Validate() && editContextBicycle.Validate())
       {
           BicycleModel.BicycleOwner = OwnerModel;
           bsService.Store(BicycleModel);
       }     
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BicycleStorage bsService { get; set; }
    }
}
#pragma warning restore 1591
