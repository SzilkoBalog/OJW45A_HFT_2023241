using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJW45A_HFT_2023241.Models
{
    [Table("SOLDIERS")]
    public class Soldier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public int Weight { get; set; }

        [NotMapped]
        public virtual ICollection<Equipment> Equipment { get; set; }

        [NotMapped]
        public virtual ArmyBase ArmyBase { get; set; }

        [ForeignKey(nameof(ArmyBase))]
        public int ArmyBaseId { get; set; }

        public Soldier()
        {
            Equipment = new HashSet<Equipment>();              
        }
    }
}
