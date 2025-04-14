using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MascotasASP.IServices;
using MascotasASP.DTOs;

namespace MascotasASP.Controllers
{
    public class DueñosController : Controller
    {
        //inyeccion de dependencias 
        private readonly IDueño _dueñoService;

        public DueñosController(IDueño dueñoService)
        {
            _dueñoService = dueñoService;
        }

        #region "Mostrar"

        // GET: DueñosController1
        public async Task<IActionResult> Index()
        {
            var dueños = await _dueñoService.GetallDueño();
            return View(dueños);
        }

        #endregion

        #region "Detalles"
        public async Task<IActionResult> Details(int id)
        {

            var dueños = await _dueñoService.GetByIdDueño(id);

            if (dueños == null)
            {
                TempData["ErrorMessage"] = "Dueño no existe.";
                return RedirectToAction("Index");
            }


            return View(dueños); // Muestra la vista de detalles
            
        }

        #endregion

        #region "agregar dueño"
        // GET: DueñosController1/Create
        public async Task<IActionResult> Create()
        {
            DueñoDTO dueñoDTO = new DueñoDTO();
            return View(dueñoDTO);
        }

        // POST: DueñosController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(DueñoDTO dueñoDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dueñoService.AddDueño(dueñoDTO);
                    TempData["SuccessMessage"] = "Dueño agregado exitosamente";
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

        #region "Actualizar"

        public async Task<IActionResult> Edit(int id)
        {
            DueñoDTO dueñoDTO = await _dueñoService.GetByIdDueño(id);
            if (dueñoDTO == null)
            {
                TempData["ErrorMessage"] = "Dueño no encontrado.";
                return RedirectToAction("Index");
            }

            return View(dueñoDTO);
        }

        // Acción para procesar el formulario de edición de producto
        [HttpPost]
        public async Task<IActionResult> Edit(DueñoDTO dueñoDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dueñoService.UpdateAsync(dueñoDTO);
                    TempData["SuccessMessage"] = "dueño actualizado exitosamente.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Hubo un error al actualizar el dueño.";
            }


            return View(dueñoDTO);
        }





        #endregion

        #region "Eliminar"
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var product = await _dueñoService.GetByIdDueño(id);

            if (product == null)
            {
                TempData["ErrorMessage"] = "El dueño no existe.";
                return RedirectToAction("Index");
            }

            return View(product); // Muestra la vista de confirmación
        }

        // Acción para eliminar un producto
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _dueñoService.DeleteDueño(id);
                TempData["SuccessMessage"] = "Dueño eliminado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Hubo un error al eliminar el dueño.";
            }

            return RedirectToAction("Index");
        }


        #endregion

        
    }
}
