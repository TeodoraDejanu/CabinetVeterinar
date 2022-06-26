using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CabinetVeterinar.Models
{
    public class DataContext:DbContext
    {
        public DataContext(): base("CabinetVeterinar") { }
        public DbSet<Utilizator> Utilizatori {get; set;}
        public DbSet<Categorie> Categorii { get; set; }
        public DbSet<Animal> Animale { get; set; }
        public DbSet<Programare> Programari { get; set; }
        public DbSet<Fisa> Fise { get; set; }
        public DataContext(DbSet<Animal> animale)
        {
            Animale = animale;
        }
    }
}