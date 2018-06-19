using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SchedulePage : ContentPage {
		DateTime MondayDateTime;
		DateTime FridayDateTime;

		int amount_of_days = 5;
		int amount_of_hours = 24;
		bool ShowingDay = false;

		GridLength old_column_width = new GridLength();

		public SchedulePage(List<Models.Lesson> lessons, List<Models.ReservationTestObject> reservations) {
			InitializeComponent();

			InitializeMondayAndFriday();
			ApiCall();
		}

		void InitializeMondayAndFriday() {
			DateTime day = DateTime.Today;
			while(day.DayOfWeek != DayOfWeek.Monday) {
				day.AddDays(-1);
			}
			MondayDateTime = day;
			FridayDateTime = day.AddDays(4);
		}
		void ApiCall() {

		}

		void SetupCalendarRaster() {
			//AddColumnsToGrids2();
			//AddMonthLabel();
			//AddDayGrids();

			//first column

			//other columns

			AddColumnsToGrids();
			AddCalendarHeaders();
			AddCalendarRows();
		}

		void AddColumnsToGrids2() {
			WholeCalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
			for(int day = 0; day < amount_of_days; day++) {
				WholeCalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			}
		}
		void AddMonthLabel() {
			Label MonthLabel = new Label { Text = DateTime.Today.ToString("MMM"), VerticalTextAlignment = TextAlignment.Center };
			MonthLabel.FontSize = Device.GetNamedSize(NamedSize.Large, MonthLabel);
			AddToGrid(WholeCalendarGrid, MonthLabel, 0, 0);
		}
		void AddDayGrids() {
			for (int i = 0; i < WholeCalendarGrid.ColumnDefinitions.Count - 1; i++) {

			}
		}

		void AddColumnsToGrids() {
			//column most left
			HeaderGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
			CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
			//other columns
			//HeaderGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			//CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			for(int day = 0; day < amount_of_days; day++) {
				CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
				HeaderGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			}
		}
		//add calendar headers (e.g. May 29Mon 30Tue 31Wed 1Thu 2Fri)
		void AddCalendarHeaders() {
			HeaderGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
			HeaderGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
			//Month
			Label MonthLabel = new Label { Text = DateTime.Today.ToString("MMM"), VerticalTextAlignment = TextAlignment.Center };
			MonthLabel.FontSize = Device.GetNamedSize(NamedSize.Large, MonthLabel);
			AddToGrid(HeaderGrid, MonthLabel, 0, 0, 1, 2);
			//Days
			for(int i = 0; i < 5; i++) {
				Label DayLabel = new Label { Text = DateTime.Today.AddDays(i).Day.ToString(), HorizontalTextAlignment = TextAlignment.Center };
				DayLabel.FontSize = Device.GetNamedSize(NamedSize.Large, DayLabel);
				AddToGrid(HeaderGrid, DayLabel, 1 + i, 0);
				Label DayDDDLabel = new Label { Text = DateTime.Today.AddDays(i).ToString("ddd"), HorizontalTextAlignment = TextAlignment.Center };
				AddToGrid(HeaderGrid, DayDDDLabel, 1 + i, 1);
			}
		}
		void AddCalendarRows() {
			//add calendar rows
			for(int hr = 0; hr < amount_of_hours; hr++) {
				if(hr != 0)
					CalendarGrid.RowDefinitions.Add(new RowDefinition { Height = 1 });
				CalendarGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
				//hour text
				Label lbl = new Label { Text = hr + ":00\r\n" };
				AddToGrid(CalendarGrid, lbl, 0, 2 * hr);
				//gray line to seperate hours
				if(hr != 0) {
					Label color_lbl = new Label { BackgroundColor = Color.LightGray };
					AddToGrid(CalendarGrid, color_lbl, 0, 2 * hr - 1, amount_of_days + 1, 1);
				}
			}
		}

		void AddToGrid(Grid grid, View item, int column, int row) {
			Grid.SetColumn(item, column);
			Grid.SetRow(item, row);
			grid.Children.Add(item);
		}
		//void AddToGrid(Grid grid, View item, int column, int row, int column_span) {
		//	Grid.SetColumn(item, column);
		//	Grid.SetRow(item, row);
		//	Grid.SetColumnSpan(item, column_span);
		//	grid.Children.Add(item);
		//}
		//void AddToGrid(Grid grid, View item, int column, int row, int row_span) {
		//	Grid.SetColumn(item, column);
		//	Grid.SetRow(item, row);
		//	Grid.SetRowSpan(item, row_span);
		//	grid.Children.Add(item);
		//}
		void AddToGrid(Grid grid, View item, int column, int row, int column_span, int row_span) {
			Grid.SetColumn(item, column);
			Grid.SetRow(item, row);
			Grid.SetColumnSpan(item, column_span);
			Grid.SetRowSpan(item, row_span);
			grid.Children.Add(item);
		}

		void AddCalendarItemsToRaster(List<Models.Lesson> lessons, List<Models.ReservationTestObject> reservations) {

		}

		void DayButtonClicked(object sender, EventArgs e) {

		}
		void WeekButtonClicked(object sender, EventArgs e) {

		}
		void DayWeekSwitchClicked(object sender, EventArgs e) {
			if(ShowingDay) {
				DayWeekSwitchButton.Text = "Show Day";
				ShowingDay = false;
				HeaderGrid.ColumnDefinitions.Where((cd) => !InRange(HeaderGrid.ColumnDefinitions.IndexOf(cd), 0, 1)).ToList().ForEach((c) => { c.Width = old_column_width; });
				//CalendarGrid.ColumnDefinitions.Where((cd) => !InRange(HeaderGrid.ColumnDefinitions.IndexOf(cd), 0, 1)).ToList().ForEach((c) => { c.Width = old_column_width; });
			} else {
				DayWeekSwitchButton.Text = "Show Week";
				ShowingDay = true;





				HeaderGrid.ColumnDefinitions.Where((cd) => !InRange(HeaderGrid.ColumnDefinitions.IndexOf(cd), 0, 1)).ToList().ForEach((c) => { old_column_width = c.Width; c.Width = 0; });
				//CalendarGrid.ColumnDefinitions.Where((cd) => !InRange(HeaderGrid.ColumnDefinitions.IndexOf(cd), 0, 1)).ToList().ForEach((c) => { old_column_width = c.Width; c.Width = 0; });
			}
		}

		bool InRange(int i, int include_min, int include_max) {
			return i >= include_min &  i <= include_max;
		}
	}
}