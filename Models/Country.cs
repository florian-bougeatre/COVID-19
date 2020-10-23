using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COVID_19.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public char[] Code { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}