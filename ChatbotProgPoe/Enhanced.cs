using System;
using System.Collections;
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
        static string name = Greeting.name;
        static Random rand = new Random();
        public static string topic = "";

        public static void DetectSentiment(string input)
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

        public static void DetectInterest(List<string> userTopic, string input)
        {
            
            int index = input.IndexOf("interested in");
            topic = input.Substring(index + 13).Trim().TrimEnd('.', '!', '?');

            if (!string.IsNullOrWhiteSpace(topic) && !userTopic.Contains(topic))
            {
                userTopic.Add(topic);
                TextDelay.textDelay($"Great! I'll remember that you're interested in {topic}. It's a crucial part of staying safe online.");
            }
            else if (userTopic.Contains(topic))
            {
                TextDelay.textDelay($"You've already mentioned you're interested in {topic}.");
            }
        }
        public static void Remember(List<string> userTopic)
        {
            TextDelay.textDelay("You were interested in:");
            foreach (string topic in userTopic)
            {
                TextDelay.textDelay($"\n{topic}");
            }
        }
        public static void memres(List<string> userTopic , string input)
        {
            // Check if UserTopic is empty
            if (userTopic.Count == 0)
            {
                return;
            }

            foreach (string topic in userTopic)
            {
                if (input == topic)
                {
                    if (topic.Contains("privacy"))
                    {
                        TextDelay.textDelay("Since you're interested in privacy.");
                    }
                    else if (topic.Contains("password"))
                    {
                        TextDelay.textDelay("Since you're interested in passwords.");
                    }
                    else if (topic.Contains("phishing"))
                    {
                        TextDelay.textDelay("Since you're interested in phishing.");
                    }
                    else if (topic.Contains("safety"))
                    {
                        TextDelay.textDelay("Since you're interested in safety.");
                    }
                    else if (topic.Contains("2fa"))
                    {
                        TextDelay.textDelay("Since you're interested in 2FA.");
                    }

                    return; // Exit after finding the first matching topic
                }
            }
        }
        public static void tips(List<string> userTopic)
        {
            // Check if UserTopic is empty
            if (userTopic.Count == 0)
            {
                return;
            }

            string currentTopic = userTopic[userTopic.Count - 1];

            if (currentTopic.Contains("privacy"))
            {
                TextDelay.textDelay("\nSince you're interested in privacy:\n- Review your social media privacy settings.\n- Avoid oversharing personal details online.\n- Use secure, private browsers like Brave or Firefox.\n");
            }
            else if (currentTopic.Contains("password"))
            {
                TextDelay.textDelay("\nSince you're interested in passwords:\n- Use long, complex passwords with symbols.\n- Never reuse the same password.\n- Use a password manager like Bitwarden or LastPass.\n");
            }
            else if (currentTopic.Contains("phishing"))
            {
                TextDelay.textDelay("\nSince you're interested in phishing:\n- Don’t click on suspicious links or attachments.\n- Always verify the sender’s email address.\n- Report phishing emails to your service provider.\n");
            }
            else if (currentTopic.Contains("safety"))
            {
                TextDelay.textDelay("\nSince you're interested in safety:\n- Keep your software and antivirus up to date.\n- Lock your devices when not in use.\n- Use two-factor authentication whenever possible.\n");
            }
            else if (currentTopic.Contains("2fa"))
            {
                TextDelay.textDelay("\nSince you're interested in 2FA:\n- Enable 2FA on all major accounts (email, banking, social).\n- Prefer using an authenticator app over SMS.\n- Keep backup codes in a safe place.\n");
            }
        }
    }
}
