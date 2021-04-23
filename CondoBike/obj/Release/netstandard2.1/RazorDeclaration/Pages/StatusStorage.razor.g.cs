#pragma checksum "C:\projects\csharp\CondoBike.Project.DIO\CondoBike\Pages\StatusStorage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c94e48a9112acc1f97ddf01aacde7cd12949a399"
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
#line 8 "C:\projects\csharp\CondoBike.Project.DIO\CondoBike\_Imports.razor"
using CondoBike.Model;

#line default
#line hidden
#nullable disable
    public partial class StatusStorage : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 26 "C:\projects\csharp\CondoBike.Project.DIO\CondoBike\Pages\StatusStorage.razor"
 
    public int Capacity;

    public string Ocupation;

    public string StoredBicycles {get ; set ;}

    public string NotStoredBicycles {get ; set ;}
    protected override void OnInitialized()
    {
        getCapacity();
    }
    public void getCapacity (){
        bsService.BicycleStorageCapacity = 30;
        Capacity = bsService.BicycleStorageCapacity;
        Ocupation = bsService.StorageOcupation().ToString("0.00");
    }

    public void getStatusBicycles()
    {
       StoredBicycles = bsService.Bicycles.Where(b => b.BicycleStatus == BicycleStatus.Guarded).ToList().Count.ToString(); 
       NotStoredBicycles = bsService.Bicycles.Where(b => b.BicycleStatus == BicycleStatus.NotGuarded).ToList().Count.ToString();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private CondoBike.Model.BicycleStorage bsService { get; set; }
    }
}
#pragma warning restore 1591
