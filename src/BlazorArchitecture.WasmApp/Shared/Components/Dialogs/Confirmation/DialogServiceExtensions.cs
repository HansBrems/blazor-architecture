using MudBlazor;

namespace BlazorArchitecture.WasmApp.Shared.Components.Dialogs.Confirmation;

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