using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using WParking.App.DTOs;
using WParking.App.ViewModels;
using WParking.App.Views.Forms;
using Xamarin.Forms;

namespace WParking.App.ViewModels.Forms
{
    public class ClientsViewModels :BaseViewModel
    {

        public Command RegisterClientCommand { get; set; }


        #region Attributes
        private ObservableCollection<ClientItemViewModel> _client;
        private bool _isRefreshing;

        

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _telephone;
        private int _membershipId;
        private int _idParking;
        
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

        public string FirstName
        {
            get { return _firstName; }
            set { this.SetValue(ref _firstName, value); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { this.SetValue(ref _lastName, value); }

        }

        [JsonProperty("email")]
        public string Email
        {
            get { return _email; }
            set { this.SetValue(ref _email, value); }

        }

        public string Telephone
        {
            get { return _telephone; }
            set { this.SetValue(ref _telephone, value); }

        }

        public int MembershipId
        {
            get { return _membershipId; }
            set { this.SetValue(ref _membershipId, value); }

        }

        public int IdParking
        {
            get { return _idParking; }
            set { this.SetValue(ref _idParking, value); }

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
        public Command NewClientCommand { get; set; }
        #endregion

        async void GoToCreateClientPage()
        {


            await Application.Current.MainPage.Navigation.PushAsync(new CreateClientPage());
        }


        async void RegisterClient()
        {
            var data = new ClientsDTO
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                email = this.Email,
                Telephone = this.Telephone,
                MembershipId = this.MembershipId,
                IdParking = this.IdParking

            };
            var json = JsonConvert.SerializeObject(data);
            var req = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://62a296785bd3609cee565414.mockapi.io/api/wp/clients";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, req);

                var statusCode = response.StatusCode;
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var clientDTO = JsonConvert.DeserializeObject<ClientsDTO>(result);
                    var clientId = clientDTO.IdClient;
                    await Application.Current.MainPage.DisplayAlert("Notify Is Successful", $"Id Asignado: {clientId}", "OK");
                    await Application.Current.MainPage.Navigation.PushAsync(new ClientPage());
                }

            }
        }



        public ClientsViewModels()
        {
            this.RefreshCommand = new Command(GetClients);
            this.RefreshCommand.Execute(null);
            this.NewClientCommand = new Command(RegisterClient);
            this.RegisterClientCommand = new Command(this.GoToCreateClientPage);
        }
    }
}
