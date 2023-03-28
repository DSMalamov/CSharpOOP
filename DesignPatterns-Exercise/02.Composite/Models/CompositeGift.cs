using _02.Composite.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Composite.Models
{
    internal class CompositeGift : GiftBase, IGiftOperations
    {
        private ICollection<GiftBase> gifts;

        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            gifts= new List<GiftBase>();
        }

        public void Add(GiftBase gift)
            => gifts.Add(gift);

        public void Remove(GiftBase gift)
            => gifts.Remove(gift);

        public override int CalculateTotalPrice()
        {
            int total = 0;

            Console.WriteLine($"{Name} contains the fallowing products with prices:");

            foreach (var item in gifts)
            {
                total += item.CalculateTotalPrice();
            }

            return total;
        }

    }
}
