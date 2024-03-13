using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using OJW45A_HFT_2023241.Endpoint.Services;
using OJW45A_HFT_2023241.Logic.LogicInterfaces;
using OJW45A_HFT_2023241.Models;
using System.Collections.Generic;

namespace OJW45A_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArmyBaseController : ControllerBase
    {
        IArmyBaseLogic logic;
        IHubContext<SignalRHub> hub;

        public ArmyBaseController(IArmyBaseLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<ArmyBase> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public ArmyBase Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] ArmyBase value)
        {
            this.logic.Create(value);
            hub.Clients.All.SendAsync("ArmyBaseCreated", value);
        }

        [HttpPut]
        public void Update(int id, [FromBody] ArmyBase value)
        {
            this.logic.Update(value);
            hub.Clients.All.SendAsync("ArmyBaseUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ArmyBase armyBaseToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ArmyBaseDeleted", armyBaseToDelete);
        }
    }
}
