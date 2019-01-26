using System;
using System.Collections.Generic;   

namespace B03.EE.SchuermansEva.Lib.Models
{
    public class Activity : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
