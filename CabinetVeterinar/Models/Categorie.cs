using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CabinetVeterinar.Models
{
    public class Categorie
    {
        [Key]
        public int Id_categorie { get; set; }
        public string DescriereCategorie { get; set; }
    }
}