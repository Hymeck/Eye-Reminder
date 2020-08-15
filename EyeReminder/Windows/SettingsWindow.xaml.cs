using EyeReminder.Models;
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

namespace EyeReminder.Windows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private SettingsViewModel settingsViewModel;
        public SettingsWindow()
        {
            InitializeComponent();
            settingsViewModel = new SettingsViewModel();
            leftTimeMinute.Content = (int)settingsViewModel.Configuration.LeftTime.TotalMinutes;
            breakTimeMinute.Content = (int)settingsViewModel.Configuration.BreakTime.TotalMinutes;
        }

        private void LeftTimeNumberClick(object sender, RoutedEventArgs e)
        {
            object buttonContent = ((Button)sender).Content;
            if (!leftTimeMinute.Content.Equals(Convert.ToInt32(buttonContent)))
                leftTimeMinute.Content = Convert.ToInt32(buttonContent);
        }

        private void BreakTimeNumberClick(object sender, RoutedEventArgs e)
        {
            object buttonContent = ((Button)sender).Content;
            if (!breakTimeMinute.Content.Equals(Convert.ToInt32(buttonContent)))
                breakTimeMinute.Content = Convert.ToInt32(buttonContent);
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            leftTimeMinute.Content = (int)settingsViewModel.Configuration.LeftTime.TotalMinutes;
            breakTimeMinute.Content = (int)settingsViewModel.Configuration.BreakTime.TotalMinutes;
        }

        private void ApplyButtonClick(object sender, RoutedEventArgs e)
        {
            TimeSpan leftTime = TimeSpan.FromMinutes(Convert.ToDouble(leftTimeMinute.Content));
            TimeSpan breakTime = TimeSpan.FromMinutes(Convert.ToDouble(breakTimeMinute.Content));

            ConfigurationModel configuration = ConfigurationModel.GetInstance();
            configuration.LeftTime = leftTime;
            configuration.BreakTime = breakTime;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //private void ResetOtherButtons(Button button)
        //{
        //    if (button.Equals(applyButton))
        //    {

        //    }
        //}
    }
}
