using Biblioteca.Core.Enums;

namespace Biblioteca.Core.Entities
{
    public class Libro
    {

        public Libro()
        {
            Estado = Estado.DISPONIBLE;
            Prestamos = new List<Prestamo>();
        }


        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaDePublicacion { set; get; }

        public TipoDeLibro Tipo { get; set; }

        public Estado Estado { get; set; }


        public List<Prestamo> Prestamos { get; set; }

    }
}