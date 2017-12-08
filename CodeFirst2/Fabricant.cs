
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeFirst2
{
    public class Fabricant
    {
        [Key]
        public int ID { get; set; }
        [StringLength(30)]
        public String Nom { get; set; }

        public virtual ICollection<Salade> Salades { get; set; }
    }
}