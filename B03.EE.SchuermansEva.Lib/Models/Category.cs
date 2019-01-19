using System;           
using System.Collections.Generic;
using Newtonsoft.Json;

namespace B03.EE.SchuermansEva.Lib.Models
{
    public class Category : EntityBase
    {
        public List<string> CategoryNames
        {
            get
            {
                return new List<string> {"None", "Crafts", "Culinary", "Culture", "Sports", "Wellness" };
            }
        }
        public string CategoryName { get; set; }            

        [JsonIgnore]
        public ICollection<Activity> Activities { get; set; }
    }                                                              
}
