using System;
using System.Collections.Generic;
using System.Text;
using WParking.App.DTOs;
using WParking.App.Views.Forms;
using Xamarin.Forms;


namespace WParking.App.ViewModels.Forms
{
    public class HomePageViewModel
    {
        async void GoToParkingPage()
        {


            await Application.Current.MainPage.Navigation.PushAsync(new ParkingPage());
        }


        async void GoToClientPage()
        {


            await Application.Current.MainPage.Navigation.PushAsync(new ClientPage());
        }

        public Command ParkingCommand { get; set; }
        public Command ClientCommand { get; set; }


        public HomePageViewModel()
        {
            this.ParkingCommand = new Command(GoToParkingPage);
            this.ClientCommand = new Command(GoToClientPage);
            
        }
    }
}
