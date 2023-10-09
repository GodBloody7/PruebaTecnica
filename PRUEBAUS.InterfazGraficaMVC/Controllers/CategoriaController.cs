using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRUEBAUS.EntidadesDeNegocio;
using PRUEBAUS.LogicaDeNegocio;

namespace PRUEBAUS.InterfazGraficaMVC.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaBL categoriaBL = new CategoriaBL();

        // GET: Accion que muestra la pagina principal de categoria
        public async Task<IActionResult> Index(Categoria pCategoria = null)
        {
            if (pCategoria == null)
                pCategoria = new Categoria();
            if (pCategoria.top_aux == 0)
                pCategoria.top_aux = 10;
            else if (pCategoria.top_aux == -1)
                pCategoria.top_aux = 0;

            var categorias = await categoriaBL.BuscarAsync(pCategoria);
            ViewBag.Top = pCategoria.top_aux;

            return View(categorias);
        }

        // GET: Accion que muestra el detalle de un registro
        public async Task<IActionResult> Details(int id)
        {
            var categoria = await categoriaBL.ObtenerPorIdAsync(new Categoria { Id = id });
            return View(categoria);
        }

        // GET: Accion que muestra el formulario para crear una nueva categoria
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: Accion que recibe los datos del formulario y los envia a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria pCategoria)
        {
            try
            {
                int result = await categoriaBL.CrearAsync(pCategoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Accion que muestra el formulario con los datos cargados para modificarlos
        public async Task<IActionResult> Edit(Categoria pCategoria)
        {
            var categoria = await categoriaBL.ObtenerPorIdAsync(pCategoria);
            ViewBag.Error = "";
            return View(categoria);
        }

        // POST: Accion que recibe los datos modificados y los envia a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categoria pCategoria)
        {
            try
            {
                int result = await categoriaBL.ModificarAsync(pCategoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCategoria);
            }
        }

        // GET: Accion que muestra los datos del registro para confirmar la eliminacion
        public async Task<IActionResult> Delete(Categoria pCategoria)
        {
            var categoria = await categoriaBL.ObtenerPorIdAsync(pCategoria);
            ViewBag.Error = "";
            return View(categoria);
        }

        // POST: Accion que recibe la confirmacion para eliminar el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Categoria pCategoria)
        {
            try
            {
                int result = await categoriaBL.EliminarAsync(pCategoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCategoria);
            }
        }
    }
}
