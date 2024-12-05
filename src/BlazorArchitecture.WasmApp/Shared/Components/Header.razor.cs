using Microsoft.AspNetCore.Components;

namespace BlazorArchitecture.WasmApp.Shared.Components;

public partial class Header : ComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}