using System.Collections.Generic;
using ProgamObiektoweZadanieDomowe.Models;
using ProgamObiektoweZadanieDomowe.SharedKernel.Interfaces;

namespace ProgamObiektoweZadanieDomowe.Controllers
{
    public class IngredientController
    {
        private IRepository _repository;
        public IngredientController(IRepository repository)   
        {
            _repository = repository;
        }
        public List<Ingredient> GetIngredients()
        {
            return _repository.GetIngredients();
        }
        public void AddIngredient(string name, int calories=0)
        {
            _repository.AddIngredient(new Ingredient(name, calories));
        }
        public bool IsNew(string name)
        {
            foreach (var item in GetIngredients())
            {
                if (item.Name == name) return false;
            }
            return true;
        }
    }
}
