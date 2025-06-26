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
    public partial class TaskManagerWindow : Window
    {
        private List<TaskModel> tasks;
        private Action<string> logActivity;

        public TaskManagerWindow(List<TaskModel> taskList, Action<string> logActivityAction)
        {
            InitializeComponent();
            tasks = taskList;
            logActivity = logActivityAction;
            RefreshTaskList();
        }

        private void RefreshTaskList()
        {
            TaskListBox.ItemsSource = null;
            TaskListBox.ItemsSource = tasks;
        }

        private void MarkCompleted_Click(object sender, RoutedEventArgs e)
        {
            TaskModel selected = TaskListBox.SelectedItem as TaskModel;
            if (selected != null)
            {
                selected.IsCompleted = true;
                StatusText.Text = $"Task marked as completed: {selected.Title}";
                logActivity?.Invoke($"Task marked completed: {selected.Title}");
                RefreshTaskList();
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            TaskModel selected = TaskListBox.SelectedItem as TaskModel;
            if (selected != null)
            {
                tasks.Remove(selected);
                StatusText.Text = $"Deleted task: {selected.Title}";
                logActivity?.Invoke($"Task deleted: {selected.Title}");
                RefreshTaskList();
            }
        }
    }
}
