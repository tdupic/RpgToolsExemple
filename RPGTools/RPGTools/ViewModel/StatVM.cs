using BiblioJdr;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RPGTools.ViewModel
{
    public class StatVM : BaseViewModel
    {
        private Stat model_;

        private string name_;
        public string Name
        {
            get => name_;
            set => SetValue(ref name_, value);
        }

        private int value_;
        public int Value
        {
            get => value_;
            set => SetValue(ref value_, value);
        }

        private Color colorCell_;
        public Color ColorCell
        {
            get => colorCell_;
            set => SetValue(ref colorCell_, value);
        }

        public StatVM(string name, int value)
        {
            model_ = new Stat(name, value);
            Name = name;
            Value = value;
            ColorCell = Color.GhostWhite;
        }

        public StatVM(Stat inModel)
        {
            model_ = inModel;
            ColorCell = Color.GhostWhite;
            Name = model_.Nom;
            Value = model_.Valeur;
        }
            
        public Stat GetModel()
        {
            return model_;
        }

        public void Upgrade()
        {
            if(Value<100)
                 Value = Value + 1;
        }

        public void Downgrade()
        {
            if(Value>0)
                Value = Value - 1;
        }

        override public string ToString()
        {
            return (Name + " : \t " + Value);
        }
    }
}
