using System;
using System.Diagnostics;
using BiblioJdr;
using BiblioJdr.metier;
using BPersistance.bdd;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async System.Threading.Tasks.Task TestGetAsyncBDD()
        {
            JdrDBManager manager = new JdrDBManager(false);
            //manager.InitJdrDBEntities();
            Personnage p = new Personnage("Jordan", "Mage", 0, new Arme("Baton", 0, "pas d'effet", 2), new Armure("Slip", 0, "", 0));
            p.AjouterItem(new Divers("Crochet",12));
            p.AjouterItem(new Nouriture("Banane", 2));
            await manager.AddAsync((IPersonnage)p);

            Personnage pRes = manager.GetAsync(p).Result;
            Assert.Equal(p.Nom, pRes.Nom);
        }
    }
}   
