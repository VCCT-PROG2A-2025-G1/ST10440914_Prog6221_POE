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
using System.Windows.Shapes;

namespace CybersecurityAwarenessGUI
{
    public partial class QuizWindow : Window
    {
        private class Question
        {
            public string Text { get; set; }
            public List<string> Options { get; set; }
            public int CorrectIndex { get; set; }
        }

        private readonly List<Question> questions = new List<Question>();
        private Action<string> logActivity;

        private int currentQuestionIndex = 0;
        private int score = 0;

        public QuizWindow(Action<string> logActivityAction)
        {
            InitializeComponent();
            logActivity = logActivityAction;
            LoadQuestions();
            DisplayCurrentQuestion();
        }


        private void LoadQuestions()
        {
            questions.Add(new Question
            {
                Text = "1. What should you do if you receive an email asking for your password?",
                Options = new List<string> { "Reply with your password", "Delete the email", "Report it as phishing", "Ignore it" },
                CorrectIndex = 2
            });

            questions.Add(new Question
            {
                Text = "2. What makes a strong password?",
                Options = new List<string> { "Your pet's name", "Short and simple", "Long and complex with symbols", "123456" },
                CorrectIndex = 2
            });

            questions.Add(new Question
            {
                Text = "3. Which of the following is a sign of a phishing attempt?",
                Options = new List<string> { "Email from your bank with perfect grammar", "Email asking you to confirm personal info urgently", "Newsletter from a trusted site", "Email from a friend" },
                CorrectIndex = 1
            });

            questions.Add(new Question
            {
                Text = "4. Which is the most secure way to access your accounts?",
                Options = new List<string> { "Username and password only", "Password + security question", "Two-factor authentication", "Using the same password everywhere" },
                CorrectIndex = 2
            });

            questions.Add(new Question
            {
                Text = "5. Which of these passwords is the strongest?",
                Options = new List<string> { "password123", "P@55w0rd!", "LetMeIn", "sunshine" },
                CorrectIndex = 1
            });

            questions.Add(new Question
            {
                Text = "6. True or False: HTTPS means a website is completely safe.",
                Options = new List<string> { "True", "False", "Only on login pages", "Only with VPN" },
                CorrectIndex = 1
            });

            questions.Add(new Question
            {
                Text = "7. What is the purpose of antivirus software?",
                Options = new List<string> { "Make your PC faster", "Block spam emails", "Protect against malware", "Manage passwords" },
                CorrectIndex = 2
            });

            questions.Add(new Question
            {
                Text = "8. Which one is a social engineering attack?",
                Options = new List<string> { "Brute-force login", "Phishing email", "Wi-Fi spoofing", "SQL injection" },
                CorrectIndex = 1
            });

            questions.Add(new Question
            {
                Text = "9. What should you do before clicking on a link in an email?",
                Options = new List<string> { "Just click it", "Scan it with antivirus", "Hover to preview URL", "Forward it to a friend" },
                CorrectIndex = 2
            });

            questions.Add(new Question
            {
                Text = "10. Which of these is safest to use?",
                Options = new List<string> { "Public Wi-Fi with no VPN", "Bank app on shared PC", "Your home network with a strong password", "Free proxy browser" },
                CorrectIndex = 2
            });

            questions.Add(new Question
            {
                Text = "11. What is a secure way to store your passwords?",
                Options = new List<string> { "Write them in a notebook", "Store in browser", "Use a password manager", "Text them to yourself" },
                CorrectIndex = 2
            });

            questions.Add(new Question
            {
                Text = "12. Which of these is a good cybersecurity habit?",
                Options = new List<string> { "Using the same password everywhere", "Clicking unknown links", "Keeping software up to date", "Ignoring system updates" },
                CorrectIndex = 2
            });

            questions.Add(new Question
            {
                Text = "13. What is multi-factor authentication?",
                Options = new List<string> { "Using many passwords", "Using one strong password", "Combining a password with another form of ID", "Letting someone else log in for you" },
                CorrectIndex = 2
            });

            questions.Add(new Question
            {
                Text = "14. Which of these is a type of malware?",
                Options = new List<string> { "Phishing", "Trojan", "Firewall", "Cookie" },
                CorrectIndex = 1
            });

            questions.Add(new Question
            {
                Text = "15. What does a firewall do?",
                Options = new List<string> { "Stores passwords", "Blocks unauthorized access", "Infects your PC", "Sends spam" },
                CorrectIndex = 1
            });

            questions.Add(new Question
            {
                Text = "16. Which of these is the safest email attachment to open?",
                Options = new List<string> { "invoice.exe", "document.pdf", "click_me_now.vbs", "account_update.bat" },
                CorrectIndex = 1
            });

            questions.Add(new Question
            {
                Text = "17. What is ransomware?",
                Options = new List<string> { "Spam mail", "A password manager", "Malware that locks your files and demands money", "Antivirus software" },
                CorrectIndex = 2
            });

            questions.Add(new Question
            {
                Text = "18. What is the best way to protect against data loss?",
                Options = new List<string> { "Ignore backups", "Only use cloud", "Use strong passwords", "Regular backups" },
                CorrectIndex = 3
            });

            questions.Add(new Question
            {
                Text = "19. What is a digital footprint?",
                Options = new List<string> { "A type of malware", "A backup method", "Your online activity history", "A virtual shoe size" },
                CorrectIndex = 2
            });

            questions.Add(new Question
            {
                Text = "20. Which of these is NOT a good practice?",
                Options = new List<string> { "Locking your devices", "Leaving accounts logged in on public computers", "Using 2FA", "Avoiding public Wi-Fi for banking" },
                CorrectIndex = 1
            });

        }


