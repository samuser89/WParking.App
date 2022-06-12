using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using WParking.App.ViewModels;
using Xamarin.Forms;


namespace WParking.App.ViewModels.Forms
{
    public class ParkingsViewModels : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<ParkingItemViewModel> _parking;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<ParkingItemViewModel> Parking
        {
            get { return _parking; }
            set { this.SetValue(ref _parking, value); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion

        #region Methods
        async void GetParkings()
        {
            this.IsRefreshing = true;
            var url = "https://62a296785bd3609cee565414.mockapi.io/api/wp/parkings";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var parkings = JsonConvert.DeserializeObject<ObservableCollection<ParkingItemViewModel>>(result);
                    this.Parking = parkings;
                }
            }
            this.IsRefreshing = false;
        }
        #endregion


        #region Commands
        public Command RefreshCommand { get; set; }
        #endregion


        public ParkingsViewModels()
        {
            this.RefreshCommand = new Command(GetParkings);
            this.RefreshCommand.Execute(null);
        }

    }
}
