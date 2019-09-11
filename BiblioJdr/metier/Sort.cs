using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioJdr
{
    /// <summary>
    /// Classe qui représente les sorts
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// Nom du sort
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Effet du sort
        /// </summary>
        public string Effet { get; set; }
        /// <summary>
        /// Montant maximum de dégats du sort
        /// </summary>
        public int MontantDommage { get; set; }
        /// <summary>
        /// Coût en mana du sort
        /// </summary>
        public int CoutMana { get; set; }
        /// <summary>
        /// Temps de récupération en tour du sort
        /// </summary>
        public int Cooldown { get; set; }
        /// <summary>
        /// Constructeur de Sort
        /// </summary>
        /// <param name="nom">nom du sort</param>
        /// <param name="effet"> effet du sort</param>
        /// <param name="montantDommage"> nombre max de dégat du sort</param>
        /// <param name="mana">coût en mana du sort</param>
        public Sort(string nom, string effet, int montantDommage,int mana)
        {
            this.Nom = nom;
            this.Effet = effet;
            this.MontantDommage = montantDommage;
            this.CoutMana = mana;
        }


    }
}
