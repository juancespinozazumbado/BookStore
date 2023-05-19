using Biblioteca.BL.Repositorios;
using Biblioteca.modelo.Entidades;
using Biblioteca.web.Models.Entidades;
using Biblioteca.web.Models.modelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Prestamo = Biblioteca.modelo.Entidades.Prestamo;

namespace Biblioteca.web.Controllers
{
    public class LibrosDisponiblesController : Controller
    {

        RepositorioDeLibros _RepositorioDeLibros;

        public LibrosDisponiblesController(IMemoryCache cache)
        {
            _RepositorioDeLibros = new RepositorioDeLibros(cache);
        }


        // GET: LibrosDisponiblesController/

        public ActionResult Index(string nombre)
        {
            if (nombre is null)
            {
                List<Libro> librosDisponibles = _RepositorioDeLibros.ObtenerLibrosDisponibles();
                return View(librosDisponibles);
            }else
            {
                List<Libro> libro = _RepositorioDeLibros.ObtenerLibroPorNombre(nombre);
                return View(libro);
            }
        }

        // GET: LibrosDisponiblesController/Details/5
        public ActionResult Details(int id)
        {

            Libro libro = _RepositorioDeLibros.ObtenerUnLibroPorId(id);
            return View(libro);
        }

        // GET: LibrosDisponiblesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibrosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LibroDTO libroDTO)
        {
            try
            {
                // mapeo
                Libro libro = new Libro();
                libro.Id = new Random().Next(1, 1000);
                libro.Nombre = libroDTO.Nombre;
                libro.Descripcion = libroDTO.Descripcion;
                libro.FechaDePublicacion = libroDTO.FechaDePublicacion;
                libro.Tipo = (modelo.Enums.TipoDeLibro)libroDTO.Tipo;



                _RepositorioDeLibros.AgregarLibro(libro);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: LibrosDisponiblesController/Edit/5

        public ActionResult Edit(int id)
        {
            Libro libro = _RepositorioDeLibros.ObtenerUnLibroPorId(id);
            LibroDTO libroAEditar = new LibroDTO();
            libroAEditar.Id = libro.Id;
            libroAEditar.Nombre = libro.Nombre;
            libroAEditar.FechaDePublicacion = libro.FechaDePublicacion;
            libroAEditar.Tipo = (Models.TipoDeLibro)libro.Tipo;
            libroAEditar.Descripcion = libro.Descripcion;

            return View(libroAEditar);
        }

        // POST: LibrosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LibroDTO libroDTO)
        {
            try
            {
                int id = libroDTO.Id;
                Libro? libro = _RepositorioDeLibros.ObtenerUnLibroPorId(id);
                libro.Id = libroDTO.Id;
                libro.Nombre = libroDTO.Nombre;
                libro.Descripcion = libroDTO.Descripcion;
                libro.FechaDePublicacion = libroDTO.FechaDePublicacion;
                libro.Tipo = (modelo.Enums.TipoDeLibro)libroDTO.Tipo;


                _RepositorioDeLibros.EditarLibro(libro);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: LibrosDisponiblesController/Delete/5
        public ActionResult Delete(int id)
        {
            Libro libro = _RepositorioDeLibros.ObtenerUnLibroPorId(id);
            return View(libro);
        }

        // POST: LibrosController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLibro(int id)
        {
            try
            {
                Libro libro = _RepositorioDeLibros.ObtenerUnLibroPorId(id);
                _RepositorioDeLibros.EliminarUnLibro(libro);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: LibrosController/Prestamo/
        public ActionResult Prestamo(int id)
        {
            Libro libro = _RepositorioDeLibros.ObtenerUnLibroPorId(id);
            PrestamoViewModel prestamoModel = new PrestamoViewModel();
            prestamoModel.Libro = libro;
            return View(prestamoModel);
        }

        //POST: LibrosController/Prestamo


        [HttpPost, ActionName("Prestamo")]
        [ValidateAntiForgeryToken]
        public ActionResult PrestarLibro(PrestamoViewModel prestamoModel)
        {
            try
            {
                int id = prestamoModel.Libro.Id;
                Libro libro = _RepositorioDeLibros.ObtenerUnLibroPorId(id);

                libro.Estado = modelo.Enums.Estado.PRESTADO;
                Prestamo prestamo = prestamoModel.Prestamo;
                libro.Prestamos.Add(prestamo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        //GET: LibrosCOntroller/Devolucion/7
        public ActionResult Devolucion(int id)
        {
            Libro libro = _RepositorioDeLibros.ObtenerUnLibroPorId(id);
            libro.Estado = modelo.Enums.Estado.DISPONIBLE;
            return RedirectToAction(nameof(Index));
        }

        //GET: LibrosCOntroller/PrestamosHistory/7
        public ActionResult PrestamosHistory(int id)
        {
            Libro libro = _RepositorioDeLibros.ObtenerUnLibroPorId(id);
            PrestamoViewModel viewData = new PrestamoViewModel();
            viewData.Libro = libro;
            return View(viewData);
        }

    }
}
