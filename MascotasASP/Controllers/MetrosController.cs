using MascotasASP.DTOs;
using MascotasASP.IServices;
using MascotasASP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MascotasASP.Controllers
{
    public class MetrosController : Controller
    {

        //inyeccion de dependencias 
        private readonly IMetroscuadrados _metros;


        public MetrosController(IMetroscuadrados metros)
        {
            _metros = metros;
        }

        #region "Mostrar"
        public async Task<IActionResult> Index()
        {
            var metros = await _metros.GetallMetros();
            return View(metros);
        }
        #endregion

        #region "agregar dueño"
        // GET: DueñosController1/Create
        public async Task<IActionResult> Create()
        {
            MetrosCuadradosDTO metrosCuadradosDTO = new MetrosCuadradosDTO();
            return View(metrosCuadradosDTO);
        }

        // POST: DueñosController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(MetrosCuadradosDTO metrosCuadradosDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                await _metros.AddMetros(metrosCuadradosDTO);
                    TempData["SuccessMessage"] = "Metros agregado exitosamente";
                    return RedirectToAction("Index");
                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el dueño: " + ex.Message);
            }
            return View();

        }

        #endregion

        #region "Detalles"
        public async Task<IActionResult> Details(int id)
        {

            var metros = await _metros.GetByIdMetros(id);

            if (metros == null)
            {
                TempData["ErrorMessage"] = "Metros no existe.";
                return RedirectToAction("Index");
            }

            return View(metros); // Muestra la vista de detalles

        }

        #endregion

        #region "Actualizar"

        public async Task<IActionResult> Edit(int id)
        {
            MetrosCuadradosDTO metrosCuadradosDTO = await _metros.GetByIdMetros(id);
            if (metrosCuadradosDTO == null)
            {
                TempData["ErrorMessage"] = "metros no encontrado.";
                return RedirectToAction("Index");
            }

            return View(metrosCuadradosDTO);
        }

        // Acción para procesar el formulario de edición de producto
        [HttpPost]
        public async Task<IActionResult> Edit(MetrosCuadradosDTO metrosCuadradosDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _metros.UpdateMetros(metrosCuadradosDTO);
                    TempData["SuccessMessage"] = "Metros actualizado exitosamente.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Hubo un error al actualizar los metros.";
            }


            return View(metrosCuadradosDTO);
        }





        #endregion

        #region "Eliminar"
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var metros = await _metros.GetByIdMetros(id);

            if (metros == null)
            {
                TempData["ErrorMessage"] = "El dueño no existe.";
                return RedirectToAction("Index");
            }

            return View(metros); // Muestra la vista de confirmación
        }

        // Acción para eliminar un producto
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _metros.DeleteMetros(id);
                TempData["SuccessMessage"] = "metros eliminado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Hubo un error al eliminar el metros.";
            }

            return RedirectToAction("Index");
        }


        #endregion


    }
}
