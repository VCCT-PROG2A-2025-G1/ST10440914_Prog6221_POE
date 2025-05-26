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
        public static List<string> UserTopic = new List<string>();
        static string name = Greeting.name;
        static Random rand = new Random();
        public static string topic = "";
        static string currtopic = "";

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

        public static void DetectInterest(string input)
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
        public static void Remember()
        {
            TextDelay.textDelay("You were interested in:");
            foreach (string topic in UserTopic)
            {
                TextDelay.textDelay($"\n{topic}");
            }
        }
        public static void memres()
        {
            currtopic = UserTopic[UserTopic.Count-1];

            if (currtopic.Contains("privacy"))
            {
                TextDelay.textDelay("Since you're interested in privacy. ");
            }
            else if (currtopic.Contains("password"))
            {
                TextDelay.textDelay("Since you're interested in passwords. ");
            }
            else if (currtopic.Contains("phishing"))
            {
                TextDelay.textDelay("Since you're interested in phishing. ");
            }
            else if (currtopic.Contains("safety"))
            {
                TextDelay.textDelay("Since you're interested in safety. ");
            }
            else if (currtopic.Contains("2fa"))
            {
                TextDelay.textDelay("Since you're interested in 2fa");
            }
        }
        public static void tips()
        {
            if (currtopic.Contains("privacy"))
            {
                TextDelay.textDelay("Since you're interested in privacy:\n- Review your social media privacy settings.\n- Avoid oversharing personal details online.\n- Use secure, private browsers like Brave or Firefox.\n");
            }
            else if (currtopic.Contains("password"))
            {
                TextDelay.textDelay("Since you're interested in passwords:\n- Use long, complex passwords with symbols.\n- Never reuse the same password.\n- Use a password manager like Bitwarden or LastPass.\n");
            }
            else if (currtopic.Contains("phishing"))
            {
                TextDelay.textDelay("Since you're interested in phishing:\n- Don’t click on suspicious links or attachments.\n- Always verify the sender’s email address.\n- Report phishing emails to your service provider.\n");
            }
            else if (currtopic.Contains("safety"))
            {
                TextDelay.textDelay("Since you're interested in safety:\n- Keep your software and antivirus up to date.\n- Lock your devices when not in use.\n- Use two-factor authentication whenever possible.\n");
            }
            else if (currtopic.Contains("2fa"))
            {
                TextDelay.textDelay("Since you're interested in 2FA:\n- Enable 2FA on all major accounts (email, banking, social).\n- Prefer using an authenticator app over SMS.\n- Keep backup codes in a safe place.\n");
            }
        }
    }
}
