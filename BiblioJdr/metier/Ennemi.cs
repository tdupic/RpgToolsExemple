using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using BiblioJdr.metier;

namespace BiblioJdr
{
    /// <summary>
    /// Classe correspondant aux ennemi
    /// </summary>
    public class Ennemi
    {
        /// <summary>
        /// Nom de l'ennemi
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Liste des statistiques de l'ennemi
        /// </summary>
        private List<Stat> lesStats = new List<Stat>();
        /// <summary>
        /// Liste des statistiques de l'ennemi en lecture seul
        /// </summary>
        public ReadOnlyCollection<Stat> ROCStats { get; }
        /// <summary>
        /// Arme de l'ennemi
        /// </summary>
        public Arme SonArme { get; set; }
        /// <summary>
        /// Liste des sorts de l'ennemi
        /// </summary>
        private List<Sort> lesSorts = new List<Sort>();
        /// <summary>
        /// Liste des sorts de l'ennemi en lecture seul
        /// </summary>
        public ReadOnlyCollection<Sort> ROCSorts { get; }
        /// <summary>
        /// Constructeur de la classe ennemi
        /// </summary>
        /// <param name="nom">Nom de l'ennemi</param>
        /// <param name="ar">Arme de l'ennemi</param>
        public Ennemi(string nom, Arme ar)
        {
            this.Nom = nom;
            this.ROCStats = new ReadOnlyCollection<Stat>(lesStats);
            SonArme = ar;
            this.ROCSorts = new ReadOnlyCollection<Sort>(lesSorts);
        }

        /// <summary>
        /// Permet d'ajouter des statistiques à l'ennemi
        /// </summary>
        /// <param name="s">Statistique à ajouter à l'ennemi</param>
        public void AjouterStat(Stat s)
        {
            lesStats.Add(s);
        }

        /// <summary>
        /// Permet de retrouver une statistique dans la liste
        /// </summary>
        /// <param name="nomStat">Nom de la statistique recherchée</param>
        /// <returns></returns>
        public Stat FindStat(string nomStat)
        {
            Stat laStat = lesStats.Find(stat => stat.Nom == nomStat);
            return laStat;
        }

        /// <summary>
        /// Permet à l'ennemi de lance un sort sur un groupe de personnage
        /// </summary>
        /// <param name="s">Sort à lancer</param>
        /// <param name="lesPersos">Liste des personnage ciblés par l'ennemi</param>
        public void CasterSort(Sort s, List<Personnage> lesPersos)
        {
            lesStats.Find(stat => stat.Nom == "Mana").PerdrePoint(s.CoutMana);
            foreach (Personnage p in lesPersos)
            {
                p.FindStat("PV").PerdrePoint(Dice.lancerDe(s.MontantDommage));
            }
        }

        /// <summary>
        /// Permet à l'ennemi de lancer un sort sur un personnage
        /// </summary>
        /// <param name="s">Sort à lancer</param>
        /// <param name="p">Personnage ciblé</param>
        public void CasterSort(Sort s, Personnage p)
        {
            lesStats.Find(stat => stat.Nom == "Mana").PerdrePoint(s.CoutMana);
            p.FindStat("PV").PerdrePoint(Dice.lancerDe(s.MontantDommage));
        }

        /// <summary>
        /// Permet à l'ennemi d'attaquer un personnage avec son arme
        /// </summary>
        /// <param name="p">Personnage à attaquer</param>
        public void Attaquer(Personnage p)
        {
            int totalDgt = ((Dice.lancerDe(SonArme.MttDegats)) - p.ArmureEquipe.MttDefense);
            if (totalDgt > 0)
            {
                p.FindStat("PV").PerdrePoint(totalDgt);
            }
            
        }


    }
}
