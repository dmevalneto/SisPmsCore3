using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisPmsCore.Models;

namespace SisPmsCore.Controllers
{
    public class PrestadoraServicoController : Controller
    {

        IHttpContextAccessor HttpContextAccessor;
        public PrestadoraServicoController(IHttpContextAccessor httpContextAcessor)
        {
            HttpContextAccessor = httpContextAcessor;
        }

        public IActionResult Index()
        {
            ViewBag.ListaPrestadoraServico = new PrestadoraServico(HttpContextAccessor).ListaPrestadoraServico();
            return View();
        }

        [HttpGet]
        public IActionResult NovoRegistro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NovoRegistro(PrestadoraServico formulario)
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