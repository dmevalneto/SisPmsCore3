using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisPmsCore.Models;

namespace SisPmsCore.Controllers
{
    public class SetorController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;
        public SetorController(IHttpContextAccessor httpContextAcessor)
        {
            HttpContextAccessor = httpContextAcessor;
        }

        public IActionResult Index()
        {
            ViewBag.ListaTipoSetor = new TipoSetor(HttpContextAccessor).ListaTipoSetor();
            ViewBag.ListaSetor = new Setor(HttpContextAccessor).ListaSetor();
            return View();
            
        }

        [HttpGet]
        public IActionResult NovoRegistro()
        {
            ViewBag.ListaTipoSetor = new TipoSetor(HttpContextAccessor).ListaTipoSetor();
            return View();
        }

        [HttpPost]
        public IActionResult NovoRegistro(Setor formulario)
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