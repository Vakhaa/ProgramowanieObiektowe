using ProgamObiektoweZadanieDomowe.Controllers;
using ProgamObiektoweZadanieDomowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgamObiektoweZadanieDomowe
{
    class Program
    {
        static void Main(string[] args)
        {
            MockRepository repository = new MockRepository();
            IngredientController ic = new IngredientController(repository);
            RecipeController rc = new RecipeController(repository);
            Console.WriteLine("Hello World!");
            while(true)
            {
                try
                {
                    Console.Clear();
                    var recipes = rc.GetRecipes();
                    Console.WriteLine($"Masz {recipes.Count} recepta");
                    foreach (var item in recipes)
                    {
                        Console.WriteLine($"{item.Id}. {item.Name}");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Rzeby dodac nacisn \"A\""); //Add
                    Console.WriteLine("Rzeby odkryc nacisn \"D\""); //Display
                    Console.WriteLine("Rzeby wyjsc \"E\""); //Exit
                    var answer = Console.ReadKey();
                    Console.WriteLine();
                    switch (answer.Key)
                    {
                        case ConsoleKey.A :
                            DisplayRecipe(AddRecipe(ic, rc));
                        break;
                        case ConsoleKey.D:
                            Console.WriteLine("Napish id recepta:");
                            int.TryParse(Console.ReadLine(), out int result);
                            DisplayRecipe(recipes.First(i=>i.Id==result));
                            break;
                        case ConsoleKey.E:
                            Environment.Exit(0);
                            break;
                    }
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static Recipe AddRecipe(IngredientController ic, RecipeController rc)
        {
            Console.Clear();
            var ingredients = new List<Ingredient>();
            var countIngredients = new List<string>();
            var description = new List<string>();
            int count;
            string answer;
            bool isText = false;

            Console.WriteLine("Nazwa recepta: ");
            var recipeName = Console.ReadLine();
            Console.WriteLine("Ile chcesz dodac ingredientow ? ");
            
            do {
                isText= int.TryParse(Console.ReadLine(), out count);
            }
            while (!isText);

            for(int i=0; i < count; i++)
            {
                Console.WriteLine("Dodaj ingredient:");
                answer = Console.ReadLine();
                if (ic.IsNew(answer))
                {
                    ic.AddIngredient(answer);
                    ingredients.Add(new Ingredient(answer));
                }
                else
                {
                    ingredients.Add(new Ingredient(answer));
                }
                Console.WriteLine($"Dodaj ilość {answer}:");
                countIngredients.Add(Console.ReadLine());
            }
            Console.WriteLine("Ile chcesz dodac krokow przygotowania ? ");
            do
            {
                isText = int.TryParse(Console.ReadLine(), out count);
            }
            while (!isText);

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Dodaj krok:");
                description.Add(Console.ReadLine());
            }
            rc.AddRecipe(recipeName, ingredients, countIngredients, description);
            var recipes = rc.GetRecipes();
            return recipes.FirstOrDefault(i=>i.Name==recipeName);
        }
        public static void DisplayRecipe(Recipe recipe)
        {
            Console.Clear();
            Console.WriteLine($"Nazwa: {recipe.Name}");
            Console.WriteLine("Description:");
            foreach (var item in recipe.Description)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < recipe.Ingredients.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + recipe.Ingredients[i].Name + " - " + recipe.CountIngredietns[i]);
            }
        }
    }
}
