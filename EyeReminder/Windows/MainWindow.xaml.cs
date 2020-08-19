using EyeReminder.Interfaces;
using EyeReminder.Models;
using System.ComponentModel;
using System.Windows;

namespace EyeReminder.Windows
{
    /// <summary>
    /// Interaction logic for EyeReminderWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // DataContext is IMainWindowViewModel instance
        }
    }
}
