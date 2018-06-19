using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;

namespace ModuloReloaded6
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecommendationTestPage : ContentPage
	{

		int amount_people2 = 0;
		public RecommendationTestPage (string begin_time, string end_time, int amount_people)
		{
			InitializeComponent ();

			amount_people2 = amount_people;

			GetTestRecomms(begin_time, end_time, amount_people);
		//	string url = "http://ictlab.michelvanleeuwen.nl/public/api/recommendations";
		//	var values = new Dictionary<string, string> {
	 //{ "begin_time", "2018-05-23 12:00:00" },
	 //{ "end_time", "2018-05-23 13:00:00" }
		//	};

		//	var content = new FormUrlEncodedContent(values);

		//	API.APIClass.APIPost(url, content, ApiSucces, ApiResIsNull, ApiCatch);
		}

		private void GetTestRecomms(string begin_time, string end_time, int amount_people) {
			string url = "http://ictlab.michelvanleeuwen.nl/public/api/recommendations";
			var values = new Dictionary<string, string> {
				{ "begin_time", begin_time },
				{ "end_time", end_time },
				{ "amount_people", amount_people.ToString() }
			};

			var content = new FormUrlEncodedContent(values);

			API.APICommunication.APIPost(url, content, ApiSucces, ApiResIsNull, ApiCatch);
		}

		private void ApiSucces(string result) {
			var res = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.Recommendation>>(result);
			Navigation.PushAsync(new RecommendationsReservationPage(res, amount_people2));
			Navigation.RemovePage(this);
			Console.WriteLine(res);
		}
		private void ApiResIsNull() {
			Console.WriteLine("nuuuuuulll");
		}
		private void ApiCatch(string exception) {
			Console.WriteLine(exception);
		}
	}
}