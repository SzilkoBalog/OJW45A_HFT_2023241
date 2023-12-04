using OJW45A_HFT_2023241.Models;
using System.Collections.Generic;

namespace OJW45A_HFT_2023241.Logic.LogicInterfaces
{
    public interface ISoldierLogic
    {
        void Create(Soldier item);
        void Delete(int id);
        Soldier Read(int id);
        IEnumerable<Soldier> ReadAll();
        void Update(Soldier item);

        IEnumerable<KeyValuePair<Soldier, IEnumerable<string>>> GetSoldiersWithEquipmentTypes();
        IEnumerable<GetSoldiersWithTotalEquipmentWeightData> GetSoldiersWithTotalEquipmentWeight();
    }
}