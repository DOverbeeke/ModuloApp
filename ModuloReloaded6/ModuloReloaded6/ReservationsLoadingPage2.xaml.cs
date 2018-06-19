using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReservationsLoadingPage2 : ContentPage {
		public ReservationsLoadingPage2() {
			InitializeComponent();

			Title = "Loading Reservations!";

			string url = "http://ictlab.michelvanleeuwen.nl/public/api/reservations";
			API.APICommunication.APIGet(url, APISuccess, APIResIsNull, APIException);
		}

		private void APISuccess(string result) {
			var res = JsonConvert.DeserializeObject<List<Models.ReservationTestObject>>(result);
			Navigation.PushAsync(new MyReservationsPage2(res));
			Navigation.RemovePage(this);
		}
		private void APIResIsNull() {
			Console.WriteLine("nuuuuuuuuuuuuull ReservationsLoadingPage2");
		}
		private void APIException(string exception) {
			Console.WriteLine("exceptiooooon ReservationsLoadingPage2: " + exception);
		}
	}
}