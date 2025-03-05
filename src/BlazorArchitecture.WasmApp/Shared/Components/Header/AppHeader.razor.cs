using Microsoft.AspNetCore.Components;

namespace BlazorArchitecture.WasmApp.Shared.Components.Header;

public partial class AppHeader : ComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
}