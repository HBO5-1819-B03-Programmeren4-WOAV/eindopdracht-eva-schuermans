using System;

namespace B03.EE.SchuermansEva.Lib.Models
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        private DateTime? created;
        public DateTime? Created
        {
            get
            {
                return created ?? DateTime.Now;
            }

            set { created = value; }
        }
    }
}
