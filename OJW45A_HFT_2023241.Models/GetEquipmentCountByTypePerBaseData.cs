using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJW45A_HFT_2023241.Models
{
    public class GetEquipmentCountByTypePerBaseData
    {
        public string BaseName { get; set; }

        public string EquipmentType { get; set; }

        public int EquipmentCount { get; set; }

        public override bool Equals(object obj)
        {
            return obj is GetEquipmentCountByTypePerBaseData data &&
                   BaseName == data.BaseName &&
                   EquipmentType == data.EquipmentType &&
                   EquipmentCount == data.EquipmentCount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BaseName, EquipmentType, EquipmentCount);
        }
    }
}
