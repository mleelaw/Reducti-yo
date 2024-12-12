using System.Runtime.InteropServices.Marshalling;

List<Productum> Productums = new List<Productum>
{
    new Productum
    {
        Name = "Invisibility Cloak",
        Price = 999.99m,
        IsAvailable = true,
        ProductumTypeId = 1,
        DateStocked = new DateTime(2024, 3, 15),
    },

    new Productum
    {
        Name = "Healing Potion",
        Price = 247.50m,
        IsAvailable = true,
        ProductumTypeId = 2,
        DateStocked = new DateTime(2024, 7, 22)
    },

    new Productum
    {
        Name = "Phoenix Feather",
        Price = 45.75m,
        IsAvailable = false,
        ProductumTypeId = 3,
        DateStocked = new DateTime(2024, 1, 5),
    },

    new Productum
    {
        Name = "Elder Wand",
        Price = 1499.99m,
        IsAvailable = true,
        ProductumTypeId = 4,
        DateStocked = new DateTime(2024, 9, 30),
    }
};

Dictionary<int, string> ProductumTypes = new Dictionary<int, string>()
{
    {1, "Apparel"},
    {2, "Potions"},
    {3,"Enchanted Objects"},
    {4,"Wands"},
};

string greeting = @"*~*~*~*~* Red & Abe's *~*~*~*~*";

void InventoryList()
{
    for (int i = 0; i < Productums.Count; i++)
    {
        Console.WriteLine($"Name: {Productums[i].Name}");
        Console.WriteLine($"Price:  ${Productums[i].Price}");
        Console.WriteLine($"Available: {Productums[i].IsAvailable}");
        Console.WriteLine($"Type: {ProductumTypes[Productums[i].ProductumTypeId]}");
        Console.WriteLine($"On the shelf for {Productums[i].DaysOnShelf} days.");
        Console.WriteLine();
    }

    Console.WriteLine("\nPress any key to return to menu...");

}

void AddToInventory()
{
    Console.Clear();
    Console.WriteLine("Please Enter In Your Productum's Name:");
    string Name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(Name))
    {
        Console.WriteLine("\nName cannot be empty.");
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
        return;
    }

    Console.Clear();
    Console.WriteLine("Please Enter In Your Productum's Price:");
    decimal Price = decimal.Parse(Console.ReadLine());

    Console.Clear();
    Console.WriteLine("Please Choose The Type of Productum That Best Represents Your Item:");
    foreach (var type in ProductumTypes)
    {
        Console.WriteLine($"{type.Key}. {type.Value}");
    }
    int typeChoice = int.Parse(Console.ReadLine());

    Productum newProductum = new Productum()
    {
        Name = Name,
        Price = Price,
        IsAvailable = true,
        ProductumTypeId = typeChoice,
    };

    Productums.Add(newProductum);

    Console.Clear();
    Console.WriteLine($"***{Name} has been added to your inventory!***");
    Console.WriteLine("\nPress any key to return to menu...");

}

