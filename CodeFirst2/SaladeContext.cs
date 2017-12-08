
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeFirst2
{
    public class SaladesContext : DbContext
    {
        public SaladesContext()
            : base("salades") //Nom de la chaine de connexion
        {

        }
        //Définition de mes DbSet ( qui sont mappés aux tables )
        public virtual DbSet<Salade> Salades { get; set; }

        public virtual DbSet<Composant> Composants { get; set; }

        public virtual DbSet<Fabricant> Fabricants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}