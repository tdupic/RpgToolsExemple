using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioJdr.metier
{
    public interface IPersonnage
    {
        string Nom { get; set; }
        string Classe { get; set; }
        int Level { get; set; }
        IEnumerable<Stat> ROCStats { get; }
        int Po { get; set; }
        IEnumerable<Item> ROCInventaire { get; }
        IEnumerable<Sort> ROCSorts { get; }
        int XpMax { get; set; }
        int XpEnCours { get; set; }
        Arme ArmeEquipe { get; set; }
        Armure ArmureEquipe { get; set; }
    }
}
