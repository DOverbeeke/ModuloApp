using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft;
using ModuloReloaded6.Models;

namespace ModuloReloaded6
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoosterGetPage : ContentPage
	{
		public RoosterGetPage ()
		{
			InitializeComponent ();

			string url = "http://ictlab.michelvanleeuwen.nl/public/api/rooms";
			API.APICommunication.APIGet(url, ApiSuccess, ApiResultNull, ApiExceptionCatch);
		}

		private void ApiSuccess(string result) {
			var res = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReservationTestObject>>(result);
			debugLabel.Text = result;
			//res = new ReservationTest.ResBasis() { Reservations = new List<ReservationTest>() { new ReservationTest() { id = "", name = "", size = 9, created_at = new DateTime(), updated_at = new DateTime() } } };
		}

		private void ApiResultNull() {
			string ha = "ha";
		}

		private void ApiExceptionCatch(string exception) {
			string ho = "ho";
		}
	}
}