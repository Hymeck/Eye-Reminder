using EyeReminder.Interfaces;
using System;
using System.ComponentModel;

namespace EyeReminder.Models
{
    class CountdownTimeModel : INotifyPropertyChanged, ICountdownTime
    {
        private TimeSpan countdownTime;
        public TimeSpan CountdownTime
        {
            get => countdownTime;
            set
            {
                if (countdownTime == value)
                    return;
                countdownTime = value;
                OnPropertyChanged("CountdownTime");
            }
        }

        public override string ToString() =>
            countdownTime.ToString();

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
