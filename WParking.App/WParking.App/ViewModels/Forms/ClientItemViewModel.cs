using System;
using System.Collections.Generic;
using System.Text;
using WParking.App.DTOs;
using WParking.App.Views.Forms;
using Xamarin.Forms;

namespace WParking.App.ViewModels.Forms
{
    public class ClientItemViewModel : ClientsDTO
    {

        async void OnItemClick()
        {
            await Application.Current.MainPage.DisplayAlert("Notify", $"Selected {this.FirstName} {this.LastName}", "Ok");

            ClientDetailPage detailPage = new ClientDetailPage();
            detailPage.BindingContext = new ClientDetailViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }

        public Command OnItemClickCommand { get; set; }

        public ClientItemViewModel()
        {
            this.OnItemClickCommand = new Command(OnItemClick);
        }
    }
}
