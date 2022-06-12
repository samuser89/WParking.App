using System;
using System.Collections.Generic;
using System.Text;
using WParking.App.DTOs;
using WParking.App.Views.Forms;
using Xamarin.Forms;


namespace WParking.App.ViewModels.Forms
{
    public class ParkingItemViewModel : ParkingsDTO
    {
        async void OnItemClick()
        {
            await Application.Current.MainPage.DisplayAlert("Notify", $"Selected {this.NameParking}", "Ok");

            ParkingDetailPage detailPage = new ParkingDetailPage();
            detailPage.BindingContext = new ParkingDetailViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }

        public Command OnItemClickCommand { get; set; }

        public ParkingItemViewModel()
        {
            this.OnItemClickCommand = new Command(OnItemClick);
        }
    }
}
