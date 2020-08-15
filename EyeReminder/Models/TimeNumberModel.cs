using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeReminder.Models
{
    class TimeNumberModel : INotifyPropertyChanged
    {
        private double leftTimeMinute;
        public double LeftTimeMinute
        {
            get => leftTimeMinute;
            set
            {
                leftTimeMinute = value;
                OnPropertyChanged("LeftTimeMinute");
            }
        }

        private double breakTimeMinute;
        public double BreakTimeMinute
        {
            get => breakTimeMinute;
            set
            {
                breakTimeMinute = value;
                OnPropertyChanged("BreakTimeMinute");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
