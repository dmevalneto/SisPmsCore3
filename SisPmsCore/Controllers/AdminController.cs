using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisPmsCore.Models;

namespace SisPmsCore.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            List<Admin> lista = new Admin().RetornarDadosGragicoPie();

            string valores = "";
            string labels = "";
            string cores = "";
            var random = new Random();
            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].Total.ToString() + ",";
                labels += "'" + lista[i].Descricao.ToString() + "',";
                cores += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            }
            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;
            return View();
        }
    }
}