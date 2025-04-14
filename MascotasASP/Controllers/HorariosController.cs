using Microsoft.AspNetCore.Mvc;
using MascotasASP.IServices;
using MascotasASP.DTOs;

namespace MascotasASP.Controllers
{
    public class HorariosController : Controller
    {
        // inyeccion de dependencias
        private readonly IHorarios _horarios;

        // constructor
        public HorariosController (IHorarios horarios)
        {
            _horarios = horarios;
        }

        #region "Mostrar"
        public async Task<IActionResult> Index()
        {
            var horarios = await _horarios.GetallHorarios();
            return View(horarios);
        }
        #endregion

        #region "agregar "
        // GET: DueñosController1/Create
        public async Task<IActionResult> Create()
        {
            HorariosDTO horariosDTO = new HorariosDTO();
            return View(horariosDTO);
        }

        // POST: DueñosController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(HorariosDTO horariosDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _horarios.AddHorarios(horariosDTO);
                    TempData["SuccessMessage"] = "Horario agregado exitosamente";
                    return RedirectToAction("Index");
                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el horario: " + ex.Message);
            }
            return View();

        }

        #endregion

        #region "Detalles"
        public async Task<IActionResult> Details(int id)
        {

            var horarios = await _horarios.GetByIdHorarios(id); // Obtiene el dueño por id

            if (horarios == null)
            {
                TempData["ErrorMessage"] = "Horario no existe.";
                return RedirectToAction("Index");
            }

            return View(horarios); // Muestra la vista de detalles

        }

        #endregion

        #region "Actualizar"

        public async Task<IActionResult> Edit(int id)
        {
            HorariosDTO horariosDTO = await _horarios.GetByIdHorarios(id); // Obtiene el dueño por id
            if (horariosDTO == null)
            {
                TempData["ErrorMessage"] = "Horarios no encontrado.";
                return RedirectToAction("Index");
            }

            return View(horariosDTO);
        }

        // Acción para procesar el formulario de edición de producto
        [HttpPost]
        public async Task<IActionResult> Edit(HorariosDTO horariosDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _horarios.UpdateHorarios(horariosDTO);
                    TempData["SuccessMessage"] = "Horarios actualizado exitosamente.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Hubo un error al actualizar los horarios.";
            }


            return View(horariosDTO);
        }





        #endregion

        #region "Eliminar"
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var horarios = await _horarios.GetByIdHorarios(id); // Obtiene el horario por id

            if (horarios == null)
            {
                TempData["ErrorMessage"] = "El Horario no existe.";
                return RedirectToAction("Index");
            }

            return View(horarios); // Muestra la vista de confirmación
        }

        // Acción para eliminar un producto
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _horarios.DeleteHorarios(id); // Llama al servicio para eliminar el horario
                TempData["SuccessMessage"] = "horario eliminado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Hubo un error al eliminar el horario.";
            }

            return RedirectToAction("Index");
        }


        #endregion







    }  // fin clase Horarios controller
} // fin namespace MascotasASP
