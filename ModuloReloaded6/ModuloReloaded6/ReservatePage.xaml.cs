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
	public partial class ReservatePage : ContentPage
	{
		//private TimeSpan ts1;
		//private TimeSpan ts2;
		//private TimeSpan ts3;

		public ReservatePage ()
		{
			InitializeComponent ();

			DatePicker1.Date = DateTime.Today;
			DayLabel.Text = "Day (Today)";
			FromPicker.Time = DateTime.Now.TimeOfDay;
			TillPicker.Time = DateTime.Now.AddHours(1).TimeOfDay;

			List<string> rooms = new List<string>() {
				"H.1.110","H.1.112","H.1.114","H.1.206","H.1.306","H.1.308","H.1.312","H.1.315","H.1.318","H.1.403","H.2.111","H.2.204","H.2.306","H.2.308","H.2.318","H.2.403","H.3.206","H.3.308","H.3.312","H.3.403","H.4.308","H.4.312","H.4.318","H.5.314","W.0.116","WD.01.003","WD.01.016","WD.01.019","WD.02.002","WD.02.016","WD.02.019","WD.03.005","WD.03.033","WD.04.002","WD.05.002","WD.05.005","WD.05.013","WD.05.018","WN.01.022","WN.02.007","WN.02.017","WN.02.022","WN.02.026","WN.03.007","WN.03.017","WN.03.022","WN.05.025","WD.04.020","WD.04.016","H.3.111","H.4.115","Spreekkamer","T30","Extern","extern","auditorium RDM","WN.01.014","Maaspodium","WD.00.026"
			};
			//foreach(string room in rooms) {
			//	RoomPicker.Items.Add(room);
			//}
		}


		private void BestOptions_Clicked(object sender, EventArgs e) {
			string begintime = "";
			string endtime = "";
			int amount_people = Int32.Parse(PeopleAmountEntry.Text);

			begintime += (DatePicker1.Date + FromPicker.Time) .ToString("yyyy-MM-dd HH:mm:ss");
			endtime += (DatePicker1.Date + TillPicker.Time).ToString("yyyy-MM-dd HH:mm:ss");

			//begintime += " " + FromPicker.Time.ToString("HH:mm:ss");
			//endtime += " " + TillPicker.Time.ToString("HH:mm:ss");

			Navigation.PushAsync(new RecommendationTestPage(begintime, endtime, amount_people));

			//Navigation.PushAsync(new RecommTEST());
			
			//Navigation.PushAsync(new LoadRecommendationsPage(UserTypePicker.SelectedItem.ToString(), RoomPicker.SelectedItem.ToString(), PeopleAmountEntry.Text,
			//	FromPicker.Time.ToString(), TillPicker.Time.ToString(), UserEntry.Text));
		}

		private void timepicker2_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
			//TimeSpan new_time = timepicker2.Time - timepicker1.Time;
			//if(new_time < new TimeSpan(0)) {
			//	timepicker3.Time = new TimeSpan(0);
			//	return;
			//}
			//timepicker3.Time = new_time;
		}

		private void DatePicker1_DateSelected(object sender, DateChangedEventArgs e) {
			if (e.NewDate < DateTime.Today) {
				DayLabel.Text = "Days of the past are over";
			} else if(e.NewDate.Year == DateTime.Today.Year & e.NewDate.Month == DateTime.Today.Month & e.NewDate.Day == DateTime.Today.Day) {
				DayLabel.Text = "Day (Today)";
			} else {
				DayLabel.Text = "Day";
			}
		}

		private void RoomPicker_SelectedIndexChanged(object sender, EventArgs e) {
			//if(RoomPicker.SelectedIndex == 0) RoomPicker.TextColor = Color.LightGray;
			//else RoomPicker.TextColor = Color.Black;
		}
	}
}