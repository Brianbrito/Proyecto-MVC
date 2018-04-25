using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        [Required]
        public string Sector { get; set; }
        [Required]
        public string Calle { get; set; }
        public Persona Persona { get; set; }
        public int PersonaId { get; set; }
}
}