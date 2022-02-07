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


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropChange([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
