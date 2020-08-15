using EyeReminder.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EyeReminder.Models
{
    class SettingsViewModel
    {
        public ConfigurationModel Configuration { get; }
        public LeftTimeModel LeftTimeModel { get; private set; }
        public BreakTimeModel BreakTimeModel { get; private set; }
        //public TimeNumberModel TimeNumberModel { get; private set; }
        public ICommand ApplyButtonCommand { get; set; }
        public ICommand CancelButtonCommand { get; set; }
        public ICommand DefaultButtonCommand { get; set; }
        public ICommand BackButtonCommand { get; set; }

        public SettingsViewModel() : this (ConfigurationModel.GetInstance()) { }

        public SettingsViewModel(ConfigurationModel configuration)
        {
            Configuration = configuration;

            InitTimeModels(configuration);
            //InitTimeNumbers(configuration);
            //InitCommands();
        }
        private void InitTimeModels(ConfigurationModel configuration)
        {
            LeftTimeModel = new LeftTimeModel { LeftTime = configuration.LeftTime };
            BreakTimeModel = new BreakTimeModel { BreakTime = configuration.BreakTime };
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
