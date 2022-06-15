using System;
using System.Collections.Generic;
using System.Text;

namespace WParking.App.DTOs
{
    public class ClientsDTO
    {
        public int IdClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public string Telephone { get; set; }
        public int MembershipId { get; set; }
        public int IdParking { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

    }
}
