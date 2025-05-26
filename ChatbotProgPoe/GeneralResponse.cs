using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ST10440914_PROG6221_POEPart2
{
    internal class GeneralResponse
    {
        static Random rand = new Random();

        public static void basic()
        {
            string[] responses = new string[]
            {
                "I'm doing great, thanks for asking! Ready to help you stay safe online.",
                "Feeling fantastic! Nothing beats talking cybersecurity with you.",
                $"I'm doing great {Greeting.name}, thanks for asking! Are you ready to talk cyber safety",
                "All systems are running smoothly. Let's secure your digital world together!",
                "Thanks for asking! I’m always at my best when I get to talk about cybersecurity."
            };

            int num = rand.Next(0, responses.Length);
            TextDelay.textDelay(responses[num]);
        }

        public static void help()
        {
            string[] responses = new string[]
            {
                "I'm here to help you with your cybersecurity questions.",
                "Feel free to ask me anything about online safety.",
                $"Good question {Greeting.name}, you can ask me about password safety, phishing, safe browsing and other topics related to cybersecurity.",
                "You can ask me about anything related to online safety like passwords, phishing, scams, and safe browsing.",
                "Great question! I can help you understand how to protect yourself online, from creating strong passwords to spotting fake emails."
            };

            int num = rand.Next(0, responses.Length);
            TextDelay.textDelay(responses[num]);
        }

        public static void appreciate()
        {
            string[] responses = new string[]
            {
                $"You're welcome {Greeting.name}.",
                $"No problem! I'm here to help {Greeting.name}.",
                $"Anytime {Greeting.name}! I'm always here to help you stay safe online."
            };

            int num = rand.Next(0, responses.Length);
            TextDelay.textDelay(responses[num]);
        }

        public static void responce()
        {
            string[] prompts = new string[]
            {
                $"\nGot a question for me {Greeting.name}?: ",
                $"\nWhat would you like help with {Greeting.name}?: ",
                $"\nWould you like to continue our conversation {Greeting.name}?: ",
                $"\nWhat's on your mind {Greeting.name}?: ",
                $"\nWhat's up {Greeting.name}?: "
            };

            int num = rand.Next(0, prompts.Length);
            TextDelay.textDelay("\n\n---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            TextDelay.textDelay(prompts[num]);
            Console.ResetColor();
        }
    }
}
