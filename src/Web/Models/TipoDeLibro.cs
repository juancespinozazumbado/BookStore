using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Web.Models
{

    public enum TipoDeLibro
    {
        [Display (Name = "Cientificos")]
        CIENTIFICO,

        [Display(Name = "Literatura y Linguisticos")]
        LITERATURA_LINGUISTICO,

        [Display(Name = "Viajes")]
        VIAJE,

        [Display(Name = "Bobliografias")]
        BIOGRAFIA,

        [Display(Name = "Libro de Texto")]
        LIBRO_TEXTO
    }

}
