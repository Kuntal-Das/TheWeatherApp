using AccWeatherHelper.APIHelper;
using AccWeatherHelper.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WeatherApp.Commands;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<City> Cities { get; set; }
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
                GetCurrentConditionsAsync();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public SearchCityCommand SearchCityCommand { get; set; }

        public WeatherViewModel()
        {
            SearchCityCommand = new SearchCityCommand(this);
            Cities = new ObservableCollection<City>();
        }

        private void OnPropChange([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public async Task SearchCityAsync()
        {
            var cities = await AccWeatherApi.GetCitiesAsync(CityQuery);

            Cities.Clear();
            foreach (var city in cities) Cities.Add(city);
        }

        private async Task GetCurrentConditionsAsync()
        {
            CityQuery = string.Empty;
            Cities.Clear();
            CurrentConditions = await AccWeatherApi.GetCurrentConditionsAsync(SelectedCity.Key);
        }
    }
}
