using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CabinetVeterinar.Models
{
    public class Utilizator
    {
        [Key]
        public int Id_utilizator { get; set; }
        [Required]
        [Display(Name = "Utilizator")] 
        public string Username { get; set; }
        [Required]
        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        public string Parola { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        [Display(Name = "E-mail")] 
        [DataType(DataType.EmailAddress, ErrorMessage = "Adresa e-mail invalida")]
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Rol { get; set; }
        [DataType(DataType.MultilineText)]
        public string Specializari { get; set; }
        public string Ani_experienta{ get; set; }
        [DataType(DataType.MultilineText)]
        public string Descriere { get; set; }
        public byte[] Poza { get; set; }
        public string Motto { get; set; }
        public virtual ICollection<Animal> Animale { get; set; }
    }
}