using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioJdr.metier
{
    public interface IItem
    {
        //Guid Id { get;}

        string Nom
        { get; set; }
        int Qte { get; set; }
    }
}
