using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BiblioJdr;
using BiblioJdr.outils;
using System.Linq;
using System.Threading.Tasks;
using BPersistance;

namespace APIItem.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("items/[controller]")]
    public class ArmesController : ControllerBase
    {
        //List<Arme> armes = Stub.Armes();
        private readonly IDataManager manager;

        public ArmesController(IDataManager manager)
        {
            this.manager = manager;
            this.manager.AddAsync(Stub.UneArme());
        }




        // GET api/values
        [ProducesResponseType(200, Type = typeof(IEnumerable<Arme>))]
        [ProducesResponseType(204)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int index= 0, [FromQuery] int count = 10)
        {
            var result = await manager.GetItems<Arme>(index,count);
            return Ok(result);
            //return result ? (IActionResult)Ok(result) : NoContent();
        }

        // GET api/values/name
        [ProducesResponseType(200, Type = typeof(Arme))]
        [ProducesResponseType(204)]
        [HttpGet("{nom}")]
        public async Task<ActionResult<Arme>> Get(string nom)
        {
            var result = await manager.GetAsync(new Arme(nom,1,"",1));
            return result;
        }

        // POST api/values
        [ProducesResponseType(201, Type = typeof(Arme))]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<ActionResult<Arme>> Post([FromBody] Arme arme)
        {
            var result = await manager.AddAsync(arme);
            return result == null ? (ActionResult)CreatedAtAction("Get", result) : BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{nom}")]
        public async Task<ActionResult<Arme>> Put(string nom, [FromBody] Arme arme)
        {
            arme.Nom = nom;
            var updatedArme = await manager.Update(arme);
            return updatedArme == null ?   (ActionResult)BadRequest() : Ok(updatedArme);
        }

        // DELETE api/values/5
        [HttpDelete("Arme")]
        public async Task<ActionResult<Arme>> Delete([FromBody] Arme arme)
        {
            var result = await manager.RemoveAsync(arme);
            return result ? (ActionResult)Ok(result) : BadRequest();
        }
    }
}
