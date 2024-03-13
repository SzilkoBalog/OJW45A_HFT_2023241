using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using OJW45A_HFT_2023241.Endpoint.Services;
using OJW45A_HFT_2023241.Logic.LogicInterfaces;
using OJW45A_HFT_2023241.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OJW45A_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        IEquipmentLogic logic;
        IHubContext<SignalRHub> hub;

        public EquipmentController(IEquipmentLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Equipment> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Equipment Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Equipment value)
        {
            this.logic.Create(value);
            hub.Clients.All.SendAsync("EquipmentCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Equipment value)
        {
            this.logic.Update(value);
            hub.Clients.All.SendAsync("EquipmentUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Equipment EquipmentToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            hub.Clients.All.SendAsync("EquipmentDeleted", EquipmentToDelete);
        }
    }
}
