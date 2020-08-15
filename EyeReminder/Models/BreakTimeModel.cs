using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeReminder.Models
{
    class BreakTimeModel : INotifyPropertyChanged
    {
        private TimeSpan breakTime;
        public TimeSpan BreakTime
        {
            get => breakTime;
            set
            {
                if (breakTime == value)
                    return;
                breakTime = value;
                OnPropertyChanged("BreakTime");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
