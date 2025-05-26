using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ST10440914_PROG6221_POEPart2
{
    internal class SafeBrowsingResponse
    {
        static Random rand = new Random();

        public static void safeB()
        {
            string[] responses = new string[]
            {
                $"It's very easy to tell if a website is safe {Greeting.name}. Look for HTTPS in the URL, a padlock icon in the address bar, and check for reviews or ratings of the site. Avoid visiting sites that have poor design, contain suspicious pop-ups, or ask for unnecessary personal information.",
                $"Safe browsing is all about protecting yourself online. Use secure connections (HTTPS), avoid suspicious links, and keep your software up to date to stay safe.",
                $"Safe browsing is crucial for your online security. Always check for HTTPS in the URL, avoid clicking on suspicious links, and keep your browser updated."
            };

            int num = rand.Next(0, responses.Length);
            TextDelay.textDelay(responses[num]);
        }

        public static void sbmalware()
        {
            string[] responses = new string[]
            {
                $"Use a reputable antivirus program. There are also a couple of free options {Greeting.name}. Keep your browser and operating system up to date, and avoid downloading files or clicking links from untrusted sources. Consider using browser extensions that block malicious ads and websites.",
                $"To stay safe while browsing, use a reputable antivirus program, keep your software updated, and avoid clicking on suspicious links or downloading files from untrusted sources.",
                "To protect yourself from malware, always keep your software and antivirus up to date, avoid clicking suspicious links or downloading unknown files, and only use trusted websites and apps. Using a secure browser and enabling automatic updates can also go a long way."
            };

            int num = rand.Next(0, responses.Length);
            TextDelay.textDelay(responses[num]);
        }

        public static void incmode()
        {
            string[] responses = new string[]
            {
                $"Incognite mode hides your browsing history from the other people on your device. However {Greeting.name}, it doesn’t hide it from your internet provider, employer, or the websites you visit.",
                $"Incognito mode is a private browsing feature that doesn't save your browsing history, cookies, or site data. However, it doesn't make you completely anonymous online.",
                "Incognito mode hides your browsing history from others using your device, but it doesn’t make you anonymous online. Your ISP, employer, and websites can still track you."
            };

            int num = rand.Next(0, responses.Length);
            TextDelay.textDelay(responses[num]);
        }

        public static void cookies()
        {
            string[] responses = new string[]
            {
                $"Cookies store data about your browsing habits {Greeting.name}. Some cookies improve the user's experience but there are others that will track you. Blocking third-party cookies enhances privacy.",
                $"Cookies are small files that store information about your browsing habits. They can enhance your experience but also track your activity. Blocking third-party cookies can improve your privacy.",
                "Cookies are small files websites store on your device to remember your preferences and login info."
            };

            int num = rand.Next(0, responses.Length);
            TextDelay.textDelay(responses[num]);
        }

        public static void pubwifi()
        {
            string[] responses = new string[]
            {
                $"Public Wi-Fi is risky {Greeting.name}. You should avoid banking or shopping. Use a VPN, disable sharing, and never enter passwords or sensitive info unless you're on a secured network.",
                $"Public Wi-Fi can be risky. Avoid sensitive transactions like banking or shopping. Use a VPN, disable sharing, and only enter passwords on secure networks.",
                "Public Wi-Fi can be risky because hackers can intercept your data. Always avoid logging into sensitive accounts on unsecured networks."
            };

            int num = rand.Next(0, responses.Length);
            TextDelay.textDelay(responses[num]);
        }

        public static void safesocial()
        {
            string[] responses = new string[]
            {
                $"You should keep your account private {Greeting.name}. Make sure you don’t share personal info like address or birthday, avoid strangers, and report anything suspicious. Make sure you review your privacy settings often as well.",
                "To stay safe on social media, keep your account private, avoid sharing personal info, and be cautious about accepting friend requests from strangers. Regularly review your privacy settings.",
                "Use strong, unique passwords for every account and enable two-factor authentication whenever possible."
            };

            int num = rand.Next(0, responses.Length);
            TextDelay.textDelay(responses[num]);
        }
    }
}
