using System.ComponentModel.DataAnnotations;

/*
  Tøída Film obsahuje atributy, které jsou vyuity pro vytvoøení tabulky v databázi.
  Atributy obsahují rùzné validace, které zajišují, e vstupní data splòují poadavky.
  Atribut Display(Name = "Název filmu") slouí k pøejmenování sloupce v tabulce.
*/

namespace VideotekaApp.Models
{
    public class Film  // Tøída Film obsahuje atributy, které jsou vyuity pro vytvoøení tabulky v databázi
    {
        public int ID { get; set; } // ID filmu je primární klíè

        [Required(ErrorMessage = "Název filmu je povinnı")]  // Required a Range (atributy) zajišují, e vstupní data splòují poadavky
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Délka názvu filmu musí bıt v rozmezí 2 - 60 znakù")]
        [Display(Name = "Název filmu")]  // Zmìna názvu sloupce v tabulce
        public string Title { get; set; } 
        
        [Required(ErrorMessage = "Rok vydání filmu je povinnı")]
        [Range(1900, 2025, ErrorMessage = "Rok vydání filmu musí bıt mezi 1900 a 2025")]
        [Display(Name = "Rok vydání")]  // Zmìna názvu sloupce v tabulce
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "ánr filmu je povinnı")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "ánr filmu musí bıt v rozmezí 3 a 30 znaky")]
        [Display(Name = "ánr filmu")]  // Zmìna názvu sloupce v tabulce
        public string Genre { get; set; }

        [Required(ErrorMessage = "Hodnocení filmu je povinné")]
        [Range(1, 10, ErrorMessage = "Hodnocení filmu musí bıt v rozmezí 1 a 10")]
        [Display(Name = "Hodnocení filmu")]  // Zmìna názvu sloupce v tabulce
        public int Rating { get; set; }
    }
}
