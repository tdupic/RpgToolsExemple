using System;

namespace BiblioJdr
{
    /// <summary>
    /// Classe gérant les dés
    /// </summary>
    public class Dice
    {
        private static Random rd = new Random();
        /// <summary>
        /// Sert à générer un nombre aléatoire
        /// </summary>
        /// <param name="unNum">Valeur maximum que peut atteindre le nombre</param>
        /// <returns></returns>
        public static int lancerDe(int unNum)
        {
            return rd.Next(1, unNum+1);
        }
    }
}