        private void DisplayCurrentQuestion()
        {
            if (currentQuestionIndex >= questions.Count)
            {
                QuestionText.Text = $"Quiz complete! Your score: {score}/{questions.Count}";
                AnswerOptions.Visibility = Visibility.Collapsed;

                string resultMessage = score >= questions.Count * 0.7
                    ? "Great job! You're a cybersecurity pro!"
                    : "Keep learning to stay safe online!";
                FeedbackText.Text = resultMessage;

                logActivity?.Invoke($"Quiz completed. Score: {score}/{questions.Count}");
                return;
            }


            Question current = questions[currentQuestionIndex];
            QuestionText.Text = current.Text;
            AnswerOptions.Items.Clear();
            foreach (var option in current.Options)
            {
                AnswerOptions.Items.Add(option);
            }

            FeedbackText.Text = "";
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (AnswerOptions.SelectedIndex == -1)
            {
                FeedbackText.Text = "Please select an answer.";
                return;
            }

            // Prevent out-of-range access
            if (currentQuestionIndex >= questions.Count)
            {
                FeedbackText.Text = "Quiz complete!";
                return;
            }

            Question current = questions[currentQuestionIndex];
            if (AnswerOptions.SelectedIndex == current.CorrectIndex)
            {
                FeedbackText.Text = "Correct!";
                score++;
            }
            else
            {
                FeedbackText.Text = $"Incorrect. The correct answer was: {current.Options[current.CorrectIndex]}";
            }

            currentQuestionIndex++;

            // If quiz is complete, show results immediately and do not call DisplayCurrentQuestion again
            if (currentQuestionIndex >= questions.Count)
            {
                Dispatcher.InvokeAsync(async () =>
                {
                    await System.Threading.Tasks.Task.Delay(1500);
                    QuestionText.Text = $"Quiz complete! Your score: {score}/{questions.Count}";
                    AnswerOptions.Visibility = Visibility.Collapsed;
                    FeedbackText.Text = score >= questions.Count * 0.7
                        ? "Great job! You're a cybersecurity pro!"
                        : "Keep learning to stay safe online!";
                });
            }
            else
            {
                // Delay next question slightly (optional)
                Dispatcher.InvokeAsync(async () =>
                {
                    await System.Threading.Tasks.Task.Delay(1500);
                    DisplayCurrentQuestion();
                });
            }
        }
    }
}
