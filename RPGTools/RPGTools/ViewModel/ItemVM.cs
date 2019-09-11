using BiblioJdr;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RPGTools.ViewModel
{
    public class ItemVM : BaseViewModel
    {
        private PersoVM proprietaire;
        public void SetProp(PersoVM p)
        {
            proprietaire = p;
        }

        private string nom_;
        public string Nom
        {
            get => nom_;
            set => SetValue(ref nom_, value);
        }

        private int mtt_;
        public int Mtt
        {
            get => mtt_;
            set => SetValue(ref mtt_, value);
        }

        private string effet_;
        public string Effet
        {
            get => effet_;
            set => SetValue(ref effet_, value);
        }

        private int quantite_;
        public int Quantite
        {
            get => quantite_;
            set => SetValue(ref quantite_, value);
        }

        private bool hasMtt_;
        public bool HasMtt
        {
            get => hasMtt_;
            set => SetValue(ref hasMtt_, value);
        }

        private bool haEffet_;
        public bool HasEffet
        {
            get => haEffet_;
            set => SetValue(ref haEffet_, value);
        }

        private Item model_;
        public Item Model
        {
            get => model_;
            set => SetValue(ref model_, value);
        }

        private string icon_;
        public string Icon
        {
            get => icon_;
            set => SetValue(ref icon_, value);
        }

        private Color color_;
        public Color Color
        {
            get => color_;
            set => SetValue(ref color_, value);
        }

        public ICommand UseItemCmd { get; private set; }

        public ItemVM(Item model)
        {
            UseItemCmd = new Command(UseItem);
            Model = model;
            Nom = model.Nom;
            Quantite = model.Qte;
            SetItemProperty(model);
            Color = Color.White;
        }

       

        private void SetItemProperty(Item model)
        {
            if(model.GetType() == typeof(Arme))
            {
                Icon = "shield.png";
                Arme modelAsArme = model as Arme;
                Effet = modelAsArme.Effet;
                Mtt = modelAsArme.MttDegats;
                HasEffet = true;
                HasMtt = true;
            }
            else if(model.GetType() == typeof(Armure))
            {
                Icon = "armour.png";
                Armure modelAsArmure = model as Armure;
                Effet = modelAsArmure.Effet;
                Mtt = modelAsArmure.MttDefense;
                HasEffet = true;
                HasMtt = true;
            }
            else if(model.GetType() == typeof(Potion))
            {
                Icon = "potion.png";
                Potion modelAsPotion = model as Potion;
                Effet = modelAsPotion.Effet;
                HasEffet = true;
                HasMtt = false;
            }
            else if(model.GetType() == typeof(Nouriture))
            {
                Icon = "meat.png";
                HasEffet = false;
                HasMtt = false;
            }
            else if(model.GetType() == typeof(Divers))
            {
                Icon = "lighter.png";
                HasEffet = false;
                HasMtt = false;
            }
        }

        private void UseItem()
        {
            if (Model.GetType() == typeof(Arme) && proprietaire.ArmeEquipe != this)
            {
                if (proprietaire.ArmeEquipe != null)
                {
                    proprietaire.ArmeEquipe.Color = Color.White;
                }
                this.Color = Color.Green;
                proprietaire.ArmeEquipe = this;

            }
            else if (Model.GetType() == typeof(Armure) && proprietaire.ArmureEquipe != this)
            {
                if (proprietaire.ArmureEquipe != null)
                {
                    proprietaire.ArmureEquipe.Color = Color.White;
                }
                this.Color = Color.Green;
                proprietaire.ArmureEquipe = this;
            }
            else
            {
                Quantite = Quantite - 1;
                if (Quantite == 0)
                {
                    proprietaire.Inventaire.Remove(this);
                }
                
            }
            App.Current.MainPage.Navigation.PopAsync();
        }

    }
}
