using System;
using System.Collections.Generic;
using System.Text;
using WParking.App.DTOs;

namespace WParking.App.ViewModels.Forms
{
    public class ParkingDetailViewModel : BaseViewModel
    {
        private ParkingsDTO _parking;
        public ParkingsDTO Parkings
        {
            get { return _parking; }
            set { this.SetValue(ref _parking, value); }
        }

        public ParkingDetailViewModel(ParkingsDTO parkings)
        {
            this.Parkings = parkings;
        }
        public ParkingDetailViewModel()
        {

        }
    }
}
