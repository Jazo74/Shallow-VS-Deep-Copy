using System;
using System.Collections.Generic;

namespace ShallowVSDeepCopy
{
    class Program
    {
        static List<Recipe> recipeList = new List<Recipe>();
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                Menu();
                loop = Choose();
            }
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("(1) Making a recipe");
            Console.WriteLine("(2) Preload 5 recipes");
            Console.WriteLine("(3) Showing all recipes");
            Console.WriteLine("(4) Cloning a recipe");
            Console.WriteLine("(5) Changing a recipe");
            Console.WriteLine("(6) Exit program");
        }
        public static bool Choose()
        {
            string choice = AnyInput("Choose an option: ");
            switch (choice)
            {
                case "1":
                    Console.WriteLine();
                    NewRecipe();
                    return true;
                case "2":
                    PreLoad();
                    return true;
                case "3":
                    Console.WriteLine();
                    foreach (Recipe recipe in recipeList)
                    {
                        Console.WriteLine(recipe.ToString());
                    }
                    AnyInput("Press any key to continue...");
                    return true;
                case "4":
                    Console.WriteLine();
                    int id = JustNumber("Give me the ID of the recipe you want to clone: ");
                    bool found = false;
                    Recipe newRecipe = new Recipe();
                    for (int i = 0; i<recipeList.Count; i++)
                    {
                        if (recipeList[i].id == id)
                        {
                            newRecipe = recipeList[i].Clone();
                            found = true;
                        }
                    }
                    if (found)
                    {
                        recipeList.Add(newRecipe);
                    }
                    else
                    {
                        Console.WriteLine("There is no such recipe with this ID!");
                    }
                    return true;
                case "5":
                    Console.WriteLine();
                    int id2 = JustNumber("Give me the ID of the recipe you want to change: ");
                    bool found2 = false;
                    for (int i = 0; i < recipeList.Count; i++)
                    {
                        if (recipeList[i].id == id2)
                        {
                            recipeList[i].id = JustNumber("Give me the new ID: ");
                            recipeList[i].Name = AnyInput("Give me the new name: ");
                            List<string> keyList = new List<string>();
                            foreach (KeyValuePair<string, string> item in recipeList[i].Ingredients)
                            {
                                keyList.Add(item.Key);
                            }
                            foreach (string key in keyList)
                            {
                                Console.Write(key + " - ");
                                Console.WriteLine(recipeList[i].Ingredients[key]);
                                recipeList[i].Ingredients[key] = AnyInput("Give me the new quantity: ");
                            }
                            break;
                        }
                    }
                    if (!found2)
                    {
                        Console.WriteLine("There is no such recipe with this ID!");
                    }
                    return true;
                case "6":
                    Console.WriteLine("Bye, bye!");
                    return false;
                default:
                    Console.WriteLine("Wrong option!");
                    return true;
            }
        }
        public static void NewRecipe()
        {
            string recipeName = AnyInput("The name of the recipe?: ");
            Console.WriteLine();
            Dictionary<string, string> ingredients = new Dictionary<string, string>();
            while (true)
            {
                string ingredient = AnyInput("Give me an ingredient or just hit enter to finish it: ");
                string quantity = AnyInput("Give me the quantity with the unit of measurement: ");
                if (ingredient.Length != 0)
                {
                    ingredients.Add(ingredient, quantity);
                }
                else
                {
                    break;
                }
            }
            Recipe newRecipe = new Recipe(recipeName,ingredients);
            recipeList.Add(newRecipe);
        }
        public static void PreLoad()
        {
            Recipe newRecipe = new Recipe();
            newRecipe.id = 1;
            newRecipe.Name = "Omelett";
            newRecipe.Ingredients.Add("Egg", "2 pieces");
            newRecipe.Ingredients.Add("Cheese", "10 dkg");
            newRecipe.Ingredients.Add("Flour", "5 dkg");
            newRecipe.Ingredients.Add("Salt", "a pinch");
            recipeList.Add(newRecipe);

            Recipe newRecipe2 = new Recipe();
            newRecipe2.id = 2;
            newRecipe2.Name = "Pancake";
            newRecipe2.Ingredients.Add("Egg", "2 pieces");
            newRecipe2.Ingredients.Add("Flour", "10 dkg");
            newRecipe2.Ingredients.Add("Vegetable oil", "a tablespoon");
            newRecipe2.Ingredients.Add("Salt", "a pinch");
            recipeList.Add(newRecipe2);

            Recipe newRecipe3 = new Recipe();
            newRecipe3.id = 3;
            newRecipe3.Name = "Pasta";
            newRecipe3.Ingredients.Add("Egg", "2 pieces");
            newRecipe3.Ingredients.Add("Flour", "50 dkg");
            newRecipe3.Ingredients.Add("Salt", "a pinch");
            recipeList.Add(newRecipe3);

            Recipe newRecipe4 = new Recipe();
            newRecipe4.id = 4;
            newRecipe4.Name = "Ham & Eggs";
            newRecipe4.Ingredients.Add("Egg", "2 pieces");
            newRecipe4.Ingredients.Add("Ham or bacon", "10 dkg");
            newRecipe4.Ingredients.Add("Pork fett or vegetable oil", "1 tablespoon");
            newRecipe4.Ingredients.Add("Salt", "a pinch");
            newRecipe4.Ingredients.Add("Seasoning", "some");
            recipeList.Add(newRecipe4);

            Recipe newRecipe5 = new Recipe();
            newRecipe5.id = 5;
            newRecipe5.Name = "Mashed potato";
            newRecipe5.Ingredients.Add("Potato", "60 dkg");
            newRecipe5.Ingredients.Add("Butter", "10 dkg");
            newRecipe5.Ingredients.Add("Milk or sour cream", "2 tablespoon");
            newRecipe5.Ingredients.Add("Salt", "a pinch");
            newRecipe5.Ingredients.Add("Seasoning", "a pinch");
            recipeList.Add(newRecipe5);
        }
        public static int JustNumber(string inputMessage)
        {
            int number;
            string input;
            while (true)
            {
                Console.Write(inputMessage);
                input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    return int.Parse(input);
                }
                else
                {
                    Console.WriteLine("It is not a number!");
                }
            }
        }
        public static float JustFloat(string inputMessage)
        {
            float number;
            string input;
            while (true)
            {
                Console.Write(inputMessage);
                input = Console.ReadLine();
                if (float.TryParse(input, out number))
                {
                    return float.Parse(input);
                }
                else
                {
                    Console.WriteLine("It is not a number!");
                }
            }
        }
        public static string AnyInput(string inputMessage)
        {
            Console.Write(inputMessage);
            return Console.ReadLine();
        }
        public static bool BoolInput(string inputMessage)
        {
            while (true)
            {
                Console.Write(inputMessage);
                string input = Console.ReadLine().ToLower();
                if (input == "y" || input == "yes")
                {
                    return true;
                }
                else if (input == "n" || input == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Wrong answer!");
                }
            }
        }
    }
}
