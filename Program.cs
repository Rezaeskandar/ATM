using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Console.WriteLine("Invalid username or password.");
            Console.WriteLine("-------VÄLKOMMEN TILL SWEDBANK--------");
            Console.WriteLine("Tryck 'enter' för at gå vidare.");
            Console.ReadKey();
            Console.Clear();
            login.loginM();
        }
    }
}
  