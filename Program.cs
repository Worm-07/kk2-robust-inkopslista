ShoppingList list = new ShoppingList("items.txt");
//list.Load();

while (true)
{
    Console.WriteLine();
    list.Print();
    Console.WriteLine();
    Console.WriteLine("1. Lägg till vara");
    Console.WriteLine("2. Ta bort vara");
    Console.WriteLine("3. Spara");
    Console.WriteLine("4. Sök vara");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj: ");

    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        Console.Write("Namn: ");
        string name = Console.ReadLine();
        Console.Write("Pris: ");
        string price = Console.ReadLine();
        if (int.TryParse(price, out int output))
        {
            list.Add(new Item(name, output));
        }
        else
        {
            Console.WriteLine("=== Ange priset i siffror ===");
        }
    }
    else if (choice == 2)
    {
        Console.Write("Nummer: ");
        string number = Console.ReadLine();
        if (int.TryParse(number, out int output))
        {
            if (output >= 0 && output <= list.Count)
            {
                list.RemoveAt(output);
            }
            else
            {
                Console.WriteLine(" === produkten finns inte i din lista ===");
            }
        }
        else
        {
            Console.WriteLine(" === Ange nummret i siffror ===");
        }
    }
    else if (choice == 3)
    {
        list.Save();
    }
    else if (choice == 4)
    {
        Console.Write("Namn att söka efter: ");
        string wanted = Console.ReadLine();
        Item found = list.Find(wanted);

        if (found == null)
        {
            Console.WriteLine("Varan finns inte i listan.");
        }
        else
        {
            Console.WriteLine($"Hittade: {found}");
        }
    }
    else if (choice == 5)
    {
        break;
    }
}
