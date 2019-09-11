using System;
using System.Collections.Generic;
using System.Text;
using BiblioJdr;
using BiblioJdr.metier;

namespace BPersistance 
{
    public class Stub
    {
        public static List<Personnage> LesPerso()
        {
            List<Personnage> lesPersos = new List<Personnage>
            {
                new Personnage("Karjo", "L'homme fail", 0, UneArme(), UneArmure()),
                new Personnage("Louis", "Voleur", 5, UneArme(), UneArmure()),
                new Personnage("Antoine", "KING", 100, UneArme(), UneArmure()),
                new Personnage("Shlacktroug", "Entité", 2001, UneArme(), UneArmure()),
                new Personnage("Pixi", "Healer", 0, UneArme(), UneArmure())
            };
            return lesPersos;
        }

        public static List<Personnage> LesPersoAvecStuffs()
        {
            List<Personnage> lesPersos = LesPerso();
            lesPersos[0].AjouterItem(new Arme("Baton magique", 1, "Fait des trucs",1));
            lesPersos[0].AjouterItem(new Armure("Barbe de coco", 110, "Jolie", 1));
            lesPersos[1].AjouterItem(new Divers("Cuir", 5));
            lesPersos[1].AjouterItem(new Nouriture("Steak", 52));
            lesPersos[2].AjouterItem(new Potion("Potion rouge", "???", 1));
            lesPersos[3].AjouterItem(new Arme("Dague", 99999, "oui", 1));
            lesPersos[3].AjouterItem(new Arme("Dague en fer", 1, "coupe", 2));
            lesPersos[4].AjouterItem(new Armure("Armure de fer", 5, "", 1));
            lesPersos[4].AjouterItem(new Arme("Couteau qui coupe", 42389645, "Coupe bien la viande", 1));
            return lesPersos;
        }

        public static List<Arme> Armes()
        {
                return new List<Arme>()
            {
                new Arme("Baton de Michel",12, "Paralyse l'ennemi", 1 ),
                new Arme("Prout",12, "Paralyse l'ennemi", 1 ),
                new Arme("Un couteau",12, "Coupe", 1 ),
                new Arme("Oui",12, "Non", 1 ),
                new Arme("Le nez de tommy",12, "Paralyse l'ennemi", 1 )
            };
        }

        public static List<Armure> Armures()
        {
            return new List<Armure>()
            {
                new Armure("Casque",12, "Paratonnerre", 1 ),
                new Armure("Plastron en mousse",12, "Bloque 1 dégat", 1 ),
                new Armure("Bignou magique",12, "Mystère", 1 ),
                new Armure("JCVD",12, "Tue tout le monde", 1 ),
                new Armure("Bague",12, "Emprisonne a jamais", 1 )
            };
        }

        public static Arme UneArme()
        {
            return new Arme("Couteau de cuisine", 5, "Coupe la viande", 1);
        }

        public static Armure UneArmure()
        {
            return new Armure("Armure en laine", 1, "Cadeau de la grand mère", 1);
        }

        public static Ennemi UnEnnemi()
        {
            return new Ennemi("Le méchant monsieur", UneArme());
        }

        public static List<Personnage> LesPersoAvecSorts()
        {
            List<Personnage> p = LesPerso();
            p[0].AjouterSort(new Sort("Boule de feu", "Brule", 5, 1));
            p[1].AjouterSort(new Sort("Soin", "Restaure des Pv", -20, 2));
            p[2].AjouterSort(new Sort("SkitKabak", "Désoriente les ennemies", 0, 5));
            p[3].AjouterSort(new Sort("La roue des enfers", "Effet aléatoire", 0, 20));
            p[4].AjouterSort(new Sort("Finger of deaf", "One shot l'ennemie en le rendant sourd", 99999999, 50));

            return p;
        }

        public static List<Sort> LesSorts()
        {
            List<Sort> s = new List<Sort>();
            s.Add(new Sort("Boule de feu", "Brule", 5, 1));
            s.Add(new Sort("Soin", "Restaure des Pv", -20, 2));
            s.Add(new Sort("SkitKabak", "Désoriente les ennemies", 0, 5));
            s.Add(new Sort("La roue des enfers", "Effet aléatoire", 0, 20));
            s.Add(new Sort("Finger of deaf", "One shot l'ennemie en le rendant sourd", 99999999, 50));
            return s;
        }
       
        public static Nouriture UneNourriture()
        {
            return new Nouriture("Steak", 1);
        }

        public static Potion UnePotion()
        {
            return new Potion("Smecta", "Provoque une désorientation pendant 2 tours", 1);
        }

        public static Divers UnDivers()
        {
            return new Divers("Vis", 5);
        }

        public static List<Stat> LesStats()
        {
            List<Stat> s = new List<Stat>
            {
                new Stat("PV", 50),
                new Stat("Mana", 50),
                new Stat("Force", 50),
                new Stat("Endurance", 50)
            };
            return s;
        }

        public static List<Personnage> LesPersoStats()
        {
            List<Personnage> p = LesPerso();
            foreach (Stat s in LesStats())
            {
                foreach(Personnage pes in p)
                {
                    pes.AjouterStat(s);
                }
            }
            return p;
        }

        public static List<Personnage> LesPersoStatsInventaire()
        {
            List<Personnage> p = LesPersoAvecStuffs();
            foreach (Stat s in LesStats())
            {
                foreach (Personnage pes in p)
                {
                    pes.AjouterStat(s);
                }
            }
            return p;
        }

        public static List<Personnage> LesPersoStatsInventaireSpeel()
        {
            List<Personnage> p = LesPersoAvecStuffs();
            foreach (Sort s in LesSorts())
            {
                foreach (Personnage pes in p)
                {
                    pes.AjouterSort(s);
                }
            }
            return p;
        }

    }
}
