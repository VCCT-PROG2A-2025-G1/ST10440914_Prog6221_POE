
/*References
    https://support.microsoft.com/en-us/windows/create-and-use-strong-passwords-c5cebb49-8c53-4f5e-2bc4-fe357ca048eb#:~:text=Create%20strong%20passwords&text=At%20least%2012%20characters%20long,character%2C%20product%2C%20or%20organization.
    https://www.ncsc.gov.uk/collection/phishing-scams/spot-scams#:~:text=They%20might%20contain%20bad%20spelling,users%20into%20visiting%20scam%20websites.
 */

using System;
using System.Media;
using System.Numerics;
using System.IO;

namespace ChatbotProgPoe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string asciiArt = " ___________________\r\n | _______________ |\r\n | |XXXXXXXXXXXXX| |\r\n | |XXXXXXXXXXXXX| |\r\n | |XXXXXXXXXXXXX| |\r\n | |XXXXXXXXXXXXX| |\r\n | |XXXXXXXXXXXXX| |\r\n |_________________|\r\n     _[_______]_\r\n ___[___________]___\r\n|         [_____] []|__\r\n|         [_____] []|  \\__\r\nL___________________J     \\ \\___\\/\r\n ___________________      /\\\r\n/###################\\    (__)";
            string asciiArt = "  ____      _                                        _ _         \r\n / ___|   _| |__   ___ _ __ ___  ___  ___ _   _ _ __(_) |_ _   _ \r\n| |  | | | | '_ \\ / _ \\ '__/ __|/ _ \\/ __| | | | '__| | __| | | |\r\n| |__| |_| | |_) |  __/ |  \\__ \\  __/ (__| |_| | |  | | |_| |_| |\r\n \\____\\__, |_.__/ \\___|_|  |___/\\___|\\___|\\__,_|_|  |_|\\__|\\__, |\r\n  ____|___/        _   ____        _                       |___/ \r\n / ___| |__   __ _| |_| __ )  ___ | |_                           \r\n| |   | '_ \\ / _` | __|  _ \\ / _ \\| __|                          \r\n| |___| | | | (_| | |_| |_) | (_) | |_                           \r\n \\____|_| |_|\\__,_|\\__|____/ \\___/ \\__|                          ";
            string errorMessage = "Sorry, I didn't understand that. Can you please rephrase your question?";

            try
            {
                using (SoundPlayer player = new SoundPlayer("Assets/Test.wav"))
                {
                    player.Load();
                    player.PlaySync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            

            /*string audioPath = Path.Combine("Assets", "Test.wav");

            if (File.Exists(audioPath))
            {
                SoundPlayer player = new SoundPlayer(audioPath);
                player.PlaySync();
            }
            else
            {
                Console.WriteLine("Audio file not found.");
            }*/

            //textDelay function           
            static void textDelay(string greeting, int delay = 5)
            {
                foreach (var c in greeting)
                {
                    Console.Write(c);
                    Thread.Sleep(delay);
                }
            }

            //program start
            //asiiart
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(asciiArt);
            Console.ResetColor();

            //greeting
            Console.WriteLine("\nHello! Welcome to the Cybersecurity Awareness Bot. I’m here to help you stay safe online.");
            Console.Write("\n\nPlease enter your name: ");
            string name = Console.ReadLine();

            Console.Write($"Hello {name}, what can I help you with today?");

            while (true)
            {
                Console.Write("\nAsk me a Question: ");
                string userInput = Console.ReadLine();

                //Add responses for different user inputs

                //general questions
                if (userInput == "How are you?" ||
                    userInput == "How are you doing?" ||
                    userInput == "What’s up?" ||
                    userInput == "Are you okay ?")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("I'm doing great, thank you for asking! Ready to talk cyber safety?");
                    Console.ResetColor();
                }
                else if(userInput == "what can I ask you about?")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You can ask me about password safety, phishing, safe browsing and other topics related to cybersecurity.");
                    Console.ResetColor();
                }

                //Password Safety
                else if (userInput == "How do I make a strong password?" ||
                         userInput == "What’s a secure password?" ||
                         userInput == "Tell me about passwords" ||
                         userInput == "How to keep my password safe?" ||
                         userInput == "Password tips?" ||
                         userInput == "how do I create a good password?" ||
                         userInput == "password help")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("At least 12 characters long but 14 or more is better. A combination of uppercase letters, lowercase letters, numbers, and symbols. Not a word that can be found in a dictionary or the name of a person, character, product, or organization.");
                    Console.ResetColor();
                }

                //Phishing
                else if (userInput == "What is phishing")
                {
                    Console.WriteLine("Phishing is a type of cyber attack where attackers impersonate legitimate organizations to trick individuals into providing sensitive information, such as passwords or credit card numbers. This is often done through emails, messages, or fake websites.");
                }
                else if (userInput == "How do I spot a fake email?")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("They might contain bad spelling or grammar, come from an unusual email address, or feature imagery or design that feels 'off'. But scams are getting smarter and some even fool the experts. Criminals are increasingly using QR codes within phishing emails to trick users into visiting scam websites.");
                    Console.ResetColor();
                }

                //Error Message
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }
    }
}
