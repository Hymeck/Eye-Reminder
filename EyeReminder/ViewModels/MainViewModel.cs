using EyeReminder.Interfaces;
using EyeReminder.Models;
using EyeReminder.Properties;
using EyeReminder.Tools;
using EyeReminder.Windows;
using System;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace EyeReminder.ViewModels
{
    class MainViewModel : IMainWindowViewModel
    {
        private ConfigurationModel configuration;
        private bool isTickingActive;
        private bool isLeftTimeTicking;
        private DispatcherTimer timer;

        public ICountdownTime LeftTimeModel { get; private set; }
        public ICountdownTime BreakTimeModel { get; private set; }
        public ICommand StartButtonCommand { get; set; }
        public ICommand StopButtonCommand { get; set; }
        public ICommand ResetButtonCommand { get; set; }
        public ICommand SettingsButtonCommand { get; set; }

        public MainViewModel(ConfigurationModel configuration)
        {
            isTickingActive = false;
            isLeftTimeTicking = true;
            this.configuration = configuration;
            InitCountdownTimeModels();
            InitTimer();
            InitCommands();
        }

        public MainViewModel() : this(ConfigurationModel.GetInstance()) { }

        private void InitCommands()
        {
            StartButtonCommand = new Command(x => true, x => StartCountdown());
            StopButtonCommand = new Command(x => true, x => StopCountdown());
            ResetButtonCommand = new Command(x => true, x => ResetCountdownTime());
            SettingsButtonCommand = new Command(x => true, x => OpenSettingsWindow());
        }

        private void InitCountdownTimeModels()
        {
            LeftTimeModel = new CountdownTimeModel { CountdownTime = configuration.LeftTime };
            BreakTimeModel = new CountdownTimeModel { CountdownTime = configuration.BreakTime };
        }

        private void InitTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += LeftTimeTick;
            timer.Interval = TimeSpan.FromSeconds(1);
        }

        private void StartCountdown()
        {
            if (!isTickingActive && isLeftTimeTicking)
            {
                isTickingActive = true;
                timer.Start();
            }
        }

        private void StopCountdown()
        {
            if (isTickingActive && isLeftTimeTicking)
            {
                isTickingActive = false;
                timer.Stop();
            }
        }

        private void ResetCountdownTime()
        {
            if (LeftTimeModel.CountdownTime != configuration.LeftTime)
                LeftTimeModel.CountdownTime = configuration.LeftTime;
            if (BreakTimeModel.CountdownTime != configuration.BreakTime)
                BreakTimeModel.CountdownTime = configuration.BreakTime;
        }

        private void OpenSettingsWindow()
        {
            new SettingsWindow().ShowDialog(); // returns false when window was closed
        }

        private void StartBreakTimeTick()
        {
            timer.Tick -= LeftTimeTick;
            timer.Tick += BreakTimeTick;
            StartCountdown();
            isLeftTimeTicking = false;
        }
        private void StartLeftTimeTick()
        {
            timer.Tick -= BreakTimeTick;
            timer.Tick += LeftTimeTick;
            StartCountdown();
            isLeftTimeTicking = true;
        }

        private async void ShowMessage(string message)
        {
            await Task.Run(() =>
            MessageBox.Show(
                    message,
                    Resources.Title,
                    MessageBoxButton.OK,
                    MessageBoxImage.Information,
                    MessageBoxResult.OK,
                    MessageBoxOptions.DefaultDesktopOnly));
        }

        private void LeftTimeTick(object sender, EventArgs e)
        {
            if (LeftTimeModel.CountdownTime != TimeSpan.Zero)
            {
                LeftTimeModel.CountdownTime -= Constants.Second;
                return;
            }

            StopCountdown();
            ShowMessage(configuration.BreakTimeNotificationMessage);
            LeftTimeModel.CountdownTime = configuration.LeftTime;
            StartBreakTimeTick();
        }

        private void BreakTimeTick(object sender, EventArgs e)
        {
            if (BreakTimeModel.CountdownTime != TimeSpan.Zero)
            {
                BreakTimeModel.CountdownTime -= Constants.Second;
                return;
            }

            StopCountdown();
            PlaySoundNotification();
            ShowMessage(configuration.BreakTimeOverNotificationMessage);
            BreakTimeModel.CountdownTime = configuration.BreakTime;
            StartLeftTimeTick();
        }

        private async void PlaySoundNotification() =>
            await Task.Run(() => SystemSounds.Exclamation.Play());

        public void RefreshStateTimeModels()
        {
            LeftTimeModel.CountdownTime = configuration.LeftTime;
            BreakTimeModel.CountdownTime = configuration.BreakTime;
        }
    }
}
