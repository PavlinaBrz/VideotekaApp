namespace VideotekaApp.Models

/* Třída ErrorViewModel obsahuje vlastnosti pro zobrazení chybového stavu aplikace.
 * Vlastnost RequestId obsahuje ID požadavku a vlastnost ShowRequestId zobrazuje ID požadavku.
 */

{
    public class ErrorViewModel  //
    {
        public string RequestId { get; set; } = string.Empty;  // Vlastnost RequestId obsahuje ID požadavku
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);  // Vlastnost ShowRequestId zobrazuje ID požadavku
    }
}
