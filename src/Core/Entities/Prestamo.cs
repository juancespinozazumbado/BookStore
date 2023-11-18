namespace Biblioteca.Core.Entities
{
    public class Prestamo
    {
        public int Identificacion { set; get; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaDeDevolucion { set; get; }

        public string NombreCompleto => Nombre + " " + Apellidos;
    }
}
