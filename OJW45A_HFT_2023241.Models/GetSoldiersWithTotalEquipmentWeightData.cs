using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJW45A_HFT_2023241.Models
{
    public class GetSoldiersWithTotalEquipmentWeightData
    {
        public Soldier soldier { get; set; }

        public int TotalEquipmentWeight { get; set; }

        public override bool Equals(object obj)
        {
            return obj is GetSoldiersWithTotalEquipmentWeightData data &&
                   EqualityComparer<Soldier>.Default.Equals(soldier, data.soldier) &&
                   TotalEquipmentWeight == data.TotalEquipmentWeight;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(soldier, TotalEquipmentWeight);
        }
    }
}
