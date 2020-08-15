using EyeReminder.Properties;
using EyeReminder.Tools;
using EyeReminder.Windows;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace EyeReminder.Models
{
    class MainViewModel
    {
        public ConfigurationModel Configuration { get; private set; }

        public LeftTimeModel LeftTimeModel { get; set; }

        public BreakTimeModel BreakTimeModel { get; set; }

        public ICommand StartButtonCommand { get; set; }

        public ICommand StopButtonCommand { get; set; }

        public ICommand ResetButtonCommand { get; set; }

        public ICommand SettingsButtonCommand { get; set; }

        private bool isTickingActive;
        private bool isLeftTimeTicking;

        private DispatcherTimer timer;

        public MainViewModel(ConfigurationModel configuration)
        {
            isTickingActive = false;
            isLeftTimeTicking = true;
            Configuration = configuration;
            InitTimeModels(configuration);
            InitTimer();
            InitCommands();
        }

        public MainViewModel() : this(ConfigurationModel.GetInstance()) { }

        private void InitCommands()
        {
            StartButtonCommand = new Command(x => true, x => StartCountdown());
            StopButtonCommand = new Command(x => true, x => StopCountdown());
            ResetButtonCommand = new Command(x => true, x => ResetLeftTime());
            SettingsButtonCommand = new Command(x => true, x => OpenSettingsWindow());
        }

        private void InitTimeModels(ConfigurationModel configuration)
        {
            LeftTimeModel = new LeftTimeModel { LeftTime = configuration.LeftTime };
            BreakTimeModel = new BreakTimeModel { BreakTime = configuration.BreakTime };
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

        private void ResetLeftTime()
        {
            if (LeftTimeModel.LeftTime != Configuration.LeftTime)
                LeftTimeModel.LeftTime = Configuration.LeftTime;
            if (BreakTimeModel.BreakTime != Configuration.BreakTime)
                BreakTimeModel.BreakTime = Configuration.BreakTime;
        }

        private void OpenSettingsWindow()
        {
            new SettingsWindow().ShowDialog(); // returns false when window was closed
            if (!isTickingActive)
                RefreshStateTimeModels(ConfigurationModel.GetInstance());
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
            if (LeftTimeModel.LeftTime == TimeSpan.Zero)
            {
                StopCountdown();
                LeftTimeModel.LeftTime = Configuration.LeftTime;
                ShowMessage(Configuration.BreakTimeNotificationMessage);
                StartBreakTimeTick();
            }
            else
                LeftTimeModel.LeftTime -= Constants.Second;
        }

        private void BreakTimeTick(object sender, EventArgs e)
        {
            if (BreakTimeModel.BreakTime == TimeSpan.Zero)
            {
                StopCountdown();
                BreakTimeModel.BreakTime = Configuration.BreakTime;
                ShowMessage(Configuration.BreakTimeOverNotificationMessage);
                StartLeftTimeTick();
            }
            else
                BreakTimeModel.BreakTime -= Constants.Second;
        }

        public void Close()
        {
            if (!isLeftTimeTicking)
                isLeftTimeTicking = true;
            StopCountdown();
        }

        public void RefreshStateTimeModels(ConfigurationModel configuration)
        {
            LeftTimeModel.LeftTime = configuration.LeftTime;
            BreakTimeModel.BreakTime = configuration.BreakTime;
        }
    }
}
