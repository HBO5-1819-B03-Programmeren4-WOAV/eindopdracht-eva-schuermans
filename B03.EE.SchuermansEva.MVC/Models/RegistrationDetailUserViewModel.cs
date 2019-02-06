using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B03.EE.SchuermansEva.Lib.Models;

namespace B03.EE.SchuermansEva.MVC.Models
{
    public class RegistrationDetailUserViewModel
    {
        public List<Registration> Registrations { get; set; }
        public User User { get; set; }
        public List<Activity> ActivitiesForUser { get; set; }
    }
}
