using System;
using System.Collections.Generic;
using System.Text;

namespace B03.EE.SchuermansEva.Lib.Models
{
    public class Registration : EntityBase
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
