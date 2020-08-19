using System.Windows.Input;

namespace EyeReminder.Interfaces
{
    public interface IMainWindowViewModel
    {
        ICommand StartButtonCommand { get; set; }
        ICommand StopButtonCommand { get; set; }
        ICommand ResetButtonCommand { get; set; }
        ICommand SettingsButtonCommand { get; set; }
    }
}
