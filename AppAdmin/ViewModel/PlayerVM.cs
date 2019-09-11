using BiblioJdr;
using BiblioJdr.metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAdmin.ViewModel
{
    public class PlayerVM : BaseViewModel
    {
        private string _nom;
        public string Nom
        {
            get => _nom;
            set => SetValue(ref _nom, value);
        }

        private string _classe;
        public string Classe
        {
            get => _classe;
            set => SetValue(ref _classe, value);
        }

        private int _level;
        public int Level
        {
            get => _level;
            set => SetValue(ref _level, value);
        }

        public string Display
        {
            get => Nom + ", " + Classe + " Level : " + Level;
        }


        private Personnage _model;
        public Personnage Model
        {
            get => _model;
            set => SetValue(ref _model, value);
        }

        public PlayerVM(Personnage p)
        {
            Model = p;
            Nom = p.Nom;
            Level = p.Level;
            Classe = p.Classe;
        }
    }
}
