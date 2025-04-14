using MascotasASP.IServices;
using MascotasASP.Services;
using Microsoft.AspNetCore.Mvc;

namespace MascotasASP.Controllers
{
    public class ReportesController : Controller
    {
        private readonly IReporte _reporte;
        public ReportesController(IReporte reporte)
        {
            _reporte = reporte;
        }



        #region "Mostrar"

        // GET: DueñosController1
        public async Task<IActionResult> Index()
        {
            var reporte = await _reporte.GetallReportes();
            return View(reporte);
        }

        #endregion
    }
}
