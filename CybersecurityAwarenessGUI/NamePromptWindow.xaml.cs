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
    public partial class NamePromptWindow : Window
    {
        public string UserName { get; private set; }

        public NamePromptWindow()
        {
            InitializeComponent();
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameInput.Text))
            {
                UserName = FormatName(NameInput.Text.Trim());
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter your name.");
            }
        }

        private string FormatName(string input)
        {
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
