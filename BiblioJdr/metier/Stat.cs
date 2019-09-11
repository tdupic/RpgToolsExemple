using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioJdr
{
    /// <summary>
    /// Classe correspondant au statistique
    /// </summary>
    public class Stat
    {
        /// <summary>
        /// Valeur de la statistique
        /// </summary>
        public int Valeur { get; set; }
        /// <summary>
        /// Nom de la statistique
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Constructeur de la stat
        /// </summary>
        /// <param name="nom">nom de la nouvelle statistique</param>
        /// <param name="valeur"> valeur de la nouvelle statistique</param>
        public Stat(string nom, int valeur)
        {
            this.Nom = nom;
            this.Valeur = valeur;
        }
        /// <summary>
        /// Ajoute des points à la valeur actuelle de la statistique
        /// </summary>
        /// <param name="nbPoints"> nombre de points supplémentaires</param>
        public void AjouterPoint(int nbPoints)
        {
            Valeur += nbPoints;
            if (Valeur > 100)
            {
                Valeur = 100;
            }
        }
        /// <summary>
        /// Enleve des points à la valeur de la statistique actuelle
        /// </summary>
        /// <param name="nbPoints"> nombre de points à enlever</param>
        public void PerdrePoint(int nbPoints)
        {
            Valeur -= nbPoints;
            if (Valeur < 0)
            {
                Valeur = 0;
            }
        }
    }
}
