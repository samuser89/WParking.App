using System;
using System.Collections.Generic;
using System.Text;
using WParking.App.Views.Forms;
using Xamarin.Forms;

namespace WParking.App.ViewModels.Forms
{
    public class CreateClientViewModel
    {
        public Command RegisterClientCommand { get; set; }

        async void GoToCreateClientPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateClientPage());
        }

        #region ViewsModels
        public CreateClientViewModel()
        {
            this.RegisterClientCommand = new Command(this.GoToCreateClientPage);
        }
        #endregion
    }
}
