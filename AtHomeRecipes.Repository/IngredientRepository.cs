using AtHomeRecipes.Data;

namespace AtHomeRecipes.Repository
{
    //this is just a object that holds a collection 
    // of Ingredients
    // it can also perform actions on the collection
    public class IngredientRepository
    {
        //this is the literal collection.
        private List<Ingredient> _ingredientDB = new List<Ingredient>();
        //make a counter 
        private int _count = 0;

        //C.R.U.D Methods

        //C -> Create
        public bool AddIngredient(Ingredient ingredient)
        {
            if (ingredient is null)
            {
                //if we have bad data
                return false;
            }
            else
            {
                //if we have good data
                //increment our counter
                _count++;

                //assign the _count value to ingredent.Id
                ingredient.Id = _count;

                //add the ingredient to the database
                _ingredientDB.Add(ingredient);
                return true;
            }
        }

        //R -> Read All
        public List<Ingredient> GetIngredients()
        {
            return _ingredientDB;
        }

        //R -> Read by Id
        public Ingredient GetIngredientById(int ingredientId)
        {
            //we need to loop through the entire database (_ingredientDb)
            foreach (Ingredient ing in _ingredientDB)
            {
                //check if we have matching data
                if (ing.Id == ingredientId)
                {
                    //if the data matches we will return the ingredient
                    return ing; //ing is a ingredient
                }
            }
            //otherwise we will return null
            return null;
        }

        //U -> Update
        public bool UpdateIngredientData(int ingredientId, Ingredient newIngredientData)
        {
            //find an existing ingredient based on the 'ingredientId' the user passes in
            Ingredient oldIngredientData = GetIngredientById(ingredientId);

            //check if the ingredient exists
            if (oldIngredientData != null)
            {
                //writing over everthing except the Id...
                oldIngredientData.Name = newIngredientData.Name;

                oldIngredientData.Description = newIngredientData.Description;

                oldIngredientData.Protein = newIngredientData.Protein;

                oldIngredientData.Calories = newIngredientData.Calories;

                oldIngredientData.SaturatedFat = newIngredientData.SaturatedFat;

                oldIngredientData.Sugar = newIngredientData.Sugar;

                return true;
            }
            return false;
        }

        //D -> Delete
        public bool DeleteExistingIngredient(int ingredientId)
        {
            foreach (Ingredient ing in _ingredientDB)
            {
                if (ing.Id == ingredientId)
                {
                    _ingredientDB.Remove(ing);
                    return true;
                }
            }
            return false;
        }
    
        //Method returns List<ingredient>, by Calories (int)
    }
}