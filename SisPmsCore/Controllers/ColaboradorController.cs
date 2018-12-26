using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisPmsCore.Models;

namespace SisPmsCore.Controllers
{
    public class ColaboradorController : Controller
    {

        IHttpContextAccessor HttpContextAccessor;
        public ColaboradorController(IHttpContextAccessor httpContextAcessor)
        {
            HttpContextAccessor = httpContextAcessor;
        }


        public IActionResult Index()
        {
            ViewBag.ListaColaborador = new Colaborador(HttpContextAccessor).ListaColaborador();
            return View();
        }

        [HttpGet]
        public IActionResult NovoRegistro()
        {
            ViewBag.ListaSetor = new Setor(HttpContextAccessor).ListaSetor();
            ViewBag.ListaCargo = new Cargo(HttpContextAccessor).ListaCargo();
            ViewBag.ListaOcorrencia = new Ocorrencia(HttpContextAccessor).ListaOcorrencia();
            ViewBag.ListaPrestadoraServico = new PrestadoraServico(HttpContextAccessor).ListaPrestadoraServico();
            return View();
        }

        [HttpPost]
        public IActionResult NovoRegistro(Colaborador formulario)
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