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
    public partial class ActivityLogWindow : Window
    {
        private readonly List<string> fullLog;
        private bool showingAll = false;

        public ActivityLogWindow(List<string> activityLog)
        {
            InitializeComponent();
            fullLog = new List<string>(activityLog);
            LoadLogPreview();
        }

        private void LoadLogPreview()
        {
            LogListBox.Items.Clear();
            int count = fullLog.Count < 10 ? fullLog.Count : 10;

            for (int i = 0; i < count; i++)
            {
                LogListBox.Items.Add(fullLog[i]);
            }

            if (fullLog.Count <= 10)
            {
                ShowMoreButton.Visibility = Visibility.Collapsed;
            }
        }

        private void ShowMoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (!showingAll)
            {
                LogListBox.Items.Clear();
                foreach (string entry in fullLog)
                {
                    LogListBox.Items.Add(entry);
                }

                ShowMoreButton.Content = "Show Less";
                showingAll = true;
            }
            else
            {
                LoadLogPreview();
                ShowMoreButton.Content = "Show More";
                showingAll = false;
            }
        }
    }
}
