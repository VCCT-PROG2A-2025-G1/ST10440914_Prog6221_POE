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
    public partial class TaskWindow : Window
    {
        public TaskModel NewTask { get; private set; }

        public TaskWindow()
        {
            InitializeComponent();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitleBox.Text.Trim();
            string description = TaskDescBox.Text.Trim();
            DateTime? reminder = ReminderDatePicker.SelectedDate;

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a task title.");
                return;
            }

            NewTask = new TaskModel
            {
                Title = title,
                Description = description,
                ReminderDate = reminder
            };

            this.DialogResult = true;
            this.Close();
        }
    }

    public class TaskModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsCompleted { get; set; }

        public string DisplayText
        {
            get
            {
                string status = IsCompleted ? "[✓]" : "[ ]";
                string reminder = ReminderDate.HasValue ? $" (Remind: {ReminderDate.Value.ToShortDateString()})" : "";
                return $"{status} {Title} - {Description}{reminder}";
            }
        }
    }
}
