using CabinetVeterinar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CabinetVeterinar.Controllers
{
    public class ClientController : Controller
    {
        DataContext DB = new DataContext();
        public ActionResult Index()
        {
            int id_utilizator = Convert.ToInt32(Session["Id_Utilizator"]);
            Utilizator u = DB.Utilizatori.Where(U => U.Id_utilizator == id_utilizator).FirstOrDefault();
            u.Animale = DB.Animale.Where(a => a.Id_utilizator == id_utilizator).ToList();

            return View(u);
        }

        public ActionResult IstoricFise(int id)
        {
            List<Fisa> lista = DB.Fise.Where(f => f.Id_Animal == id).ToList();
            return View(lista);
        }
    }
}