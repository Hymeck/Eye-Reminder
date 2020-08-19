using EyeReminder.Interfaces;
using EyeReminder.Models;
using EyeReminder.Tools;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EyeReminder.Windows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            //Loaded += OnSettingsWindowLoaded;
            SetTimeMinutes();
        }

        //private void OnSettingsWindowLoaded(object sender, RoutedEventArgs e)
        //{
        //    //applyButton.Click += 
        //}

        private void SetTimeMinutes()
        {
            ConfigurationModel configuration = ConfigurationModel.GetInstance();
            leftTimeMinute.Content = (int)configuration.LeftTime.TotalMinutes;
            breakTimeMinute.Content = (int)configuration.BreakTime.TotalMinutes;
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
            SetTimeMinutes();
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
    }
}
