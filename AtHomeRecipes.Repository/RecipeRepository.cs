using AtHomeRecipes.Data;

namespace AtHomeRecipes.Repository
{
    public class RecipeRepository
    {
        private List<Recipe> _recipeDB = new List<Recipe>();
        private int _count = 0;

        //C.R.U.D 

        //C -> Create
        public bool AddRecipe(Recipe recipe)
        {
            if (recipe is null)
            {
                return false;
            }
            else
            {
                _count++;
                recipe.Id = _count;
                _recipeDB.Add(recipe);
                return true;
            }
        }
        //R -> Read All
        public List<Recipe> GetRecipes()
        {
            return _recipeDB;
        }
        //R -> Read By Id
        public Recipe GetRecipeById(int recipeId)
        {
            return _recipeDB.FirstOrDefault(recipe => recipe.Id == recipeId)!;
        }
        //U -> Update
        public bool UpdateRecipe(int recipeId, Recipe newRecipeData)
        {
            var oldRecipeData = GetRecipeById(recipeId);
            if (oldRecipeData != null)
            {
                oldRecipeData.Name = newRecipeData.Name;
                oldRecipeData.Description = newRecipeData.Description;
                oldRecipeData.RecipeType = newRecipeData.RecipeType;

                if (newRecipeData.Ingredients.Count() > 0)
                {
                    oldRecipeData.Ingredients = newRecipeData.Ingredients;
                }
                return true;
            }
            return false;
        }
        //D -> Delete
        public bool Delete(int recipeId)
        {
            return _recipeDB.Remove(GetRecipeById(recipeId));
        }
    }
}