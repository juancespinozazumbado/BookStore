using Biblioteca.Core.Entities;


namespace Biblioteca.Infraestructure.Persistence
{
    public interface IRepositorioDeLibros
    {
        public void AgregarLibro(Libro libro);

        public List<Libro> ObtenerLibros();

        public Libro? ObtenerUnLibroPorId(int id);

        public List<Libro> ObtenerLibroPorNombre(string nombre);

        public void EditarLibro(Libro libro);


        public void PrestarUnLibro(int id, Prestamo prestamo);

        public void DevolverUnLibroPrestado(int id);

        public List<Libro> ObtenerLibrosPrestados();

        public List<Libro> ObtenerLibrosDisponibles();

        public void EliminarUnLibro(Libro libro);



    }
}
