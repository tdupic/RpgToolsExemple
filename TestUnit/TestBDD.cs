using System;
using BPersistance;
using BPersistance.bdd;
using BiblioJdr.metier;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnit
{
    [TestClass]
    public class TestBDD
    {
        [TestMethod]
        public async System.Threading.Tasks.Task TestCreateBddAsync()
        {
            JdrDBManager manager = new JdrDBManager(true);
            IPersonnage p = new Personnage("Jordan","Mage",0, new BiblioJdr.Arme("Baton",0,"pas d'effet",2), new BiblioJdr.Armure("Slip",0,"",0));
            await manager.AddAsync(p);

            Assert.IsNotNull(manager.GetAsync(p));
        }
    }
}
