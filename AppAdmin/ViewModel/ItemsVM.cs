using BiblioJdr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAdmin.ViewModel
{
    public class ItemsVM : BaseViewModel
    {
        private string _nom;
        public string Nom
        {
            get => _nom;
            set => SetValue(ref _nom, value);
        }

        private string _type;
        public string Type
        {
            get => _type;
            set => SetValue(ref _type, value);
        }

        public string Display
        {
            get => Type + " : " + Nom;
        }

        private Item _model;
        public Item Model
        {
            get => _model;
            set => SetValue(ref _model, value);
        }

        public ItemsVM(Item i)
        {
            Model = i;
            Nom = i.Nom;
            Type = i.GetType().Name;
        }
    }
}
