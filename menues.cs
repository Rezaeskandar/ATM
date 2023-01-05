using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class menues
    {
        public static void mainMethod()
        {
            //user1
           //menu input
           strat:
            Console.WriteLine("-------Huvud Meny-----------");
            Console.WriteLine("1. Se dina konton och saldo");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4. Logga ut");

            string input;
            //key info get back to main menu
            ConsoleKeyInfo keyInfo;
            do
            {
                input = Console.ReadLine();
                if (input == "1")
                {
                    amountAndAcount();

                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Meny. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }

                    continue;
                }
                else if (input == "2")
                {
                    transfore();

                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Meny. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }
                    continue;
                }
                else if (input == "3")
                {
                   
                    withdraw();

                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Meny. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }
                    continue;
                    
                }
                else if (input == "4")
                {
                    logout();
                    break;
                }
                else
                {
                    Console.WriteLine("välj en av alternativ ovan för att gå vidare!");
                }
            } while (input != "1" || input != "2" || input != "3" || input != "4");

        }

        //input "1"
        public static void amountAndAcount()
        {
            double pBalance = 50000.23;
            double csnB = 20000.22; 
            string sek = "SEK";

            Console.WriteLine("välj ett konto.");
            Console.WriteLine("----------------------------------\n");
            Console.WriteLine("1.Privat Konto");
            Console.WriteLine("2.CSN Konto");
            string choseAcount = Console.ReadLine();
            if (choseAcount == "1")
            {
                privateAcount();
            }
            else if (choseAcount == "2")
            {
                CSNAcount();
            }

            void privateAcount()
            {
                Console.WriteLine("Privat konto:  {0} {1} ", pBalance, sek);
            }
            void CSNAcount()
            {
                Console.WriteLine("CSN balance: {0} {1} ", csnB, sek);
            }
        }

       

        //transfor1 >> input "2"
        public static void transfore()
        {
            double csnB = 2000d;
            double pBalance = 5000d;
            string sek = "SEK";
            string choseAcount;
            do
            {

                Console.WriteLine("välj kontot du vill överföra pengar från.");

                Console.WriteLine("-----------------------------------------------------\n");
                Console.WriteLine("1.CSN Konto");
                Console.WriteLine("2.Privat Konto");
                choseAcount = Console.ReadLine();
                if (choseAcount == "1")
                {
                    csnAcount();
                    break;
                }
                else if (choseAcount == "2")
                {

                    privateAcount();
                    break;
                }
                else
                {
                    Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", choseAcount);
                }
            } while (choseAcount != "1" || choseAcount != "2");

            //transfore to csnAcount
            void csnAcount()
            {
                double transforeAmount;


                string transforTo;
                do
                {

                    Console.WriteLine("CSN balance: {0:N2} {1} ", csnB, sek);
                    Console.WriteLine("Private balance: {0:N2} {1} ", pBalance, sek);

                    Console.WriteLine("Tillgängliga konto att överföra till.");
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine("2.Privat Konto");
                    Console.WriteLine("Välj kontot som du vill överföra till.\n");
                    transforTo = Console.ReadLine();
                    if (transforTo == "2")
                    {


                        do
                        {
                            Console.WriteLine("Privat Konto ballance: {0:N2}  {1} ", pBalance, sek);
                            Console.WriteLine("Ange summan som du vill överföra (SEK).");
                            transforeAmount = double.Parse(Console.ReadLine());
                            double totaltansValue = csnB - transforeAmount;
                            double finishTrans = transforeAmount + pBalance;
                            if (transforeAmount < csnB)
                            {
                                Console.WriteLine("Du överförde {0} SEK från 'CSN konto' till 'Private konto' \n", transforeAmount);

                                Console.WriteLine("Nya balance");
                                Console.WriteLine("-------------------------------------\n");
                                
                                Console.WriteLine("CSN Konto balance: {0:N2} {1}", totaltansValue, sek);
                                Console.WriteLine("Privat Konto ballance: {0:N2} {1}", finishTrans, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Du har inte tillräckligt med pengar din balance är {0:N2} {1} försök igen med lägre summa.", csnB, sek);

                            }
                        } while (transforeAmount > csnB);

                    }
                    else
                    {
                        Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", transforTo);

                    }

                } while (transforTo != "2");

            }

            //transfor to privateAcount
            void privateAcount()
            {
                string transforTo;
                double transforeAmount;
                do
                {

                    Console.WriteLine("Privat Konto balance: {0:N2} {1} ", pBalance, sek);
                    Console.WriteLine("CSN Konto {0:N2} {1} ", csnB, sek);
                    

                    Console.WriteLine("Tillgängliga konto att överföra till.");
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine("1.CSN Konto");
                    Console.WriteLine("Välj kontot som du vill överföra till.\n");
                    transforTo = Console.ReadLine();
                    if (transforTo == "1")
                    {

                        do
                        {
                            Console.WriteLine("Lån ballance: {0:N2}  {1} ", csnB, sek);
                            Console.WriteLine("Ange summan som du vill överföra (SEK).");
                            transforeAmount = double.Parse(Console.ReadLine());
                            double totaltansValue = pBalance - transforeAmount;
                            double finishTrans = transforeAmount + csnB;
                            if (transforeAmount < pBalance)
                            {
                                Console.WriteLine("Du överförde {0} SEK från 'private konto' till 'CSN konto' \n", transforeAmount);

                                Console.WriteLine("Nya balance");
                                Console.WriteLine("-------------------------------------\n");
                                Console.WriteLine("Lån ballance: {0:N2} {1}", finishTrans, sek);
                                Console.WriteLine("Spar balance: {0:N2} {1}", totaltansValue, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Du har inte tillräckligt med pengar din balance är {0:N2} {1} försök igen med lägre summa.", pBalance, sek);

                            }
                        } while (transforeAmount > pBalance);

                    }
                    else
                    {
                        Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", transforTo);

                    }

                } while (transforTo != "1");
            }


        }


        //withdraw money user1
        public static void withdraw()
        {

            double pBalance = 50000.23d;
            double csnB = 20000.22d;
            string sek = "SEK";

            string choseAcount;
           
            do
            {


                Console.WriteLine("välj ett konto.");
                Console.WriteLine("----------------------------------\n");
                Console.WriteLine("1.Privat Konto");
                Console.WriteLine("2.CSN Konto");
                choseAcount = Console.ReadLine();
                if (choseAcount == "1")
                {
                    privateWithdraw();
                    break;
                }
                else if (choseAcount == "2")
                {
                    csnWithdraw();
                    break;
                }
                else
                {
                    Console.WriteLine("Du måste välja ett av de alternativerna. \n");
                }
            } while (choseAcount != "1" || choseAcount != "2");
            void privateWithdraw()
            {
                double withdrawAmount;

                //check pass to take out money
                string checkPass;
                do
                {

                
                    Console.WriteLine("Din private konto balance: {0:N} {1}", pBalance, sek);
                    Console.WriteLine("----------------------------------\n");
                    Console.WriteLine("Ange summan som du vill ta ut.");
                    Console.WriteLine("----------------------------------\n");
                    withdrawAmount = double.Parse(Console.ReadLine());

                    double resoutWithdraw = pBalance - withdrawAmount;
                    if (withdrawAmount  < pBalance)
                    {
                        //check pass to take out money
                        do
                        {

                        
                            Console.WriteLine("Skriv din password for att gönomföra det.");
                             checkPass = Console.ReadLine();
                            if (checkPass =="pass1")
                            {
                                Console.WriteLine("\n-- Det är genomfört, du tog ut {0:N} {1}!", withdrawAmount, sek);
                                Console.WriteLine("-- Din private konto balance nu: {0:N} {1}\n", resoutWithdraw, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Fell password kontrollera igen.");
                            }
                        } while (checkPass != "pass1");
                    }
                    else
                    {
                        //Console.WriteLine("Din saldo: {0:N} {1}", pBalance,sek);
                        Console.WriteLine("----------------------------------\n");
                        Console.WriteLine("Du har inte tillräkligt pengar i kontot! var snäll och kontrollera din belop.\n");
                        
                    }
                } while (withdrawAmount > pBalance);
            }

            void csnWithdraw()
            {

                double withdrawAmount;
                string checkPass;
                do
                {


                    Console.WriteLine("Din CSN konto balance: {0:N} {1}", csnB, sek);
                    Console.WriteLine("----------------------------------\n");
                    Console.WriteLine("Ange summan som du vill ta ut.");
                    Console.WriteLine("----------------------------------\n");
                    withdrawAmount = double.Parse(Console.ReadLine());

                    double resoutWithdraw = csnB - withdrawAmount;
                    if (withdrawAmount < csnB)
                    {
                        //check pass to take out money
                        do
                        {


                            Console.WriteLine("Skriv din password for att gönomföra det.");
                            checkPass = Console.ReadLine();
                            if (checkPass == "pass1")
                            {
                                Console.WriteLine("\n-- Det är genomfört, du tog ut {0:N} {1}!", withdrawAmount, sek);
                                Console.WriteLine("-- Din CSN konto balance nu: {0:N} {1}\n", resoutWithdraw, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Fell password kontrollera igen.");
                            }
                        } while (checkPass != "pass1");
                        
                    }
                    else
                    {
                        //Console.WriteLine("Din saldo: {0:N} {1}", pBalance,sek);
                        Console.WriteLine("----------------------------------\n");
                        Console.WriteLine("Du har inte tillräkligt pengar i kontot! var snäll och kontrollera din belop.\n");

                    }
                } while (withdrawAmount > csnB);

            }
        }

        //user2
        public static void Muser2()
        {
            strat:
            Console.WriteLine("-------Huvud Meny----------");
            Console.WriteLine("1. Se dina konton och saldo");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4. Logga ut");

            string input;
            ConsoleKeyInfo keyInfo;
            do
            {
                input = Console.ReadLine();
                if (input == "1") 
                {
                    amountAndAcountUser2();
                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Menu. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }

                    continue;
                }
                else if (input == "2")
                {
                  
                   transfore2();
                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Menu. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }

                    continue;
                }
                else if (input == "3")
                {
                    withdraw2();

                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Menu. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }

                    continue;
                }
                else if (input == "4")
                {
                    logout();
                    break;
                }
                else
                {
                    Console.WriteLine("välj en av alternativ ovan för att gå vidare!");
                }
            } while (input != "1" || input != "2" || input != "3" || input != "4");
            
        }


        

       

        public static void amountAndAcountUser2()
        {
            double lBalance = 303.55;
            double dBalance = 3500.01;
            string sek = "SEK";

           Console.WriteLine("välj en dina konto.");
            Console.WriteLine("--------------------------------\n");
            Console.WriteLine("1.Lån Konto");
            Console.WriteLine("2.Spar Konto");
            string choseAcount = Console.ReadLine();
            if (choseAcount == "1")
            {
                debtAcount();

            }
            else if (choseAcount == "2")
            {
               
                saveAcount();
            }

            void debtAcount()
            {
                Console.WriteLine("Lån ballance: {0:N2} {1} ", lBalance,sek);
            }
            void saveAcount()
            {
                Console.WriteLine("Spar ballance: {0:N2}  {1} ", dBalance,sek);
            }
            
        }

         public static void transfore2()
         {
            double lBalance = 30d;
            double dBalance = 10d;
            string sek = "SEK";
            string choseAcount;
            do
                {

                 Console.WriteLine("välj kontot du vill överföra pengar från.");
            
                Console.WriteLine("-----------------------------------------------------\n");
                Console.WriteLine("1.Lån Konto");
                Console.WriteLine("2.Spar Konto");
                 choseAcount = Console.ReadLine();
                if (choseAcount == "1")
                {
                    debtAcount();
                    break;
                }
                else if (choseAcount == "2")
                {

                    saveAcount();
                    break;
                }
                else
                {
                    Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", choseAcount);
                }
            } while (choseAcount !="1" || choseAcount != "2");

            //transfore to debet acount
            void debtAcount()
            {
                double transforeAmount;


                string transforTo;
                do
                {

                    Console.WriteLine("Lån balance: {0:N2} {1} ", lBalance, sek);
                    Console.WriteLine("Spar balance: {0:N2} {1} ", dBalance, sek);

                    Console.WriteLine("Tillgängliga konto att överföra till.");
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine("2.Spar Konto");
                    Console.WriteLine("Välj kontot som du vill överföra till.\n");
                    transforTo = Console.ReadLine();
                    if (transforTo == "2")
                    {
                       

                        do
                        {
                            Console.WriteLine("Spar ballance: {0:N2}  {1} ", dBalance, sek);
                            Console.WriteLine("Ange summan som du vill överföra (SEK).");
                            transforeAmount = double.Parse(Console.ReadLine());
                            double totaltansValue = lBalance - transforeAmount;
                            double finishTrans = transforeAmount + dBalance;
                            if (transforeAmount < lBalance)
                            {
                                Console.WriteLine("Du överförde {0} SEK från 'Lån konto' till 'spar konto' \n", transforeAmount);

                                Console.WriteLine("Nya balance");
                                Console.WriteLine("-------------------------------------\n");
                                Console.WriteLine("Spar ballance: {0:N2} {1}", finishTrans, sek);
                                Console.WriteLine("Lån balance: {0:N2} {1}", totaltansValue, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Du har inte tillräckligt med pengar din balance är {0:N2} {1} försök igen med lägre summa.", lBalance, sek);

                            }
                        } while (transforeAmount > lBalance);
                       
                    }
                    else
                    {
                        Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", transforTo);
                       
                    }

                } while (transforTo != "2");

            }

            //transfor to saveAcount
            void saveAcount()
            {
                string transforTo;
                double transforeAmount;
                do
                {


                    Console.WriteLine("Lån balance: {0:N2} {1} ", lBalance, sek);
                    Console.WriteLine("Spar balance: {0:N2} {1} ", dBalance, sek);

                    Console.WriteLine("Tillgängliga konto att överföra till.");
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine("1.Lån Konto");
                    Console.WriteLine("Välj kontot som du vill överföra till.\n");
                    transforTo = Console.ReadLine();
                    if (transforTo == "1")
                    {

                        do
                        {
                            Console.WriteLine("Lån ballance: {0:N2}  {1} ", lBalance, sek);
                            Console.WriteLine("Ange summan som du vill överföra (SEK).");
                            transforeAmount = double.Parse(Console.ReadLine());
                            double totaltansValue = dBalance - transforeAmount;
                            double finishTrans = transforeAmount + lBalance;
                            if (transforeAmount < dBalance)
                            {
                                Console.WriteLine("Du överförde {0} SEK från 'spar konto' till 'Lån konto' \n", transforeAmount);

                                Console.WriteLine("Nya balance");
                                Console.WriteLine("-------------------------------------\n");
                                Console.WriteLine("Lån ballance: {0:N2} {1}", finishTrans, sek);
                                Console.WriteLine("Spar balance: {0:N2} {1}", totaltansValue, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Du har inte tillräckligt med pengar din balance är {0:N2} {1} försök igen med lägre summa.",dBalance, sek);

                            }
                        } while (transforeAmount > dBalance);

                    }
                    else
                    {
                        Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", transforTo);

                    }

                } while (transforTo != "1");
            }

            
        }


        //withdraw money user2
        public static void withdraw2()
        {
            double lBalance = 30d;
            double sBalance = 10d;
            string sek = "SEK";

            string choseAcount;

            do
            {


                Console.WriteLine("välj ett konto.");
                Console.WriteLine("----------------------------------\n");
                Console.WriteLine("1.Lån Konto");
                Console.WriteLine("2.Spar Konto");
                choseAcount = Console.ReadLine();
                if (choseAcount == "1")
                {
                    debetWithdraw();
                    break;
                }
                else if (choseAcount == "2")
                {
                    borrowWithdraw();
                    break;
                }
                else
                {
                    Console.WriteLine("Du måste välja ett av de alternativerna. \n");
                }
            } while (choseAcount != "1" || choseAcount != "2");
            void debetWithdraw()
            {
                double withdrawAmount;

                //check pass to take out money
                string checkPass;
                do
                {


                    Console.WriteLine("Din Lån konto balance: {0:N} {1}", lBalance, sek);
                    Console.WriteLine("----------------------------------\n");
                    Console.WriteLine("Ange summan som du vill ta ut.");
                    Console.WriteLine("----------------------------------\n");
                    withdrawAmount = double.Parse(Console.ReadLine());

                    double resoutWithdraw = lBalance - withdrawAmount;
                    if (withdrawAmount < lBalance)
                    {
                        //check pass to take out money
                        do
                        {

                            Console.WriteLine("Skriv din password for att gönomföra det.");
                            checkPass = Console.ReadLine();
                            if (checkPass == "pass2")
                            {
                                Console.WriteLine("\n-- Det är genomfört, du tog ut {0:N} {1}!", withdrawAmount, sek);
                                Console.WriteLine("-- Din Lån konto balance nu: {0:N} {1}\n", resoutWithdraw, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Fell password kontrollera igen.");
                            }
                        } while (checkPass != "pass2");
                    }
                    else
                    {
                        //Console.WriteLine("Din saldo: {0:N} {1}", pBalance,sek);
                        Console.WriteLine("----------------------------------\n");
                        Console.WriteLine("Du har inte tillräkligt pengar i kontot! var snäll och kontrollera din belop.\n");

                    }
                } while (withdrawAmount > lBalance);
            }

            void borrowWithdraw()
            {

                double withdrawAmount;
                //check pass to take out money
                string checkPass;
                do
                {


                    Console.WriteLine("Din Spar konto balance: {0:N} {1}", sBalance, sek);
                    Console.WriteLine("----------------------------------\n");
                    Console.WriteLine("Ange summan som du vill ta ut.");
                    Console.WriteLine("----------------------------------\n");
                    withdrawAmount = double.Parse(Console.ReadLine());

                    double resoutWithdraw = sBalance - withdrawAmount;
                    if (withdrawAmount < sBalance)
                    {
                        //check pass to take out money
                        do
                        {
                            
                            Console.WriteLine("Skriv din password for att gönomföra det.");
                            checkPass = Console.ReadLine();
                            if (checkPass == "pass2")
                            {
                                Console.WriteLine("\n-- Det är genomfört, du tog ut {0:N} {1}!", withdrawAmount, sek);
                                Console.WriteLine("-- Din Spar konto balance nu: {0:N} {1}\n", resoutWithdraw, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Fell password kontrollera igen.");
                            }
                        } while (checkPass != "pass2");

                    }
                    else
                    {
                        //Console.WriteLine("Din saldo: {0:N} {1}", pBalance,sek);
                        Console.WriteLine("----------------------------------\n");
                        Console.WriteLine("Du har inte tillräkligt pengar i kontot! var snäll och kontrollera din belop.\n");

                    }
                } while (withdrawAmount > sBalance);

            }
        }




        //user3
        public static void Muser3()
        {
            strat:
            Console.WriteLine("-------Huvud Meny----------");
            Console.WriteLine("1. Se dina konton och saldo");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4. Logga ut");

            ConsoleKeyInfo keyInfo;
            string input;
            do
            {
                input = Console.ReadLine();
                if (input == "1")
                {
                    amountAndAcountUser3();
                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Menu. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }

                    continue;
                }
                else if (input == "2")
                {
                    transfore3();
                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Menu. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }

                    continue;
                }
                else if (input == "3")
                {
                    withdraw3();
                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Menu. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }

                    continue;
                }
                else if (input == "4")
                {
                    logout();
                    break;
                }
                else
                {
                    Console.WriteLine("välj en av alternativ ovan för att gå vidare!");
                }
            } while (input != "1" || input != "2" || input != "3" || input != "4");

        }





        //input "3"
        public static void amountAndAcountUser3()
        {
            double Abalance = 3300d;
            double Hbalance = 55000d;
            string sek = "SEK";

            Console.WriteLine("välj en dina konto.");
            Console.WriteLine("----------------------");
            Console.WriteLine("1.Avanza Konto");
            Console.WriteLine("2.Handel Konto ");
            string choseAcount = Console.ReadLine();
            if (choseAcount == "1")
            {
                avanzaAcount();
            }
            else if (choseAcount == "2")
            {

                handelAcount();
            }

            void avanzaAcount()
            {
                Console.WriteLine("Avanza ballance: {0} {1} ", Abalance, sek);
            }
            void handelAcount()
            {
               
                Console.WriteLine("Handel ballance: {0} {1} ", Hbalance, sek);

            }


        }
        //transfor3
        public static void transfore3()
        {
            double Abalance = 330d;
            double Hbalance = 550d;
            string sek = "SEK";
            string choseAcount;
            do
            {

                Console.WriteLine("välj kontot du vill överföra pengar från.");

                Console.WriteLine("-----------------------------------------------------\n");
                Console.WriteLine("1.Avanza Konto");
                Console.WriteLine("2.Handel Konto");
                choseAcount = Console.ReadLine();
                if (choseAcount == "1")
                {
                    AvanzaAcount();
                    break;
                }
                else if (choseAcount == "2")
                {

                    HandelAcount();
                    break;
                }
                else
                {
                    Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", choseAcount);
                }
            } while (choseAcount != "1" || choseAcount != "2");

            //transfore to AvanzaAcount
            void AvanzaAcount()
            {
                double transforeAmount;


                string transforTo;
                do
                {

                    Console.WriteLine("Avanza Konto balance: {0:N2} {1} ", Abalance, sek);
                    Console.WriteLine("Handel Konto balance: {0:N2} {1} ", Hbalance, sek);

                    Console.WriteLine("Tillgängliga konto att överföra till.");
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine("2.Handel Konto");
                    Console.WriteLine("Välj kontot som du vill överföra till.\n");
                    transforTo = Console.ReadLine();
                    if (transforTo == "2")
                    {
                        do
                        {
                            Console.WriteLine("Handel Konto ballance: {0:N2}  {1} ", Hbalance, sek);
                            Console.WriteLine("Ange summan som du vill överföra till Handel Konto (SEK).");
                            transforeAmount = double.Parse(Console.ReadLine());
                            double totaltansValue = Abalance - transforeAmount;
                            double finishTrans = transforeAmount + Hbalance;
                            if (transforeAmount < Abalance)
                            {
                                Console.WriteLine("Du överförde {0} SEK från 'Lån konto' till 'spar konto' \n", transforeAmount);

                                Console.WriteLine("Nya balance");
                                Console.WriteLine("-------------------------------------\n");
                               
                                Console.WriteLine("Avanza Kontobalance: {0:N2} {1}", totaltansValue, sek);
                                Console.WriteLine("Handel Konto ballance: {0:N2} {1}", finishTrans, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Du har inte tillräckligt med pengar din balance är {0:N2} {1} försök igen med lägre summa.", Abalance, sek);

                            }
                        } while (transforeAmount > Abalance);

                    }
                    else
                    {
                        Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", transforTo);

                    }

                } while (transforTo != "2");

            }

            //transfor to HandelAcount
            void HandelAcount()
            {
                string transforTo;
                double transforeAmount;
                do
                {


                    Console.WriteLine("Avanza Konto balance: {0:N2} {1} ", Abalance, sek);
                    Console.WriteLine("Handel Konto balance: {0:N2} {1} \n", Hbalance, sek);

                    Console.WriteLine("Tillgängliga konto att överföra till.");
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine("1.Avanza Konto");
                    Console.WriteLine("Välj kontot som du vill överföra till.\n");
                    transforTo = Console.ReadLine();
                    if (transforTo == "1")
                    {

                        do
                        {
                            Console.WriteLine("Avanza Konto ballance: {0:N2}  {1} ", Abalance, sek);
                            Console.WriteLine("Ange summan som du vill överföra till Avanza Konto (SEK).");
                            transforeAmount = double.Parse(Console.ReadLine());
                            double totaltansValue = Hbalance - transforeAmount;
                            double finishTrans = transforeAmount + Abalance;
                            if (transforeAmount < Hbalance)
                            {
                                Console.WriteLine("Du överförde {0} SEK från 'Handel konto' till 'Avanza Konto' \n", transforeAmount);

                                Console.WriteLine("Nya balance");
                                Console.WriteLine("-------------------------------------\n");
                                Console.WriteLine("Avanza konto ballance: {0:N2} {1}", finishTrans, sek);
                                Console.WriteLine("Handel konto balance: {0:N2} {1}", totaltansValue, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Du har inte tillräckligt med pengar din balance är {0:N2} {1} försök igen med lägre summa.", Hbalance, sek);

                            }
                        } while (transforeAmount > Hbalance);

                    }
                    else
                    {
                        Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", transforTo);

                    }

                } while (transforTo != "1");
            }


        }

        //withdra user3 
        public static void withdraw3()
        {
            double Abalance = 330d;
            double Hbalance = 550d;
            string sek = "SEK";
     
            string choseAcount;

            do
            {


                Console.WriteLine("välj ett konto.");
                Console.WriteLine("----------------------------------\n");
                Console.WriteLine("1.Avanza Konto");
                Console.WriteLine("2.Handel Konto");
                choseAcount = Console.ReadLine();
                if (choseAcount == "1")
                {
                    AvanzaWithdraw();
                    break;
                }
                else if (choseAcount == "2")
                {
                    handelWithdraw();
                    break;
                }
                else
                {
                    Console.WriteLine("Du måste välja ett av de alternativerna. \n");
                }
            } while (choseAcount != "1" || choseAcount != "2");
            void AvanzaWithdraw()
            {
                double withdrawAmount;

                //check pass to take out money
                string checkPass;
                do
                {


                    Console.WriteLine("Din Avanza konto balance: {0:N} {1}", Abalance, sek);
                    Console.WriteLine("----------------------------------\n");
                    Console.WriteLine("Ange summan som du vill ta ut.");
                    Console.WriteLine("----------------------------------\n");
                    withdrawAmount = double.Parse(Console.ReadLine());

                    double resoutWithdraw = Abalance - withdrawAmount;
                    if (withdrawAmount < Abalance)
                    {
                        //check pass to take out money
                        do
                        {

                            Console.WriteLine("Skriv din password for att gönomföra det.");
                            checkPass = Console.ReadLine();
                            if (checkPass == "pass3")
                            {
                                Console.WriteLine("\n-- Det är genomfört, du tog ut {0:N} {1}!", withdrawAmount, sek);
                                Console.WriteLine("-- Din Avanza konto balance nu: {0:N} {1}\n", resoutWithdraw, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Fell password kontrollera igen.");
                            }
                        } while (checkPass != "pass3");
                    }
                    else
                    {
                        //Console.WriteLine("Din saldo: {0:N} {1}", pBalance,sek);
                        Console.WriteLine("----------------------------------\n");
                        Console.WriteLine("Du har inte tillräkligt pengar i kontot! var snäll och kontrollera din belop.\n");

                    }
                } while (withdrawAmount > Abalance);
            }

            void handelWithdraw()
            {

                double withdrawAmount;
                //check pass to take out money
                string checkPass;
                do
                {


                    Console.WriteLine("Din Handel konto balance: {0:N} {1}", Hbalance, sek);
                    Console.WriteLine("----------------------------------\n");
                    Console.WriteLine("Ange summan som du vill ta ut.");
                    Console.WriteLine("----------------------------------\n");
                    withdrawAmount = double.Parse(Console.ReadLine());

                    double resoutWithdraw = Hbalance - withdrawAmount;
                    if (withdrawAmount < Hbalance)
                    {
                        //check pass to take out money
                        do
                        {

                            Console.WriteLine("Skriv din password for att gönomföra det.");
                            checkPass = Console.ReadLine();
                            if (checkPass == "pass3")
                            {
                                Console.WriteLine("\n-- Det är genomfört, du tog ut {0:N} {1}!", withdrawAmount, sek);
                                Console.WriteLine("-- Din Handel konto balance nu: {0:N} {1}\n", resoutWithdraw, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Fell password kontrollera igen.");
                            }
                        } while (checkPass != "pass3");

                    }
                    else
                    {
                        //Console.WriteLine("Din saldo: {0:N} {1}", pBalance,sek);
                        Console.WriteLine("----------------------------------\n");
                        Console.WriteLine("Du har inte tillräkligt pengar i kontot! var snäll och kontrollera din belop.\n");

                    }
                } while (withdrawAmount > Hbalance);

            }
        }

        //user4
        public static void Muser4()
        {
            strat:
            Console.WriteLine("-------Huvud Meny----------");
            Console.WriteLine("1. Se dina konton och saldo");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4. Logga ut");

            ConsoleKeyInfo keyInfo;
            string input;
            do
            {
                input = Console.ReadLine();
                if (input == "1")
                {
                    amountAndAcountUser4();
                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Menu. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }

                    continue;
                }
                else if (input == "2")
                {
                    transfore4();
                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Menu. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }

                    continue;
                }
                else if (input == "3")
                {
                    withdraw4();
                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Menu. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }

                    continue;
                }
                else if (input == "4")
                {
                    logout();
                    break;
                }
                else
                {
                    Console.WriteLine("Fel inmat! Välj en av alternativ ovan för att gå vidare!");
                }
            } while (input != "1" || input != "2" || input != "3" || input != "4");

        }





        //user4 input "1"
        public static void amountAndAcountUser4()
        {
            double icaBalance = 155550.00;
            double SEB = 1500.11;
            string sek = "SEK";

            Console.WriteLine("välj en dina konto.");
            Console.WriteLine("-----------------------------\n");
            Console.WriteLine("1.ICA Konto");
            Console.WriteLine("2.SEB Konto ");
            string choseAcount = Console.ReadLine();
            if (choseAcount == "1")
            {
                icaAcount();
            }
            else if (choseAcount == "2")
            {

                sebAcount();
            }

            void icaAcount()
            {
                Console.WriteLine("ICA ballance: {0} {1} ", icaBalance,sek);
            }
            void sebAcount()
            {
                Console.WriteLine("SEB ballance: {0} {1} ", SEB,sek);
            }


        }

        //transfor4 input "2"
        public static void transfore4()
        {
            double icaBalance = 155550.00;
            double SEB = 1500.11;
            string sek = "SEK";
            string choseAcount;
            do
            {

                Console.WriteLine("välj kontot du vill överföra pengar från.");

                Console.WriteLine("-----------------------------------------------------\n");
                Console.WriteLine("1.ICA Konto");
                Console.WriteLine("2.SEB Konto ");
                choseAcount = Console.ReadLine();
                if (choseAcount == "1")
                {
                    icaAcount();
                    break;
                }
                else if (choseAcount == "2")
                {

                    sebAcount();
                    break;
                }
                else
                {
                    Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", choseAcount);
                }
            } while (choseAcount != "1" || choseAcount != "2");

            //transfore to AvanzaAcount
            void icaAcount()
            {
                double transforeAmount;


                string transforTo;
                do
                {

                    Console.WriteLine("Ica Konto balance: {0:N2} {1} ", icaBalance, sek);
                    Console.WriteLine("SEB Konto balance: {0:N2} {1} ", SEB, sek);

                    Console.WriteLine("Tillgängliga konto att överföra till.");
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine("2.SEB Konto");
                    Console.WriteLine("Välj kontot som du vill överföra till.\n");
                    transforTo = Console.ReadLine();
                    if (transforTo == "2")
                    {
                        do
                        {
                            Console.WriteLine("SEB Konto ballance: {0:N2}  {1} ", SEB, sek);
                            Console.WriteLine("Ica Konto balance: {0:N2} {1} \n", icaBalance, sek);
                            Console.WriteLine("Ange summan som du vill överföra till SEB Konto (SEK).");
                            transforeAmount = double.Parse(Console.ReadLine());
                            double totaltansValue = icaBalance - transforeAmount;
                            double finishTrans = transforeAmount + SEB;
                            if (transforeAmount < icaBalance)
                            {
                                Console.WriteLine("Du överförde {0} SEK från 'Ica Konto' till 'SEB konto' \n", transforeAmount);

                                Console.WriteLine("Nya balance");
                                Console.WriteLine("-------------------------------------\n");

                                Console.WriteLine("Ica Konto balance: {0:N2} {1}", totaltansValue, sek);
                                Console.WriteLine("SEB Konto ballance: {0:N2} {1}", finishTrans, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Du har inte tillräckligt med pengar din balance är {0:N2} {1} försök igen med lägre summa.", icaBalance, sek);

                            }
                        } while (transforeAmount > icaBalance);

                    }
                    else
                    {
                        Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", transforTo);

                    }

                } while (transforTo != "2");

            }

            //transfor to HandelAcount
            void sebAcount()
            {
                string transforTo;
                double transforeAmount;
                do
                {


                    Console.WriteLine("Ica Konto balance: {0:N2} {1} ", icaBalance, sek);
                    Console.WriteLine("SEB Konto balance: {0:N2} {1} \n", SEB, sek);

                    Console.WriteLine("Tillgängliga konto att överföra till.");
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine("1.Ica Konto");
                    Console.WriteLine("Välj kontot som du vill överföra till.\n");
                    transforTo = Console.ReadLine();
                    if (transforTo == "1")
                    {

                        do
                        {
                            Console.WriteLine("Ica Konto ballance: {0:N2}  {1} ", icaBalance, sek);
                            Console.WriteLine("SEB Konto balance: {0:N2} {1} \n", SEB, sek);
                            Console.WriteLine("Ange summan som du vill överföra till Ica Konto (SEK).");
                            transforeAmount = double.Parse(Console.ReadLine());
                            double totaltansValue = SEB - transforeAmount;
                            double finishTrans = transforeAmount + icaBalance;
                            if (transforeAmount < SEB)
                            {
                                Console.WriteLine("Du överförde {0} SEK från 'SEB konto' till 'Ica Konto' \n", transforeAmount);

                                Console.WriteLine("Nya balance");
                                Console.WriteLine("-------------------------------------\n");
                                Console.WriteLine("Ica ballance: {0:N2} {1}", finishTrans, sek);
                                Console.WriteLine("SEB balance: {0:N2} {1}", totaltansValue, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Du har inte tillräckligt med pengar din balance är {0:N2} {1} försök igen med lägre summa.", SEB, sek);

                            }
                        } while (transforeAmount > SEB);

                    }
                    else
                    {
                        Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", transforTo);

                    }

                } while (transforTo != "1");
            }


        }

        //withdra user4 
        public static void withdraw4()
        {
            double icaBalance = 155550.00;
            double SEB = 1500.11;
            string sek = "SEK";

            string choseAcount;

            do
            {


                Console.WriteLine("välj ett konto.");
                Console.WriteLine("----------------------------------\n");
               Console.WriteLine("1.ICA Konto");
                Console.WriteLine("2.SEB Konto ");
                choseAcount = Console.ReadLine();
                if (choseAcount == "1")
                {
                    icaWithdraw();
                    break;
                }
                else if (choseAcount == "2")
                {
                    sebWithdraw();
                    break;
                }
                else
                {
                    Console.WriteLine("Du måste välja ett av de alternativerna. \n");
                }
            } while (choseAcount != "1" || choseAcount != "2");
            void icaWithdraw()
            {
                double withdrawAmount;

                //check pass to take out money
                string checkPass;
                do
                {


                    Console.WriteLine("Din ICA konto balance: {0:N} {1}", icaBalance, sek);
                    Console.WriteLine("----------------------------------\n");
                    Console.WriteLine("Ange summan som du vill ta ut.");
                    Console.WriteLine("----------------------------------\n");
                    withdrawAmount = double.Parse(Console.ReadLine());

                    double resoutWithdraw = icaBalance - withdrawAmount;
                    if (withdrawAmount < icaBalance)
                    {
                        //check pass to take out money
                        do
                        {

                            Console.WriteLine("Skriv din password for att gönomföra det.");
                            checkPass = Console.ReadLine();
                            if (checkPass == "pass4")
                            {
                                Console.WriteLine("\n-- Det är genomfört, du tog ut {0:N} {1}!", withdrawAmount, sek);
                                Console.WriteLine("-- Din Ica konto balance nu: {0:N} {1}\n", resoutWithdraw, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Fell password kontrollera igen.");
                            }
                        } while (checkPass != "pass4");
                    }
                    else
                    {
                        //Console.WriteLine("Din saldo: {0:N} {1}", pBalance,sek);
                        Console.WriteLine("----------------------------------\n");
                        Console.WriteLine("Du har inte tillräkligt pengar i kontot! var snäll och kontrollera din belop.\n");

                    }
                } while (withdrawAmount > icaBalance);
            }

            void sebWithdraw()
            {

                double withdrawAmount;
                //check pass to take out money
                string checkPass;
                do
                {


                    Console.WriteLine("Din SEB konto balance: {0:N} {1}", SEB, sek);
                    Console.WriteLine("----------------------------------\n");
                    Console.WriteLine("Ange summan som du vill ta ut.");
                    Console.WriteLine("----------------------------------\n");
                    withdrawAmount = double.Parse(Console.ReadLine());

                    double resoutWithdraw = SEB - withdrawAmount;
                    if (withdrawAmount < SEB)
                    {
                        //check pass to take out money
                        do
                        {

                            Console.WriteLine("Skriv din password for att gönomföra det.");
                            checkPass = Console.ReadLine();
                            if (checkPass == "pass4")
                            {
                                Console.WriteLine("\n-- Det är genomfört, du tog ut {0:N} {1}!", withdrawAmount, sek);
                                Console.WriteLine("-- Din SEB konto balance nu: {0:N} {1}\n", resoutWithdraw, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Fell password kontrollera igen.");
                            }
                        } while (checkPass != "pass4");

                    }
                    else
                    {
                        //Console.WriteLine("Din saldo: {0:N} {1}", pBalance,sek);
                        Console.WriteLine("----------------------------------\n");
                        Console.WriteLine("Du har inte tillräkligt pengar i kontot! var snäll och kontrollera din belop.\n");

                    }
                } while (withdrawAmount > SEB);

            }
        }

        //user5
        public static void Muser5()
        {
            strat:
            Console.WriteLine("-------Huvud Meny----------");
            Console.WriteLine("1. Se dina konton och saldo");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4. Logga ut");

            ConsoleKeyInfo keyInfo;
            string input;
            do
            {
                input = Console.ReadLine();
                if (input == "1")
                {
                    amountAndAcountUser5();
                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Menu. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }

                    continue;
                }
                else if (input == "2")
                {
                    transfore5();

                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Menu. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }

                    continue;
                }
                else if (input == "3")
                {
                    withdraw5();
                    //key info get back to main menu
                    Console.WriteLine("Tryck 'Enter' for att komma till huvud Menu. \n");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        goto strat;
                    }

                    continue;
                }
                else if (input == "4")
                {
                    logout();
                    break;
                }
                else
                {
                    Console.WriteLine("välj en av alternativ ovan för att gå vidare!");
                }
            } while (input != "1" || input != "2" || input != "3" || input != "4");

        }





        //input"1" show balance
        public static void amountAndAcountUser5()
        {
            double Fbalance = 34230.12;
            double Ebalance = 15000.01;
            string sek = "SEK";

            Console.WriteLine("välj en dina konto.");
            Console.WriteLine("-------------------------------------\n");
            Console.WriteLine("1.Företag Konto");
            Console.WriteLine("2.Eget Konto ");
            string choseAcount = Console.ReadLine();
            if (choseAcount == "1")
            {
                componyAcount();
            }
            else if (choseAcount == "2")
            {

                privateAcount();
            }

            void componyAcount()
            {
                Console.WriteLine("Företag ballance: {0} {1} ", Fbalance,sek);
            }
            void privateAcount()
            {
                Console.WriteLine("Eget ballance: {0} {1} ", Ebalance,sek);
            }

           

        }

        //transfor5
        public static void transfore5()
        {
            double Fbalance = 34230.12;
            double Ebalance = 15000.01;
            string sek = "SEK";
            string choseAcount;
            do
            {

                Console.WriteLine("välj kontot du vill överföra pengar från.");

                Console.WriteLine("-----------------------------------------------------\n");
                Console.WriteLine("1.Företag Konto");
                Console.WriteLine("2.Eget Konto ");
                choseAcount = Console.ReadLine();
                if (choseAcount == "1")
                {
                    componiAcount();
                    break;
                }
                else if (choseAcount == "2")
                {

                    privateAAcount();
                    break;
                }
                else
                {
                    Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", choseAcount);
                }
            } while (choseAcount != "1" || choseAcount != "2");

            //transfore to AvanzaAcount
            void componiAcount()
            {
                double transforeAmount;


                string transforTo;
                do
                {

                    Console.WriteLine("Företag Konto balance: {0:N2} {1} ", Fbalance, sek);
                    Console.WriteLine("Eget Konto balance: {0:N2} {1} ", Ebalance, sek);

                    Console.WriteLine("Tillgängliga konto att överföra till.");
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine("2.Eget Konto");
                    Console.WriteLine("Välj kontot som du vill överföra till.\n");
                    transforTo = Console.ReadLine();
                    if (transforTo == "2")
                    {
                        do
                        {
                            Console.WriteLine("Eget Konto ballance: {0:N2}  {1} ", Ebalance, sek);
                            Console.WriteLine("Företag Konto balance: {0:N2} {1} \n", Fbalance, sek);
                            Console.WriteLine("Ange summan som du vill överföra till Eget Konto (SEK).");
                            transforeAmount = double.Parse(Console.ReadLine());
                            double totaltansValue = Fbalance - transforeAmount;
                            double finishTrans = transforeAmount + Ebalance;
                            if (transforeAmount < Fbalance)
                            {
                                Console.WriteLine("Du överförde {0} SEK från 'Företag Konto' till 'Eget konto'. \n", transforeAmount);

                                Console.WriteLine("Nya balance....");
                                Console.WriteLine("-------------------------------------\n");

                                Console.WriteLine("Företag Konto balance: {0:N2} {1}", totaltansValue, sek);
                                Console.WriteLine("Eget Konto ballance: {0:N2} {1}", finishTrans, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Du har inte tillräckligt med pengar din balance är {0:N2} {1} försök igen med lägre summa.", Fbalance, sek);

                            }
                        } while (transforeAmount > Fbalance);

                    }
                    else
                    {
                        Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", transforTo);

                    }

                } while (transforTo != "2");

            }

            //transfor to HandelAcount
            void privateAAcount()
            {
                string transforTo;
                double transforeAmount;
                do
                {



                    Console.WriteLine("Företag Konto balance: {0:N2} {1} ", Fbalance, sek);
                    Console.WriteLine("Eget Konto balance: {0:N2} {1} ", Ebalance, sek);

                    Console.WriteLine("Tillgängliga konto att överföra till.");
                    Console.WriteLine("---------------------------------------\n");
                    Console.WriteLine("1.Företag Konto");
                    Console.WriteLine("Välj kontot som du vill överföra till.\n");
                    transforTo = Console.ReadLine();
                    if (transforTo == "1")
                    {

                        do
                        {
                            Console.WriteLine("Företag Konto ballance: {0:N2}  {1} ", Fbalance, sek);
                            Console.WriteLine("Eget Konto balance: {0:N2} {1} \n", Ebalance, sek);
                            Console.WriteLine("Ange summan som du vill överföra till Företag Konto (SEK).");
                            transforeAmount = double.Parse(Console.ReadLine());
                            double totaltansValue = Ebalance - transforeAmount;
                            double finishTrans = transforeAmount + Fbalance;
                            if (transforeAmount < Ebalance)
                            {
                                Console.WriteLine("Du överförde {0} SEK från 'Eget konto' till 'Företag Konto' \n", transforeAmount);

                                Console.WriteLine("Nya balance");
                                Console.WriteLine("-------------------------------------\n");
                                Console.WriteLine("Företag ballance: {0:N2} {1}", finishTrans, sek);
                                Console.WriteLine("Eget balance: {0:N2} {1}", totaltansValue, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Du har inte tillräckligt med pengar din balance är {0:N2} {1} försök igen med lägre summa.", Ebalance, sek);

                            }
                        } while (transforeAmount > Ebalance);

                    }
                    else
                    {
                        Console.WriteLine(" Detta ({0}) alternative finns inte med, du kan bara välja de som finns!", transforTo);

                    }

                } while (transforTo != "1");
            }


        }

        //withdra user5 
        public static void withdraw5()
        {
            double Fbalance = 34230.12;
            double Ebalance = 15000.01;
            string sek = "SEK";
        
            string choseAcount;

            do
            {


                Console.WriteLine("välj ett konto.");
                Console.WriteLine("----------------------------------\n");
                Console.WriteLine("1.Företag Konto");
                Console.WriteLine("2.Eget Konto ");
                choseAcount = Console.ReadLine();
                if (choseAcount == "1")
                {
                    componithdraw();
                    break;
                }
                else if (choseAcount == "2")
                {
                    minethdraw();
                    break;
                }
                else
                {
                    Console.WriteLine("Du måste välja ett av de alternativerna. \n");
                }
            } while (choseAcount != "1" || choseAcount != "2");
            void componithdraw()
            {
                double withdrawAmount;

                //check pass to take out money
                string checkPass;
                do
                {


                    Console.WriteLine("Din Företag konto balance: {0:N} {1}", Fbalance, sek);
                    Console.WriteLine("----------------------------------\n");
                    Console.WriteLine("Ange summan som du vill ta ut.");
                    Console.WriteLine("----------------------------------\n");
                    withdrawAmount = double.Parse(Console.ReadLine());

                    double resoutWithdraw = Fbalance - withdrawAmount;
                    if (withdrawAmount < Fbalance)
                    {
                        //check pass to take out money
                        do
                        {

                            Console.WriteLine("Skriv din password for att gönomföra det.");
                            checkPass = Console.ReadLine();
                            if (checkPass == "pass5")
                            {
                                Console.WriteLine("\n-- Det är genomfört, du tog ut {0:N} {1}!", withdrawAmount, sek);
                                Console.WriteLine("-- Din Företag konto balance nu: {0:N} {1}\n", resoutWithdraw, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Fell password kontrollera igen.");
                            }
                        } while (checkPass != "pass5");
                    }
                    else
                    {
                        //Console.WriteLine("Din saldo: {0:N} {1}", pBalance,sek);
                        Console.WriteLine("----------------------------------\n");
                        Console.WriteLine("Du har inte tillräkligt pengar i kontot! var snäll och kontrollera din belop.\n");

                    }
                } while (withdrawAmount > Fbalance);
            }

            void minethdraw()
            {

                double withdrawAmount;
                //check pass to take out money
                string checkPass;
                do
                {


                    Console.WriteLine("Din Eget konto balance: {0:N} {1}", Ebalance, sek);
                    Console.WriteLine("----------------------------------\n");
                    Console.WriteLine("Ange summan som du vill ta ut.");
                    Console.WriteLine("----------------------------------\n");
                    withdrawAmount = double.Parse(Console.ReadLine());

                    double resoutWithdraw = Ebalance - withdrawAmount;
                    if (withdrawAmount < Ebalance)
                    {
                        //check pass to take out money
                        do
                        {

                            Console.WriteLine("Skriv din password for att gönomföra det.");
                            checkPass = Console.ReadLine();
                            if (checkPass == "pass5")
                            {
                                Console.WriteLine("\n-- Det är genomfört, du tog ut {0:N} {1}!", withdrawAmount, sek);
                                Console.WriteLine("-- Din Eget konto balance nu: {0:N} {1}\n", resoutWithdraw, sek);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Fell password kontrollera igen.");
                            }
                        } while (checkPass != "pass5");

                    }
                    else
                    {
                        //Console.WriteLine("Din saldo: {0:N} {1}", pBalance,sek);
                        Console.WriteLine("----------------------------------\n");
                        Console.WriteLine("Du har inte tillräkligt pengar i kontot! var snäll och kontrollera din belop.\n");

                    }
                } while (withdrawAmount > Ebalance);

            }
        }


        public static void transferMoney()
        {
            
            Console.WriteLine("välj kontot du vill övrföra pengar från. ");
          
        }

        public static void tackoutMoney()
        {
            Console.WriteLine("hur mycket pengar vill du ta ut?");
        }
        public static void logout()
        {
            Console.WriteLine("Du är vällkomen åter. (:");
         
        }

        



    }
}
