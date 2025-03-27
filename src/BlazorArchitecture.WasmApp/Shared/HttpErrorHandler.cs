using MudBlazor;

namespace BlazorArchitecture.WasmApp.Shared;

public class HttpErrorHandler(ISnackbar snackbar) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);
        
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            snackbar.Add($"HTTP Error {response.StatusCode}: {errorContent}", Severity.Error);
        }

        return response;
    }
}