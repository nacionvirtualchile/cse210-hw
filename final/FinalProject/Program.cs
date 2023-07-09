using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello FinalProject World!");
        Menu menu1 = new Menu();
        int option = 0;

        Console.Clear();
        Console.WriteLine("___________________");
        Console.WriteLine("___________________");
        Console.WriteLine("WELCOME TO SUBSCRIPTIONS MANAGER");
        Console.WriteLine("");

        while (option != 7){
            Console.WriteLine("___________________");
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("___________________");
            menu1.DisplayMainMenu();
            Console.Write("Select an option from the menu: ");
            Console.WriteLine("");
            option = menu1.GetChoiceFromUser();
        }

    }
}