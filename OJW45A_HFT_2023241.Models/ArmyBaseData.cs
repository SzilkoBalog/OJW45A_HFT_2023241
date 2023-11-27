using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJW45A_HFT_2023241.Models
{
    public class ArmyBaseData
    {
        public string BaseName { get; set; }
        public int Count { get; set; }
        public int AvgWeight { get; set; }
        public int AvgAge { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ArmyBaseData data &&
                   BaseName == data.BaseName &&
                   Count == data.Count &&
                   AvgWeight == data.AvgWeight &&
                   AvgAge == data.AvgAge;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BaseName, Count, AvgWeight, AvgAge);
        }
    }
}
