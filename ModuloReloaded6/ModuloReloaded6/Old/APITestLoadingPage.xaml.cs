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
	public partial class APITestLoadingPage : ContentPage {
		public APITestLoadingPage() {
			InitializeComponent();

			Task t = new Task(APIGetTest);
			t.Start();

			
			//string res = await MyTask();
		}

		private async Task<string> MyTask(){
			ModuloReloaded6.App app = App.Current as App;
			HttpClient client = app.Client;

			string page = "http://api.openweathermap.org/data/2.5/weather?q={city%20name}";

			string result = "";

			using(client)
			using(HttpResponseMessage response = await client.GetAsync(page))
			using(HttpContent content = response.Content) {
				try {

					result = await content.ReadAsStringAsync();

					if(result == null) {
						//Navigation.PushAsync(new APITestPage("result == null"));
						//Navigation.RemovePage(this);
					} else {
						return result;
						//Navigation.PushAsync(new APITestPage(result));
						//Navigation.RemovePage(this);
					}
				} catch(Exception ex) {
					Console.WriteLine("MyStackTrace: {0}", ex.ToString());
				}
			}

			return result;
		}

		private async void APIGetTest() {
			string page = "http://145.24.222.229:8081/webapi/public/api/teachers";

			ModuloReloaded6.App app = App.Current as App;
			HttpClient client = app.Client;

			string result = "";

			using(client)
			using(HttpResponseMessage response = await client.GetAsync(page))
			using(HttpContent content = response.Content) {
				try {

					result = await content.ReadAsStringAsync();

					if(result == null) {
						Device.BeginInvokeOnMainThread(() => lol("result == null"));
						//Navigation.RemovePage(this);
					} else {
						Device.BeginInvokeOnMainThread(() => lol(result));
						//Navigation.PushAsync(new APITestPage(result));
						//Navigation.RemovePage(this);
					}
				} catch(Exception ex) {
					lol(ex.ToString());
				}
			}
		}

		private void lol(string result) {
			label1.Text = result;
		}
	}
}