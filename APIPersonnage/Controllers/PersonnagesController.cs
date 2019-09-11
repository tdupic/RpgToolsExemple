using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblioJdr;
using BiblioJdr.metier;
using BPersistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIPersonnage.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class PersonnagesController : Controller
    {
        //Get liste personnage
        [HttpGet]
        public IEnumerable<Personnage> Get()
        {           
            return Stub.LesPerso();
        }

        [HttpGet("{nom}")]
        public Personnage GetPersonnage(string nom)
        {
            return Stub.LesPerso().Find(pe => pe.Nom == nom);
        }

        //Get inventaire d'un personnage passé en paramètre
        [HttpGet("{nom}/Inventaire")]
        public IEnumerable<Item>Get(string nom)
        {
            Personnage p = Stub.LesPersoAvecStuffs().Find(pe => pe.Nom == nom);
            return p.ROCInventaire;
        }

        [HttpGet("{nom}/Sort")]
        public IEnumerable<Sort>GetSort(string nom)
        {
            Personnage p = Stub.LesPersoAvecSorts().Find(pe => pe.Nom == nom);
            return p.ROCSorts;
        }

        [HttpGet("{nom}/Stats")]
        public IEnumerable<Stat>GetStats(string nom)
        {
            Personnage p = Stub.LesPersoStats().Find(pe => pe.Nom == nom);
            return p.ROCStats;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{nom}")]
        public void Delete(string nom)
        {
            List<Personnage>lesPersos = Stub.LesPerso();
            lesPersos.Remove(lesPersos.Find(pe => pe.Nom == nom));        
        }
    }
}
