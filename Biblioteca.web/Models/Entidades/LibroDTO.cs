using System.ComponentModel.DataAnnotations;

namespace Biblioteca.web.Models.Entidades
{
    public class LibroDTO
    {
        [Key]
        
        public int Id { get; set; }

        [Required (ErrorMessage ="El campo Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es requerida")]
        [MaxLength(50)]
        [MinLength(5)]
        public string Descripcion { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaDePublicacion { set; get; }

        [Required(ErrorMessage = "Debe seleccionar el tipo de libro")]
        public TipoDeLibro Tipo { get; set; }




  
    }
}
