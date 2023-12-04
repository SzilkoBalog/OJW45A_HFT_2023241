using Microsoft.AspNetCore.Mvc;
using OJW45A_HFT_2023241.Logic.LogicInterfaces;
using OJW45A_HFT_2023241.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OJW45A_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCrudController : ControllerBase
    {
        IArmyBaseLogic armyLogic;
        ISoldierLogic sodlierLogic;

        public NonCrudController(IArmyBaseLogic armyLogic, ISoldierLogic sodlierLogic)
        {
            this.armyLogic = armyLogic;
            this.sodlierLogic = sodlierLogic;
        }

        [HttpGet]
        public IEnumerable<GetBasesWithAverageSoldierAgeData> GetBasesWithAverageSoldierAge()
        {
            return this.armyLogic.GetBasesWithAverageSoldierAge();
        }

        [HttpGet]
        public IEnumerable<ArmyBaseData> GetArmyBaseStatistics()
        {
            return this.armyLogic.GetArmyBaseStatistics();
        }

        [HttpGet]
        public IEnumerable<GetEquipmentCountByTypePerBaseData> GetEquipmentCountByTypePerBase()
        {
            return this.armyLogic.GetEquipmentCountByTypePerBase();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<Soldier, IEnumerable<string>>> GetSoldiersWithEquipmentTypes()
        {
            return this.sodlierLogic.GetSoldiersWithEquipmentTypes();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<Soldier, int>> GetSoldiersWithTotalEquipmentWeight()
        {
            return this.sodlierLogic.GetSoldiersWithTotalEquipmentWeight();
        }
    }
}
