using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using B03.EE.SchuermansEva.MVC.Models;
using B03.EE.SchuermansEva.MVC.Helpers;
using B03.EE.SchuermansEva.Lib.Models;

namespace B03.EE.SchuermansEva.MVC.Controllers
{

    public class RegistrationsController : Controller
    {
        string baseuri = "https://localhost:44335/api/";
        List<User> participants;

        public IActionResult IndexVue()
        {
            return View();
        }

        public IActionResult Index()
        {
            string uri = $"{baseuri}/activities";
            RegistrationIndexViewModel vm = new RegistrationIndexViewModel();
            vm.Activities = WebApiHelper.GetApiResult<List<Activity>>(uri);
            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            string uri = $"{baseuri}/registrations";
            RegistrationIndexViewModel vm = new RegistrationIndexViewModel();
            vm.Registrations = WebApiHelper.GetApiResult<List<Registration>>(uri);
            try
            {
                foreach (Registration reg in vm.Registrations)
                {
                    if (reg.ActivityId == id)
                    {
                        participants.Add(reg.User);
                    }
                }
                vm.Participants = participants;
            }
            catch(Exception e)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
    }
}