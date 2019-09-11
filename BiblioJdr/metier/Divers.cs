using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioJdr
{
    /// <summary>
    /// Classe correspondant aux objets divers, herite de la classe Item
    /// </summary>
    public class Divers : Item
    {
        /// <summary>
        /// Constructeur de la classe Divers
        /// </summary>
        /// <param name="nom">Nom de l'objet</param>
        /// <param name="qte">Quantite</param>
        public Divers(string nom, int qte) : base(nom, qte)
        {
        }
    }
}
