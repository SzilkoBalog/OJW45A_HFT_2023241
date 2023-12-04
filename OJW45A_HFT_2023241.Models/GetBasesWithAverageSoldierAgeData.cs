using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJW45A_HFT_2023241.Models
{
    public class GetBasesWithAverageSoldierAgeData
    {
        public string BaseName { get; set; }

        public double AverageSoldierAge { get; set; }

        public override bool Equals(object obj)
        {
            return obj is GetBasesWithAverageSoldierAgeData data &&
                   BaseName == data.BaseName &&
                   AverageSoldierAge == data.AverageSoldierAge;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BaseName, AverageSoldierAge);
        }
    }
}
