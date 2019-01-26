using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace B03.EE.SchuermansEva.Lib.Models
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

        [JsonIgnore]
        public ICollection<Registration> Registrations { get; set; }
                   
    }
}
