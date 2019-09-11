using BiblioJdr.metier;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace BiblioJdr
{
    /// <summary>
    /// Classe abstraite Item
    /// </summary>
    [Table("Item")]
    public abstract class Item : IItem
    {
        /// <summary>
        /// Id autogénéré de l'item
        /// </summary>
        
        //public Guid Id { get; }
        /// <summary>
        /// Nom de l'item
        /// </summary>
        [Key]
        public string Nom { get; set; }
        /// <summary>
        /// Qte item 
        /// </summary>
        public int Qte { get; set; }
        /// <summary>
        /// Constructeur d'item
        /// </summary>
        /// <param name="nom">nom de l'item</param>
        /// <param name="qte">qt de l'item</param>
        public Item(string nom, int qte)
        {
            this.Nom = nom;
            Qte = qte;
        }
    }
}
