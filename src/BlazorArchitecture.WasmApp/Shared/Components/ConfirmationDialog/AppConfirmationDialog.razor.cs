using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorArchitecture.WasmApp.Shared.Components.ConfirmationDialog;

public partial class AppConfirmationDialog : ComponentBase
{
    [CascadingParameter] public required MudDialogInstance MudDialog { get; set; }
    [Parameter] public ConfirmationType ConfirmationType { get; set; } = ConfirmationType.Neutral;
    [Parameter] public string ButtonText { get; set; } = "Ok";
    [Parameter] public string ContentText { get; set; } = "Are you sure?";
    
    private void Submit()
    {
        MudDialog.Close(DialogResult.Ok(true));
    }

    private void Cancel()
    {
        MudDialog.Cancel();
    }
}