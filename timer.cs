using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class timer
    {
        public static void timmer()
        {

            //sätter timer för hur mycket tid ska man vänta om man försökt 4X fel
            DateTime endTime = DateTime.Now.AddSeconds(20);
            // Loopa tills vi når endtime.
            while (DateTime.Now < endTime)
            {
                // räkna tiden som är kvar.
                TimeSpan remaining = endTime - DateTime.Now;

                // skriv tiden som är kvar in line.
                Console.Write($"\r{remaining.Minutes:00}:{remaining.Seconds:00}:{remaining.Milliseconds / 10:00}");

                // Sleep for 100 milliseconds to avoid using too much CPU time.
                System.Threading.Thread.Sleep(100);

            }
            Console.WriteLine("\nDu kan prova logain igen!");

        }
    }
}
