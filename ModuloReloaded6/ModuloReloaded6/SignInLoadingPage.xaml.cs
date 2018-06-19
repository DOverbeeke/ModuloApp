using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInLoadingPage : ContentPage
	{
		private string random_key;
		private int api_success_count = 0;

		public SignInLoadingPage (string random_key)
		{
			InitializeComponent ();

			this.random_key = random_key;
			CheckIfUserSignedIn();
		}

		private void CheckIfUserSignedIn() {
			//string url = "http://145.24.222.229:8081/webapi/public/api/reservations"; //?random_key=" + random_key;
			//API.APIClass.APIGet(url, APIGetSuccess, APIGetResIsNull, APIGetException);
			APIGetSuccess("something success something");
		}

		private void APIGetSuccess(string result) {
			api_success_count++;
			DebugLabel.Text = "successful apiGET no. " + api_success_count + "\r\n\r\n";
			ResultLabel.Text = result;
			if(result == "no user found") {
				DebugLabel.Text = "No user found that has the key.\r\n\r\nTrying again...";
				CheckIfUserSignedIn();
			} else {
				DebugLabel.Text = "result != \"no user found\"\r\n\r\nShould app go to user's Home Page now?\r\n\r\nI DON'T THINK SO !";
				//GoToRegisterInfoUserPage();
			}
		}
		private void APIGetResIsNull() {
			DebugLabel.Text = "result == null";
		}
		private void APIGetException(string exception) {
			DebugLabel.Text = "EXCEPTION:\r\n" + exception;
		}

		private void GoToRegisterInfoUserPage() {

		}

		private void Button_Clicked(object sender, EventArgs e) {
			//TODO: make sure that thread with apicall is canceled if not done automatically

			Navigation.PushAsync(new SignInPage());
			Navigation.RemovePage(this);
		}
	}
}