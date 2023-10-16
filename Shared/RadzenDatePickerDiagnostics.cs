namespace radzen_issue_1174.Shared;

using Microsoft.AspNetCore.Components;
using Radzen.Blazor;

public class RadzenDatePickerDiagnostics<TValue> : RadzenDatePicker<TValue>
{
    [Parameter] public string DiagnosticsName { get; set; } = string.Empty;

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
        if (EditContext != null && ValueExpression != null && FieldIdentifier.Model != EditContext.Model)
        {
            EditContext.OnValidationStateChanged += (_, _) => LogStateHasChangedCall();
        }
    }

    private void LogStateHasChangedCall() 
    {
        Console.WriteLine($"{DiagnosticsName} wants to call StateHasChanged()");
    }
}