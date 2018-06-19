using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace ModuloReloaded6.API {
	class APICommunication {

		public static async void APIGet(string page, Action<string> followup_success, Action followup_res_is_null, Action<string> followup_exception_catch) {
			ModuloReloaded6.App app = App.Current as App;
			app.Client.Dispose();
			app.Client = new HttpClient();
			HttpClient client = app.Client;

			using(client)
			using(HttpResponseMessage response = await client.GetAsync(page))
			using(HttpContent content = response.Content) {
				try {

					var result = await content.ReadAsStringAsync();

					if(result == null) {
						Device.BeginInvokeOnMainThread(() => followup_res_is_null());
					} else {
						Device.BeginInvokeOnMainThread(() => followup_success(result));
					}
				} catch(Exception ex) {
					Device.BeginInvokeOnMainThread(() => followup_exception_catch(ex.ToString()));
				}
			}
		}
		public static async void APIWaitGet(string page, Action<string> followup_success, Action followup_res_is_null, Action<string> followup_exception_catch) {
			ModuloReloaded6.App app = App.Current as App;
			HttpClient client = app.Client;

			string result = "";

			HttpResponseMessage response = null;

			Device.BeginInvokeOnMainThread(async () => response = await client.GetAsync(page));

			//using(client)
			//using(HttpResponseMessage response = await client.GetAsync(page))
			using(HttpContent content = response.Content) {
				try {

					Device.BeginInvokeOnMainThread(async () => result = await content.ReadAsStringAsync());


					//result = await content.ReadAsStringAsync();

					if(result == null) {
						Device.BeginInvokeOnMainThread(() => followup_res_is_null());
					} else {
						Device.BeginInvokeOnMainThread(() => followup_success(result));
					}
				} catch(Exception ex) {
					Device.BeginInvokeOnMainThread(() => followup_exception_catch(ex.ToString()));
				}
			}
		}

		public static async void APIPost(string page, FormUrlEncodedContent http_content, Action<string> followup_success, Action followup_res_is_null, Action<string> followup_exception_catch) {
			ModuloReloaded6.App app = App.Current as App;
			HttpClient client = app.Client;
			//if(client == null)
//			client.CancelPendingRequests();
				client = new HttpClient();

			using(client)
			using(HttpResponseMessage response = await client.PostAsync(page, http_content))
			using(HttpContent content = response.Content) {
				try {
					var result = await content.ReadAsStringAsync();

					if(result == null) {
						Device.BeginInvokeOnMainThread(() => followup_res_is_null());
					} else {
						Device.BeginInvokeOnMainThread(() => followup_success(result));
					}
				} catch(Exception ex) {
					Device.BeginInvokeOnMainThread(() => followup_exception_catch(ex.ToString()));
				}
			}
		}

		public static async void APIDelete(string page, Action<string> followup_success, Action followup_res_is_null, Action<string> followup_exception_catch) {
			HttpClient client = new HttpClient();

			using(client)
			using(HttpResponseMessage response = await client.DeleteAsync(page))
			using(HttpContent content = response.Content) {
				try {
					var result = await content.ReadAsStringAsync();

					if(result == null) {
						Device.BeginInvokeOnMainThread(() => followup_res_is_null());
					} else {
						Device.BeginInvokeOnMainThread(() => followup_success(result));
					}
				} catch(Exception ex) {
					Device.BeginInvokeOnMainThread(() => followup_exception_catch(ex.ToString()));
				}
			}
		}
	}
}
