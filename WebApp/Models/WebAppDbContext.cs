using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public partial class WebAppDbContext : DbContext
    {
        public WebAppDbContext()
            : base("name=WebAppDbContext")
        {
        }


        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
    }
}