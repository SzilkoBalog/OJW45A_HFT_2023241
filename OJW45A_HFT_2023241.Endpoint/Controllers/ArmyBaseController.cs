using Microsoft.AspNetCore.Mvc;
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

        public ArmyBaseController(IArmyBaseLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<ArmyBase> Create()
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
        }

        [HttpPut]
        public void Update(int id, [FromBody] ArmyBase value)
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
