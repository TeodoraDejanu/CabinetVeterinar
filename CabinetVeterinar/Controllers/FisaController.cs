using CabinetVeterinar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CabinetVeterinar.Controllers
{
    public class FisaController : Controller
    {
        DataContext DB = new DataContext();
        public ActionResult Index()
        {
            int id_veterinar = Convert.ToInt32(Session["Id_Veterinar"]);
            DateTime startOfDay = DateTime.Today.AddDays(2).Date;
            DateTime endOfDay = startOfDay.AddDays(1);         
            List<Programare> programari = DB.Programari.Where(p => p.Id_veterinar == id_veterinar && p.Start >= startOfDay && p.End < endOfDay).ToList();
            foreach(var p in programari)
            {
                p.Client = DB.Utilizatori.Where(U => U.Id_utilizator == p.Id_utilizator).FirstOrDefault();
            }

            return View(programari);
        }

        public ActionResult Detalii(int id)
        {
            Fisa fisa = new Fisa();
            Programare prg = DB.Programari.Where(p => p.Id_programare == id).FirstOrDefault();
            fisa.Id_Client = prg.Id_utilizator;
            fisa.Id_Veterinar = prg.Id_veterinar;
            var animale = DB.Animale.Where(a => a.Id_utilizator == prg.Id_utilizator );
            SelectList listaAnimale = new SelectList(animale, "Id_animal", "Nume");
            ViewBag.ListaAnimaleDetinute = listaAnimale;
            return View(fisa);
        }
        [HttpPost]
        public ActionResult Detalii(Fisa fisa)
        {
            DB.Fise.Add(fisa);
            DB.SaveChanges();
            return RedirectToAction("Index", "Fisa");
        }

        public JsonResult GetDateAnimal(int idAnimal)
        {

            Animal animal = DB.Animale.Where(a => a.Id_animal == idAnimal).FirstOrDefault();
            animal.DenCategorie = DB.Categorii.Where(c => c.Id_categorie == animal.Id_categorie).FirstOrDefault().DescriereCategorie;
            return Json(new
            {
                Nume = animal.Nume,
                Greutate = animal.Greutate,
                DenCategorie = animal.DenCategorie,
                Varsta = animal.Varsta,
                Rasa = animal.Rasa,
                Gen = animal.Gen,
                Id_Utilizator = animal.Id_utilizator,
                Id_Categorie = animal.Id_categorie,
                Id_Animal = animal.Id_animal

        }, JsonRequestBehavior.AllowGet);
        }

    }
}