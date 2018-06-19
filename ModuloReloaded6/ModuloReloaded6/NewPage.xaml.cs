using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPage : ContentPage {
		public NewPage() {
			InitializeComponent();
			string url = "https://www.myurl.com/getsubject";
			API.APICommunication.APIGet(url, OnAPISuccess, OnResultIsNull, OnAPIException);
		}
		void OnAPISuccess(string result) {
			Models.Subject subject = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Subject>(result);
			WelcomeLabel.Text = subject.Name;
		}
		void OnResultIsNull() {

		}
		void OnAPIException(string exception) {

		}
	}
}


