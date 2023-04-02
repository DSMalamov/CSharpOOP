using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        private const double Gprice = 4;
        public Gingerbread(string delicacyName) 
            : base(delicacyName, Gprice)
        {
        }

    }
}
