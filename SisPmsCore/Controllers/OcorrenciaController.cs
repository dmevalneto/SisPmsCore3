using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisPmsCore.Models;

namespace SisPmsCore.Controllers
{
    public class OcorrenciaController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;
        public OcorrenciaController(IHttpContextAccessor httpContextAcessor)
        {
            HttpContextAccessor = httpContextAcessor;
        }

        public IActionResult Index()
        {
            ViewBag.ListaOcorrencia = new Ocorrencia(HttpContextAccessor).ListaOcorrencia();
            return View();
        }

        [HttpGet]
        public IActionResult NovoRegistro()
        {
            return View();
        }


        [HttpPost]
        public IActionResult NovoRegistro(Ocorrencia formulario)
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