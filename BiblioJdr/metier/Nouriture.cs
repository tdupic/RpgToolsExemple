using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioJdr
{
    /// <summary>
    /// Classe nouriture héritant de Item
    /// </summary>
    public class Nouriture : Item
    {
        /// <summary>
        /// Constructeur de nourriture
        /// </summary>
        /// <param name="nom">nom de l'item</param>
        /// <param name="qte">qt de l'item</param>
        public Nouriture(string nom, int qte) : base(nom,qte)
        {
        }
    }
}
