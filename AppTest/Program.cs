using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using BiblioJdr;
using Afficheur;
using BPersistance;
using BiblioJdr.metier;

namespace AppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (JdrDBEntities jdrDB = new JdrDBEntities())
                {
                    jdrDB.Database.EnsureCreated();
                    /*foreach (Arme a in Stub.armes())
                    {
                        jdrDB.ArmeSet.Add(a);
                    }*/
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Impossible de créer la base");
            }
            Personnage test = new Personnage("hjk", "ghjg", 0, new Arme("", 0, "", 1), new Armure("", 0, "", 0));
            Item it = new Arme("Epée courte", 3, "Saignement a 1d100", 1);
            test.AjouterItem(it);
            test.AjouterStat(new Stat("PV", 100));
            test.AjouterSort(new Sort("Finger of Death", "InstaKill", 999999, 555));
            Afficheur.AfficheurPersonnage.afficher(test);
            Console.ReadLine();
        }
    }
}
