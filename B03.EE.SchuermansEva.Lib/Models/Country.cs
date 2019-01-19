using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace B03.EE.SchuermansEva.Lib.Models
{
    public class Country : EntityBase
    {
        public List<string> CountryNames
        {
            get
            {
                return new List<string> { "Austria", "Belgium", "Bulgaria", "Croatia", "Cyprus", "Czechia", "Denmark", "Estonia",
                    "Finland", "France", "Germany", "Greece", "Hungary", "Ireland", "Italy", "Latvia", "Lithuania", "Luxembourg",
                    "Malta", "Netherlands", "Poland", "Portugal", "Romania", "Slovakia", "Slovenia", "Spain", "Sweden", "United Kingdom"};                                                                                                                                          
            }
        }
        public string CountryName { get; set; }

        [JsonIgnore]
        public ICollection<Activity> Ativities { get; set; }
    }
}
