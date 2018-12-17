using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisPmsCore.Models;

namespace SisPmsCore.Controllers
{
    public class UsuarioController : Controller
    { 
        public IActionResult Login(int? id)
        {
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult ValidarLogin(Usuario usuario)
        {
            bool login = usuario.Validarlogin();
            if (login)
            {
                HttpContext.Session.SetString("NomeUsuarioLogado", usuario.Nome);
                HttpContext.Session.SetString("IdUsuarioLogado", usuario.IdUsuario.ToString());
                return RedirectToAction("Menu", "Home");
            }
            else
            {
                TempData["MensagemLoginInvalido"] = "Dados de login inválidos!";
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.RegistrarUsuario();
                return RedirectToAction("Sucesso");
            }
            return View();
        }

        public IActionResult Sucesso()
        {
            return View();
        }
    }
}