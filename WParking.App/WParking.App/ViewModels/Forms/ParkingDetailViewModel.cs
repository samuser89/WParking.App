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
    public class ParkingDetailViewModel : BaseViewModel
    {

        private ParkingsDTO _parking;
        private ObservableCollection<ClientsDTO> _clients;
        public ParkingsDTO Parkings
        {
            get { return _parking; }
            set { this.SetValue(ref _parking, value); }
        }

        public ObservableCollection<ClientsDTO> Clients
        {
            get { return _clients; }
            set { this.SetValue(ref _clients, value); }
        }


        public ParkingDetailViewModel(ParkingsDTO parkings)
        {
            this.Parkings = parkings;
            this.RefreshCommand = new Command(GetClients);
            this.RefreshCommand.Execute(null);
        }
        public ParkingDetailViewModel()
        {

        }

        async void GetClients()
        {
            
            var url = "https://62a296785bd3609cee565414.mockapi.io/api/wp/clients";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var clients = JsonConvert.DeserializeObject<ObservableCollection<ClientsDTO>>(result);
                    var clientsFilter = clients.Where(x => x.IdParking == _parking.IdParking).ToList();
                    this.Clients = new ObservableCollection<ClientsDTO>(clientsFilter);
                }
            }
            
        }

        public Command RefreshCommand { get; set; }
    }
}

