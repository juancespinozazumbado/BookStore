using Biblioteca.Core.Entities;
using Biblioteca.Core.Enums;

using Microsoft.Extensions.Caching.Memory;

namespace Biblioteca.Infraestructure.Persistence
{
    public class RepositorioDeLibros : IRepositorioDeLibros { 

        private List<Libro> _Libros;
        private IMemoryCache _Cache;

        public RepositorioDeLibros(IMemoryCache cache) 
        {
           _Cache= cache;
            configureElCache();

        }


        public void AgregarLibro(Libro libro)
        {
             
            _Libros.Add(libro);
           
        }

      

        public List<Libro> ObtenerLibros()
        {
            return _Libros;
        }

        public List<Libro> ObtenerLibrosDisponibles()
        {
            var librosPrestados = from libro in _Libros
                                  where libro.Estado == Estado.DISPONIBLE
                                  select libro;
            return (List<Libro>)librosPrestados.ToList();
        }

        public List<Libro> ObtenerLibrosPrestados()
        {
            var librosPrestados = from libro in _Libros
                                  where libro.Estado == Estado.PRESTADO  
                                  select libro;
            return (List<Libro>) librosPrestados.ToList();
        }

        public Libro? ObtenerUnLibroPorId(int id)
        {
           Libro? libro = _Libros.Find(lib => lib.Id == id);
            return libro;
        }

        public List<Libro> ObtenerLibroPorNombre(string nombre)
        {
            List<Libro> libros = _Libros.Where(lib => lib.Nombre.Equals(nombre)).ToList();
            return libros;
        }

        public void PrestarUnLibro(int id, Prestamo prestamo)
        {
            Libro? libro = ObtenerUnLibroPorId(id);
            if (libro != null && libro.Estado == Estado.DISPONIBLE)
            {

                libro.Estado = Estado.PRESTADO;
                libro.Prestamos.Add(prestamo);
            }
        }

        public void DevolverUnLibroPrestado(int id)
        {
            Libro? libro = ObtenerUnLibroPorId(id);
            if (libro != null && libro.Estado == Estado.PRESTADO)

                libro.Estado = Estado.DISPONIBLE;

        }


        private void configureElCache()
        {

            if (_Cache.Get("ListaDeLibros") is null)
                CargaElCache();
            else CargaLaListaDesdeElCache();

        }

        private void CargaElCache()
        {
            _Libros = new List<Libro>();
            _Cache.Set("ListaDeLibros", _Libros);
        }

        private void CargaLaListaDesdeElCache()
        {
            _Libros = new List<Libro>();
            _Libros = _Cache.Get("ListaDeLibros") as List<Libro>;

        }

        public void EditarLibro( Libro libro)
        {
            Libro libroAEditar = ObtenerUnLibroPorId(libro.Id);

            if (! (libroAEditar is null))
            
                libroAEditar = libro;
 

        }

        public void EliminarUnLibro(Libro libro)
        {
      
               _Libros.Remove(libro);
        }
    }
}
