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

//References
// https://chatgpt.com/

//Youtube Video Presentation link

namespace CybersecurityAwarenessGUI
{
    public partial class MainWindow : Window
    {
        //*********************************************************************************************************************
        public static string userName;
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
        // Event handler for the Send button click
        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userText = UserInput.Text.Trim();
            userText = userText.ToLower();

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
                quiz.ShowDialog();
            }


            //*********************************************************************************************************************
            //Task Window
            if (userText.Contains("add task") || userText.Contains("add new task"))
            {
                OpenTaskWindow();
            }

            //*********************************************************************************************************************
            //Task Manager Window
            if (userText.Contains("manage tasks") || userText.Contains("view tasks") || userText.Contains("task manager"))
            {
                OpenTaskManager();
            }

            //*********************************************************************************************************************
            //Log Activity/View Window
            if (userText.Contains("activity log") || userText.Contains("what have i have done") || userText.Contains("show me what i have done") || userText.Contains("logs"))
            {
                OpenActivityLog();
            }

            //*********************************************************************************************************************
            //General Responses
            if (userText.Contains("general") ||
                    userText.Contains("how are you") ||
                    userText.Contains("how are you doing") ||
                    userText.Contains("whats up") ||
                    userText.Contains("are you okay"))
            {
                Logic.basic();
            }
            else if (userText.Contains("what can i ask you about") ||
                     userText.Contains("what can you help me with") ||
                     userText.Contains("what questions can i ask you") ||
                     userText.Contains("what can i ask"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                GeneralResponse.help();
                Console.ResetColor();
            }
            else if (userText.Contains("thank you") ||
                     userText.Contains("i appreciate the help") ||
                     userText.Contains("thanks"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                GeneralResponse.appreciate();
                Console.ResetColor();
            }


            //Default Response
            else
            {
                ChatDisplay.Text += $"Bot: You said \"{userText}\"\n";
                //ChatDisplay.Text += "Bot: I'm not sure how to respond to that. Try asking about cybersecurity tips, tasks, or quizzes.\n";
            }

            UserInput.Clear();
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
