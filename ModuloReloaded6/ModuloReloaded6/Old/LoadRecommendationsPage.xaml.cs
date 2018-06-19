using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;

namespace ModuloReloaded6
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadRecommendationsPage : ContentPage
	{
		public LoadRecommendationsPage(string person_type, string room_chosen, string amount_people, string begin_time, string end_time, string user) {
			InitializeComponent();

			// ask API for recommendations based on:
			// person_type, room_chosen, amount_people, begin_time, end_time, user?(reservate_limit)";

			string url = string.Format("http://145.24.222.229:8081/webapi/public/api/reservations/recommendations" +
				"?person_type={0}?room={1}?amount_people={2}?begin_time={3}?end_time={4}?user={5}",
				person_type, room_chosen, amount_people, begin_time, end_time, user);

			API.APICommunication.APIGet(url, Success, ResIsNull, Exception);
		}

		private void Success(string result) {
			//var jsonised = JsonConvert.DeserializeObject<Models.Recommendation.RootObject>(result);
			//Navigation.PushAsync(new RecommendationsReservationPage());
			//Navigation.PushAsync(new TestListViewPage());
			Navigation.RemovePage(this);
		}

		private void ResIsNull() {
			TextLabel.Text = "result == null";
		}

		private void Exception(string exception) {
			TextLabel.Text = exception;
		}
	}
}