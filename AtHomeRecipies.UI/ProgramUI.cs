using AtHomeRecipes.Data;
using AtHomeRecipes.Repository;
using static System.Console;

namespace AtHomeRecipies.UI
{
    public class ProgramUI
    {
        private readonly RecipeRepository _recRepo = new RecipeRepository();
        private readonly IngredientRepository _iRepo = new IngredientRepository();
        public void Run()
        {
            Seed();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Clear();
                WriteLine("Welcome to At Home Recipies!\n" +
                "Please make a selection.\n" +
                "1.  Add new Ingredient \n" +
                "2.  Get All Ingredients\n" +
                "3.  Get Ingredient by Id\n" +
                "4.  Update Ingredient\n" +
                "5.  Delete Ingredient\n" +
                "==================================\n" +
                "6.  Add New Recipe\n" +
                "7.  Get All Recipies\n" +
                "8.  Get Recipe by Id\n" +
                "9.  Update Recipe\n" +
                "10. Delete Recipe\n" +
                "00. Close Application\n");

                string userInput = ReadLine()!;

                switch (userInput)
                {
                    case "1":
                        AddNewIngredient();
                        break;
                    case "2":
                        GetAllIngredients();
                        break;
                    case "3":
                        GetIngredientById();
                        break;
                    case "4":
                        UpdateIngredient();
                        break;
                    case "5":
                        DeleteIngredient();
                        break;
                    case "6":
                        AddNewRecipe();
                        break;
                    case "7":
                        GetAllRecipies();
                        break;
                    case "8":
                        GetRecipebyId();
                        break;
                    case "9":
                        UpdateRecipe();
                        break;
                    case "10":
                        DeleteRecipe();
                        break;
                    case "00":
                        isRunning = CloseApplication();
                        break;
                    default:
                        WriteLine("Invalid Selection.");
                        break;
                }
            }
        }

        private bool CloseApplication()
        {
            Clear();
            WriteLine("Thanks for using the app!");
            PressAnyKey();
            return false;
        }

        private void PressAnyKey()
        {
            WriteLine("Press Any Key to continue.");
            ReadKey();
        }

        private void DeleteRecipe()
        {
            throw new NotImplementedException();
        }

        private void UpdateRecipe()
        {
            throw new NotImplementedException();
        }

        private void GetRecipebyId()
        {
            throw new NotImplementedException();
        }

        private void GetAllRecipies()
        {
            throw new NotImplementedException();
        }

        private void AddNewRecipe()
        {
            throw new NotImplementedException();
        }

        private void DeleteIngredient()
        {
            Clear();
            WriteLine("Please enter the Ingredient Id:");
            var userInput = int.Parse(ReadLine()!);
            var ing = _iRepo.GetIngredientById(userInput);
            if (ing != null)
            {
                bool isSuccess = _iRepo.DeleteExistingIngredient(ing.Id);
                if (isSuccess == true)
                {
                    WriteLine($"{ing.Name} was Deleted!");
                }
                else
                {
                    WriteLine("Fail!");
                }

            }
            ReadKey();
        }

        private void UpdateIngredient()
        {
            Clear();
            WriteLine("Please enter the Ingredient Id:");
            var userInput = int.Parse(ReadLine()!);

            var oldIngredientData = _iRepo.GetIngredientById(userInput);

            if (oldIngredientData != null)
            {
                Clear();
                Ingredient newIngredientData = new Ingredient();

                WriteLine("Please enter the ingredient Name: ");
                newIngredientData.Name = Console.ReadLine();

                WriteLine("Please enter the ingredient Description: ");
                newIngredientData.Description = Console.ReadLine();

                WriteLine("Please enter the Protiens: ");
                newIngredientData.Protein = int.Parse(Console.ReadLine());

                WriteLine("Please enter the Calories: ");
                newIngredientData.Calories = int.Parse(Console.ReadLine());

                WriteLine("Please enter the Saturated Fat: ");
                newIngredientData.SaturatedFat = int.Parse(Console.ReadLine());

                WriteLine("Please enter the Sugar: ");
                newIngredientData.Sugar = int.Parse(Console.ReadLine());

                //add to the database _iRepo
                bool isSuccess = _iRepo.UpdateIngredientData(oldIngredientData.Id, newIngredientData);

                if (isSuccess)
                {
                    WriteLine("Success");
                }
                else
                {
                    WriteLine("Fail");
                }
            }
            ReadKey();
        }

