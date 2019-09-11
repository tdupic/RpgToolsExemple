using System;
using System.Collections.Generic;
using System.Text;
using BiblioJdr;

namespace Afficheur
{
    /// <summary>
    /// Classe gerant l'affichage des statistiques, herite d'Affichage
    /// </summary>
    public class AfficheurStat : Afficheur
    {
        /// <summary>
        /// Affiche les stats reçues en paramètre
        /// </summary>
        /// <param name="lesStats"> les stats à afficher</param>
        public static void afficher(List<Stat> lesStats)
        {
            string txt = "";
            foreach (Stat s in lesStats)
            {
                txt += "\nNom stat : "+s.Nom;
                txt += "\nValeur : " + s.Valeur;
            }
            afficher(txt);
        }
    }
}
