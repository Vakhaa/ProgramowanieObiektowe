using System;
using ProgamObiektoweZadanieDomowe.SharedKernel;

namespace ProgamObiektoweZadanieDomowe.Models
{
    public class Ingredient : BaseEntity
    {
        private static int counter=0;
        public int Calories { get; set; }
        public Ingredient (string name, int calories=0):this(calories)
        {
            Name = name;
            counter++;
            Id = counter;
        }
        public Ingredient(int calories=0)
        {
            Calories = calories;
        }
    }
}
