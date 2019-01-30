using System.Collections.Generic;
using B03.EE.SchuermansEva.Lib.DTO;
using B03.EE.SchuermansEva.MVC.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace B03.EE.SchuermansEva.MVC.Controllers
{
    public class UsersController : Controller
    {
        //string baseuri = "https://localhost:44335/api/users";
        //public IActionResult Index()
        //{
        //    string uri = $"{baseuri}/basic";
        //    return View(WebApiHelper.GetApiResult<List<UserBasic>>(uri));
        //}

        public IActionResult IndexVue()
        {
            return View();
        }
    }
}                                                    