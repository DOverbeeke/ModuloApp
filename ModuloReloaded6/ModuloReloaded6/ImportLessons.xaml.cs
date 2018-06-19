using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImportLessons : ContentPage {
		string[] rooms = new string[] { "H.1.110", "H.1.112", "H.1.114", "H.1.206", "H.1.306", "H.1.308", "H.1.312", "H.1.315", "H.1.318", "H.1.403", "H.2.111", "H.2.204", "H.2.306", "H.2.308", "H.2.318", "H.2.403", "H.3.206", "H.3.308", "H.3.312", "H.3.403", "H.4.308", "H.4.312", "H.4.318", "H.5.314", "W.0.116", "WD.01.003", "WD.01.016", "WD.01.019", "WD.02.002", "WD.02.016", "WD.02.019", "WD.03.005", "WD.03.033", "WD.04.002", "WD.05.002", "WD.05.005", "WD.05.013", "WD.05.018", "WN.01.017", "WN.01.022", "WN.01.023", "WN.02.007", "WN.02.017", "WN.02.022", "WN.02.026", "WN.03.007", "WN.03.017", "WN.03.022", "WN.05.025", "WD.04.020", "WD.04.016", "H.3.111", "Spreekkamer", "T30", "Extern", "extern", "auditorium RDM", "WN.01.014", "Maaspodium", "geen lokaal", "WD.00.026" };
		int room_number = 0;

		public ImportLessons() {
			InitializeComponent();

			GetLessons();
		}

		void GetLessons() {
			string url = "https://hint.hr.nl/xsp/public/InfApp/2018gr3/getLokaalRooster.xsp?sharedSecret=0882630-v4KasUksRdaHXnsiwkwR4fI0dsWuFy5fbCy&element=H.1.110&startDate=2018-04-21&endDate=2019-07-30&json";

			API.APICommunication.APIGet(url, ApiSucces, ApiResIsNull, ApiCatch);
		}

		void GetLessons1() {
			string room = rooms[room_number];

			string url = "https://hint.hr.nl/xsp/public/InfApp/2018gr3/getLokaalRooster.xsp";
			var values = new Dictionary<string, string> {
				{ "sharedSecret", "0882630-v4KasUksRdaHXnsiwkwR4fI0dsWuFy5fbCy" },
				{ "element", room },
				{ "startDate", "2018-06-01" },
				{ "endDate", "2019-01-01" },
				//{ "", "json" }
			};

			var content = new FormUrlEncodedContent(values);

			API.APICommunication.APIPost(url, content, ApiSucces, ApiResIsNull, ApiCatch);

			//API.APIClass.APIGet(url, OnSuccess, OnResIsNull, OnError);
		}

		void ApiSucces(string result) {
			Label.Text = room_number.ToString();
			var list = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.LessonImport.LessonHelp>(result);
			foreach(var item in list.Lesson)	
				Console.WriteLine(item.ToString());
			if(room_number < rooms.Count() - 1) {
				room_number++;
				GetLessons();
			} else {
				Label.Text = "FINITO\r\n\r\n" + Label.Text;
			}
		}
		void ApiResIsNull() {
			Label.Text = room_number.ToString() + " resisnull";
		}
		void ApiCatch(string exception) {
			Label.Text = room_number.ToString() +  " error:\r\n\r\n" + exception;
		}
	}
}