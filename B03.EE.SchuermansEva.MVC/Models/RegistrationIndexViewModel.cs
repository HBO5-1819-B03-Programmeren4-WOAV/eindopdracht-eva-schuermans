using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B03.EE.SchuermansEva.Lib.Models;

namespace B03.EE.SchuermansEva.MVC.Models
{
    public class RegistrationIndexViewModel
    {
        public List<Activity> Activities { get; set; }
        public List<Registration> Registrations { get; set; }
        public List<User> Participants { get; set; }   
    }
}
