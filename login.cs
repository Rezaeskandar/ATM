using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class login
    {
      public static void loginM()
      {
          

         int trys = 3;
         bool loops = true;
         bool valid = false;
       

          
         while (loops)
         {
            start:

                string[,] usernames = new string[5, 2] {
                {"user1", "pass1" },
                {"user2", "pass2" },
                {"user3", "pass3" },
                {"user4", "pass4" },
                {"user5", "pass5" }
                };

                Console.WriteLine("skriv ditt username. ");
               string usernam = Console.ReadLine();

                Console.WriteLine("skirv ditt password. ");
                string password = Console.ReadLine();

               

                for (int i = 0; i < usernames.GetLength(0); i++)
                {
                    for (int j = 0; j < usernames.GetLength(1); j++)
                    {
                        if (usernam == usernames[i, 0] && password == usernames[i, 1])
                        {
                            valid = true;

                            break;
                        }
                    }
                   
                }
                if (valid == true && usernam == usernames[0,0])
                {
                    Console.WriteLine("wellcome {0}", usernam);
                    menues.mainMethod();
                    loops = false;

                  
                }
                else if (valid == true && usernam == usernames[1, 0])
                {
                    Console.WriteLine("wellcome {0}", usernam);
                    menues.Muser2();
                    loops = false;

                }
                else if (valid == true && usernam == usernames[2, 0])
                {
                    Console.WriteLine("wellcome {0}", usernam);
                    menues.Muser3();
                    loops = false;

                }
                else if (valid == true && usernam == usernames[3, 0])
                {
                    Console.WriteLine("wellcome {0}", usernam);
                    menues.Muser4();
                    loops = false;

                }
                else if (valid == true && usernam == usernames[4, 0])
                {
                    Console.WriteLine("wellcome {0}", usernam);
                    menues.Muser5();
                    loops = false;
                   
                }

                else
                {
                    
                    Console.WriteLine("\nusername eller password är int korekt var snäll och kontrollera.");
                    Console.WriteLine("du har {0} försök till!", trys);
                    trys -= 1;
                    
                    if (trys == -1)
                    {
                        Console.WriteLine("din vänte tid är 20s innan du kan försöka igen senare!");
                        timer.timmer();
                        trys = 3;
                    }

                }
                  Console.WriteLine("\n tryck ESC för log out ");

                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        goto start;
                    }




                
          }
       }


    }
}
