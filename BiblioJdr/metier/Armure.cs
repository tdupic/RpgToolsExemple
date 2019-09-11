using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioJdr
{
    /// <summary>
    /// Classe correspondant aux armures, herite de la classe Item
    /// </summary>
    public class Armure : Item
    {
        /// <summary>
        /// Montant de defense de l'armure
        /// </summary>
        public int MttDefense { get; set; }
        /// <summary>
        /// Effet applicable par l'armure
        /// </summary>
        public string Effet { get; set; }
        /// <summary>
        /// Constructeur de la classe Armure
        /// </summary>
        /// <param name="nom">Nom de l'armure</param>
        /// <param name="mttDefense">Montant de defense de l'armure</param>
        /// <param name="effet">Effet applicable par l'armure</param>
        /// <param name="qte">Quantite</param>
        public Armure(string nom, int mttDefense, string effet, int qte) : base(nom, qte)
        {
            MttDefense = mttDefense;
            Effet = effet;
        }
        
    }
}
