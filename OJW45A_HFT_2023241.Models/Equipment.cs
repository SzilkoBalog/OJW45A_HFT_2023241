using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJW45A_HFT_2023241.Models
{
    [Table("EQUIPMENT")]
    public class Equipment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }//Serial number of the equipment

        [Required]
        [StringLength(50)]
        public string Type { get; set; }//Weapon, Gear...

        [StringLength(200)]
        public string Description { get; set; }

        public int Weight {  get; set; }

        [NotMapped]
        public virtual Soldier Soldier { get; set; }

        [ForeignKey(nameof(Soldier))]
        public int SoldierId { get; set; }

        public Equipment()
        {
        }
    }
}
