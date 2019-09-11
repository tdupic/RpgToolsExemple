using System;
using System.Collections.Generic;
using System.Text;
using BiblioJdr;

namespace Afficheur
{
    /// <summary>
    /// Classe gérant l'affiche des sorts, herite d'Affichage
    /// </summary>
    public class AfficheurSort : Afficheur
    {
        /// <summary>
        /// Affiche les sorts reçues en paramètre
        /// </summary>
        /// <param name="lesSorts"> les sorts à afficher</param>
        public static void afficher(List<Sort> lesSorts)
        {
            string txt = "";
            foreach (Sort s in lesSorts)
            {
                txt += "\nNom sort : " + s.Nom;
                txt += "\nEffet : " + s.Effet;
                txt += "\nMttDommage : " + s.MontantDommage;
            }
            afficher(txt);
        }
    }
}
