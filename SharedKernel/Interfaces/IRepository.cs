using ProgamObiektoweZadanieDomowe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgamObiektoweZadanieDomowe.SharedKernel.Interfaces
{
    public interface IRepository
    {
        List<Ingredient> GetIngredients();
        List<Recipe> GetRecipes();
        void AddIngredient(Ingredient entity);
        void AddRecipe(Recipe entity);
    }
}
