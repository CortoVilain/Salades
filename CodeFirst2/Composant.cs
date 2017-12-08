
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeFirst2
{
    public class Composant
    {
        [Key]
        public int ID { get; set; }

        public string Nom { get; set; }

        public virtual ICollection<Salade> Salades { get; set; }

        public Composant()
        {
            Salades = new HashSet<Salade>();
        }
    }
}