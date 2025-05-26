using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ST10440914_PROG6221_POEPart2
{
    internal class PhishingResponse
    {
        static Random rand = new Random();

        public static void phishhelp()
        {
            string[] responses = new string[]
            {
                $"Phishing is pretty dangerous cyber attack that's pretty common {Greeting.name}.It's is a type of cyber attack where attackers impersonate legitimate organizations to trick individuals into providing sensitive information, such as passwords or credit card numbers. This is usually done through emails, messages, or fake websites.",
                "If you suspect an email is phishing, do not click on any links or download attachments. Report it to your email provider and delete it.",
                "Watch out for suspicious emails, especially those with strange links, spelling errors, or requests for personal information."
            };

            int num = rand.Next(0, responses.Length);
            TextDelay.textDelay(responses[num]);
        }

        public static void phishrecognize()
        {
            string[] responses = new string[]
            {
                $"Spotting fake emails isn't as hard as you think it is {Greeting.name}. They might contain bad spelling or grammar, come from an unusual email address, or feature imagery or design that feels 'off'. But scams are getting smarter and some even fool the experts. Criminals are increasingly using QR codes within phishing emails to trick users into visiting scam websites.",
                $"Spotting fake emails can be tricky, but look for signs like poor spelling or grammar, unusual email addresses, and suspicious links. If it seems too good to be true, it probably is.",
                $"To spot fake emails, look for poor spelling or grammar, unusual email addresses, and suspicious links. If it seems too good to be true, it probably is."
            };

            int num = rand.Next(0, responses.Length);
            TextDelay.textDelay(responses[num]);
        }

        public static void phishsocial()
        {
            string[] responses = new string[]
            {
                $"Yes {Greeting.name}, phishing can occur on social media. Attackers may send direct messages or post fake offers or links that direct you to phishing websites. Be cautious when clicking on links from unknown users or profiles, and never share personal information on unverified platforms.",
                $"Yes, phishing can happen on social media. Be cautious of messages or posts that ask for personal information or direct you to suspicious links.",
                "Absolutely. Phishing can happen on social media through fake profiles, suspicious links in messages, or scam giveaways. Always be cautious when clicking links or sharing information, even if it looks like it’s from someone you know."
            };

            int num = rand.Next(0, responses.Length);
            TextDelay.textDelay(responses[num]);
        }
    }
}
