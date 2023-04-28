namespace AtHomeRecipes.Data
{
    public class Ingredient
    {
        public Ingredient()
        {

        }
        //full constructor
        public Ingredient(
         string name, 
         string description, 
         int calories,
         int protein, 
         int saturatedFat, 
         int sugar)
        {
            Name = name;
            Description = description;
            Calories = calories;
            Protein = protein;
            SaturatedFat = saturatedFat;
            Sugar = sugar;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int SaturatedFat { get; set; }
        public int Sugar { get; set; }
    }
}