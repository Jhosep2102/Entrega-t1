using ENTREGA_T1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ENTREGA_T1.Controllers
{
    public class EjerciciosController : Controller
    {
        [HttpGet]
        public IActionResult Llamada()
        {
            return View(new LlamadaViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Llamada(LlamadaViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Calcular();
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Gimnasio()
        {
            return View(new GimnasioViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Gimnasio(GimnasioViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Calcular();
            }

            return View(model);
        }
    }
}
