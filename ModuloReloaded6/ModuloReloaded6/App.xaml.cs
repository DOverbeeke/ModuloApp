using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;

using Xamarin.Forms;

using System.Timers;

namespace ModuloReloaded6 {
	public partial class App : Application {
		HttpClient client = new HttpClient();
		public HttpClient Client { get { return client; } set { client = value; } }

		public Models.User LoggedInUser = new Models.User { IsStudent = true, Id = "0876543", FirstName = "FName", LastName = "LName", Class = "CMD5W", StudentNumber = "0876543" };

		public App() {
			InitializeComponent();

			MainPage = new NavigationPage(new SignInPage()) { BarBackgroundColor = Color.Red };
			//MainPage = new NavigationPage(new ImportLessons());
		}

		protected override void OnStart() {
			// Handle when your app starts
		}

		protected override void OnSleep() {
			// Handle when your app sleeps
		}

		protected override void OnResume() {
			// Handle when your app resumes
			if(IsSignInPageOpen()) {
				SignInPage sip = MainPage.Navigation.NavigationStack[MainPage.Navigation.NavigationStack.Count - 1] as SignInPage;
				sip.StartLoadingSignIn();
				//sip.StartAskingAPIForSignInSuccess();
			}
		}

		private bool IsSignInPageOpen() {
			return MainPage.Navigation.NavigationStack[MainPage.Navigation.NavigationStack.Count - 1].GetType() == typeof(SignInPage);
		}
	}
}
