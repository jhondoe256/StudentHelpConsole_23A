namespace AtHomeRecipes.Data
{
    public class Recipe
    {
        //Empty constructor
        public Recipe() { }

        //Full constructor
        public Recipe(string name, string description, List<Ingredient> ingredients)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
        }

        //* PK -> unique identifier
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public RecipeType RecipeType {get;set;}

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}