namespace BlazorArchitecture.WasmApp.Shared.Components.ConfirmationDialog;

public class ConfirmationDialogOptions
{
    public string ButtonText { get; set; } = "Ok";
    public ConfirmationType ConfirmationType { get; set; } = ConfirmationType.Neutral;
}