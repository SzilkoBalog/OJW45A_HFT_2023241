using Microsoft.AspNetCore.Mvc;
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

        public EquipmentController(IEquipmentLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] Equipment value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
