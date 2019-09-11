using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioJdr.metier
{
    /// <summary>
    /// Classe correspondant au personnage d'un joueur
    /// </summary>
    [Table("Personnage")]
    public class Personnage : IPersonnage
    {
        
        /// <summary>
        /// Nom du personnage
        /// </summary>
        [Key]
        public string Nom { get; set; }
        /// <summary>
        /// Niveau actuel du personnage
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// Classe du personnage
        /// </summary>
        public string Classe { get; set; }
        /// <summary>
        /// Liste des statistiques du personnage
        /// </summary>
        private List<Stat> lesStats=new List<Stat>();
        /// <summary>
        /// Liste des statistiques du personnage en lecture seul
        /// </summary>
        [NotMapped]
        public IEnumerable<Stat> ROCStats { get; }
        /// <summary>
        /// Piece d'or que possede le personnage
        /// </summary>
        public int Po { get; set; }
        /// <summary>
        /// Liste des objets que possède le personnage
        /// </summary>
        //[NotMapped]
        private List<Item> inventaire = new List<Item>();
        /// <summary>
        /// Liste des objets du personnage en lecture seul
        /// </summary>
        [NotMapped]
        public IEnumerable<Item> ROCInventaire { get; }
        /// <summary>
        /// Liste de sort que possede le personnage
        /// </summary>
        [NotMapped]
        private List<Sort> lesSorts= new List<Sort>();
        /// <summary>
        /// Liste des sorts du personnage en lecture seul
        /// </summary>
        [NotMapped]
        public IEnumerable<Sort> ROCSorts { get; }
        /// <summary>
        /// Points d'experience maximum avant le passage de niveau du personnage
        /// </summary>
        public int XpMax { get; set; }
        /// <summary>
        /// Ponts d'experience actuel du personnage
        /// </summary>
        public int XpEnCours { get; set; }
        /// <summary>
        /// Arme actuellement equipe par le personnage
        /// </summary>
        [NotMapped]
        public Arme ArmeEquipe { get; set; }   
        /// <summary>
        /// Armure actuellement equipe par le personnage
        /// </summary>
        [NotMapped]
        public Armure ArmureEquipe { get; set; }
        /// <summary>
        /// Constructeur de personnage
        /// </summary>
        /// <param name="nom">nom du personnage</param>
        /// <param name="classe">classe du personnage</param>
        /// <param name="po">pièce d'or du personnage</param>
        /// <param name="armeDepart">arme de depart du personnage</param>
        /// <param name="armureDepart">armure de depart du personnage</param>
        public Personnage(string nom, string classe, int po, Arme armeDepart, Armure armureDepart)
        {
            this.Nom = nom;
            this.Classe = classe;
            this.ROCStats = new ReadOnlyCollection<Stat>(lesStats);
            this.Po = po;
            this.ROCInventaire = new ReadOnlyCollection<Item>(inventaire);
            this.Level = 1;
            this.ROCSorts = new ReadOnlyCollection<Sort>(lesSorts);
            this.XpMax = 10;
            this.XpEnCours = 0;
            this.ArmeEquipe = armeDepart;
            this.ArmureEquipe = armureDepart;
        }

        /// <summary>
        /// Constructeur de personnage
        /// </summary>
        /// <param name="nom">nom du personnage</param>
        /// <param name="classe">classe du personnage</param>
        /// <param name="po">pièce d'or du personnage</param>
        public Personnage(string nom, string classe, int po)
        {
            this.Nom = nom;
            this.Classe = classe;
            this.ROCStats = new ReadOnlyCollection<Stat>(lesStats);
            this.Po = po;
            this.ROCInventaire = new ReadOnlyCollection<Item>(inventaire);
            this.Level = 1;
            this.ROCSorts = new ReadOnlyCollection<Sort>(lesSorts);
            this.XpMax = 10;
            this.XpEnCours = 0;
            this.ArmeEquipe = new Arme("Baton de berger émoussé",1,"Baisse de charisme",1);
            this.ArmureEquipe = new Armure("Slip",12,"Cache les couilles",1);
        }

        /// <summary>
        /// Ajoute de l'experience au personnage et augmente son niveau en conséquence
        /// </summary>
        /// <param name="mtt">Montant d'xp gagné</param>
        public void GainXp(int mtt)
        {
            XpEnCours += mtt;
            while (XpEnCours>=XpMax)
            {
                Level += 1;
                XpEnCours = XpEnCours - XpMax;
                XpMax += 5;
            }
        }


        /// <summary>
        /// Ajouter une nouvelle statistique au personnage
        /// </summary>
        /// <param name="uneStat">La nouvelle statistique</param>
        public void AjouterStat(Stat uneStat)
        {
            lesStats.Add(uneStat);
        }

        /// <summary>
        /// Ajouter un sort au personnage
        /// </summary>
        /// <param name="unSort">Le nouveau sort</param>
        public void AjouterSort(Sort unSort)
        {
            lesSorts.Add(unSort);
        }
        /// <summary>
        /// Ajouter un item au personnage
        /// </summary>
        /// <param name="unItem">Le nouvel item</param>
        public void AjouterItem(Item unItem)
        {
            inventaire.Add(unItem);
        }

        /// <summary>
        /// Supprimer un item
        /// </summary>
        /// <param name="unItem">item à supprimer</param>
        public void DelItem(Item unItem)
        {
            inventaire.Remove(unItem);
        }
        /// <summary>
        /// Modifier une statistique du personnage
        /// </summary>
        /// <param name="lastat">La statistique à modifier</param>
        /// <param name="valeur">La valeur à ajouter</param>
        public void EditStat(Stat lastat,  int valeur)
        {
            lesStats.Find(stat => stat == lastat).AjouterPoint(valeur);
        }
        /// <summary>
        /// Permet au personnage de lancer un sort
        /// </summary>
        /// <param name="s">Le sort à lancer</param>
        /// <param name="lesEnnemis">Les ennemis ciblés</param>
        public void CasterSort(Sort s, List<Ennemi> lesEnnemis)
        {
            lesStats.Find(stat => stat.Nom == "Mana").PerdrePoint(s.CoutMana);
            foreach (Ennemi e in lesEnnemis)
            {
                e.FindStat("PV").PerdrePoint(Dice.lancerDe(s.MontantDommage));
            }
        }
        /// <summary>
        /// Permet au personnage de lancer un sort
        /// </summary>
        /// <param name="s">Le sort à lancer</param>
        /// <param name="e">L'ennemi ciblé</param>
        public void CasterSort(Sort s, Ennemi e)
        {
            lesStats.Find(stat => stat.Nom == "Mana").PerdrePoint(s.CoutMana);
            e.FindStat("PV").PerdrePoint(Dice.lancerDe(s.MontantDommage));
        }

        /// <summary>
        /// Permet au personnage d'attaquer avec son arme
        /// </summary>
        /// <param name="e">L'ennemi attaqué</param>
        public void Attaquer(Ennemi e)
        {
            e.FindStat("PV").PerdrePoint(Dice.lancerDe(ArmeEquipe.MttDegats));
        }

        /// <summary>
        /// Permet de recuperer une statistique dans la liste a partir de son nom
        /// </summary>
        /// <param name="nomStat">nom de la statistique rechercher</param>
        /// <returns></returns>
        public Stat FindStat(string nomStat)
        {
            Stat laStat = lesStats.Find(stat => stat.Nom == nomStat);
            return laStat;
        }

        /// <summary>
        /// Permet d'ajouter des pieces d'or au personnage
        /// </summary>
        /// <param name="mtt">montant a ajouter</param>
        public void AjouterPO(int mtt)
        {
            Po += mtt;
        }

        /// <summary>
        /// Permet de retirer des pieces d'or au personnage
        /// </summary>
        /// <param name="mtt">monter a retirer</param>
        public void RetirerPO(int mtt)
        {
            Po -= mtt;
        }

    }
}
