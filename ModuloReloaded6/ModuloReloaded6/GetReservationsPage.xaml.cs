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
	public partial class GetReservationsPage : ContentPage {
		List<Models.Lesson> lessons;
		DateTime monday;
		DateTime day_to_show;

		public GetReservationsPage(List<Models.Lesson> lessons, DateTime monday, DateTime day_to_show) {
			InitializeComponent();

			this.lessons = lessons;
			this.monday = monday;
			this.day_to_show = day_to_show;

			string url = "http://ictlab.michelvanleeuwen.nl/public/api/reservations";
			API.APICommunication.APIGet(url, ApiSuccess, ApiResIsNull, ApiException);
		}

		void ApiSuccess(string result) {
			var res = JsonConvert.DeserializeObject<List<Models.ReservationTestObject>>(result);
			if(day_to_show.Year == 1) {
				Navigation.PushAsync(new ScheduleWeekTestPage1(lessons, res, monday));
				Navigation.RemovePage(this);
			} else {
				Navigation.PushAsync(new ScheduleDayTestPage1(lessons, res, day_to_show, monday));
				Navigation.RemovePage(this);
			}
		}
		void ApiResIsNull() {
			Console.WriteLine("Res is null in GetReservationsPage.");
		}
		void ApiException(string exception) {
			Console.WriteLine("exception in GetReservationsPage: " + exception);
		}
	}
}