using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using CabinetVeterinar.Models;

namespace CabinetVeterinar.Controllers
{
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {           
                List<Utilizator> utilizatori = db.Utilizatori.Where(x => x.Rol != "ADMIN").ToList();
                if (utilizatori.Count > 0)
                {
                    ViewBag.Utilizatori = utilizatori;

                }    
            return View();
        }
        public ActionResult AdaugaUtilizator()
        {
            var user = new Utilizator();
            user.Animale = new List<Animal>();
            user.Rol = "CLIENT";
            return View(user);
        }
        public ActionResult AdaugaVeterinar()
        {
            var user = new Utilizator();
            user.Rol = "VETERINAR";
            return View(user);
        }
        [HttpPost]
        public ActionResult AdaugaUtilizator(Utilizator user)
        {           
                if (ModelState.IsValid)
                {
                    user.Rol = "CLIENT";
                    db.Utilizatori.Add(user);
                    db.SaveChanges();
                    
                    List<Animal> animale = (List<Animal>)Session["Animale"];
                     foreach (var animal in animale)
                {
                    animal.Id_utilizator = user.Id_utilizator;
                    db.Animale.Add(animal);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
                else
                {
                    Session["MesajInregistrare"] = "Va rugam sa incercati din nou inregistrarea in clinica noastra";
                    return RedirectToAction("MesajInregistrare");
                }
            
        }

        [HttpPost]
        public ActionResult AdaugaVeterinar(Utilizator user)
        {
            
                HttpPostedFileBase fisier = Request.Files["PozaVeterinar"];
                var imagine = ConvertToBytes(fisier);
                if (ModelState.IsValid)
                {
                user.Rol = "VETERINAR";
                user.Poza = imagine;
                    db.Utilizatori.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    Session["MesajInregistrare"] = "Va rugam sa incercati din nou inregistrarea in clinica noastra";
                    return RedirectToAction("MesajInregistrare");
                }
            
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public async Task<ActionResult> GetCategorie(int? defaultEntityId)
        {
            var categ = (await db.Categorii.Where(i => i.Id_categorie != 0).ToArrayAsync()).OrderBy(r => r.DescriereCategorie);
            if (categ.Count() == 0)
            {
                string s = "intra aici";
            }
            return Json(new SelectList(categ, "Id_categorie", "DescriereCategorie", defaultEntityId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AdaugaAnimale(List<Animal> animale)
        {
            Session["Animale"] = animale;
            return Json("OK");
        }

        public PartialViewResult Edit(int id)
        {
            CabinetVeterinar.Models.Utilizator user = db.Utilizatori.Where(u => u.Id_utilizator == id).First();
            user.Animale= db.Animale.Where(a => a.Id_utilizator == id).ToList();
            foreach (Animal a in user.Animale)
            {
                a.DenCategorie = db.Categorii.Where(t => t.Id_categorie == a.Id_categorie).FirstOrDefault().DescriereCategorie;
            }
            Session["User"] = user;
            return PartialView(user);
        }

        [HttpPost]
        public ActionResult Edit(Utilizator u)
        {
            u.Rol = "CLIENT";
            db.Entry(u).State = EntityState.Modified;
            db.SaveChanges();

            List<Animal> animale = (List<Animal>)Session["Animale"];
            foreach (var animal in animale)
            {
                if (animal.Id_animal == 0)
                {
                    animal.Id_utilizator = u.Id_utilizator;
                    db.Animale.Add(animal);
                    db.SaveChanges();
                }
                else
                {
                    animal.Id_utilizator = u.Id_utilizator;
                    db.Entry(animal).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Index", "Admin");
        }


    }


}