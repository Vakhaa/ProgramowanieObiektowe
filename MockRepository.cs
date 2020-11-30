using System;
using System.Collections.Generic;
using System.Text;
using ProgamObiektoweZadanieDomowe.Models;
using ProgamObiektoweZadanieDomowe.SharedKernel;
using ProgamObiektoweZadanieDomowe.SharedKernel.Interfaces;

namespace ProgamObiektoweZadanieDomowe
{
    class MockRepository: IRepository
    {
        private List<Ingredient> _ingredients;
        private List<Recipe> _recipes;

        public MockRepository()
        {

            _ingredients = new List<Ingredient>{
            new Ingredient("Sol"),
            new Ingredient("Ziemniaki", 82),
            new Ingredient("Mleko 2,5%", 54)
            };
            _recipes = new List<Recipe>();
        }

        public void AddIngredient(Ingredient entity)
        {
            _ingredients.Add(entity);
        }

        public void AddRecipe(Recipe entity)
        {
            _recipes.Add(entity);
        }

        public List<Ingredient> GetIngredients()
        {
            return _ingredients;
        }
        public List<Recipe> GetRecipes()
        {
            return _recipes;
        }
    }
}
