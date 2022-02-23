using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.ViewModels;

namespace WeatherApp.Commands
{
    public class SearchCityCommand : ICommand
    {
        public WeatherViewModel VM { get; set; }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SearchCityCommand(WeatherViewModel weatherViewModel)
        {
            VM = weatherViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return (!string.IsNullOrWhiteSpace(parameter as string)) && (parameter as string).Length > 3;
        }

        public void Execute(object parameter)
        {
            _ = VM.SearchCityAsync();
        }
    }
}
