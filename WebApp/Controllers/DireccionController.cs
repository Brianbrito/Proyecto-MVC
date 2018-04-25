using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DireccionController : Controller
    {
        // GET: Direccion
        public ActionResult Index()
        {
            WebAppDbContext db = new WebAppDbContext();
            return View(db.Direccions.ToList());
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Direccion direccion)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new WebAppDbContext())
                {
                  

                    db.Direccions.Add(direccion);
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
                   Direccion d = db.Direccions.Find(Id);
                    return View(d);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Direccion d)
        {
            try
            {

                if (!ModelState.IsValid)
                    return View();
                using (var db = new WebAppDbContext())
                {
                    Direccion direccion = db.Direccions.Find(d.Id);
                    direccion.Sector = d.Sector;
                    direccion.Calle = d.Calle;
                    direccion.PersonaId= d.PersonaId;

                    db.SaveChanges();

                    return RedirectToAction("Index");

                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public ActionResult DetalleDireccion(int Id)
        {
            using (var db = new WebAppDbContext())
            {
                Direccion direccion = db.Direccions.Find(Id);
                return View(direccion);
            }
        }
        public ActionResult EliminarDireccion(int Id)
        {
            using (var db = new WebAppDbContext())
            {
                Direccion direccion = db.Direccions.Find(Id);
                db.Direccions.Remove(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}