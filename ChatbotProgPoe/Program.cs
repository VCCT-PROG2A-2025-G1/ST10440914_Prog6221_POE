
/*References
 * https://chatgpt.com/
 */

/* Youtube Video Presentation
 * https://youtu.be/jd0WOrJGdLA
 */

using System;
using System.Media;
using System.Numerics;
using System.IO;
using System.Text.RegularExpressions;

namespace ChatbotProgPoe
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string asciiArt = "  ____      _                                        _ _         \r\n / ___|   _| |__   ___ _ __ ___  ___  ___ _   _ _ __(_) |_ _   _ \r\n| |  | | | | '_ \\ / _ \\ '__/ __|/ _ \\/ __| | | | '__| | __| | | |\r\n| |__| |_| | |_) |  __/ |  \\__ \\  __/ (__| |_| | |  | | |_| |_| |\r\n \\____\\__, |_.__/ \\___|_|  |___/\\___|\\___|\\__,_|_|  |_|\\__|\\__, |\r\n  ____|___/        _   ____        _                       |___/ \r\n / ___| |__   __ _| |_| __ )  ___ | |_                           \r\n| |   | '_ \\ / _` | __|  _ \\ / _ \\| __|                          \r\n| |___| | | | (_| | |_| |_) | (_) | |_                           \r\n \\____|_| |_|\\__,_|\\__|____/ \\___/ \\__|                          ";
            string errorMessage = "Sorry, I didn't understand that. Can you please rephrase your question?";
            string userInput;
            Boolean runApp;
            

            //Sound greeting
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
            textDelay("\nHello! Welcome to the Cybersecurity Awareness Bot. I’m here to help you stay safe online.");
            textDelay("\n\nPlease enter your name: ");

            string name = Console.ReadLine();

            textDelay($"Hello {name}, what can I help you with today?");

            runApp = true;

            while (runApp == true)
            {
                textDelay("\n\n---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                textDelay("\nAsk me a Question or type 'exit' to exit: ");
                Console.ResetColor();

                string input = Console.ReadLine().ToLower();
                userInput = Regex.Replace(input, @"[^\w\s]", "");


                //Add responses for different user inputs              

                switch (userInput)
                {
                    //general questions
                    case "how are you":
                    case "how are you doing":
                    case "whats up":
                    case "are you okay":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"I'm doing great {name}, thanks for asking! Are you ready to talk cyber safety");
                        Console.ResetColor();
                        break;
                    case "what can i ask you about":
                    case "what can you help me with":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"Good question {name}, you can ask me about password safety, phishing, safe browsing and other topics related to cybersecurity.");
                        Console.ResetColor();
                        break;

                    //Password Safety
                    case "how do i make a strong password":
                    case "whats a secure password":
                    case "tell me about passwords":
                    case "how to keep my password safe":
                    case "password tips":
                    case "how do i create a good password":
                    case "password help":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"I'm glad you're curious about strong passwords {name}. They're pretty important. You should try to make your passwords at least 12 characters long but 14 or more is better. You should also make use of a combination of uppercase letters, lowercase letters, numbers, and symbols. Try not to use a word that can be found in a dictionary or the name of a person, character, product, or organization.");
                        Console.ResetColor();
                        break;
                    case "why should i use a password manager":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"Password managers are super useful {name}. They can help you create and store strong, unique passwords for all your accounts. This makes it a lot easier to manage your online security.");
                        Console.ResetColor();
                        break;
                    case "how often should i change my password":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"It's a good practice to change your passwords every 3-6 months, especially for sensitive accounts. However {name}, if you suspect a breach change it immediately.");
                        Console.ResetColor();
                        break;
                    case "how do I remember my passwords":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"Everyone forgets their passwords now and again {name} so don't feel bad. You can use a password manager to store them securely or create a memorable phrase that incorporates elements of your password.");
                        Console.ResetColor();
                        break;
                    case "what is two factor authentication":
                    case "tell me about two factor authentication":
                    case "2fa":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"This one is kind of confusing {name}. Two-factor authentication (MFA) adds an extra layer of security by requiring something you know (a password) and something you have (like a phone for a verification code) or something you are (like a fingerprint). This helps protect your accounts even if your password is compromised.");
                        break;

                    //phishing
                    case "what is phishing":
                    case "phising":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"Phishing is pretty dangerous cyber attack that's pretty common {name}.It's is a type of cyber attack where attackers impersonate legitimate organizations to trick individuals into providing sensitive information, such as passwords or credit card numbers. This is usually done through emails, messages, or fake websites.");
                        Console.ResetColor();
                        break;
                    case "how can i recognize phishing":
                    case "how do i spot a fake email":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"Spotting fake emails isn't as hard as you think it is {name}. They might contain bad spelling or grammar, come from an unusual email address, or feature imagery or design that feels 'off'. But scams are getting smarter and some even fool the experts. Criminals are increasingly using QR codes within phishing emails to trick users into visiting scam websites.");
                        Console.ResetColor();
                        break;
                    case "what should i do if i suspect a fake email":
                    case "what do i do if i suspect a phishing email":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay("If you suspect an email is phishing, do not click on any links or download attachments. Report it to your email provider and delete it.");
                        Console.ResetColor();
                        break;
                    case "can phishing happen on social media":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"Yes {name}, phishing can occur on social media. Attackers may send direct messages or post fake offers or links that direct you to phishing websites. Be cautious when clicking on links from unknown users or profiles, and never share personal information on unverified platforms.");
                        Console.ResetColor();
                        break;
                    
                    //Safe Browsing
                    case "How can i tell if a website is safe":
                    case "how can i tell if a website is safe to visit":
                    case "how do i know if a website is safe":
                    case "what makes a website secure":
                    case "how do i know if a website is secure":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"It's very easy to tell if a website is safe {name}. Look for HTTPS in the URL, a padlock icon in the address bar, and check for reviews or ratings of the site. Avoid visiting sites that have poor design, contain suspicious pop-ups, or ask for unnecessary personal information.");
                        Console.ResetColor();
                        break;
                    case "how can i protect myself from malware":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"Use a reputable antivirus program. There are also a couple of free options {name}. Keep your browser and operating system up to date, and avoid downloading files or clicking links from untrusted sources. Consider using browser extensions that block malicious ads and websites.");
                        Console.ResetColor();
                        break;
                    case "what is incognite mode":
                    case "is incognito mode safe":
                    case "inognite mode":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"Incognite mode hides your browsing history from the other people on your device. However {name}, it doesn’t hide it from your internet provider, employer, or the websites you visit.");
                        Console.ResetColor();
                        break;
                    case "what are cookies":
                    case "cookies":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"Cookies store data about your browsing habits {name}. Some cookies improve the user's experience but there are others that will track you. Blocking third-party cookies enhances privacy.");
                        Console.ResetColor();
                        break;
                    case "is public wifi safe":
                    case "how to stay safe on public wifi":
                    case "what if i have to use public wifi":
                    case "can hackers see what i do on public wifi":
                    case "how do i protect my data on public wifi":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay($"Public Wi-Fi is risky {name}. You should avoid banking or shopping. Use a VPN, disable sharing, and never enter passwords or sensitive info unless you're on a secured network.");
                        Console.ResetColor();
                        break;
                    case "how can i stay safe on social media":
                    case "should i post my location online":
                    case "what if someone is impersonating me":
                    case "how to make my account private":
                    case "is it safe to accept random friend requests":
                    case "should i post my birthday online":
                    case "how to stop people from seeing my info":
                    case "how do i report abuse on social media":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay("You should keep your account private {name}. Make sure you don’t share personal info like address or birthday, avoid strangers, and report anything suspicious. Make sure you review your privacy settings often aswell.");
                        Console.ResetColor();
                        break;

                    //exit application
                    case "exit":
                    case "quit":
                    case "bye":
                    case "goodbye":
                    case "i'm done":
                    case "see you":
                    case "stop":
                        Console.ForegroundColor = ConsoleColor.Red;
                        textDelay($"Exiting application. Goodbye {name}!!");
                        runApp = false;
                        break;

                    //Exception handling
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        textDelay(errorMessage);
                        Console.ResetColor();
                        break;

                }
            }
        }
    }
}
