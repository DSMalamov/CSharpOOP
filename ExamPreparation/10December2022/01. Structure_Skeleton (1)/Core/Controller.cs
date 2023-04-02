using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;

            Booth booth = new Booth(boothId, capacity);

            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded,boothId, capacity);
        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy;
            if (booths.Models.Any(d => d.DelicacyMenu.Models.Any(d => d.Name == delicacyName) ))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            if (delicacyTypeName == nameof(Gingerbread))
            {
                 delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                 delicacy = new Stolen(delicacyName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId== boothId);

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(MulledWine) && cocktailTypeName != nameof(Hibernation))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booths.Models.Any(c => c.CocktailMenu.Models.Any(n => n.Name == cocktailName && n.Size == size)))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            ICocktail cocktail;
            if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                cocktail = new Hibernation(cocktailName, size);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            var oBooth = booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (oBooth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth,countOfPeople);
            }

            oBooth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, oBooth.BoothId, countOfPeople);
        }
        public string TryOrder(int boothId, string order)
        {
            string[] orderEl = order.Split("/");
            string itemTypeName = orderEl[0];
            string itemName = orderEl[1];
            int orderdPieces = int.Parse(orderEl[2]);

            if (itemTypeName != nameof(Hibernation) && itemTypeName != nameof(MulledWine)
                && itemTypeName != nameof(Gingerbread) && itemTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (!booth.CocktailMenu.Models.Any(m => m.Name == itemName) &&
                !booth.DelicacyMenu.Models.Any(m => m.Name == itemName))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            if (orderEl.Length == 4)
            {
                string cocktailSize = orderEl[3];
                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(b => b.Name == itemName
                && b.GetType().Name == itemTypeName && b.Size == cocktailSize);

                if (cocktail == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, cocktailSize, itemName);
                }

                booth.UpdateCurrentBill(orderdPieces * cocktail.Price);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, orderdPieces, itemName);
            }
            else
            {
                var delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName 
                && d.GetType().Name == itemTypeName);

                if (delicacy == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                booth.UpdateCurrentBill(orderdPieces * delicacy.Price);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, orderdPieces, itemName);
            }
        }

        public string BoothReport(int boothId)
        {
            return booths.Models.FirstOrDefault(b => b.BoothId == boothId).ToString().TrimEnd();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId== boothId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");

            booth.Charge();
            booth.ChangeStatus();

            sb.AppendLine(string.Format(OutputMessages.BoothIsAvailable, boothId));

            return sb.ToString().Trim();
        }


    }
}
