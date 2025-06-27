using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

//References
// https://chatgpt.com/

//Youtube Video Presentation link
// https://youtu.be/6mNcBOUJi2M

namespace CybersecurityAwarenessGUI
{
    public partial class MainWindow : Window
    {
        //*********************************************************************************************************************
        public static string userName;
        public bool handled = false; // Flag to check if input was handled
        // List to store tasks and activity log
        private List<TaskModel> taskList = new List<TaskModel>();
        // List to store activity log entries
        private List<string> activityLog = new List<string>();
        // List of greetings to display at startup
        private readonly List<string> greetings = new List<string>
        {
            $"Welcome {userName}! I'm here to help you stay safe online.",
            $"Hey there {userName}! Ready to boost your cybersecurity skills?",
            $"Hi {userName}! Ask me anything about protecting your digital life.",
            $"Hello {userName}! I'm your friendly cybersecurity assistant!"
        };

        //*********************************************************************************************************************
        // Method to get a random greeting from the list
        private string GetRandomGreeting()
        {
            Random rng = new Random();
            int index = rng.Next(greetings.Count); // Picks a random index
            return greetings[index];
        }

        //*********************************************************************************************************************
        // Constructor for MainWindow Greeting
        public MainWindow()
        {
            InitializeComponent();

            // Ask for name before anything else
            NamePromptWindow nameWindow = new NamePromptWindow();
            bool? result = nameWindow.ShowDialog();

            if (result == true)
            {
                userName = nameWindow.UserName;

                string greeting = GetRandomGreeting();
                ChatDisplay.Text += $"Bot: {greeting} {userName}!\n";
                ChatDisplay.Text += $"Bot: How can I assist you today?\n";

                LogActivity($"User name set to {userName}");
            }
            else
            {
                // Default fallback if user closes the window or enters nothing
                userName = "friend";
                ChatDisplay.Text += "Bot: Welcome! How can I assist you today?\n";
            }
        }


        //*********************************************************************************************************************
        private void RespondToInput(string input)
        {
            handled = false;
        }

        //*********************************************************************************************************************
        // Event handler for the Send button click
        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userText = UserInput.Text.Trim();
            userText = userText.ToLower();
            // Store and format
            String retInput = UserInput.Text;
            string formattedInput = $"You: {retInput}";
            UserInput.Clear();
            // Show user's message
            ChatDisplay.Text += $"{formattedInput}\n";

            if (string.IsNullOrEmpty(userText)) return;
            //*********************************************************************************************************************
            //Exiting the Application
            if (userText.Contains("exit") || userText.Contains("bye") || userText.Contains("cheers") || userText.Contains("goodbye") || userText.Contains("quit"))
            {
                ChatDisplay.Text += "Bot: Goodbye! Stay safe online.\n";

                // Wait for 1 second before closing
                await Task.Delay(1000);

                Application.Current.Shutdown();
            }

            //*********************************************************************************************************************
            //Quizz Window
            if (userText.Contains("quiz"))
            {
                LogActivity("Started cybersecurity quiz");
                QuizWindow quiz = new QuizWindow(LogActivity);
                ChatDisplay.Text += $"Bot: Starting the cybersecurity quiz...\n";
                quiz.ShowDialog();
                handled = true;
            }

            //*********************************************************************************************************************
            //Add Task Window
            if (userText.Contains("add task") || userText.Contains("add new task"))
            {
                ChatDisplay.Text += $"Bot: Opening the task creator...\n";
                OpenTaskWindow();
                handled = true;
            }

            //*********************************************************************************************************************
            //Task Manager Window
            if (userText.Contains("manage tasks") || userText.Contains("view tasks") || userText.Contains("task manager"))
            {
                ChatDisplay.Text += $"Bot: Opening the task manager...\n";
                OpenTaskManager();
                handled = true;
            }

            //*********************************************************************************************************************
            //Log Activity/View Window
            if (userText.Contains("activity log") || userText.Contains("what have i have done") ||
                userText.Contains("show me what i have done") || userText.Contains("logs") ||
                userText.Contains("what have you done for me"))
            {
                ChatDisplay.Text += "Bot: Here is your activity log.\n";
                OpenActivityLog();
                handled = true;
            }

