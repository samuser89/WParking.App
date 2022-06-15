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



        async void Register()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateParkingPage());

            var data = new ParkingsDTO { NameParking = this.NameParking, AddressParking = this.AddressParking,
                StatusParking = this.StatusParking};
            var json = JsonConvert.SerializeObject(data);
            var req = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://62a296785bd3609cee565414.mockapi.io/api/wp/parkings";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, req);

                var statusCode = response.StatusCode;
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var parkingDTO = JsonConvert.DeserializeObject<ParkingsDTO>(result);
                    var IdParking = parkingDTO.IdParking;
                    await Application.Current.MainPage.DisplayAlert("Notify Is Successful", $"Id Asignado: {IdParking}" , "OK");
                    await Application.Current.MainPage.Navigation.PushAsync(new ParkingPage());
                }

            }
        }

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
