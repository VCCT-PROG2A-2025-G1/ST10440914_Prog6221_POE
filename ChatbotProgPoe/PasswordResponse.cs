using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ST10440914_PROG6221_POEPart2
{
    internal class PasswordResponse
    {
        public static void phelp()
        {
            string[] responses = new string[]
            {
        $"I'm glad you're curious about strong passwords {Greeting.name}. They're pretty important. You should try to make your passwords at least 12 characters long but 14 or more is better. You should also make use of a combination of uppercase letters, lowercase letters, numbers, and symbols. Try not to use a word that can be found in a dictionary or the name of a person, character, product, or organization.",

        $"It's a good practice to change your passwords every 3-6 months, especially for sensitive accounts. However {Greeting.name}, if you suspect a breach change it immediately.",

        $"Good question {Greeting.name}. A strong password is one that is at least 12 characters long and includes a mix of uppercase letters, lowercase letters, numbers, and symbols. Avoid using easily guessable information like your name or birthdate.",

        $"Everyone forgets their passwords now and again {Greeting.name} so don't feel bad. You can use a password manager to store them securely or create a memorable phrase that incorporates elements of your password."
            };

            Random random = new Random();
            int index = random.Next(0, responses.Length);

            TextDelay.textDelay(responses[index]);
        }


        public static void pmanager()
        {
            string[] responses = new string[]
            {
        $"Password managers are super useful {Greeting.name}. They can help you create and store strong, unique passwords for all your accounts. This makes it a lot easier to manage your online security.",

        $"Password managers are great tools for keeping your passwords safe. They can generate strong passwords for you and store them securely, so you don't have to remember them all. Just make sure to use a reputable one.",

        $"Password managers are a great way to keep your passwords secure. They can generate strong passwords for you and store them safely, so you don't have to remember them all. Just make sure to choose a reputable one."
            };

            Random random = new Random();
            int index = random.Next(0, responses.Length);

            TextDelay.textDelay(responses[index]);
        }


        public static void twofa()
        {
            string[] responses = new string[]
            {
        $"This one is kind of confusing {Greeting.name}. Two-factor authentication (MFA) adds an extra layer of security by requiring something you know (a password) and something you have (like a phone for a verification code) or something you are (like a fingerprint). This helps protect your accounts even if your password is compromised.",

        $"Two-factor authentication (MFA) is a security measure that requires two forms of verification before granting access to an account. This usually involves something you know (like a password) and something you have (like a phone for a verification code). It adds an extra layer of security.",

        "Two-Factor Authentication (2FA) adds an extra layer of security to your accounts by requiring not just your password, but also something you have like a code sent to your phone or an authentication app. Even if someone guesses your password, they can’t access your account without that second factor."
            };

            Random random = new Random();
            int index = random.Next(0, responses.Length);

            TextDelay.textDelay(responses[index]);
        }

    }
}

