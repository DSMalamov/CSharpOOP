﻿using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private readonly List<ICocktail> cocktails;
        public CocktailRepository()
        {
            cocktails = new List<ICocktail>();
        }
        public IReadOnlyCollection<ICocktail> Models => cocktails;

        public void AddModel(ICocktail model)
        {
            cocktails.Add(model);
        }
    }
}
