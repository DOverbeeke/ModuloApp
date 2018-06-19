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
	public partial class GetLessonsPage : ContentPage {
		DateTime monday;
		DateTime day_to_show;

		public GetLessonsPage(DateTime monday, DateTime day_to_show) {
			InitializeComponent();

			this.monday = monday;
			this.day_to_show = day_to_show;

			string url = "http://ictlab.michelvanleeuwen.nl/public/api/lessons";
			API.APICommunication.APIGet(url, ApiSuccess, ApiResIsNull, ApiException);
		}

		void ApiSuccess(string result) {
			var res = JsonConvert.DeserializeObject<List<Models.Lesson>>(result);
			Navigation.PushAsync(new GetReservationsPage(res, monday, day_to_show));
			if (Navigation.NavigationStack.Count == 3) {
				Navigation.RemovePage(Navigation.NavigationStack[0]);
			}
			Navigation.RemovePage(this);
		}
		void ApiResIsNull() {
			Console.WriteLine("Res is null in GetCalendarItemsPage.");
		}
		void ApiException(string exception) {
			Console.WriteLine("exception in GetCalendarItemsPage: " + exception);
		}
	}
}