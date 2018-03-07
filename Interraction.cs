using System;
using System.Collections.Generic;
using System.Text;
using static Time.TimeChanger;

namespace Time
{
    public class Interraction
    {
        public static void KeyBordCapture()
        {
            DateTime date = new DateTime();
            bool contToken = true, errorToken = false;
            int rep;

            Console.WriteLine("\n-------------------------------------------" +
                    "\n|-------------TIME CHANGER 2.0------------|" +
                    "\n-------------------------------------------");
            do
            {
                Console.WriteLine("--MENU--" +
    "\n 1: Change Full Date" +
    "\n 2: Change YYYYMMDD only" +
    "\n 3: Change HHMMSS only" +
    "\n 4: Exit" +
    "\n-------------------------------------------");
                do
                {

                    Console.Write("\nYour Choice: ");
                    rep = Convert.ToInt32(Console.ReadLine());

                    switch (rep)
                    {
                        case 1:
                            date = FullDate();
                            errorToken = false;
                            break;
                        case 2:
                            date = DateOnly();
                            errorToken = false;
                            break;
                        case 3:
                            date = TimeOnly(DateTime.Now);
                            errorToken = false;
                            break;
                        case 4:
                            contToken = false;
                            errorToken = false;
                            break;
                        default:
                            Console.WriteLine("Invalid entry: " + rep);
                            errorToken = true;
                            break;
                    }
                } while (errorToken);
                if (contToken)
                {
                    ChangeTime(date);
                }
            } while (contToken);

            DateTime ntpdate = NtpClient.GetNetworkTime();

            ChangeTime(ntpdate);
            Console.WriteLine("Time set back to: ");
            Console.WriteLine("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);

            Console.WriteLine("\n\nExiting program, press a key...");
            Console.Read();
        }

        public static DateTime FullDate()
        {
            int year, month, day, hour, minute, second;
            Console.WriteLine("Enter the full date bellow:");
            Console.Write("Year: ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Month: ");
            month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Day: ");
            day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Hours: ");
            hour = Convert.ToInt32(Console.ReadLine());
            Console.Write("Minutes: ");
            minute = Convert.ToInt32(Console.ReadLine());
            Console.Write("Seconds: ");
            second = Convert.ToInt32(Console.ReadLine());

            return new DateTime(year, month, day, hour, minute, second);
        }

        public static DateTime DateOnly()
        {
            int year, month, day;
            Console.WriteLine("Enter the date only bellow:");
            Console.Write("Year: ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Month: ");
            month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Day: ");
            day = Convert.ToInt32(Console.ReadLine());

            return new DateTime(year, month, day);
        }

        public static DateTime TimeOnly(DateTime today)
        {
            int hour, minute, second;
            Console.WriteLine("Enter the full date bellow:");
            Console.Write("Hours: ");
            hour = Convert.ToInt32(Console.ReadLine());
            Console.Write("Minutes: ");
            minute = Convert.ToInt32(Console.ReadLine());
            Console.Write("Seconds: ");
            second = Convert.ToInt32(Console.ReadLine());

            return new DateTime(today.Year, today.Month, today.Day, hour, minute, second);
        }
    }
}
