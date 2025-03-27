using Microsoft.AspNetCore.Components;

namespace BlazorArchitecture.WasmApp.Features.Products.Overview;

public partial class OverviewPage : ComponentBase
{
    [Inject] public OverviewPageViewModel Vm { get; set; } = null!;

    protected override Task OnInitializedAsync() => Vm.Initialize();
}