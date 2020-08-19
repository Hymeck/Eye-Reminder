using System.Windows.Input;

namespace EyeReminder.Interfaces
{
    public interface ISettingsWindowViewModel
    {
        ICommand ApplyButtonCommand { get; set; }
        ICommand CancelButtonCommand { get; set; }
        ICommand BackButtonCommand { get; set; }
    }
}
