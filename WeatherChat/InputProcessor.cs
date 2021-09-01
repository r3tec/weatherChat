using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherChat
{
    public class InputProcessor : BackgroundService
    {
        public enum Advice { None, GoOut, WearSuncsreen, FlyKite, GoodBye}
        string zip = string.Empty;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
                GetZipInfo(stoppingToken);
                if (!string.IsNullOrEmpty(zip))
                {
                    GiveAdvice(stoppingToken);
                    Console.WriteLine($"your zip code is {zip}");
                }
                break;
            }
            Environment.Exit(0);
        }

        private void GetZipInfo(CancellationToken stoppingToken)
        {
            Console.WriteLine("Please type your zipcode and press Enter");
            while (!stoppingToken.IsCancellationRequested && string.IsNullOrEmpty(zip))
            {
                var res = Console.ReadLine();
                if (res == null)
                    break;
                if (res.Length == 5 && int.TryParse(res, out int nZip))
                {
                    zip = nZip.ToString("D5");
                }
                else
                {
                    Console.WriteLine("Try again. Please make sure your zip has exactly five digits");
                    Console.WriteLine("If you wish to exit the app press Ctrl + c");
                }
            }
        }

        private void GiveAdvice(CancellationToken stoppingToken)
        {
            Console.WriteLine("You can ask me the following questions:");
            Console.WriteLine("To find out if you can go out press 1 + Enter");
            Console.WriteLine("To find out if you need to wear sunscreen press 2 + Enter");
            Console.WriteLine("To find out if you can fly a kite press 3 + Enter");
            Console.WriteLine("To end the game press 4 + Enter or press Ctrl + c");

            Advice advice = Advice.None;
            while (!stoppingToken.IsCancellationRequested) {
                var res = Console.ReadLine();
                if (res != null)
                {
                    if (res.Length == 1 && Enum.TryParse(res, out advice))
                    {
                        if (advice == Advice.GoodBye)
                            break;
                        Console.WriteLine($"Advice: {advice}");
                    }
                    else
                        Console.WriteLine("Try again.");
                }
                else
                    Console.WriteLine("Stop requested");
            }
            Console.WriteLine("Good bye!..");
        }
    }
}
