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

    
    } // fin controller
} // fin namespace
