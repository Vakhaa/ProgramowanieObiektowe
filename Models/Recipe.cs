using System.Collections.Generic;
using System;
using ProgamObiektoweZadanieDomowe.SharedKernel;

namespace ProgamObiektoweZadanieDomowe.Models
{
    public class Recipe :BaseEntity
    {
        private static int counter = 0;
        public List<Ingredient> Ingredients { get; set; }
        public List<string> CountIngredietns { get; set; }
        public List<string> Description { get; set; }
        public Recipe(string name, List<Ingredient> ingredients, List<string> countIngredietns, List<string> description):this(ingredients,countIngredietns,description)
        {
            Name = name;
        }
        public Recipe(List<Ingredient> ingredients, List<string> countIngredietns, List<string> description)
        {
            if (ingredients == null)
            {
                throw new ArgumentNullException(nameof(ingredients), "Ingredients can't be null");
            }
            if (countIngredietns == null)
            {
                throw new ArgumentNullException(nameof(countIngredietns), "Count ingredietns can't be null");
            }
            if (description == null)
            {
                throw new ArgumentNullException(nameof(description), "Description can't be null");
            }
            counter++;
            Id = counter;
            Ingredients = ingredients;
            CountIngredietns = countIngredietns;
            Description = description;
        }
    }
}
