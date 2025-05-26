using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ST10440914_PROG6221_POEPart2
{
    internal class Response
    {
        public static string name = Greeting.name;
        public static string errorMessage = "Sorry, I didn't understand that. Can you please rephrase your question?";

        public static void chatFeature()
        {
            Boolean runApp = true;
            string userInput = "";
            string input = "";
            string topic = "";
            List<string> UserTopic = new List<string>();

            while (runApp == true)
            {
                GeneralResponse.responce();

                // Take in the users input
                Console.ForegroundColor = ConsoleColor.Cyan;
                string? consoleInput = Console.ReadLine();
                if (consoleInput == null)
                {
                    TextDelay.textDelay(errorMessage);
                    continue;
                }
                userInput = consoleInput.ToLower();
                input = Regex.Replace(userInput, @"[^\w\s]", "");
                Console.ResetColor();

                //Add responses for different user inputs              
                //general questions
                if (input.Contains("general") ||
                    input.Contains("how are you") ||
                    input.Contains("how are you doing") ||
                    input.Contains("whats up") ||
                    input.Contains("are you okay"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    GeneralResponse.basic();
                    Console.ResetColor();
                }
                else if (input.Contains("what can i ask you about") ||
                         input.Contains("what can you help me with") ||
                         input.Contains("what questions can i ask you") ||
                         input.Contains("what can i ask"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    GeneralResponse.help();
                    Console.ResetColor();
                }
                else if (input.Contains("thank you") ||
                         input.Contains("i appreciate the help") ||
                         input.Contains("thanks"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    GeneralResponse.appreciate();
                    Console.ResetColor();
                }

                //Sentiment Detection
                else if (input.Contains("worried") ||
                         input.Contains("curious") ||
                         input.Contains("frustrated") ||
                         input.Contains("scared") ||
                         input.Contains("nervous") ||
                         input.Contains("anxious"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.DetectSentiment(input);
                    Console.ResetColor();
                }

                //Detect Interest
                //Displays interests if captured
                else if (input.Contains("show me my interests") ||
                         input.Contains("what am i interested in") ||
                         input.Contains("interests") ||
                         input.Contains("show me what im interested in"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.Remember(UserTopic);
                    Console.ResetColor();
                }
                //Captures interests
                else if (input.Contains("interested in"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.DetectInterest(UserTopic, input);
                    Console.ResetColor();
                }

                //password questions
                else if (input.Contains("password") ||
                         input.Contains("secure password") ||
                         input.Contains("strong password") ||
                         input.Contains("password safety") ||
                         input.Contains("password tips") ||
                         input.Contains("password help") ||
                         input.Contains("Change my password") ||
                         input.Contains("how do I remember my passwords") ||
                         input.Contains("how often should i change my password"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.memres(UserTopic, input);
                    PasswordResponse.phelp();
                    Enhanced.tips(UserTopic);
                    Console.ResetColor();
                }
                else if (input.Contains("password manager") ||
                         input.Contains("manager"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.memres(UserTopic, input);
                    PasswordResponse.pmanager();
                    Enhanced.tips(UserTopic);
                    Console.ResetColor();
                }
                else if (input.Contains("what is two factor authentication") ||
                         input.Contains("tell me about two factor authentication") ||
                         input.Contains("2fa"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.memres(UserTopic, input);
                    PasswordResponse.twofa();
                    Enhanced.tips(UserTopic);
                    Console.ResetColor();
                }

                //Phishing Questions
                else if (input.Contains("phishing") ||
                         input.Contains("what is phishing"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.memres(UserTopic, input);
                    PhishingResponse.phishhelp();
                    Enhanced.tips(UserTopic);
                    Console.ResetColor();
                }
                else if (input.Contains("how can i recognize phishing") ||
                         input.Contains("how do i spot a fake email"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.memres(UserTopic, input);
                    PhishingResponse.phishrecognize();
                    Enhanced.tips(UserTopic);
                    Console.ResetColor();
                }
                else if (input.Contains("can phishing happen on social media") ||
                         input.Contains("can i be scammed online"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.memres(UserTopic, input);
                    PhishingResponse.phishsocial();
                    Enhanced.tips(UserTopic);
                    Console.ResetColor();
                }

                //safe browsing questions
                else if (input.Contains("safe browsing") ||
                         input.Contains("browser") ||
                         input.Contains("How can i tell if a website is safe") ||
                         input.Contains("how can i tell if a website is safe to visit") ||
                         input.Contains("how do i know if a website is safe") ||
                         input.Contains("what makes a website secure") ||
                         input.Contains("how do i know if a website is secure"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.memres(UserTopic, input);
                    SafeBrowsingResponse.safeB();
                    Enhanced.tips(UserTopic);
                    Console.ResetColor();
                }
                else if (input.Contains("malware") ||
                         input.Contains("how can i protect myself from malware"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.memres(UserTopic, input);
                    SafeBrowsingResponse.sbmalware();
                    Enhanced.tips(UserTopic);
                    Console.ResetColor();
                }
                else if (input.Contains("incognito mode") ||
                         input.Contains("what is incognite mode") ||
                         input.Contains("is incognito mode safe"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.memres(UserTopic, input);
                    SafeBrowsingResponse.incmode();
                    Enhanced.tips(UserTopic);
                    Console.ResetColor();
                }
                else if (input.Contains("cookies") ||
                         input.Contains("cookie") ||
                         input.Contains("what are cookies"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.memres(UserTopic, input);
                    SafeBrowsingResponse.cookies();
                    Enhanced.tips(UserTopic);
                    Console.ResetColor();
                }
                else if (input.Contains("is public wifi safe") ||
                         input.Contains("how to stay safe on public wifi") ||
                         input.Contains("what if i have to use public wifi") ||
                         input.Contains("can hackers see what i do on public wifi") ||
                         input.Contains("how do i protect my data on public wifi"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.memres(UserTopic, input);
                    SafeBrowsingResponse.pubwifi();
                    Enhanced.tips(UserTopic);
                    Console.ResetColor();
                }
                else if (input.Contains("how can i stay safe on social media") ||
                         input.Contains("should i post my location online") ||
                         input.Contains("what if someone is impersonating me") ||
                         input.Contains("how to make my account private") ||
                         input.Contains("is it safe to accept random friend requests") ||
                         input.Contains("should i post my birthday online") ||
                         input.Contains("how to stop people from seeing my info"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.memres(UserTopic, input);
                    SafeBrowsingResponse.safesocial();
                    Enhanced.tips(UserTopic);
                    Console.ResetColor();
                }
                else if (input.Contains("privacy"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Enhanced.memres(UserTopic, input);
                    SafeBrowsingResponse.privacyTips();
                    Enhanced.tips(UserTopic);
                    Console.ResetColor();
                }

                // Ending the program by saying goodbye and stuff
                else if (input.Contains("exit") || input.Contains("bye") || input.Contains("cheers") || input.Contains("goodbye") || input.Contains("quit"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TextDelay.textDelay($"Goodbye {name}, have a good day!!");
                    runApp = false;
                }

                else if (input == null)
                {
                    TextDelay.textDelay(errorMessage);
                    continue;
                }
                else
                {
                    TextDelay.textDelay(errorMessage);
                }

                Console.ResetColor();
            }
        }
    }
}
