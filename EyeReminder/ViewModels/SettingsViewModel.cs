using EyeReminder.Interfaces;
using EyeReminder.Models;
using System.Windows.Input;

namespace EyeReminder.ViewModels
{
    class SettingsViewModel : ISettingsWindowViewModel
    {
        public ConfigurationModel configuration;
        public ICountdownTime LeftTimeModel { get; private set; }
        public ICountdownTime BreakTimeModel { get; private set; }
        public ICommand ApplyButtonCommand { get; set; }
        public ICommand CancelButtonCommand { get; set; }
        public ICommand BackButtonCommand { get; set; }

        public SettingsViewModel() : this (ConfigurationModel.GetInstance()) { }

        public SettingsViewModel(ConfigurationModel configuration)
        {
            this.configuration = configuration;

            InitTimeModels();
            //InitTimeNumbers(configuration);
            //InitCommands();
        }
        private void InitTimeModels()
        {
            LeftTimeModel = new CountdownTimeModel { CountdownTime = configuration.LeftTime };
            BreakTimeModel = new CountdownTimeModel { CountdownTime = configuration.BreakTime };
        }

        //private void InitTimeNumbers(ConfigurationModel configuration)
        //{
        //    TimeNumberModel.LeftTimeMinute = configuration.LeftTime.TotalMinutes;
        //    TimeNumberModel.BreakTimeMinute = configuration.BreakTime.TotalMinutes;
        //}

        //private void InitCommands()
        //{
        //    ApplyButtonCommand = new Command(x => true, x => ApplyChanges());
        //    CancelButtonCommand = new Command(x => true, x => CancelChanges());
        //    DefaultButtonCommand = new Command(x => true, x => SetDefaultSettings());
        //    BackButtonCommand = new Command(x => true, x => BackToMainWindow());
        //}
        //private void ApplyChanges()
        //{
        //    throw new NotImplementedException();
        //}

        //private void CancelChanges()
        //{
        //    throw new NotImplementedException();
        //}

        //private void SetDefaultSettings()
        //{
        //    throw new NotImplementedException();
        //}

        //private void BackToMainWindow()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
