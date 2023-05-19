using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.web.Models
{
    public enum Estado 
    {
        [Display(Name = " Disponible")]
        Disponible = 1,

        [Display(Name = " En Prestamo")]
        Prestado = 2
    }
}
