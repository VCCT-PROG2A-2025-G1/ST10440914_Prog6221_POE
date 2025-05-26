using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ST10440914_PROG6221_POEPart2
{

    public class Greeting
    {
        public static string asciiArt = "  ____      _                                        _ _         \r\n / ___|   _| |__   ___ _ __ ___  ___  ___ _   _ _ __(_) |_ _   _ \r\n| |  | | | | '_ \\ / _ \\ '__/ __|/ _ \\/ __| | | | '__| | __| | | |\r\n| |__| |_| | |_) |  __/ |  \\__ \\  __/ (__| |_| | |  | | |_| |_| |\r\n \\____\\__, |_.__/ \\___|_|  |___/\\___|\\___|\\__,_|_|  |_|\\__|\\__, |\r\n  ____|___/        _   ____        _                       |___/ \r\n / ___| |__   __ _| |_| __ )  ___ | |_                           \r\n| |   | '_ \\ / _` | __|  _ \\ / _ \\| __|                          \r\n| |___| | | | (_| | |_| |_) | (_) | |_                           \r\n \\____|_| |_|\\__,_|\\__|____/ \\___/ \\__|                          ";
        public static string name;
        public static void greeting()
        {
            //Sound greeting upon program start
            try
            {
                using (SoundPlayer player = new SoundPlayer("Assets/Greeting.wav"))
                {
                    player.Load();
                    player.Play();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            //asiiart display upon program start
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(asciiArt);
            Console.ResetColor();

            //greeting display upon program start
            TextDelay.textDelay("\nHello! Welcome to the Cybersecurity Awareness Bot. I’m here to help you stay safe online.");
            TextDelay.textDelay("\n\nPlease enter your name: ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            name = Console.ReadLine();
            Console.ResetColor();

            TextDelay.textDelay($"Hello {name}, what can I help you with today?");
        }
    }
}
