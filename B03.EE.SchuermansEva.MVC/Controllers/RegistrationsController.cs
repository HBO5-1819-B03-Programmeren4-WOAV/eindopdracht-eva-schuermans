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
        List<User> participants = new List<User>();
        List<Activity> activitiesForUser = new List<Activity>();

        public IActionResult IndexVue()
        {
            return View();
        }

        public IActionResult Index()
        {
            string uriActvities = $"{baseuri}/activities";
            string uriUsers = $"{baseuri}/users";
            RegistrationIndexViewModel vm = new RegistrationIndexViewModel();
            vm.Activities = WebApiHelper.GetApiResult<List<Activity>>(uriActvities); 
            vm.Users = WebApiHelper.GetApiResult<List<User>>(uriUsers);
            return View(vm);
        }

        public IActionResult DetailActivity(int id)
        {
            string uriRegistrations = $"{baseuri}/registrations";   
            string uriActivities = $"{baseuri}/activities/{id}";
            RegistrationDetailActivityViewModel vm = new RegistrationDetailActivityViewModel();
            vm.Registrations = WebApiHelper.GetApiResult<List<Registration>>(uriRegistrations);
            vm.Activity = WebApiHelper.GetApiResult<Activity>(uriActivities);
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

        public IActionResult DetailUser(int id)
        {
            string uriRegistrations = $"{baseuri}/registrations";
            string uriUser = $"{baseuri}/users/{id}";
            RegistrationDetailUserViewModel vm = new RegistrationDetailUserViewModel();
            vm.Registrations = WebApiHelper.GetApiResult<List<Registration>>(uriRegistrations);
            vm.User = WebApiHelper.GetApiResult<User>(uriUser);
            try
            {
                foreach (Registration reg in vm.Registrations)
                {
                    if (reg.UserId == id)
                    {
                        activitiesForUser.Add(reg.Activity);
                    }
                }
                vm.ActivitiesForUser = activitiesForUser;
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
    }
}