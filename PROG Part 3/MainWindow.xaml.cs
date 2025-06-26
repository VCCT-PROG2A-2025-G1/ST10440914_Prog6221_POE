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
using ST10440914_PROG6221_POEPart2;

namespace PROG_Part_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text;
            TextBlock userMessage = new TextBlock { Text = "You: " + input };
            ChatHistory.Children.Add(userMessage);

            string response = ChatbotLogic.Respond(input); // Call your chatbot logic here
            TextBlock botMessage = new TextBlock { Text = "Bot: " + response };
            ChatHistory.Children.Add(botMessage);

            UserInput.Clear();
        }
    }
}