            //*********************************************************************************************************************
            //Sentiment Detection
            if (userText.Contains("worried"))
            {
                ChatDisplay.Text += $"Bot: It's completely understandable to feel that way {userName}. Scammers can be very convincing. ";
                ChatDisplay.Text += "Let me share some tips to help you stay safe. ";
                ChatDisplay.Text += "Never click on suspicious links or attachments in emails. ";
                ChatDisplay.Text += "Always verify the sender — even if the message looks official. ";
                ChatDisplay.Text += "Use strong, unique passwords for every account. ";
                ChatDisplay.Text += "Enable two-factor authentication (2FA) on important accounts. ";
                ChatDisplay.Text += "Keep your software, apps, and antivirus up to date. ";
                ChatDisplay.Text += "Don’t share personal information unless you're 100% sure it's safe. ";
                ChatDisplay.Text += "If in doubt, contact the company or person directly using verified info.\n";
            }
            if (userText.Contains("curious"))
            {
                ChatDisplay.Text += $"Bot: Curiosity is great! Let's explore some important cybersecurity topics together {userName}.\n";
            }
            if (userText.Contains("frustrated"))
            {
                ChatDisplay.Text += $"Bot: I'm sorry you're feeling frustrated {userName}. Let's go step by step and make things clearer.\n";
            }
            if (userText.Contains("scared"))
            {
                ChatDisplay.Text += $"Bot: It's okay to feel scared. Cybersecurity can be intimidating, but I'm here to help you navigate it safely {userName}.\n";
            }
            if (userText.Contains("nervous") || userText.Contains("anxious"))
            {
                ChatDisplay.Text += $"Bot: It’s okay to feel nervous or anxious about cybersecurity {userName}. It can be overwhelming at first.\n";
                ChatDisplay.Text += "Bot: I’ll guide you through it and share some tips to help you feel more in control.\n";
            }
            //*********************************************************************************************************************
            //General Questions
            if (userText.Contains("general") ||
                userText.Contains("how are you") ||
                userText.Contains("how are you doing") ||
                userText.Contains("whats up") ||
                userText.Contains("are you okay"))
            {
                string response = Logic.basic(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with general chatbot response");
            }
            if (userText.Contains("what can i ask you about") ||
                userText.Contains("what can you help me with") ||
                userText.Contains("what questions can i ask you") ||
                userText.Contains("what can i ask"))
            {
                string response = Logic.help(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with general chatbot response");
            }
            if (userText.Contains("thank you") ||
                userText.Contains("i appreciate the help") ||
                userText.Contains("thanks"))
            {
                string response = Logic.appreciate(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with general chatbot response");
            }

            //*********************************************************************************************************************
            //Password Questions
            if (userText.Contains("password") ||
                userText.Contains("secure password") ||
                userText.Contains("strong password") ||
                userText.Contains("password safety") ||
                userText.Contains("password tips") ||
                userText.Contains("password help") ||
                userText.Contains("Change my password") ||
                userText.Contains("how do I remember my passwords") ||
                userText.Contains("how often should i change my password"))
            {
                string response = Logic.phelp(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with password chatbot response");
            }
            if (userText.Contains("password manager") ||
                userText.Contains("manager"))
            {
                string response = Logic.pmanager(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with password chatbot response");
            }
            if (userText.Contains("what is two factor authentication") ||
                userText.Contains("tell me about two factor authentication") ||
                userText.Contains("2fa"))
            {
                string response = Logic.twofa(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with password chatbot response");
            }

            //*********************************************************************************************************************
            //Phishing Questions
            if (userText.Contains("phishing") ||
                userText.Contains("what is phishing"))
            {
                string response = Logic.phishhelp(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with phishing chatbot response");
            }
            if (userText.Contains("how can i recognize phishing") ||
                userText.Contains("how do i spot a fake email"))
            {
                string response = Logic.phishrecognize(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with phishing chatbot response");
            }
            if (userText.Contains("can phishing happen on social media") ||
                userText.Contains("can i be scammed online"))
            {
                string response = Logic.phishsocial(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with phishing chatbot response");
            }

            //*********************************************************************************************************************
            //Safe browsing Questions
            if (userText.Contains("safe browsing") ||
                userText.Contains("browser") ||
                userText.Contains("How can i tell if a website is safe") ||
                userText.Contains("how can i tell if a website is safe to visit") ||
                userText.Contains("how do i know if a website is safe") ||
                userText.Contains("what makes a website secure") ||
                userText.Contains("how do i know if a website is secure"))
            {
                string response = Logic.safeB(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with safe browsing chatbot response");
            }
            if (userText.Contains("malware") ||
                userText.Contains("how can i protect myself from malware"))
            {
                string response = Logic.sbmalware(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with safe browsing chatbot response");
            }
            if (userText.Contains("incognito mode") ||
                userText.Contains("what is incognite mode") ||
                userText.Contains("is incognito mode safe"))
            {
                string response = Logic.incmode(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with safe browsing chatbot response");
            }
            if (userText.Contains("cookies") ||
                userText.Contains("cookie") ||
                userText.Contains("what are cookies"))
            {
                string response = Logic.cookies(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with safe browsing chatbot response");
            }
            if (userText.Contains("is public wifi safe") ||
                userText.Contains("how to stay safe on public wifi") ||
                userText.Contains("what if i have to use public wifi") ||
                userText.Contains("can hackers see what i do on public wifi") ||
                userText.Contains("how do i protect my data on public wifi"))
            {
                string response = Logic.pubwifi(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with safe browsing chatbot response");
            }
            if (userText.Contains("how can i stay safe on social media") ||
                userText.Contains("should i post my location online") ||
                userText.Contains("what if someone is impersonating me") ||
                userText.Contains("how to make my account private") ||
                userText.Contains("is it safe to accept random friend requests") ||
                userText.Contains("should i post my birthday online") ||
                userText.Contains("how to stop people from seeing my info"))
            {
                string response = Logic.safesocial(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with safe browsing chatbot response");
            }
            if (userText.Contains("privacy"))
            {
                string response = Logic.privacyTips(userName);
                ChatDisplay.Text += $"Bot: {response}\n";
                LogActivity("Responded with safe browsing chatbot response");
            }

            //Default Response
            if (!handled)
            {
                ChatDisplay.Text += "Bot: I'm not sure how to respond to that. Try asking about cybersecurity tips, tasks, or quizzes.\n";
            }

            UserInput.Clear();
        }

        public static class Logic
        {
            private static readonly Random rand = new Random();

            //*********************************************************************************************************************
            // Basic methods to provide general chatbot responses  
            public static string basic(string userName)
            {
                string[] responses = new string[]
                {
                    "I'm doing great, thanks for asking! Ready to help you stay safe online.",
                    "Feeling fantastic! Nothing beats talking cybersecurity with you.",
                    $"I'm doing great {userName}, thanks for asking! Are you ready to talk cyber safety?",
                    "All systems are running smoothly. Let's secure your digital world together!",
                    "Thanks for asking! I’m always at my best when I get to talk about cybersecurity."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }
            public static string help(string userName)
            {
                string[] responses = new string[]
                {
                    "I'm here to help you with your cybersecurity questions.",
                    "Feel free to ask me anything about online safety.",
                    $"Good question {userName}, you can ask me about password safety, phishing, safe browsing and other topics related to cybersecurity.",
                    "You can ask me about anything related to online safety like passwords, phishing, scams, and safe browsing.",
                    "Great question! I can help you understand how to protect yourself online, from creating strong passwords to spotting fake emails."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }
            public static string appreciate(string userName)
            {
                string[] responses = new string[]
                {
                    $"You're welcome {userName}.",
                    $"No problem! I'm here to help {userName}.",
                    $"Anytime {userName}! I'm always here to help you stay safe online."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }

            //*********************************************************************************************************************
            //Basic Methods to provide password chatbot responses
            public static string phelp(string userName)
            {
                string[] responses = new string[]
                {
                    $"I'm glad you're curious about strong passwords {userName}. They're pretty important. You should try to make your passwords at least 12 characters long but 14 or more is better. You should also make use of a combination of uppercase letters, lowercase letters, numbers, and symbols. Try not to use a word that can be found in a dictionary or the name of a person, character, product, or organization.",
                    $"It's a good practice to change your passwords every 3-6 months, especially for sensitive accounts. However {userName}, if you suspect a breach change it immediately.",
                    $"Good question {userName}. A strong password is one that is at least 12 characters long and includes a mix of uppercase letters, lowercase letters, numbers, and symbols. Avoid using easily guessable information like your name or birthdate.",
                    $"Everyone forgets their passwords now and again {userName} so don't feel bad. You can use a password manager to store them securely or create a memorable phrase that incorporates elements of your password."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }
            public static string pmanager(string userName)
            {
                string[] responses = new string[]
                {
                    $"Password managers are super useful {userName}. They can help you create and store strong, unique passwords for all your accounts. This makes it a lot easier to manage your online security.",
                    $"Password managers are great tools for keeping your passwords safe. They can generate strong passwords for you and store them securely, so you don't have to remember them all. Just make sure to use a reputable one.",
                    $"Password managers are a great way to keep your passwords secure. They can generate strong passwords for you and store them safely, so you don't have to remember them all. Just make sure to choose a reputable one."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }
            public static string twofa(string userName)
            {
                string[] responses = new string[]
                {
                    $"This one is kind of confusing {userName}. Two-factor authentication (MFA) adds an extra layer of security by requiring something you know (a password) and something you have (like a phone for a verification code) or something you are (like a fingerprint). This helps protect your accounts even if your password is compromised.",
                    $"Two-factor authentication (MFA) is a security measure that requires two forms of verification before granting access to an account. This usually involves something you know (like a password) and something you have (like a phone for a verification code). It adds an extra layer of security.",
                    "Two-Factor Authentication (2FA) adds an extra layer of security to your accounts by requiring not just your password, but also something you have like a code sent to your phone or an authentication app. Even if someone guesses your password, they can’t access your account without that second factor."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }

            //*********************************************************************************************************************
            //Basic Methods to provide phishing chatbot responses
            public static string phishhelp(string userName)
            {
                string[] responses = new string[]
                {
                    $"Phishing is pretty dangerous cyber attack that's pretty common {userName}.It's is a type of cyber attack where attackers impersonate legitimate organizations to trick individuals into providing sensitive information, such as passwords or credit card numbers. This is usually done through emails, messages, or fake websites.",
                    "If you suspect an email is phishing, do not click on any links or download attachments. Report it to your email provider and delete it.",
                    "Watch out for suspicious emails, especially those with strange links, spelling errors, or requests for personal information."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }
            public static string phishrecognize(string userName)
            {
                string[] responses = new string[]
                {
                    $"Spotting fake emails isn't as hard as you think it is {userName}. They might contain bad spelling or grammar, come from an unusual email address, or feature imagery or design that feels 'off'. But scams are getting smarter and some even fool the experts. Criminals are increasingly using QR codes within phishing emails to trick users into visiting scam websites.",
                    $"Spotting fake emails can be tricky, but look for signs like poor spelling or grammar, unusual email addresses, and suspicious links. If it seems too good to be true, it probably is.",
                    $"To spot fake emails, look for poor spelling or grammar, unusual email addresses, and suspicious links. If it seems too good to be true, it probably is."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }
            public static string phishsocial(string userName)
            {
                string[] responses = new string[]
                {
                    $"Yes {userName}, phishing can occur on social media. Attackers may send direct messages or post fake offers or links that direct you to phishing websites. Be cautious when clicking on links from unknown users or profiles, and never share personal information on unverified platforms.",
                    $"Yes, phishing can happen on social media. Be cautious of messages or posts that ask for personal information or direct you to suspicious links.",
                    "Absolutely. Phishing can happen on social media through fake profiles, suspicious links in messages, or scam giveaways. Always be cautious when clicking links or sharing information, even if it looks like it’s from someone you know."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }

            //*********************************************************************************************************************
            //Basic Methods to provide safe browsing chatbot responses
            public static string safeB(string userName)
            {
                string[] responses = new string[]
                {
                    $"It's very easy to tell if a website is safe {userName}. Look for HTTPS in the URL, a padlock icon in the address bar, and check for reviews or ratings of the site. Avoid visiting sites that have poor design, contain suspicious pop-ups, or ask for unnecessary personal information.",
                    $"Safe browsing is all about protecting yourself online. Use secure connections (HTTPS), avoid suspicious links, and keep your software up to date to stay safe.",
                    $"Safe browsing is crucial for your online security. Always check for HTTPS in the URL, avoid clicking on suspicious links, and keep your browser updated."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }
            public static string sbmalware(string userName)
            {
                string[] responses = new string[]
                {
                $"Use a reputable antivirus program. There are also a couple of free options {userName}. Keep your browser and operating system up to date, and avoid downloading files or clicking links from untrusted sources. Consider using browser extensions that block malicious ads and websites.",
                $"To stay safe while browsing, use a reputable antivirus program, keep your software updated, and avoid clicking on suspicious links or downloading files from untrusted sources.",
                "To protect yourself from malware, always keep your software and antivirus up to date, avoid clicking suspicious links or downloading unknown files, and only use trusted websites and apps. Using a secure browser and enabling automatic updates can also go a long way."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }
            public static string incmode(string userName)
            {
                string[] responses = new string[]
                {
                $"Incognite mode hides your browsing history from the other people on your device. However {userName}, it doesn’t hide it from your internet provider, employer, or the websites you visit.",
                $"Incognito mode is a private browsing feature that doesn't save your browsing history, cookies, or site data. However, it doesn't make you completely anonymous online.",
                "Incognito mode hides your browsing history from others using your device, but it doesn’t make you anonymous online. Your ISP, employer, and websites can still track you."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }
            public static string cookies(string userName)
            {
                string[] responses = new string[]
                {
                $"Cookies store data about your browsing habits {userName}. Some cookies improve the user's experience but there are others that will track you. Blocking third-party cookies enhances privacy.",
                $"Cookies are small files that store information about your browsing habits. They can enhance your experience but also track your activity. Blocking third-party cookies can improve your privacy.",
                "Cookies are small files websites store on your device to remember your preferences and login info."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }
            public static string pubwifi(string userName)
            {
                string[] responses = new string[]
                {
                $"Public Wi-Fi is risky {userName}. You should avoid banking or shopping. Use a VPN, disable sharing, and never enter passwords or sensitive info unless you're on a secured network.",
                $"Public Wi-Fi can be risky. Avoid sensitive transactions like banking or shopping. Use a VPN, disable sharing, and only enter passwords on secure networks.",
                "Public Wi-Fi can be risky because hackers can intercept your data. Always avoid logging into sensitive accounts on unsecured networks."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }
            public static string safesocial(string userName)
            {
                string[] responses = new string[]
                {
                $"You should keep your account private {userName}. Make sure you don’t share personal info like address or birthday, avoid strangers, and report anything suspicious. Make sure you review your privacy settings often as well.",
                "To stay safe on social media, keep your account private, avoid sharing personal info, and be cautious about accepting friend requests from strangers. Regularly review your privacy settings.",
                "Use strong, unique passwords for every account and enable two-factor authentication whenever possible."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }
            public static string privacyTips(string userName)
            {
                string[] responses = new string[]
                {
                $"Privacy is essential, {userName}. Be mindful of the information you share online. Adjust your privacy settings on social media and limit app permissions on your devices.",
                $"Your privacy matters, {userName}. Avoid using public Wi-Fi for sensitive tasks, disable location sharing when not needed, and think twice before sharing personal information online.",
                $"To protect your privacy online, always use strong passwords, enable two-factor authentication, and avoid signing up for unnecessary services that collect your data."
                };
                int num = rand.Next(responses.Length);
                return responses[num];
            }
        }

        //*********************************************************************************************************************
        //Enter Key submitting
        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendButton_Click(null, null); // Triggers the same action as clicking the button
                e.Handled = true; // Prevents the newline from appearing in the TextBox
            }
        }

        //*********************************************************************************************************************
        //Code to open the Task Window and add a new task
        private void OpenTaskWindow()
        {
            TaskWindow taskWindow = new TaskWindow();
            if (taskWindow.ShowDialog() == true)
            {
                TaskModel addedTask = taskWindow.NewTask;
                taskList.Add(addedTask);
                ChatDisplay.Text += $"Bot: Task added: {addedTask}\n";
                LogActivity($"Task added: {addedTask.Title}");
            }
        }


        //*********************************************************************************************************************
        //Code to open the Task Manager Window
        private void OpenTaskManager()
        {
            LogActivity("Opened Task Manager");
            TaskManagerWindow manager = new TaskManagerWindow(taskList, LogActivity);
            manager.ShowDialog();
        }


        //*********************************************************************************************************************
        //Code to log user activity
        private void LogActivity(string description)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string entry = $"{timestamp} - {description}";

            activityLog.Insert(0, entry); // Add to top of list
            if (activityLog.Count > 10)
                activityLog.RemoveAt(activityLog.Count - 1); // Keep only the last 10 entries
        }

        //*********************************************************************************************************************
        //Code to open the Activity Log Window
        private void OpenActivityLog()
        {
            LogActivity("Opened Activity Log");
            ActivityLogWindow logWindow = new ActivityLogWindow(activityLog);
            logWindow.ShowDialog();
        }
    }
}