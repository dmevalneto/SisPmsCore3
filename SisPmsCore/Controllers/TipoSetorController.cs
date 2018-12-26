using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisPmsCore.Models;

namespace SisPmsCore.Controllers
{
    public class TipoSetorController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;
        public TipoSetorController(IHttpContextAccessor httpContextAcessor)
        {
            HttpContextAccessor = httpContextAcessor;
        }
        
        public IActionResult Index()
        {
            TipoSetor objTipoSetor = new TipoSetor(HttpContextAccessor);
            ViewBag.ListaTipoSetor = objTipoSetor.ListaTipoSetor();
            return View();
        }

        [HttpGet]
        public IActionResult NovoRegistro()
        {
            return View();
        }


        [HttpPost]
        public IActionResult NovoRegistro(TipoSetor formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.SalvarNovoRegistro();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            TipoSetor objTipoSetor = new TipoSetor(HttpContextAccessor);
            objTipoSetor.Delete(id);
            return RedirectToAction("Index");
        }


    }
}