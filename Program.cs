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
        int month;
        int day;
        int year;
        int index;
        int currentYear;

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
                name = Console.ReadLine().ToUpper();

                Console.Write("Please input the item category: ");
                category = Console.ReadLine().ToUpper();

                Console.Write("Please input item quantity: ");
                quantity = CheckUserInput(1, 1000);

                Console.WriteLine("Please input expiration date");

                //get month
                Console.Write("Month (1-12): ");
                month = CheckUserInput(1, 12);

                //get day taking into account month length
                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                {
                    Console.Write("Day (1-31): ");
                    day = CheckUserInput(1, 31);
                }
                else if (month == 4 || month == 6 || month == 9 || month == 9 || month == 11)
                {
                    Console.Write("Day (1-30): ");
                    day = CheckUserInput(1, 30);
                }
                else
                {
                    Console.Write("Day (1-28): ");
                    day = CheckUserInput(1, 28);
                }

                currentYear = DateTime.Now.Year; //get current year

                Console.Write("Year (" + currentYear + "-" + (currentYear + 10) + "): ");
                year = CheckUserInput(currentYear, currentYear + 10); //restrict input to current year to current year plus 10

                expDate = month + "/" + day + "/" + year;

                newFoodItem = new FoodItem(name, category, quantity, expDate); //Create new object to store information

                foodItems.Add(newFoodItem); //Add new object to list

            }
            else if (userInput == 2)
            {

                //check if there are food items and then get the index of the item to delete
                if (foodItems.Count > 0) {
                    PrintItems(foodItems, false);
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
                    PrintItems(foodItems, true);
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
            Console.Write("Please enter a valid integer between " + min + " and " + max + ": ");
        }

        return userInput;
    }

    //print list of food items that have been entered
    private static void PrintItems(List<FoodItem> foodItems, bool otherAttributes)
    {
        //doesn't print out other attributes
        if (!otherAttributes)
        {
            Console.WriteLine("\nFood Items:");
            for (int i = 0; i < foodItems.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + foodItems[i].Name);
            }
        }
        //prints out other attributes
        else
        {
            Console.WriteLine("\nFood Items:");
            for (int i = 0; i < foodItems.Count; i++)
            {
                Console.Write((i + 1) + ": " + foodItems[i].Name + ", Cat: " + foodItems[i].Category);
                Console.Write(", Qty: " + foodItems[i].Quantity + ", Exp. Date: " + foodItems[i].ExpDate + "\n");
            }
        }
    }
}