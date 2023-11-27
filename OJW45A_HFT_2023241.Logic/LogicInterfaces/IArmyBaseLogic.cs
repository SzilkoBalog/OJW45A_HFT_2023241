using OJW45A_HFT_2023241.Logic.Logics;
using OJW45A_HFT_2023241.Models;
using System.Collections.Generic;

namespace OJW45A_HFT_2023241.Logic.LogicInterfaces
{
    public interface IArmyBaseLogic
    {
        void Create(ArmyBase item);
        void Delete(int id);
        ArmyBase Read(int id);
        IEnumerable<ArmyBase> ReadAll();
        void Update(ArmyBase item);
        IEnumerable<ArmyBaseData> GetArmyBaseStatistics();
        IEnumerable<KeyValuePair<ArmyBase, double>> GetBasesWithAverageSoldierAge();
        IEnumerable<KeyValuePair<string, Dictionary<string, int>>> GetEquipmentCountByTypePerBase();
    }
}