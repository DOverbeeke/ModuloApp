using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Net.Http;
using ModuloReloaded6.API;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class APITestPage : ContentPage {
		public APITestPage() {
			InitializeComponent();

			string page = "http://145.24.222.229:8081/webapi/public/api/teachers";
			Task.Run(() => APICommunication.APIGet(page, APIGetSuccess, APIGetResIsNull, APIGetException));

			//Task t = new Task(APIClass.APIGet("", APIGetSuccess, APIGetResIsNull, APIGetException);
			//t.Start();
		}

		private void APIGetSuccess(string result) {
			APIResLabel.Text = result;
		}
		private void APIGetResIsNull() {
			APIResLabel.Text = "result == null";
		}
		private void APIGetException(string exception) {
			APIResLabel.Text = "EXCEPTION:\r\n" + exception;
		}
	}
}