using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace B03.EE.SchuermansEva.MVC.Controllers
{
    public class RegistrationsController : Controller
    {
        public IActionResult IndexVue()
        {
            return View();
        }
    }
}