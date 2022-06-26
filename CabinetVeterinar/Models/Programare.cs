using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CabinetVeterinar.Models
{
    public class Programare
    {
        [Key]
        public int Id_programare { get; set; }
        public int Id_utilizator { get; set; }      
        public virtual Utilizator Client { get; set; }
        public int Id_veterinar { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Descriere { get; set; }
    }
}