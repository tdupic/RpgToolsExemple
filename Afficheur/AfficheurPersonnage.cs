using System;
using System.Collections.Generic;
using System.Text;
using BiblioJdr;
using BiblioJdr.metier;

namespace Afficheur
{
    /// <summary>
    /// Classe gérant l'affichage des personnages, herite d'Affichage
    /// </summary>
    public class AfficheurPersonnage : Afficheur
    {
        /// <summary>
        /// Affiche les informations du personne reçu en paramètre
        /// </summary>
        /// <param name="p">personnage à afficher</param>
        public static void afficher(Personnage p)
        {
            string infoP = "Nom : "+p.Nom;
            infoP += "\nClasse : " + p.Classe;
            infoP += "\nLevel : " + p.Level;
            infoP += "\nPO : " + p.Po;
            afficher(infoP);


        }
    }
}
