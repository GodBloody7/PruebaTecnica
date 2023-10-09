using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRUEBAUS.EntidadesDeNegocio;
using PRUEBAUS.LogicaDeNegocio;

namespace PRUEBAUS.InterfazGraficaMVC.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class PlantaController : Controller
    {
        PlantaBL plantaBL = new PlantaBL();
        CategoriaBL categoriaBL = new CategoriaBL();

        // GET: PlantaController
        public async Task<IActionResult> Index(Planta pPlanta = null)
        {
            if (pPlanta == null)
                pPlanta = new Planta();

            if (pPlanta.top_aux == 0)
                pPlanta.top_aux = 10;

            else if (pPlanta.top_aux == -1)
                pPlanta.top_aux = 0;

            var plantas = await plantaBL.BuscarIncluirCategoriaAsync(pPlanta);
            var categorias = await categoriaBL.ObtenerTodosAsync();

            ViewBag.Top = pPlanta.top_aux;
            ViewBag.Categorias = categorias;
            return View(plantas);
        }


        // GET: PlantaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var planta = await plantaBL.ObtenerPorIdAsync(new Planta { Id = id });
            planta.Categoria = await categoriaBL.ObtenerPorIdAsync(new Categoria { Id = planta.CategoriaId });
            return View(planta);
        }

        // GET: PlantaController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categorias = await categoriaBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // POST: PlantaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Planta pPlanta)
        {
            try
            {
                int result = await plantaBL.CrearAsync(pPlanta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Categorias = await categoriaBL.ObtenerTodosAsync();
                return View(pPlanta);
            }
        }







        // GET: PlantaController/Edit/5
        public async Task<IActionResult> Edit(Planta pPlanta)
        {
            var planta = await plantaBL.ObtenerPorIdAsync(pPlanta);
            var categorias = await categoriaBL.ObtenerTodosAsync();

            ViewBag.Categorias = categorias;
            ViewBag.Error = "";
            return View(planta);
        }

        // POST: PlantaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Planta pPlanta)
        {
            try
            {
                int result = await plantaBL.ModificarAsync(pPlanta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Categorias = await categoriaBL.ObtenerTodosAsync();
                return View();
            }
        }

        // GET: PlantaController/Delete/5
        public async Task<IActionResult> Delete(Planta pPlanta)
        {
            var planta = await plantaBL.ObtenerPorIdAsync(pPlanta);
            planta.Categoria = await categoriaBL.ObtenerPorIdAsync(new Categoria { Id = planta.CategoriaId });
            ViewBag.Error = "";
            return View(planta);
        }

        // POST: PlantaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Planta pPlanta)
        {
            try
            {
                int result = await plantaBL.EliminarAsync(pPlanta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var planta = await plantaBL.ObtenerPorIdAsync(pPlanta);
                if (planta == null)
                    planta = new Planta();

                if (planta.Id > 0)
                    planta.Categoria = await categoriaBL.ObtenerPorIdAsync(new Categoria { Id = planta.CategoriaId });
                return View(planta);
            }
        }
    }
}
