namespace VideotekaApp.Models

/// <summary>
/// Třída ErrorViewModel obsahuje vlastnosti pro zobrazení chybového stavu aplikace.
/// Vlastnost RequestId obsahuje ID požadavku a vlastnost ShowRequestId zobrazuje ID požadavku.
/// </summary>

{
    public class ErrorViewModel  //
    {
        public string RequestId { get; set; } = string.Empty;  // Identifikátor požadavku
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);  // Určuje, zda má být RequestId zobrazen.
    }
}
