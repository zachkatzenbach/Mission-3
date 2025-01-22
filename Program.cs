using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Mission_3;

internal class Program
{
    private static void Main(string[] args)
    {
        //initialize variables
        int userInput;
        List<FoodItem> foodItems = new List<FoodItem>();
        FoodItem newFoodItem;
        string name;
        string category;
        int quantity;
        string expDate;
        int index;

        Console.WriteLine("Welcome to Food Bank!");
        Program.PrintMenu();

        //Take user input and make sure it is an integer between 1 and 4
        userInput = Program.CheckUserInput(1, 4);

        while (userInput != 4)
        {
            if (userInput == 1)
            {
                //Take input for name, category, quantity, and expiration date
                Console.Write("\nPlease input the name of the item: ");
                name = Console.ReadLine();

                Console.Write("Please input the item category: ");
                category = Console.ReadLine();

                Console.Write("Please input item quantity: ");
                while (int.TryParse(Console.ReadLine(), out quantity) == false || quantity < 1)
                {
                    Console.Write("Please enter a valid integer above 0: ");
                }

                Console.Write("Please input expiration date: ");
                expDate = Console.ReadLine();

                newFoodItem = new FoodItem(name, category, quantity, expDate); //Create new object to store information

                foodItems.Add(newFoodItem); //Add new object to list

            }
            else if (userInput == 2)
            {

                //check if there are food items and then get the index of the item to delete
                if (foodItems.Count > 0) {
                    PrintItems(foodItems);
                    Console.WriteLine("Which item would you like to delete?\n");
                    
                    index = CheckUserInput(1, (foodItems.Count + 1)) - 1;

                    foodItems.Remove(foodItems[index]);
                }
                else
                {
                    Console.WriteLine("\nNo food items entered.");
                }
            }
            else if (userInput == 3)
            {
                //check if there are food items and then print them
                if (foodItems.Count > 0)
                {
                    PrintItems(foodItems);
                }
                else
                {
                    Console.WriteLine("\nNo food items entered.");
                }
            }

            Program.PrintMenu();
            userInput = Program.CheckUserInput(1, 4);
        }

        Console.WriteLine("Exiting program.");
    }
    
    //print menu choices
    private static void PrintMenu()
    {
        Console.WriteLine("\nHow would you like to proceed?");
        Console.WriteLine("1. Add Food Items");
        Console.WriteLine("2. Delete Food Items");
        Console.WriteLine("3. Print List of Current Food Items");
        Console.WriteLine("4. Exit the Program\n");
    }


    //checks user input to see if it's an integer and within the bounds set
    private static int CheckUserInput(int min, int max)
    {
        int userInput;
        while (int.TryParse(Console.ReadLine(), out userInput) == false || userInput < min || userInput > max)
        {
            Console.Write("Please enter a valid integer between 1 and 4:");
        }

        return userInput;
    }

    //print list of food items that have been entered
    private static void PrintItems(List<FoodItem> foodItems)
    {
        Console.WriteLine("\nFood Items:");
        for (int i = 0; i < foodItems.Count; i++)
        {
            Console.WriteLine((i + 1) + ": " + foodItems[i].Name);
        }
    }
}