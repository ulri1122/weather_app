using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wether;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace wether
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
            BindingContext = this;
            var temp = getweatherData();

        }



        private async void changeLocationPage(object sender, EventArgs args)
        {

            WeatherData data = await getweatherData();

        }
        public async Task<WeatherData> getweatherData()
        {

            try
            {

             
                var location = await Geolocation.GetLastKnownLocationAsync();
                var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                var contryName = placemarks?.FirstOrDefault().CountryName.ToString();
                var cityName = placemarks?.FirstOrDefault().Locality.ToString();



                if (location != null)
                {

                    var lblLat = location.Latitude.ToString();
                    var lblLong = location.Longitude.ToString();
                    var lblAlt = location.Altitude.ToString();

            

                    var url = "https://api.openweathermap.org/data/2.5/onecall?units=metric&exclude=minutely&lat=" + lblLat + "&lon=" + lblLong + "&appid=a37dc77d83828835dde877a78ee33fc6";
                    WeatherData data = await restAPI.GetDataAsync<WeatherData>(url);

                    currentTemp.Text = Math.Round(data.Current.Temp).ToString() + "°C";
                    currentWind.Text = data.Current.WindSpeed.ToString() + " M/s";
                    currentHumidity.Text = data.Current.Humidity.ToString() + " %";
                    fealsLike.Text = Math.Round(data.Current.FeelsLike).ToString() + " °C";
                    currentUV.Text = data.Current.Uvi.ToString();
                    gps_location.Text = cityName + ", " + contryName;

                    weather_img.Source = "img_"+data.Current.Weather.FirstOrDefault().Icon.ToString() + ".png";

                    Day_disc.Text = data.Current.Weather.FirstOrDefault().Description.ToString();

                    System.DateTime sunrise = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    sunrise = sunrise.AddSeconds(data.Current.Sunrise).ToLocalTime();
                    System.DateTime sunset = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    sunset = sunset.AddSeconds(data.Current.Sunset).ToLocalTime();
                    sunUpDown.Text = sunrise.ToString("H:mm") + " / " +  sunset.ToString("H:mm");


                    data.Daily.RemoveAt(0);
                    data.Hourly.RemoveRange(24,24);

                    collectionView.ItemsSource = data.Daily;
                    collectionView_hourly.ItemsSource = data.Hourly;

                }
            }
            catch (FeatureNotSupportedException)
            {
                // Handle not supported on device exception  
            }
            catch (PermissionException)
            {
                // Handle permission exception  
            }
            catch (Exception e )
            {
                // Unable to get location  
            }
            return null;
        }
    }
}
