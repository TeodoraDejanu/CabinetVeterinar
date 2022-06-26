using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CabinetVeterinar.Models
{
    public class Animal
    {
        [Key]
        public int Id_animal { get; set; }
        [Required]
        [Display(Name = "Nume")] 
        public string Nume { get; set; }
        public int Id_utilizator { get; set; }
        public virtual Utilizator utilizator { get; set; }
        public int Varsta { get; set; }
        public int Greutate { get; set; }
        public string Gen { get; set; }
        public int Id_categorie { get; set; }
        public virtual Categorie categorie { get; set; }
        public string Rasa { get; set; }
        public string Caracteristici { get; set; }
        [NotMapped]
        public string  DenCategorie {get;set;}
    }
}