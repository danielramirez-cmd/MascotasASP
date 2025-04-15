using Microsoft.AspNetCore.Mvc;
using MascotasASP.IServices;
using MascotasASP.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MascotasASP.Controllers
{
    public class AsignacionController : Controller
    {

        private readonly IMascotas _mascotas;
        private readonly IHorarios _horarios;
        private readonly IAsignacion _asignacion;

        public AsignacionController(IMascotas mascotas, IHorarios horarios, IAsignacion asignacion)
        {
            _mascotas = mascotas;
            _horarios = horarios;
            _asignacion = asignacion;
        }

        #region "Mostrar"

        public async Task<IActionResult> Index()
        {
            var Asignacion = await _asignacion.GetallAsignacion();
            return View(Asignacion);
        }

        #endregion

        #region "Crear"
        public async Task<IActionResult> Create()
        {
            AsignacionDTO asignacionDTO = new AsignacionDTO();

            // Obtener la lista de mascotas y horarios
            var categoriasMascota = await _mascotas.GetallMascota();
            ViewBag.Mascota = new SelectList(categoriasMascota, "Id", "Nombre");

            var categoriaHorarios = await _horarios.GetallHorarios();
            ViewBag.Horario = new SelectList(categoriaHorarios, "Id", "HoraInicio"); // Asegúrate de que "HoraInicio" sea correcto

            return View(asignacionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AsignacionDTO asignacionDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _asignacion.AddAsignacion(asignacionDTO);
                    TempData["SuccessMessage"] = "Asignación agregada exitosamente";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "Hubo un error al agregar la Asignación";
            }

            // Reasignar los datos de ViewBag en caso de error
            var categoriasMascota = await _mascotas.GetallMascota();
            ViewBag.Mascota = new SelectList(categoriasMascota, "Id", "Nombre");

            var categoriaHorario = await _horarios.GetallHorarios();
            ViewBag.Horario = new SelectList(categoriaHorario, "Id", "HoraInicio"); // Asegúrate de que "HoraInicio" sea correcto

            return View(asignacionDTO);
        }



        #endregion


    } // fin controller
} // fin namespace
