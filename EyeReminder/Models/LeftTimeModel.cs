using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeReminder.Models
{
    class LeftTimeModel : INotifyPropertyChanged
    {
        private TimeSpan leftTime;
        public TimeSpan LeftTime
        {
            get => leftTime;
            set
            {
                if (leftTime == value)
                    return;
                leftTime = value;
                OnPropertyChanged("LeftTime");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
