using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using WParking.App.DTOs;
using Xamarin.Forms;

namespace WParking.App.ViewModels.Forms
{
    public class ClientDetailViewModel : BaseViewModel
    {
        private ClientsDTO _client;
        private ObservableCollection<MembershipDTO> _memberships;

        public ClientsDTO Clients
        {
            get { return _client; }
            set { this.SetValue(ref _client, value); }
        }

        public ObservableCollection<MembershipDTO> Memberships
        {
            get { return _memberships; }
            set { this.SetValue(ref _memberships, value); }
        }

        public ClientDetailViewModel(ClientsDTO clients)
        {
            this.Clients = clients;
            this.RefreshCommand = new Command(GetMemberships);
            this.RefreshCommand.Execute(null);
        }
        public ClientDetailViewModel()
        {

        }

        async void GetMemberships()
        {

            var url = "https://62a296785bd3609cee565414.mockapi.io/api/wp/membership";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var memberships = JsonConvert.DeserializeObject<ObservableCollection<MembershipDTO>>(result);
                    var membershipsFilter = memberships.Where(x => x.Id == _client.MembershipId).ToList();
                    this.Memberships = new ObservableCollection<MembershipDTO>(membershipsFilter);
                }
            }

        }
        public Command RefreshCommand { get; set; }
    }
}
