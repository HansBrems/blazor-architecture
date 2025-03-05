using MudBlazor;

namespace BlazorArchitecture.WasmApp.Shared.Components.ConfirmationDialog;

public static class DialogServiceExtensions
{
    public static async Task<DialogResult?> ShowConfirmationDialog(this IDialogService dialogService, string title,
        string contentText, Action<ConfirmationDialogOptions>? configure = null)
    {
        var confirmationDialogOptions = new ConfirmationDialogOptions();
        configure?.Invoke(confirmationDialogOptions);
        
        var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Small, FullWidth = true };
        var parameters = new DialogParameters<AppConfirmationDialog>
        {
            { x => x.ButtonText, confirmationDialogOptions.ButtonText },
            { x => x.ContentText, contentText },
            { x => x.ConfirmationType, confirmationDialogOptions.ConfirmationType }
        };
        
        var dialog = await dialogService.ShowAsync<AppConfirmationDialog>(title, parameters, options);
        return await dialog.Result;    
    }
}