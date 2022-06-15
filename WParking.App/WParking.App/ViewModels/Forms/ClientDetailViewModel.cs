using System;
using System.Collections.Generic;
using System.Text;
using WParking.App.DTOs;

namespace WParking.App.ViewModels.Forms
{
    public class ClientDetailViewModel : BaseViewModel
    {
        private ClientsDTO _client;
        public ClientsDTO Clients
        {
            get { return _client; }
            set { this.SetValue(ref _client, value); }
        }
        
        public ClientDetailViewModel(ClientsDTO clients)
        {
            this.Clients = clients;
        }
        public ClientDetailViewModel()
        {

        }
    }
}
