using CabinetVeterinar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CabinetVeterinar.Controllers
{
    public class CalendarController : Controller
    {
        CabinetVeterinar.Models.DataContext db = new DataContext();
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["Id_utilizator"].ToString());
            CabinetVeterinar.Models.Utilizator user = db.Utilizatori.Where(u => u.Id_utilizator == id).First();
            var clienti = db.Utilizatori.Where(c => c.Rol=="CLIENT").OrderBy(r => r.Nume);
            foreach(var client in clienti)
            {
                client.Animale = db.Animale.Where(a => a.Id_utilizator == client.Id_utilizator).ToList();
            }
            SelectList listaClienti = new SelectList(clienti, "Id_utilizator", "Nume");
            ViewBag.ListaClienti = listaClienti;
            return View(user);
        }
        public JsonResult GetProgramari(int idVet)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var events = db.Programari.Where(p => p.Id_veterinar == idVet).ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };           
        }

        

        [HttpPost]
        public JsonResult SalveazaProgramare(Programare e)
        {
            var status = false;
           
                if (e.Id_programare > 0)
                {
                    var v = db.Programari.Where(a => a.Id_programare == e.Id_programare).FirstOrDefault();
                    if (v != null)
                    {
                        v.Id_utilizator = e.Id_utilizator;
                        v.Id_veterinar = e.Id_veterinar;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Descriere = e.Descriere;
                    }
                }
                else
                {
                    db.Programari.Add(e);
                }
                db.SaveChanges();
                status = true;
            
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult StergereProgramare(int eventID)
        {
            var status = false;
          
                var v = db.Programari.Where(a => a.Id_programare == eventID).FirstOrDefault();
                if (v != null)
                {
                    db.Programari.Remove(v);
                    db.SaveChanges();
                    status = true;
                }          
            return new JsonResult { Data = new { status = status } };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}