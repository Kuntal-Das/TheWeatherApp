using AccWeatherHelper.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private string _cityQuery;

        public string CityQuery
        {
            get { return _cityQuery; }
            set
            {
                _cityQuery = value;
                OnPropChange();
            }
        }

        private CurrentConditions _currentConditions;

        public CurrentConditions CurrentConditions
        {
            get { return _currentConditions; }
            set
            {
                _currentConditions = value;
                OnPropChange();
            }
        }

        private City _selectedCity;

        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                OnPropChange();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropChange([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public WeatherViewModel()
        {
            
        }


    }
}
