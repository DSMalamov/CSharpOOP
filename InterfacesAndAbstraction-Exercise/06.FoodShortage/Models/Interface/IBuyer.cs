using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage.Models.Interface
{
    public interface IBuyer
    {
        public string Name { get; }
        public int Age { get; }
        void BuyFood();
        public int Food { get;}
    }
}
