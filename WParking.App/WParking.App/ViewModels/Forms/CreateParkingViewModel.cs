using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WParking.App.DTOs;
using WParking.App.Views.Forms;
using Xamarin.Forms;

namespace WParking.App.ViewModels.Forms
{
    public class CreateParkingViewModel : BaseViewModel

    {
        #region Attributes
        
        private string _nameParking;
        private string _addressParking;
        private string _statusParking;
        #endregion

        #region Properties
        public string NameParking
        {
            get { return _nameParking; }
            set { this.SetValue(ref _nameParking, value); }
        }

        public string AddressParking
        {
            get { return _addressParking; }
            set { this.SetValue(ref _addressParking, value); }

        }

        public string StatusParking
        {
            get { return _statusParking; }
            set { this.SetValue(ref _statusParking, value); }

        }
        #endregion

        #region Commands
        public Command RegisterCommand { get; set; }
        #endregion

        #region Methods




        async void GoToCreateParkingPage()
        {


            await Application.Current.MainPage.Navigation.PushAsync(new CreateParkingPage());
        }

        #endregion

        #region ViewsModels
        public CreateParkingViewModel()
        {
            this.RegisterCommand = new Command(this.GoToCreateParkingPage);
        }
        #endregion


    }
}
