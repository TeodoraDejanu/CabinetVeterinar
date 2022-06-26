using CabinetVeterinar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CabinetVeterinar.Controllers
{
    public class HomeController : Controller
    {
        private DataContext Db = new DataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Autentificare()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Inregistrare()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SuccesInregistrare()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PrezentareVeterinari()
        {
            using(DataContext db = new DataContext())
            {
                List<Utilizator> Utilizatori = db.Utilizatori.Where(u => u.Rol == "VETERINAR").ToList();
                ViewBag.Utilizatori = Utilizatori;
               
            }
            return View();
        }
        public ActionResult PreluareImagine(int id)
        {
            byte[] poza = PreluareImagineDinBD(id);
            if(poza != null)
            {
                return File(poza, "image/jpg");
            }
            else
            {
                return null;
            }
        }
        public byte[] PreluareImagineDinBD(int id)
        {
            using (DataContext db = new DataContext())
            {
                var p = from u in db.Utilizatori where u.Id_utilizator == id select u.Poza;
                byte[] poza = p.First();
                return poza;
            }
        }
        [HttpPost]
        public ActionResult Autentificare(Utilizator user)
        {
            if (ModelState.IsValid)
            {
                using (DataContext Db = new DataContext())
                {
                    var obj = Db.Utilizatori.Where(u => u.Username == user.Username && u.Parola == user.Parola).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Id_utilizator"] = obj.Id_utilizator.ToString();
                        Session["Nume"] = obj.Nume.ToString();
                        if (obj.Rol.ToString() == "VETERINAR")
                            return RedirectToAction("Index", "Veterinar");
                        else if (obj.Rol.ToString() == "CLIENT")
                            return RedirectToAction("Index", "Client");
                        else if (obj.Rol.ToString() == "ADMIN")
                            return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        Session["MesajLogin"] = "Utilizatorul cu care incercati sa va logati la baza de date nu exista sau parola este gresita!";
                        return RedirectToAction("Index", "Eroare");
                    }
                
         
                }
            }

            return View();
        }
        [HttpPost]
        public ActionResult Inregistrare(Utilizator user)
        {
            if (ModelState.IsValid)
            {
                Db.Utilizatori.Add(user);
                Db.SaveChanges();
                return RedirectToAction("SuccesInregistrare");
            }
            else
            {
                ModelState.AddModelError("", "Exceptie");
            }
            return View(user);
        }
    }
}