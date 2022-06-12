using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WParking.App.ViewModels.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WParking.App.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public void Parking_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}