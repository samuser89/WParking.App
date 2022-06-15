using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using WParking.App.ViewModels;
using Xamarin.Forms;

namespace WParking.App.ViewModels.Forms
{
    public class ClientsViewModels :BaseViewModel
    {
        #region Attributes
        private ObservableCollection<ClientItemViewModel> _client;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<ClientItemViewModel> Client
        {
            get { return _client; }
            set { this.SetValue(ref _client, value); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion

        #region Methods
        async void GetClients()
        {
            this.IsRefreshing = true;
            var url = "https://62a296785bd3609cee565414.mockapi.io/api/wp/clients";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var clients = JsonConvert.DeserializeObject<ObservableCollection<ClientItemViewModel>>(result);
                    this.Client = clients;
                }
            }
            this.IsRefreshing = false;
        }
        #endregion


        #region Commands
        public Command RefreshCommand { get; set; }
        #endregion


        public ClientsViewModels()
        {
            this.RefreshCommand = new Command(GetClients);
            this.RefreshCommand.Execute(null);
        }
    }
}
