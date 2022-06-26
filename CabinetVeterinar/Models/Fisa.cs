using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CabinetVeterinar.Models
{
    public class Fisa
    {
        [Key]
        public int Id_Fisa { get; set; }
        public int Id_Veterinar { get; set; }
        public int Id_Client { get; set; }
        public int Id_Animal { get; set; }
        public virtual Animal Animal { get; set; }
        public string Numar_Fisa { get; set; }
        public Boolean Vaccinat { get; set; }
        [Display(Name="Produs vaccin")]
        public string Produs_Vaccin { get; set; }
        public Boolean Deparazitat_Intern { get; set; }
        [Display(Name = "Produs deparazitare interna")]
        public string Produs_DeparazitareI { get; set; }
        public Boolean Deparazitat_Extern { get; set; }
        [Display(Name = "Produs deparazitare externa")]
        public string Produs_DeparazitareE { get; set; }
        public string Observatii { get; set; }


    }
}