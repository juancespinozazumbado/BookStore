using System.ComponentModel.DataAnnotations;

namespace Biblioteca.web.Models.Entidades
{
    public class Prestamo
    {
        [Key]
        public int Identificacion { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Apellidos { get; set;}

        public string NombreCompleto => Nombre + " " + Apellidos;

        [Required]
        [DataType(DataType.Date)]
        public string FechaDeDevolucion{ get; set; }
    }
}
