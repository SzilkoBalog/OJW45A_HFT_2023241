﻿using OJW45A_HFT_2023241.Logic.Logics;
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
        IEnumerable<GetArmyBaseStatisticsData> GetArmyBaseStatistics();
        IEnumerable<GetBasesWithAverageSoldierAgeData> GetBasesWithAverageSoldierAge();
        IEnumerable<GetEquipmentCountByTypePerBaseData> GetEquipmentCountByTypePerBase();
    }
}