using System;
public class MenuRepository
{
    protected readonly List<MenuItems> _menuDirectory = new List<MenuItems>();
    public MenuRepository()
        {
            Seed();
        }
    // CRUD
    // Create
    public bool AddMealToDirectory(MenuItems item)
    {
        int startingCount = _menuDirectory.Count;
        _menuDirectory.Add(item);
        bool wasAdded = _menuDirectory.Count > startingCount;
        return wasAdded;
    }
    // Read
    public List<MenuItems> GetAllMenuItems()
    {
        return _menuDirectory;
    }
    public MenuItems GetItemByNumber(double number)
    {
        foreach (MenuItems item in _menuDirectory)
        {
            if (item.Number == number)
            {
                return item;
            }
        }
        return default;
    }
    // Update
    public bool UpdateExistingItem(double orginalItem, MenuItems newItem)
    {
        MenuItems oldItem = GetItemByNumber(orginalItem);
        if (oldItem != default)
        {
            oldItem.Number = newItem.Number;
            oldItem.Meal = newItem.Meal;
            oldItem.Description = newItem.Description;
            oldItem.Price = newItem.Price;
            return true;
        }
        else
        {
            return false;
        }
    }
    // Delete
    public bool DeleteExistingItem(double number)
    {
        MenuItems ItemToDelete = GetItemByNumber(number);
        {
            if (ItemToDelete != default)
            {
                bool deleteResult = _menuDirectory.Remove(ItemToDelete);
                return deleteResult;
            }
            else
            {
                return false;
            }
        }
    }
    // Seed
    private void Seed()
    {
        MenuItems mealOne = new MenuItems
        (
            1,
            "The Impossible-ly Delicious Burger",
            "An Impossible burger, walked through the garden, served with a side of fries.\n",
            "Ingredients: \nImpossible burger: Water, Soy Protein Concentrate, Sunflower Oil, Coconut Oil, Natural Flavors, 2% Or Less Of: Methylcellulose, Cultured Dextrose, Food Starch Modified, Yeast Extract, Soy Leghemoglobin, Salt, Mixed Tocopherols (Antioxidant), L-tryptophan, Soy Protein Isolate,Vitamins and Minerals: Zinc Gluconate, Niacin, Thiamine Hydrochloride (Vitamin B1), Pyridoxine Hydrochloride (Vitamin B6), Riboflavin (Vitamin B2), Vitamin B12.\n\nWheat Buns: Enriched Flour (Wheat Flour, Malted Barley Flour, Niacin, Reduced Iron, Thiamin Mononitrate, Riboflavin, Folic Acid), Water, High Fructose Corn Syrup, Soybean Oil, Yeast, Wheat Gluten, Contains Less Than 2% Of Salt, Mono- And Diglycerides, Vinegar, Sodium Stearoyl Lactylate, Datem, Guar Gum, Fumaric Acid, Sorbic Acid, Fully Hydrogenated Soybean, Palm And/or Cottonseed Oil, Natural Flavor, Ascorbic Acid, Enzymes, Calcium Propionate (Preservative), Soy Lecithin.\n\nFries: Potatoes, Canola oil, Salt.\nCONTAINS: WHEAT AND SOY",
            12.99 
        );
        MenuItems mealTwo = new MenuItems
        (
            2,
            "Fishless Tacos",
            "Three vegan filets with creamy jalapeño sauce, pico de gallo, cilantro, and lime on corn tortillas, served with a side of coleslaw.\n",
            "Ingredients: \nFilets: Water, Canola Oil, Textured Vegetable Protein Product (Soy Protein Concentrate, Titanium Dioxide [Color]), Enriched Wheat Flour (Wheat Flour, Niacin, Reduced Iron, Thiamine Mononitrate, Riboflavin, Folic Acid), 2% Or Less Of: Potato Starch, Tapioca Starch, Methylcellulose, Salt, Yeast Extract, Degerminated Yellow Corn Flour, Natural Flavors, Onion Powder, Garlic Powder, Leavening (Sodium Acid Pyrophosphate, Sodium Bicarbonate, Monocalcium Phosphate), Sunflower Oil, Wheat Gluten, Paprika, Dha Algal Oil, Autolyzed Yeast Extract, Spice, Soy Flour, Xanthan Gum, Sugar, Citric Acid, Soybean Oil, Turmeric. \nCONTAINS: WHEAT AND SOY",
            10.99
        );
        MenuItems mealThree = new MenuItems
        (
            3,
            "Buffalo Chik'n Tenders",
            "Six cripsy chik'n tenders tossed buffalo sauce, served with side of celery.\n",
            "Ingredients: \nTenders: Water, Enriched Wheat Flour (Wheat Flour, Niacin, Reduced Iron, Thiamine Mononitrate, Riboflavin, Folic Acid), Soy Protein Isolate, Canola Oil, Vital Wheat Gluten, 2% Or Less Of: Rice Flour, Oat Bran, Methylcellulose, Salt, Oats, Sugar, Sunflower Oil, Ancient Grain Flour (Khorasan Wheat), Spices, Quinoa Flour, Amaranth Flour, Millet Flour, Potato Starch, Natural Flavor, Leavening (Sodium Bicarbonate, Cream Of Tartar), Yeast Extract, Titanium Dioxide (Color), Yeast, Extractive Of Paprika (Color), Lactic Acid. \n\nBuffalo Sauce: Distilled Vinegar, Aged Cayenne Red Peppers, Salt, Water, Canola Oil, Paprika, Xanthan Gum, Natural Butter Type Flavor And Garlic Powder. \n\nCelery.\nCONTAINS: WHEAT AND SOY",
            11.99
        );
        MenuItems mealFour = new MenuItems
        (
            4,
            "Southwest Nachos",
            "Tortilla chips, cheez sauce, tex-mex taco “meat”, ranchero beans, pico de gallo, guacamole, cholula crema and fresno peppers \n",
            "Ingredients: \nTortilla Chips: Corn, Vegetable Oil (Corn, Canola and/or Sunflower Oil), and Salt.\n\nCheez Sauce: Water, Coconut Oil, Potato Starch, Modified Potato Starch, Salt, Potato Protein, Yeast Extract, Natural Flavor, Xanthan Gum, Lactic Acid, Annatto Extract Color\n\nTaco Impossible Meat: Water, Soy Protein Concentrate, Sunflower Oil, Coconut Oil, Natural Flavors, 2% Or Less Of: Methylcellulose, Cultured Dextrose, Food Starch Modified, Yeast Extract, Soy Leghemoglobin, Salt, Mixed Tocopherols (Antioxidant), L-tryptophan, Soy Protein Isolate,Vitamins and Minerals: Zinc Gluconate, Niacin, Thiamine Hydrochloride (Vitamin B1), Pyridoxine Hydrochloride (Vitamin B6), Riboflavin (Vitamin B2), Vitamin B12.\n\nGuacamole: Hass Avocado, Tomatillo, Dehydrated Onion, Sea Salt, Jalapeno Pepper, Dehydrated Garlic, Garlic, Dehydrated Cilantro, Dehydrated Jalapeno Pepper, Cilantro Essential Oil.\n\nCrema: Oatmilk (Filtered Water, Oats), Cane Sugar, Sunflower Oil, Natural Flavors, Sunflower Lecithin, Dipotassium Phosphate, Pea Protein, Baking Soda, Sea Salt, Vitamin C (Stabilizer), Gellan Gum\n\nBlack Beans, fresno peppers.\nCONTAINS: WHEAT AND SOY",
            9.99
        );
        MenuItems mealFive = new MenuItems
        (
            5,
            "California Wrap",
            "Grilled marinated chik'n, Dijonnaise, yellow mustard, pickled onions, tomato, avocado and sprouts wrapped in a flour tortilla \n",
            "Ingredients: \nChik'n: Water, Vital Wheat Gluten, Soy Protein Isolate, Cano Oil, Pea Protein Concentrate, Textured Wheat Protein (Wheat Gluten Wheat Starch), Less Than 2% Of: Methylcellulose, Sunflower Oil Natural Flavors, Salt, Garlic Powder, Yeast Extract, Onion Powder Titanium Dioxide (Color), Spices, Lactic Acid.\n\nFlour Tortilla: Enriched Bleached Flour (Flour, Niacin, Reduced Iron, Thiamine Mononitrate, Riboflavin, Folic Acid), Water, Vegetable Shortening (Interesterified and Hydrogenated Soybean Oils), Contains 2% or less: Salt, Sugar, Baking Soda, Sodium Acid Pyrophosphate, Distilled Monoglycerides, Enzymes, Enzymes, Fumaric Acid, Calcium Propionate and Sorbic Acid\n\nDijonnaise: Canola Oil, Water, Modified Food Starch (Potato, Corn), Distilled Vinegar, Less Than 2% Of: Sugar, Salt, Lemon Juice Concentrate, Sorbic Acid And Calcium Disodium Edta (Used To Protect Quality), Natural Flavor, Paprika Extract\n\nMustard: Vinegar, Water, Mustard Seed, Salt, Turmeric, Paprika.\nCONTAINS: WHEAT AND SOY",
            9.99
        );

        AddMealToDirectory(mealOne);
        AddMealToDirectory(mealTwo);
        AddMealToDirectory(mealThree);
        AddMealToDirectory(mealFour);
        AddMealToDirectory(mealFive);
    }
}