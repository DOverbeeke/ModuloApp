using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecommendationsReservationPage : ContentPage {
		private Grid selected_grid;
		private Dictionary<int, Color> LabelColors = new Dictionary<int, Color>();

		int amount_people2 = 0;

		public RecommendationsReservationPage(List<Models.Recommendation> api_objects, int amount_people) {
			InitializeComponent();

			Title = "Recommendations! :D";
			this.amount_people2 = amount_people;

			LView.ItemsSource = api_objects //Models.MockAPIResultToModelConvertor.ConvertToRecommendations("hahaha :D")
				.Select((r) => {
					var BeginDate = string.Format("{0} {1} {2}", r.BeginTime.Day, Utils.NumToMonth(r.BeginTime.Month - 1), r.BeginTime.Year);
					var EndDate = string.Format("{0} {1} {2}", r.EndTime.Day, Utils.NumToMonth(r.EndTime.Month - 1), r.EndTime.Year);
					string Date = "";
					if(BeginDate == EndDate) Date = BeginDate;
					else Date = BeginDate + "\r\n" + EndDate;
					var BeginTime = r.BeginTime.ToString("HH:mm");
					var EndTime = r.EndTime.ToString("HH:mm");
					return new RecommToShow { RoomId = r.RoomId, RoomName = r.Name, Size = r.Size, Date = Date, BeginTime = BeginTime, EndTime = EndTime,
					ApiDateTimeBegin = r.BeginTime.ToString("yyyy-MM-dd HH:mm:ss"), ApiDateTimeEnd = r.EndTime.ToString("yyyy-MM-dd HH:mm:ss")};
				})
				.ToList();
		}

		private class RecommToShow {
			public int RoomId { get; set; }
			public string RoomName { get; set; }
			public int Size { get; set; }
			public string Date { get; set; }
			public string BeginTime { get; set; }
			public string EndTime { get; set; }
			//format for API (see ConfirmClicked)
			public string ApiDateTimeBegin { get; set; }
			public string ApiDateTimeEnd { get; set; }
		}

		private void ItemGridTapped(object sender, EventArgs e) {
			selected_grid = sender as Grid;

			RecommToShow bc = selected_grid.Children[0].BindingContext as RecommToShow;

			LabelColors.Clear();
			int key = 0;
			selected_grid.Children
				.Where((c) => c.GetType() == typeof(Label))
				.ToList()
				.ForEach((child) => { var c = child as Label; LabelColors.Add(key, c.TextColor); c.TextColor = Color.Red; key++; });



			int count = 0;
			var time = "";
			selected_grid.Children
				.Where((c) => c.GetType() == typeof(Label))
				.ToList()
				.ForEach((child) => {
					var c = child as Label;
					if(count == 0) RoomAlertLabel.Text = c.Text;
					if(count == 1) DateAlertLabel.Text = c.Text;
					if(count == 2) { time = c.Text; };
					if(count == 3) { time += " - " + c.Text; };
					TimeAlertLabel.Text = time;
					count++;
				});

			RoomAlertLabel.Text = bc.RoomName;
			DateAlertLabel.Text = bc.Date;
			TimeAlertLabel.Text = bc.BeginTime + " - " + bc.EndTime;
			PeopleAlertLabel.Text += bc.Size;
			ConfirmButtonAlert.BindingContext = bc;

			TabGrid.IsVisible = true;
			AlertFrame.IsVisible = true;
		}

		private void ConfirmClicked(object sender, EventArgs e) {
			var b = sender as Button;
			var bc = b.BindingContext as RecommToShow;
			Navigation.PushAsync(new AddReservationPage(bc.RoomId.ToString(), amount_people2.ToString(), bc.ApiDateTimeBegin, bc.ApiDateTimeEnd));
			Navigation.RemovePage(this);
		}

		private void CancelClicked(object sender, EventArgs e) {
			int key = 0;
			selected_grid.Children
				.Where((c) => c.GetType() == typeof(Label))
				.ToList()
				.ForEach((child) => { var c = child as Label; c.TextColor = LabelColors[key]; key++; });
			TabGrid.IsVisible = false;
			AlertFrame.IsVisible = false;
		}

		private void TapGridTapped(object sender, EventArgs e) {
			if(AlertFrame.IsEnabled) {
				CancelClicked(null, null);
			}
		}

		protected override bool OnBackButtonPressed() {
			if(AlertFrame.IsEnabled) {
				CancelClicked(null, null);
				return true;
			} else {
				return base.OnBackButtonPressed();
			}
		}
	}
}