        private void GetIngredientById()
        {
            Clear();
            WriteLine("Please enter the Ingredient Id:");
            var userInput = int.Parse(ReadLine()!);
            var ing = _iRepo.GetIngredientById(userInput);
            if (ing != null)
            {
                WriteLine("=== Ingrident Details ===");
                DisplayIngridentData(ing);
            }
            ReadKey();
        }

        private void GetAllIngredients()
        {
            Clear();
            WriteLine("== Ingrident Menu ==\n");
            foreach (var ingredient in _iRepo.GetIngredients())
            {
                DisplayIngridentData(ingredient);
            }
            ReadKey();
        }

        private void DisplayIngridentData(Ingredient ingredient)
        {
            WriteLine(
            $"Name: {ingredient.Name}\n" +
            $"Description {ingredient.Description}\n" +
            $"Calories: {ingredient.Calories}\n" +
            $"Protein: {ingredient.Protein}\n" +
            $"SaturatedFat: {ingredient.SaturatedFat}\n" +
            $"Sugar: {ingredient.Sugar}\n" +
            "========================================\n");
        }

        private void AddNewIngredient()
        {
            //think of this as a form
            Clear();
            Ingredient ingredientForm = new Ingredient();

            WriteLine("Please enter the ingredient Name: ");
            ingredientForm.Name = Console.ReadLine();

            WriteLine("Please enter the ingredient Description: ");
            ingredientForm.Description = Console.ReadLine();

            WriteLine("Please enter the Protiens: ");
            ingredientForm.Protein = int.Parse(Console.ReadLine());

            WriteLine("Please enter the Calories: ");
            ingredientForm.Calories = int.Parse(Console.ReadLine());

            WriteLine("Please enter the Saturated Fat: ");
            ingredientForm.SaturatedFat = int.Parse(Console.ReadLine());

            WriteLine("Please enter the Sugar: ");
            ingredientForm.Sugar = int.Parse(Console.ReadLine());

            //add to the database _iRepo
            bool isSuccess = _iRepo.AddIngredient(ingredientForm);

            if (isSuccess)
            {
                WriteLine("Success");
            }
            else
            {
                WriteLine("Fail");
            }

            ReadKey();
        }

        private void Seed()
        {
            Recipe recipeA = new Recipe()
            {
                Name = "GRILLED CHICKEN WITH CREAMY ARTICHOKE TOPPING",
                Description = "PREP TIME: 25MIN COOK TIME: 20MIN, SERVES 4",
                RecipeType = RecipeType.Baked,
                Ingredients = _iRepo.GetIngredients().Where(i => i.Id < 4).ToList()
            };

            // these are our ingredients
            var chickenBreast = new Ingredient
            {
                Name = "PERDUE® PERDUE® FRESH BONELESS SKINLESS CHICKEN BREASTS",
                Description = "Raised right in America, with No Antibiotics Ever - PERDUE® Fresh Boneless Skinless Chicken Breasts are a popular kitchen staple you can feel great about feeding your family. Chicken Breasts are a favorite of health-conscious home cooks for their high protein/low fat content and versatility. Whether you bake it, grill it, or roast it our boneless, skinless chicken breasts are sure to please!",
                Calories = 110,
                Protein = 25,
                SaturatedFat = 0,
                Sugar = 0
            };
            var oliveOil = new Ingredient
            {
                Name = "Extra virgin olive oil"
            };
            var adobo = new Ingredient
            {
                Name = "Adobo All-Purpose Seasoning with Pepper"
            };

            var aHearts = new Ingredient
            {
                Name = "Artichoke Hearts, drained and coarsely chopped"
            };

            //adding to the ingredient Repository
            _iRepo.AddIngredient(chickenBreast);
            _iRepo.AddIngredient(oliveOil);
            _iRepo.AddIngredient(adobo);
            _iRepo.AddIngredient(aHearts);


            //access the Recipe database
            _recRepo.AddRecipe(recipeA);
        }
    }
}