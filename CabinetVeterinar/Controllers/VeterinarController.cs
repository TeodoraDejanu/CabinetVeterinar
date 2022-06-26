using CabinetVeterinar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CabinetVeterinar.Controllers
{
    public class VeterinarController : Controller
    {
        public ActionResult Index()
        {
            CabinetVeterinar.Models.Utilizator veterinar;
            using(CabinetVeterinar.Models.DataContext db = new CabinetVeterinar.Models.DataContext())
            {
                int id_utilizator = Convert.ToInt32(Session["Id_utilizator"]);
                veterinar = db.Utilizatori.Where(u => u.Id_utilizator == id_utilizator).FirstOrDefault();
                Session["Id_Veterinar"] = id_utilizator;
            }
            return View(veterinar);
        }
        public ActionResult PreluareImagine(int id)
        {
            byte[] poza = PreluareImagineDinBD(id);
            if (poza != null)
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
    }
}