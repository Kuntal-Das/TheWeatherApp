using AccWeatherHelper.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherApp.UserControls
{
    /// <summary>
    /// Interaction logic for CityWeatherInfoUserControl.xaml
    /// </summary>
    public partial class CityWeatherInfoUserControl : UserControl
    {
        public CityWeatherInfoUserControl()
        {
            InitializeComponent();
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                City = new City()
                {
                    LocalizedName = "New York"
                };

                CurrentConditions = new CurrentConditions()
                {
                    WeatherText = "Partly cloudy",
                    Temperature = new Temperature()
                    {
                        Metric = new Units()
                        {
                            Value = "21"
                        }
                    }
                };
            }
        }

        public City City
        {
            get { return (City)GetValue(CityProperty); }
            set { SetValue(CityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for City.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CityProperty =
            DependencyProperty.Register("City", typeof(City), typeof(CityWeatherInfoUserControl),
                new PropertyMetadata(new City() { LocalizedName = "New York" }, CityPropertyChanged));

        private static void CityPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null) return;

            CityWeatherInfoUserControl cityWeatherInfoUserControl = d as CityWeatherInfoUserControl;
            cityWeatherInfoUserControl.CityNameTextBlock.Text = (e.NewValue as City).LocalizedName;
        }

        public CurrentConditions CurrentConditions
        {
            get { return (CurrentConditions)GetValue(CurrentConditionsProperty); }
            set { SetValue(CurrentConditionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentConditions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentConditionsProperty =
            DependencyProperty.Register("CurrentConditions", typeof(CurrentConditions), typeof(CityWeatherInfoUserControl),
                new PropertyMetadata(null, CurrentConditionsPropertyChanged));

        private static void CurrentConditionsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null) return;

            CityWeatherInfoUserControl cityWeatherInfoUserControl = d as CityWeatherInfoUserControl;
            cityWeatherInfoUserControl.WeatherTextBlock.Text = (e.NewValue as CurrentConditions).WeatherText;
            cityWeatherInfoUserControl.TemperatureTextBlock.Text = $"{(e.NewValue as CurrentConditions).Temperature.Metric.Value}℃";
            cityWeatherInfoUserControl.PercipitationTextBlock.Text =
                ((e.NewValue as CurrentConditions).HasPercipitation) ? "Currently Raining" : "Currently Not Raining";
        }
    }
}
