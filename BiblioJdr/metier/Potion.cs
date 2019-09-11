using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioJdr
{
    /// <summary>
    /// Classe Potion héritant de item
    /// </summary>
    public class Potion : Item
    {
        /// <summary>
        /// Effet de la potion
        /// </summary>
        public string Effet { get; set; }
        /// <summary>
        /// Constructeur de la potion
        /// </summary>
        /// <param name="nom">Nom de l'item</param>
        /// <param name="effet"> effet de la potion</param>
        /// <param name="qte">nb de potions </param>
        public Potion(string nom, string effet, int qte) : base(nom, qte)
        {
            Effet = effet;
        }
    }
}
