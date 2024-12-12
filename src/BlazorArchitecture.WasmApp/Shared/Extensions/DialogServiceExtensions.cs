using BlazorArchitecture.WasmApp.Shared.Components.Dialogs.Confirmation;
using MudBlazor;

namespace BlazorArchitecture.WasmApp.Shared.Extensions;

public class ConfirmationDialogOptions
{
    public string ButtonText { get; set; } = "Ok";
    public ConfirmationType ConfirmationType { get; set; } = ConfirmationType.Neutral;
}

public static class DialogServiceExtensions
{
    public static async Task<DialogResult?> ShowConfirmationDialog(this IDialogService dialogService, string title,
        string contentText, Action<ConfirmationDialogOptions>? configure = null)
    {
        var confirmationDialogOptions = new ConfirmationDialogOptions();
        configure?.Invoke(confirmationDialogOptions);
        
        var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Small, FullWidth = true };
        var parameters = new DialogParameters<ConfirmationDialog>
        {
            { x => x.ButtonText, confirmationDialogOptions.ButtonText },
            { x => x.ContentText, contentText },
            { x => x.ConfirmationType, confirmationDialogOptions.ConfirmationType }
        };
        
        var dialog = await dialogService.ShowAsync<ConfirmationDialog>(title, parameters, options);
        return await dialog.Result;    
    }
}