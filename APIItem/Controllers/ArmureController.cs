using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BiblioJdr;
using BPersistance;
using Microsoft.AspNetCore.Authorization;
using BiblioJdr.outils;

namespace APIItem.Controllers
{
    //[Authorize]
    [Route("items/[controller]")]
    [ApiController]
    public class ArmureController : ControllerBase
    {
        private readonly IDataManager manager;

        public ArmureController(IDataManager manager)
        {
            this.manager = manager;
            this.manager.AddAsync(Stub.UneArmure());
        }

        // GET api/values
        [ProducesResponseType(200, Type = typeof(IEnumerable<Armure>))]
        [ProducesResponseType(204)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int index = 0, [FromQuery] int count = 10)
        {
            var result = await manager.GetItems<Armure>(index, count);
            return Ok(result);
            //return result ? (IActionResult)Ok(result) : NoContent();
        }

        // GET api/values/name
        [ProducesResponseType(200, Type = typeof(Armure))]
        [ProducesResponseType(204)]
        [HttpGet("{nom}")]
        public async Task<ActionResult<Armure>> Get(string nom)
        {
            var result = await manager.GetAsync(new Armure(nom, 1, "", 1));
            return result;
        }

        // POST api/values
        [ProducesResponseType(201, Type = typeof(Armure))]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<ActionResult<Armure>> Post([FromBody] Armure armure)
        {
            var result = await manager.AddAsync(armure);
            return result != null ? (ActionResult)CreatedAtAction("Get", result) : BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{nom}")]
        public async Task<ActionResult<Armure>> Put(string nom, [FromBody] Armure armure)
        {
            armure.Nom = nom;
            var updatedArmure = await manager.Update(armure);
            return updatedArmure == null ? (ActionResult)BadRequest() : Ok(updatedArmure);
        }

        // DELETE api/values/5
        [HttpDelete("Armure")]
        public async Task<ActionResult<Armure>> Delete([FromBody] Armure armure)
        {
            var result = await manager.RemoveAsync(armure);
            return result ? (ActionResult)Ok(result) : BadRequest();
        }
    }
}
