using System;
using System.Collections.Generic;
using System.Text;


namespace Afficheur
{
    /// <summary>
    /// Classe gérant l'affichage
    /// </summary>
    public abstract class Afficheur
    {
        /// <summary>
        /// Affiche un texte
        /// </summary>
        /// <param name="txt">Le texte à afficher</param>
        public static void afficher(string txt)
        {
            Console.WriteLine(txt);
        }
    }
}
