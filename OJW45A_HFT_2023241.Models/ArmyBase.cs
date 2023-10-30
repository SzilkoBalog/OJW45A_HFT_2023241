using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OJW45A_HFT_2023241.Models
{
    [Table("ARMY_BASES")]
    public class ArmyBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int NumberOfBeds { get; set; }

        public int DateOfBuild { get; set; }

        [NotMapped]
        public ICollection<Soldier> Soldiers { get; set; }

        public ArmyBase()
        {
            Soldiers = new HashSet<Soldier>();                
        }
    }
}
