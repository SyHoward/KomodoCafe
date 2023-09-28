using System;
public class ProgramUI
{
    private readonly MenuRepository _repo = new MenuRepository();
    public void Run()
    {
    RunMenu();
    }
    public void RunMenu()
    {
        bool continueToRun = true;
        do
        {
            Console.Clear();
            Console.WriteLine
            (
                "Menu:\n" +
                "1. Create New Menu Item\n" +
                "2. List Full Menu\n" +
                "3. Get Order by Meal Number\n" +
                "4. Update Menu Item\n" +
                "5. Remove Menu Item\n" +
                "0. Exit\n" 
            );
            string selection = Console.ReadLine() ?? "";
            switch (selection)
            {
                case "1":
                    CreateMenuItem();
                    break;
                case "2":
                    ListAllMenuItems();
                    break;
                case "3":
                    GetItemByNumber();
                    break;
                case "4":
                    UpdateMenuItem();
                    break;
                case "5":
                    RemoveMenuItem();
                    break;
                case "0":
                    continueToRun = false;
                    break;
                default:
                    Console.WriteLine("Please enter a valid option");
                    PauseAndWaitForKeyPress();
                    break;
            }
        } while (continueToRun);
    }
// Methods for Menu
//Create
    public void CreateMenuItem()
    {
        Console.Clear();
        string number = GetValidStringInput("Number");
        double mealNumber = double.Parse(number);
        string meal = GetValidStringInput("Name");
        string description = GetValidStringInput("Description");
        string ingredients = GetValidStringInput("Ingredients");
        string price = GetValidStringInput("Price");
        double mealPrice = double.Parse(price);

        MenuItems newContent = new MenuItems
        (
            mealNumber, meal, description, ingredients, mealPrice
        );
        _repo.AddMealToDirectory(newContent);
    PauseAndWaitForKeyPress();
    }
//Read
    public void ListAllMenuItems()
    {
        Console.Clear();
        List<MenuItems> allItems = _repo.GetAllMenuItems();

        int index = 1;
        foreach(MenuItems item in allItems)
        {
            DisplayMenuItem(item, index++);
        }
    PauseAndWaitForKeyPress();
    }
//Read number
    public void GetItemByNumber()
    {
        Console.Clear();
        Console.Write("Please enter meal number: ");
        string number = Console.ReadLine() ?? "";
        double mealNumber = double.Parse(number);
        MenuItems item = _repo.GetItemByNumber(mealNumber);
        if (item == default)
        {
            Console.WriteLine("Meal not found");
        }
        else
        {
            DisplayMenuItem(item);
        }
    PauseAndWaitForKeyPress();
    }
//Update
    public void UpdateMenuItem()
    {
        Console.Clear();
        Console.Write("Please enter meal number: ");
        string number = Console.ReadLine() ?? "";
        double mealNumber = double.Parse(number);
        Console.Clear();
    
        MenuItems item = _repo.GetItemByNumber(mealNumber);
        if (item == default)
        {
            Console.WriteLine("Meal not found");
        }
        else
        {
            DisplayMenuItem(item);
            Console.WriteLine(
                "Please enter updated meal number:"
            );
            string numTwo = Console.ReadLine() ?? "";
            double updatedMealNumber = double.Parse(numTwo);
            item.Number = updatedMealNumber;
            string meal = GetValidStringInput("Name");
            item.Meal = meal;
            string description = GetValidStringInput("Description");
            item.Description = description;
            string ingredients = GetValidStringInput("Ingredients");
            item.Ingredients = ingredients;
            string price = GetValidStringInput("Price");
            double mealPrice = double.Parse(price);
            item.Price = mealPrice;
            _repo.UpdateExistingItem(item.Number, item);
        }
    PauseAndWaitForKeyPress();
    }

//Delete
    public void RemoveMenuItem()
    {
        Console.Clear();
        Console.Write("Please enter the meal number you wish to delete: ");
        string num = Console.ReadLine() ?? "";
        double meal = double.Parse(num);
        Console.Clear();
        _repo.DeleteExistingItem(meal);
    PauseAndWaitForKeyPress();
    }

// Helper Methods
    private void PauseAndWaitForKeyPress()
    {
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    private void DisplayMenuItem(MenuItems item, int itemIndex)
    {
        Console.WriteLine
        (
            $"{item.Number}\n" +
            $"{item.Meal}\n" +
            $"{item.Description}\n" +
            $"{item.Ingredients}\n" +
            $"{item.Price}\n"
        );
    }

    private void DisplayMenuItem(MenuItems item)
    {
        Console.WriteLine
        (
            $"{item.Number}\n" +
            $"{item.Meal}\n" +
            $"{item.Description}\n" +
            $"{item.Ingredients}\n" +
            $"{item.Price}\n"
        );
    }

    private string GetValidStringInput(string name)
    {
        string input;
        do
        {
            Console.Write($"Please enter meal {name.ToLower()}:");
            input = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine($"{name} cannot be empty.");
                PauseAndWaitForKeyPress();
                Console.Clear();
            }
        }
        while(string.IsNullOrWhiteSpace(name));
        return input;
    }
}
