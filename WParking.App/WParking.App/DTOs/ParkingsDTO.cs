using System;
using System.Collections.Generic;
using System.Text;


namespace WParking.App.DTOs
{
    public class ParkingsDTO
    {
       
        public int IdParking { get; set; }
        public string NameParking { get; set; }
        public string AddressParking { get; set; }
        public string StatusParking { get; set; }
        public int ClientId { get; set; }
    }

}
