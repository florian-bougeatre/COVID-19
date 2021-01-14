using COVID_19.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace COVID_19.DAL
{
    public class CovidContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<Case> Cases { get; set; }

        public CovidContext() : base("CovidContext")
        {
        }
    }
}