using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COVID_19.Models
{
    public class Case
    {
        public int ID { get; set; }
        public int CountryID { get; set; }

        public long Confirmed { get; set; }

        public long Deaths { get; set; }

        public long Recovered { get; set; }

        public long Active { get; set; }

        public DateTime Date { get; set; }

        public virtual Country Country { get; set; }
    }
}