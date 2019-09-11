using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioJdr
{
    /// <summary>
    /// Classe correspondant aux armes, herite de la classe Item
    /// </summary>
    public class Arme : Item
    {
        /// <summary>
        /// Effet applicable par l'arme
        /// </summary>
        public string Effet { get; set; }
        /// <summary>
        /// Montant des degats que fait l'arme
        /// </summary>
        public int MttDegats { get; set; }

        /// <summary>
        /// Constructeur de la classe arme
        /// </summary>
        /// <param name="nom">Nom de l'amre</param>
        /// <param name="mttDegats">Montant des dégats de l'arme</param>
        /// <param name="effet">Effet applicable par l'arme</param>
        /// <param name="qte">Quantite</param>
        public Arme(string nom, int mttDegats, string effet, int qte) : base(nom, qte)
        {
            this.MttDegats = mttDegats;
            this.Effet = effet;
        }
    }
}
