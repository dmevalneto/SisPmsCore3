using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SisPmsCore.Areas.SetorPessoal.Controllers
{
    public class MenuController : Controller
    {
        [Area("SetorPessoal")]
        public IActionResult Index()
        {
            return View();
        }
    }
}