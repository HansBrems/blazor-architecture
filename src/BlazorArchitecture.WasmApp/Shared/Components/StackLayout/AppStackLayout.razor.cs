using Microsoft.AspNetCore.Components;

namespace BlazorArchitecture.WasmApp.Shared.Components.StackLayout;

public partial class AppStackLayout : ComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}