using System.Runtime.Serialization;

public class MenuItems
{
    public double Number {get; set;}
    public string Meal {get; set;}
    public string Description {get; set;}
    public string Ingredients {get; set;}
    public double Price {get; set;}

//Constructor
    public MenuItems() {}
    public MenuItems( double number, string meal, string description, string ingredients, double price)
    {
        Number = number;
        Meal = meal;
        Description = description;
        Ingredients = ingredients; 
        Price = price; 
    }
}
