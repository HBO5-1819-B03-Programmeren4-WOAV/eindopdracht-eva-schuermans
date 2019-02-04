using System.Collections.Generic;
using B03.EE.SchuermansEva.Lib.DTO;
using B03.EE.SchuermansEva.MVC.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace B03.EE.SchuermansEva.MVC.Controllers
{
    public class UsersController : Controller
    {  
        public IActionResult IndexVue()
        {
            return View();
        }
    }
}                                                    