using MascotasASP.DTOs;
using MascotasASP.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MascotasASP.Controllers
{
    public class MascotaController : Controller
    {

        // hacemos la inyeccion dependencias
        private readonly IMascotas _mascotas;
        private readonly IDueño _dueño;
        private readonly IMetroscuadrados _metroscuadrados;


        public MascotaController(IMascotas mascotas, IDueño dueño, IMetroscuadrados metroscuadrados)
        {
            _mascotas = mascotas;
            _dueño = dueño;
            _metroscuadrados = metroscuadrados;
        }

        #region "Mostrar"

        public async Task<IActionResult> Index()
        {
            var mascotas = await _mascotas.GetallMascota();
            return View(mascotas);
        }

        #endregion

        #region "Crear"
        public async Task<IActionResult> Create()
        {

            MascotaDTO mascotaDTO = new MascotaDTO();

            var categoriasDueño = await _dueño.GetallDueño();
            ViewBag.Duenos = new SelectList(categoriasDueño, "Id", "Nombre");

            var categoriaMetros = await _metroscuadrados.GetallMetros();
            ViewBag.Metros = new SelectList(categoriaMetros, "Id", "Metros");

            return View(mascotaDTO);
        }


        [HttpPost]
        public async Task<IActionResult> Create(MascotaDTO mascotaDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mascotas.AddMascota(mascotaDTO);
                    TempData["SuccessMessage"] = "Mascota agregado exitosamente";
                    return RedirectToAction("Index");
                }
            }

            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Hubo un error al agregar la Mascota";
            }
            var categoriasDueño = await _dueño.GetallDueño();
            ViewBag.Duenos = new SelectList(categoriasDueño, "Id", "Nombre");

            var categoriaMetros = await _metroscuadrados.GetallMetros();
            ViewBag.Metros = new SelectList(categoriaMetros, "Id", "Metros");
            return View(mascotaDTO);
        }

        #endregion

        #region "Detalles"
        public async Task<IActionResult> Details(int id)
        {

            var mascota = await _mascotas.GetByIdMascota(id);

            if (mascota == null)
            {
                TempData["ErrorMessage"] = "Mascota no existe.";
                return RedirectToAction("Index");
            }

            return View(mascota); // Muestra la vista de detalles

        }

        #endregion

        #region "Actualizar"

        public async Task<IActionResult> Edit(int id)
        {
            MascotaDTO mascotaDTO = await _mascotas.GetByIdMascota(id);
            if (mascotaDTO == null)
            {
                TempData["ErrorMessage"] = "Mascota no encontrado.";
                return RedirectToAction("Index");
            }

            return View(mascotaDTO);
        }

        // Acción para procesar el formulario de edición de producto
        [HttpPost]
        public async Task<IActionResult> Edit(MascotaDTO mascotaDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mascotas.UpdateMascota(mascotaDTO);
                    TempData["SuccessMessage"] = "Mascota actualizado exitosamente.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Hubo un error al actualizar los mascota.";
            }
            return View(mascotaDTO);
        }

        #endregion




    }
}
