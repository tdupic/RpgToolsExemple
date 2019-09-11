using System;
using BiblioJdr;
using BiblioJdr.metier;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnit
{
    [TestClass]
    public class TestPersonnage
    {
        [TestMethod]
        public void TestGainXp()
        {
            Personnage p = new Personnage("Karjo", "Fail", 0, new Arme("", 0, "", 0),new Armure("",0,"",1));

            p.GainXp(11);
            Assert.AreEqual(1, p.XpEnCours);

        }
        [TestMethod]
        public void TestGainLevel()
        {
            Personnage p = new Personnage("Karjo", "Fail", 0, new Arme("", 0, "", 0), new Armure("", 0, "", 1));

            p.GainXp(25);
            Assert.AreEqual(3, p.Level);

        }

        [TestMethod]
        public void TestEditStat()
        {
            Stat agi = new Stat("Agilité", 70);
            Personnage p = new Personnage("Karjo", "Fail", 0, new Arme("", 0, "", 0), new Armure("", 0, "", 1));
            p.AjouterStat(agi);
            p.EditStat(agi, -5);
            Assert.AreEqual(65, p.FindStat("Agilité").Valeur);
        }

        [TestMethod]
        public void TestCasterSortMana()
        {
            Sort leSort = new Sort("test", "test", 50, 30);

            Personnage p = new Personnage("Karjo", "Fail", 0,new Arme("", 0, "", 0), new Armure("", 0, "", 1));
            p.AjouterStat(new Stat("Mana", 100));
            p.AjouterSort(leSort);

            Ennemi e = new Ennemi("Evil karjo", new Arme("a",5,"rien",1));
            e.AjouterStat(new Stat("PV", 100));


            p.CasterSort(leSort, e);

            Assert.AreEqual(70, p.FindStat("Mana").Valeur);
        }

        [TestMethod]
        public void TestCasterSortDegats()
        {
            Sort leSort = new Sort("test", "test", 1, 30);

            Personnage p = new Personnage("Karjo", "Fail", 0, new Arme("",0,"",0), new Armure("", 0, "", 1));
            p.AjouterStat(new Stat("Mana", 100));
            p.AjouterSort(leSort);

            Ennemi e = new Ennemi("Evil karjo", new Arme("a", 5, "rien", 1));
            e.AjouterStat(new Stat("PV", 100));


            p.CasterSort(leSort, e);

            Assert.AreEqual(99, e.FindStat("PV").Valeur);
        }


    }
}