void RemoveFromInventory()
{
    for (int i = 0; i < Productums.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {Productums[i].Name}");
        Console.WriteLine();

    }
    Console.WriteLine("Enter In The Number Of the Productum You Wish To Remove:");
    try
    {
        string choice = Console.ReadLine();
        int chosenNumber = int.Parse(choice) - 1;

        if (chosenNumber >= 0 && chosenNumber < Productums.Count)
        {
            string ProductumName = Productums[chosenNumber].Name;
            Productums.RemoveAt(chosenNumber);
            Console.Clear();
            Console.WriteLine($"\n *~*~*~*{ProductumName} has been banished from the inventory *~*~*~*");
        }
        else
        {
            Console.WriteLine("That number doesn't match an available productum.");
        }
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();

    }
    catch (FormatException)
    {
        Console.WriteLine("Please enter a valid number.");
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
    catch (Exception)
    {
        Console.WriteLine("Invalid selection.");
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}
void SearchByType()
{
    Console.Clear();
    if (!Productums.Any())
    {
        Console.WriteLine("The inventory is empty.");
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
        return;
    }

    Console.WriteLine(">>>Available Product Types<<<");
    Console.WriteLine();
    foreach (var type in ProductumTypes)
    {
        Console.WriteLine($"{type.Key}. {type.Value}");
    }
    Console.WriteLine("\nPlease enter the number of the type you wish to view:");

    try
    {
        if (!int.TryParse(Console.ReadLine(), out int typeChoice))
        {
            throw new FormatException();
        }

        if (!ProductumTypes.ContainsKey(typeChoice))
        {
            Console.Clear();
            Console.WriteLine("\nThat productum type does not exist.");
        }
        else
        {
            var filteredProducts = Productums.Where(p => p.ProductumTypeId == typeChoice).ToList();

            if (!filteredProducts.Any())
            {
                Console.Clear();
                Console.WriteLine($"\nNo productums of type found {ProductumTypes[typeChoice]}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\n>>>Productums of the type {ProductumTypes[typeChoice]}<<<");
                Console.WriteLine();
                foreach (var product in filteredProducts)
                {
                    Console.WriteLine($"Name: {product.Name}");
                    Console.WriteLine($"Price: {product.Price:C}");
                    Console.WriteLine($"Available: {(product.IsAvailable ? "Yes" : "No")}");
                    Console.WriteLine();
                }
            }
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("\nPlease enter a valid number.");
    }
    catch (Exception)
    {
        Console.WriteLine("\nInvalid selection.");
    }

    Console.WriteLine("\nPress any key to return to menu...");
    Console.ReadKey();
}

void UpdateInventory()
{
    Console.Clear();
    Console.WriteLine("Please Enter In The Number Of The Productum That You Wish To Edit:");
    for (int i = 0; i < Productums.Count; i++)
    {
        Console.WriteLine($"\n{i + 1}. {Productums[i].Name}");
    }



    int chosenNumber = int.Parse(Console.ReadLine()) - 1;



    if (chosenNumber >= 0 && chosenNumber < Productums.Count)
    {

        void EditProductumName()
        {
            Console.Clear();
            Console.WriteLine($"Current Name: {Productums[chosenNumber].Name}");
            Console.WriteLine("Please Enter In The New Name:");
            string newName = Console.ReadLine();
            Productums[chosenNumber].Name = newName;
            Console.Clear();
            Console.WriteLine($"Done! This productums name has been updated to {Productums[chosenNumber].Name}.");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu");

        };

        void EditProductumPrice()
        {
            Console.Clear();
            Console.WriteLine($"Current Name: {Productums[chosenNumber].Price}");
            Console.WriteLine("Please Enter In The New Price:");
            decimal newPrice = decimal.Parse(Console.ReadLine());
            Productums[chosenNumber].Price = newPrice;
            Console.Clear();
            Console.WriteLine($"Done! This productums name has been updated to {Productums[chosenNumber].Price}.");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu");

        };

        void EditProductumAvailability()
        {
            Console.Clear();
            Console.WriteLine($"Currently {(Productums[chosenNumber].IsAvailable ? "Available" : "Not Available")}");
            Console.WriteLine();
            Console.WriteLine($"Would you like to change {Productums[chosenNumber].Name}'s availability? (Y/N): ");

            string response = Console.ReadLine();

            if (response.ToUpper() == "Y")
            {
                Productums[chosenNumber].IsAvailable = !Productums[chosenNumber].IsAvailable;
                Console.WriteLine($"\nDone! {Productums[chosenNumber].Name} is now {(Productums[chosenNumber].IsAvailable ? "available" : "not available")}.");
            }
            else if (response.ToUpper() == "N")
            {
                Console.Clear();
                Console.WriteLine($"\n{Productums[chosenNumber].Name} availability will stay the same..");
            }
            else
            {
                Console.WriteLine("\nInvalid input. No changes made to the productum's availability.");
            }

            Console.WriteLine("\nPress any key to return to the productum's details...");
            Console.ReadKey();
            Console.Clear();
        }


        Console.Clear();
        Console.WriteLine($"You are Editing {Productums[chosenNumber].Name}...");
        Console.WriteLine("Below are its current details.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"1.{Productums[chosenNumber].Name}");

        Console.WriteLine($"2. {Productums[chosenNumber].Price:C}");

        if (Productums[chosenNumber].IsAvailable)
        {
            Console.WriteLine("3. This Productum Is Available");
        }
        else
        {
            Console.WriteLine("3. This Productum Is Not Available");
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Please enter in the number for the detail field that you wish to edit");

        string choice = Console.ReadLine();

        switch (choice)
        {

            case "1":
                Console.WriteLine();
                EditProductumName();
                Console.ReadLine();
                break;

            case "2":
                Console.WriteLine();
                EditProductumPrice();
                Console.ReadLine();
                break;

            case "3":
                Console.WriteLine();
                EditProductumAvailability();
                break;
        }


    }
}

void AvailableInventory()
{
    List<Productum> unsoldProducts = Productums.Where(p => p.IsAvailable).ToList();

    Console.WriteLine();
    foreach (var p in Productums)
    {
        Console.WriteLine(p.Name);
    }
    Console.WriteLine("\nPress any key to return to the menu...");
    Console.ReadKey();
    Console.Clear();


}


string choice = null;
while (choice != "0")
{
    Console.Clear();
    Console.WriteLine(greeting);
    Console.WriteLine(@"
*~*~*~*~*~*~*~* Menu *~*~*~*~*~*~*~*~*
    0. >> Vanish (Exit)
    1. >> Reveal All Treasures
    2. >> Conjure New Item to Inventory
    3. >> Banish Item from Inventory 
    4. >> Transform Item Details
    5. >> Search By Type
    6. >> View Available Inventory
*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*
");

    choice = Console.ReadLine();

    switch (choice)
    {
        case "0":
            Console.WriteLine("Exiting Menu...");
            break;

        case "1":
            Console.Clear();
            Console.WriteLine(" >>>Inventory<<<\n");
            InventoryList();
            Console.ReadLine();
            break;

        case "2":
            Console.Clear();
            Console.WriteLine(">>>Conjuring<<<");
            AddToInventory();
            Console.ReadLine();
            break;

        case "3":
            Console.Clear();
            Console.WriteLine(">>>Banishing<<<");
            Console.WriteLine();
            Console.WriteLine();
            RemoveFromInventory();
            break;

        case "4":
            Console.WriteLine(">>>Transforming<<<");
            UpdateInventory();
            Console.ReadLine();
            break;

        case "5":
            Console.Clear();
            Console.WriteLine(">>>Searching By Type<<<");
            Console.WriteLine();
            SearchByType();
            break;

        case "6":
            Console.Clear();
            Console.WriteLine(">>>Availabile Productrums<<<");
            Console.WriteLine();
            AvailableInventory();
            break;

        default:
            Console.Clear();
            Console.WriteLine("You Must Choose An Option From the Menu List.");
            Console.WriteLine("Please select any key to be redirected back to the Main Menu...");
            Console.WriteLine("");
            Console.ReadKey();
            break;

    }
}