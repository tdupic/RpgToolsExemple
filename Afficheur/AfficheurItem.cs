using System;
using System.Collections.Generic;
using System.Text;
using BiblioJdr;

namespace Afficheur
{
    /// <summary>
    /// Classe d'affichage des Items, herite d'Affichage
    /// </summary>
    public class AfficheurItem : Afficheur
    {
        /// <summary>
        /// Affiche les items reçus en paramètre
        /// </summary>
        /// <param name="lesItems"> les items à afficher</param>
        public static void afficher(List<Item> lesItems)
        {
            string txt = "";
            foreach (Item s in lesItems)
            {
                txt += "\nNom item : " + s.Nom;
                txt += "\nQte : " + s.Qte;
            }
            afficher(txt);
        }
    }
}
