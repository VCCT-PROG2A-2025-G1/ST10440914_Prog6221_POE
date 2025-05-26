using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ST10440914_PROG6221_POEPart2
{
    class Enhanced
    {
        static Dictionary<string, string> memory = new Dictionary<string, string>();
        static List<string> interests = new List<string>();
        public static List<string> UserTopic = new List<string>();
        static string input = Response.input;
        static string name = Greeting.name;
        static Random rand = new Random();
        public static string topic = "";

        public static void DetectSentiment()
        {
            if (input.Contains("worried"))
            {
                TextDelay.textDelay($"It's completely understandable to feel that way {name}. Scammers can be very convincing.");
                TextDelay.textDelay("Let me share some tips to help you stay safe.");
            }
            else if (input.Contains("curious"))
            {
                TextDelay.textDelay($"Curiosity is great! Let's explore some important cybersecurity topics together {name}.");
            }
            else if (input.Contains("frustrated"))
            {
                TextDelay.textDelay($"I'm sorry you're feeling frustrated {name}. Let's go step by step and make things clearer.");
            }
            else if (input.Contains("scared"))
            {
                TextDelay.textDelay($"It's okay to feel scared. Cybersecurity can be intimidating, but I'm here to help you navigate it safely {name}.");
            }
            else if (input.Contains("nervous") || input.Contains("anxious"))
            {
                TextDelay.textDelay($"It’s okay to feel nervous or anxious about cybersecurity {name}. It can be overwhelming at first.");
                TextDelay.textDelay("I’ll guide you through it and share some tips to help you feel more in control.");
            }
        }

        public static void DetectInterest()
        {
            if (input.Contains("interested in"))
            {
                int index = input.IndexOf("interested in");
                topic = input.Substring(index + 13).Trim().TrimEnd('.', '!', '?');

                if (!string.IsNullOrWhiteSpace(topic) && !UserTopic.Contains(topic))
                {
                    UserTopic.Add(topic);
                    TextDelay.textDelay($"Great! I'll remember that you're interested in {topic}. It's a crucial part of staying safe online.");
                }
                else if (UserTopic.Contains(topic))
                {
                    TextDelay.textDelay($"You've already mentioned you're interested in {topic}.");
                }
            }
        }

        /*public static void DetectInterest()
        {
            string afterKeyword = input.Substring(input.IndexOf("im interested in") + 18).Trim().TrimEnd('.');

            // Support multiple topics separated by "and", "," or ";"
            string[] topics = afterKeyword.Split(new[] { " and ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string rawTopic in topics)
            {
                string topic = rawTopic.Trim();

                if (!string.IsNullOrWhiteSpace(topic))
                {
                    // Save if it's new
                    if (!interests.Contains(topic))
                    {
                        interests.Add(topic);
                    }

                    // Respond with varied message
                    string[] responses = new string[]
                    {
                        $"Awesome! I'll remember that you're interested in {topic}. Let’s make sure you're well-informed about it.",
                        $"Great! I'll remember that you're interested in {topic}. It's a crucial part of staying safe online.",
                        $"Noted! {topic} is more important than ever in today’s world. I’ve got some tips that can help you tighten up your settings.",
                        $"Got it! {topic} is a key area in cybersecurity. I’ll make sure to provide you with relevant information and tips.",
                    };

                    int num = rand.Next(responses.Length);
                    TextDelay.textDelay(responses[num]); // or Console.WriteLine if you're not using a typewriter effect
                }
            }
        }*/

        /*public static void DetectInterest()
        {
            string afterKeyword = input.Substring(input.IndexOf("interested in") + 13).Trim().TrimEnd('.');

            // Handle multiple topics separated by "and"
            string[] topics = afterKeyword.Split(new[] { " and ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string t in topics)
            {
                string topic = t.Trim();
                if (!string.IsNullOrWhiteSpace(topic) && !interests.Contains(topic))
                {
                    interests.Add(topic);

                    string[] responses = new string[]
                    {
                        $"Awesome! I'll remember that you're interested in {topic}. Let’s make sure you're well-informed about it.",
                        $"Great! I'll remember that you're interested in {topic}. It's a crucial part of staying safe online.",
                        $"Noted! {topic} is more important than ever in today’s world. I’ve got some tips that can help you tighten up your settings.",
                        $"Got it! {topic} is a key area in cybersecurity. I’ll make sure to provide you with relevant information and tips.",
                    };

                    int num = rand.Next(responses.Length);
                    TextDelay.textDelay(responses[num]);
                }
            }
        }*/

        /*public static void Remember()
        {
        /   TextDelay.textDelay("Here's what I remember you're interested in:");
            foreach (string topic in UserTopic)
            {
                TextDelay.textDelay($"- {topic}");
            }
        }*/

        public static void RespondUsingMemory()
        {
            if (input.Contains("")){

            }
            else if (input.Contains(""))
            {

            }
            else if (input.Contains(""))
            {

            }
        }
    }


    /*internal class Enhanced
    {

        public static string userInput = Response.userInput;
        public static string name = Greeting.name;
        public static string errorMessage = Response.errorMessage;             
        static Random rand = new Random();
        static List<string> interests = new List<string>();
        static List<string> phishingTips = new List<string>()
        {
            "Don't click on links in emails from unknown senders.",
            "Hover over links to see where they lead before clicking.",
            "Look for spelling errors or strange formatting.",
            "Avoid downloading attachments from suspicious emails."
        };

        public static void chatFeature()
        {            
            // Sentiment detection
            if (userInput.Contains("worried") || userInput.Contains("scared"))
            {
                TextDelay.textDelay($"It's okay to feel that way, {name}. Cybersecurity can be intimidating, but I'm here to help.");
            }
            else if (userInput.Contains("curious") || userInput.Contains("interested"))
            {
                TextDelay.textDelay($"Curiosity is the first step to staying safe online, {name}!");
            }

            // Keyword recognition + memory
            else if (userInput.Contains("password"))
            {
                if (!interests.Contains("password")) interests.Add("password");
                HandlePasswordTips();
            }
            else if (userInput.Contains("phishing") || userInput.Contains("phising"))
            {
                if (!interests.Contains("phishing")) interests.Add("phishing");
                int index = rand.Next(phishingTips.Count);
                TextDelay.textDelay($"{phishingTips[index]} {name}.");
            }
            else if (userInput.Contains("privacy"))
            {
                if (!interests.Contains("privacy")) interests.Add("privacy");
                TextDelay.textDelay($"Great! I'll remember that you're interested in privacy, {name}.");
            }
            else if (userInput.Contains("social media"))
            {
                TextDelay.textDelay($"Stay safe by keeping your accounts private, avoid oversharing, and report suspicious activity, {name}.");
            }
            else if (userInput.Contains("how are you") || userInput.Contains("are you okay") || userInput.Contains("whats up"))
            {
                TextDelay.textDelay($"I'm doing great {name}, thanks for asking! Are you ready to talk cyber safety?");
            }
            else if (userInput.Contains("what can i ask") || userInput.Contains("help me with"))
            {
                TextDelay.textDelay($"Good question {name}, you can ask me about password safety, phishing, safe browsing, and other topics related to cybersecurity.");
            }
            else if (userInput.Contains("remind me") || userInput.Contains("what do you know about me"))
            {
                if (interests.Count > 0)
                {
                    TextDelay.textDelay($"You told me you're interested in: {string.Join(", ", interests)}.");
                }
                else
                {
                    TextDelay.textDelay("I don't know much yet. Tell me what you're interested in!");
                }
            }
            else
            {
                TextDelay.textDelay(errorMessage);
            }

            Console.ResetColor();
        }

        private static void HandlePasswordTips()
        {
            TextDelay.textDelay($"I'm glad you're curious about strong passwords {name}. Here's some advice:");
            TextDelay.textDelay("- Use at least 12–14 characters.");
            TextDelay.textDelay("- Combine uppercase, lowercase, numbers, and symbols.");
            TextDelay.textDelay("- Avoid common words or personal info.");
            TextDelay.textDelay("- Use a password manager if possible.");
        }
    } */
}
