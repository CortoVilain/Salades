using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst2
{
    public class Salade
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Nom { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public String Description { get; set; }

        public virtual Fabricant Fabricant { get; set; }

        public virtual ICollection<Composant> Composants { get; set; }

        public Salade()
        {
            Composants = new HashSet<Composant>();
        }
    }
}
