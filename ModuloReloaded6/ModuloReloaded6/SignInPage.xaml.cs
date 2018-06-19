using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Security.Cryptography;
using System.Net.Http;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInPage : ContentPage {
		private DateTime first_success;
		private int api_success_count = 0;
		private bool sign_in_done = false;
		private string random_key;
		private bool browser_opened = false;

		public SignInPage() {
			InitializeComponent();
			PlatformIndep.IDroidButtonsBar statusbarc = DependencyService.Get<PlatformIndep.IDroidButtonsBar>();
			statusbarc?.SetDroidButtonsBarRed();
			//first_success = new DateTime(1, 1, 1, 1, 1, 1);
		}

		//called in App.xaml.cs OnResume()
		public void StartLoadingSignIn() {
			if(browser_opened) {
				Navigation.PushAsync(new SignInLoadingPage(random_key));
				Navigation.RemovePage(this);
				PlatformIndep.IDroidButtonsBar statusbarc = DependencyService.Get<PlatformIndep.IDroidButtonsBar>();
				statusbarc?.SetDroidButtonsBarWhite();
			}
		}

		/////////// IN SIGN-IN-LOADING-PAGE NOW ///////////////////////////
		//private void APIGetSuccess(string result) {
		//	api_success_count++;
		//	DebugLabel.Text = "successful apiGET no. " + api_success_count;
		//	if (result == "no user found") {
		//		DebugLabel.Text = "No user found that has the key.\r\n\r\nTrying again...";
		//		CheckIfUserSignedIn(GenerateNewKey());
		//	} else {
		//		GoToRegisterInfoUserPage();
		//	}
		//}
		//private void APIGetResIsNull() {
		//	DebugLabel.Text = "result == null";
		//}
		//private void APIGetException(string exception) {
		//	DebugLabel.Text = "EXCEPTION:\r\n" + exception;
		//}


		private void GoToRegisterInfoUserPage() {
			Navigation.PushAsync(new RegisterUserInfoPage());
			Navigation.RemovePage(this);
			PlatformIndep.IDroidButtonsBar statusbarc = DependencyService.Get<PlatformIndep.IDroidButtonsBar>();
			statusbarc?.SetDroidButtonsBarWhite();
		}

		public async void StartAskingAPIForSignInSuccess() {
			if(browser_opened) {
				try {
					await Task.Run(() => GetAPISignedIn(1));
					//await new Task(() => GetAPISignedIn(1));
				} catch(Exception ex) {
					Device.BeginInvokeOnMainThread(() => DebugLabel.Text = "GetAPISignedIn(1) exception:\r\n\r\n" + ex);
				}
			}
		}

		private void FakeSignInClicked(object sender, EventArgs e) {
			if(true) {
				Navigation.PushAsync(new RegisterUserInfoPage());
				Navigation.RemovePage(this);
				PlatformIndep.IDroidButtonsBar statusbarc = DependencyService.Get<PlatformIndep.IDroidButtonsBar>();
				statusbarc?.SetDroidButtonsBarWhite();
			} else {
				Navigation.PushAsync(new MainAppMDPage());
				Navigation.RemovePage(this);
				PlatformIndep.IDroidButtonsBar statusbarc = DependencyService.Get<PlatformIndep.IDroidButtonsBar>();
				statusbarc?.SetDroidButtonsBarWhite();
			}
		}

		private void SignInClicked(object sender, EventArgs e) {
			random_key = GetRandomKey(35);
			Console.WriteLine(random_key);

			string OurURL = "https://hr.michelvanleeuwen.nl/public/LoginHr?randomKey=" + random_key;
			//string CasURL = string.Format("https://login.hr.nl/v1/login?service={0}", OurURL);
			Device.OpenUri(new Uri(OurURL));
			browser_opened = true;
		}

		private async void GetAPISignedIn(double minute_limit) {
			string url = "http://145.24.222.229:8081/webapi/public/api/reservations"; //?random_key=" + random_key;
			for(int i = 0; i < 5; i++) {
				Console.WriteLine(first_success.AddMinutes(minute_limit).ToString() + "     " + DateTime.Now.ToString());
				if(first_success != new DateTime(1, 1, 1, 1, 1, 1)) {
					if(DateTime.Now > first_success.AddMinutes(minute_limit)) {
						Device.BeginInvokeOnMainThread(() => OverMinuteLimit());
						return;
					}
				}
				if(sign_in_done) {
					Device.BeginInvokeOnMainThread(() => SignInSuccess());
					return;
				}
				//try {

				//	ModuloReloaded6.App app = App.Current as App;
				//	HttpClient client = app.Client;

				//	string result = "";

				//	using(client)
				//	using(HttpResponseMessage response = await client.GetAsync(url))
				//	using(HttpContent content = response.Content) {
				//		try {

				//			result = await content.ReadAsStringAsync();

				//			if(result == null) {
				//				APIGetResIsNull();
				//			} else {
				//				APIGetSuccess(result);
				//			}
				//		} catch(Exception ex) {
				//			APIGetException(ex.ToString());
				//		}
				//	}











				//	await Task.Run(() => API.APIClass.APIWaitGet(url, APIGetSuccess, APIGetResIsNull, APIGetException));
				//} catch(Exception ex) {
				//	//Device.BeginInvokeOnMainThread(() => DebugLabel.Text = string.Format("ApiGet exception (i = {0}):\r\n\r\n{1}", i, ex));
				//	DebugLabel.Text = string.Format("ApiGet exception (i = {0}):\r\n\r\n{1}", i, ex);
				//}
				Console.WriteLine("APIGet count: " + i);
				//Device.BeginInvokeOnMainThread(()=> DebugLabel.Text = "APIGet count: " + i);
			}
		}

		private void OverMinuteLimit() {
			DebugLabel.Text = "Over Minute Limit";
		}

		private void SignInSuccess() {
			DebugLabel.Text = "SignInSuccess!";
		}

		//private void APIGetSuccess(string result) {
		//	DebugLabel.Text = success_count + "x API Succes.\r\n\r\nLAST RESULT:\r\n" + result;

		//	if(first_success == new DateTime(1, 1, 1, 1, 1, 1))
		//		first_success = DateTime.Now;

		//	success_count++;
		//	if (success_count > 3) {
		//		sign_in_done = true;
		//	}

		//	//if (first_success == null)
		//	//	first_success = DateTime.Now;
		//	//success_count++;
		//	//if() {

		//	//}
		//}
		//private void APIGetResIsNull() {
		//	DebugLabel.Text = "result == null";
		//}
		//private void APIGetException(string exception) {
		//	DebugLabel.Text = "EXCEPTION:\r\n" + exception;
		//}

		private string MyGetRandomKey(int length) {
			string return_string = "";
			Random rnd = new Random();
			for(int i = 0; i < length; i++) {
				int r = rnd.Next(0, 9);
				return_string += r.ToString();
			}
			return return_string;
		}

		private string GetRandomKey(int length) {
			string result_string = "";
			RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

			const int totalRolls = 25000;
			int[] results = new int[length];

			// Roll the dice 25000 times and display
			// the results to the console.
			for(int x = 0; x < totalRolls; x++) {
				byte roll = RollDice((byte)results.Length, rngCsp);
				results[roll - 1]++;
			}
			for(int i = 0; i < results.Length; ++i) {
				Console.WriteLine("{0}: {1} ({2:p1})", i + 1, results[i], (double)results[i] / (double)totalRolls);
			}

			//MINE :D
			foreach(var n in results) {
				result_string += n.ToString();
			}
			Console.WriteLine(result_string);

			rngCsp.Dispose();

			return result_string;
		}
		// This method simulates a roll of the dice. The input parameter is the
		// number of sides of the dice.
		public static byte RollDice(byte numberSides, RNGCryptoServiceProvider rngCsp) {
			if(numberSides <= 0)
				throw new ArgumentOutOfRangeException("numberSides");

			// Create a byte array to hold the random value.
			byte[] randomNumber = new byte[1];
			do {
				// Fill the array with a random value.
				rngCsp.GetBytes(randomNumber);
			}
			while(!IsFairRoll(randomNumber[0], numberSides));
			// Return the random number mod the number
			// of sides.  The possible values are zero-
			// based, so we add one.
			return (byte)((randomNumber[0] % numberSides) + 1);
		}
		private static bool IsFairRoll(byte roll, byte numSides) {
			// There are MaxValue / numSides full sets of numbers that can come up
			// in a single byte.  For instance, if we have a 6 sided die, there are
			// 42 full sets of 1-6 that come up.  The 43rd set is incomplete.
			int fullSetsOfValues = Byte.MaxValue / numSides;

			// If the roll is within this range of fair values, then we let it continue.
			// In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use
			// < rather than <= since the = portion allows through an extra 0 value).
			// 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair
			// to use.
			return roll < numSides * fullSetsOfValues;
		}

		private void TeacherButtonClicked(object sender, EventArgs e) {
			//will be via api next
			Models.User teacher = new Models.User { Id = "1", Code = "OVEDO" };
			App app = App.Current as App;
			app.LoggedInUser = teacher;
			Navigation.PushAsync(new MainAppMDPage());
			Navigation.RemovePage(this);
		}
	}
}