using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorArchitecture.WasmApp.Shared.Components.Dialogs.Confirmation;

public partial class ConfirmationDialog : ComponentBase
{
    [CascadingParameter] private MudDialogInstance MudDialog { get; set; } = null!;
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