using Microsoft.AspNetCore.Components;

namespace BlazorArchitecture.WasmApp.Shared.Components;

public partial class StackLayout : ComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}