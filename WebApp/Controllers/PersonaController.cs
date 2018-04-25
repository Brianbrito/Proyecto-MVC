using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona 
        public ActionResult Index()
        {
            WebAppDbContext db = new WebAppDbContext();
            return View(db.Personas.ToList());
        }
    

      public ActionResult Agregar()
       {            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       public ActionResult Agregar(Persona persona)
       {            if(!ModelState.IsValid)
                return View();

            try
           {
               using (var db = new WebAppDbContext())
                {
             
                   db.Personas.Add(persona);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

              ModelState.AddModelError("Error al agragar ", ex);
                return View();
            }
 }

        public ActionResult Editar(int Id)
        {
            try
            {
                using (var db = new WebAppDbContext())
                {
                    Persona p = db.Personas.Find(Id);
                    return View(p);
                }

            }
            catch (Exception)
            {

                throw;
            }
       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Persona p)
        {
            try
            {

                if (!ModelState.IsValid)
                    return View();
                using (var db = new WebAppDbContext())
                {
                    Persona persona = db.Personas.Find(p.Id);
                    persona.Nombre = p.Nombre;
                    persona.Apellido = p.Apellido;
                    persona.Genero = p.Genero;

                    db.SaveChanges();

                    return RedirectToAction("Index");

                }

            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        public ActionResult DetallePersona(int Id)
        {
            using (var db = new WebAppDbContext())
            {
                Persona p = db.Personas.Find(Id);
                return View(p);
            }
        }
         
        public ActionResult EliminarPersona(int Id)
        {
            using (var db = new WebAppDbContext())
            {
                Persona p = db.Personas.Find(Id);
                db.Personas.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}