using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisPmsCore.Models;

namespace SisPmsCore.Controllers
{
    public class CargoController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;
        public CargoController(IHttpContextAccessor httpContextAcessor)
        {
            HttpContextAccessor = httpContextAcessor;
        }


        public IActionResult Index()
        {
            Cargo objCargo = new Cargo(HttpContextAccessor);
            ViewBag.ListaCargo = objCargo.ListaCargo();
            return View();
        }

        [HttpGet]
        public IActionResult NovoRegistro()
        {
            return View();
        }


        [HttpPost]
        public IActionResult NovoRegistro(Cargo formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.SalvarNovoRegistro();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}