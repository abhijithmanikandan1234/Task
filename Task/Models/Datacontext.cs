using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Task.Models
{
    public class Datacontext :DbContext
    {
        public DbSet<Department> departments { get; set; }

        public DbSet<Product> products { get; set; }    
    }
}