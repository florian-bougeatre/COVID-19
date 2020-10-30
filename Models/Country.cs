using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COVID_19.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public string Code { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}