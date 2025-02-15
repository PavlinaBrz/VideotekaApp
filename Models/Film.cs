using System.ComponentModel.DataAnnotations;

/*
  T��da Film obsahuje atributy, kter� jsou vyu�ity pro vytvo�en� tabulky v datab�zi.
  Atributy obsahuj� r�zn� validace, kter� zaji��uj�, �e vstupn� data spl�uj� po�adavky.
  Atribut Display(Name = "N�zev filmu") slou�� k p�ejmenov�n� sloupce v tabulce.
*/

namespace VideotekaApp.Models
{
    public class Film  // T��da Film obsahuje atributy, kter� jsou vyu�ity pro vytvo�en� tabulky v datab�zi
    {
        public int ID { get; set; } // ID filmu je prim�rn� kl��

        [Required(ErrorMessage = "N�zev filmu je povinn�")]  // Required a Range (atributy) zaji��uj�, �e vstupn� data spl�uj� po�adavky
        [StringLength(60, MinimumLength = 2, ErrorMessage = "D�lka n�zvu filmu mus� b�t v rozmez� 2 - 60 znak�")]
        [Display(Name = "N�zev filmu")]  // Zm�na n�zvu sloupce v tabulce
        public string Title { get; set; } 
        
        [Required(ErrorMessage = "Rok vyd�n� filmu je povinn�")]
        [Range(1900, 2025, ErrorMessage = "Rok vyd�n� filmu mus� b�t mezi 1900 a 2025")]
        [Display(Name = "Rok vyd�n�")]  // Zm�na n�zvu sloupce v tabulce
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "��nr filmu je povinn�")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "��nr filmu mus� b�t v rozmez� 3 a 30 znaky")]
        [Display(Name = "��nr filmu")]  // Zm�na n�zvu sloupce v tabulce
        public string Genre { get; set; }

        [Required(ErrorMessage = "Hodnocen� filmu je povinn�")]
        [Range(1, 10, ErrorMessage = "Hodnocen� filmu mus� b�t v rozmez� 1 a 10")]
        [Display(Name = "Hodnocen� filmu")]  // Zm�na n�zvu sloupce v tabulce
        public int Rating { get; set; }
    }
}
