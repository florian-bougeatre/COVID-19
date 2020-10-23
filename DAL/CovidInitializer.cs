using COVID_19.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace COVID_19.DAL
{
    public class CovidInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CovidContext>
    {
        protected override void Seed(CovidContext context)
        {
            
        }
    }
}