using System;
using System.Collections.Generic;
using System.Text;
using ProgamObiektoweZadanieDomowe.Models;
using ProgamObiektoweZadanieDomowe.SharedKernel.Interfaces;

namespace ProgamObiektoweZadanieDomowe.Controllers
{
    public class RecipeController
    {
        private IRepository _repository;
        public RecipeController(IRepository repository)
        {
            _repository = repository;
        }
        public List<Recipe> GetRecipes()
        {
            return _repository.GetRecipes();
        }
        public void AddRecipe(string name, List<Ingredient> ingredients, List<string> countIngredients, List<string> descriptions)
        {
            _repository.AddRecipe(new Recipe(name, ingredients, countIngredients, descriptions));
        }
        public bool IsNew(string name)
        {
            foreach (var item in GetRecipes())
            {
                if (item.Name == name) return false;
            }
            return true;
        }
    }
}
