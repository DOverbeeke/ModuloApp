using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScheduleWeekTestPage1 : ContentPage {
		List<Models.Lesson> lessons;
		List<Models.ReservationTestObject> reservations;
		DateTime monday;
		DateTime friday;
		int amount_hours = 24;


		//puur voor maandag tot en met vrijdag. Dus 5 dagen.
		//puur voor hele dagen. Dus 24 uur per dag.
		public ScheduleWeekTestPage1(List<Models.Lesson> lessons, List<Models.ReservationTestObject> reservations, DateTime Monday) {
			InitializeComponent();

			if(Navigation.NavigationStack.Count > 1) ;

			this.lessons = lessons;
			this.reservations = reservations;
			monday = Monday;
			friday = Monday.AddDays(4);

			//fill-in calendar header
			MonthLabel.Text = Monday.ToString("MMM");
			for(int i = 0; i < 5; i++) {
				Label daynumlabel = new Label { Text = Monday.AddDays(i).Day.ToString(), HorizontalTextAlignment = TextAlignment.Center };
				daynumlabel.FontSize = Device.GetNamedSize(NamedSize.Large, daynumlabel);

				Label daynamelabel = new Label { Text = Monday.AddDays(i).ToString("ddd"), HorizontalTextAlignment = TextAlignment.Center };
				daynamelabel.FontSize = Device.GetNamedSize(NamedSize.Small, daynamelabel);


				Utils.AddToGrid(DaysGrid, daynumlabel, i, 0);
				Utils.AddToGrid(DaysGrid, daynamelabel, i, 1);
			}

			//add grid rows
			for(int i = 0; i < amount_hours * 2; i++) {
				if(i % 2 == 0)
					ScrollGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
				else if(i < amount_hours * 2 - 1)
					ScrollGrid.RowDefinitions.Add(new RowDefinition { Height = 1 });
			}

			//add calendar times like 0:00 1:00 2:00 etc.
			for(int i = 0; i < amount_hours; i++) {
				Label time_label = new Label { Text = i + ":00\r\n\r\n" };
				Utils.AddToGrid(ScrollGrid, time_label, 0, 2 * i);
			}

			//add calender_items to calendar
			//add grid for days
			Grid cal_item_grid = new Grid { ColumnSpacing = 0, RowSpacing = 0, Margin = new Thickness(1, 0, 0, 0), Padding = 0 };
			Utils.AddToGrid(ScrollGrid, cal_item_grid, 1, 0, Grid.GetColumnSpan(ScrollGrid) - 1, (ScrollGrid.RowDefinitions.Count));

			//add column for each day
			Grid monday_grid = new Grid { BackgroundColor = Color.GhostWhite, Margin = 0, Padding = 0, RowSpacing = 0 };
			Grid tuesday_grid = new Grid { BackgroundColor = Color.GhostWhite };
			Grid wednesday_grid = new Grid { BackgroundColor = Color.GhostWhite };
			Grid thursday_grid = new Grid { BackgroundColor = Color.GhostWhite };
			Grid friday_grid = new Grid { BackgroundColor = Color.GhostWhite };

			for(var i = 0; i < 24; i++) {
				monday_grid.AddRow(new RowDefinition { });
				tuesday_grid.AddRow(new RowDefinition { });
				wednesday_grid.AddRow(new RowDefinition { });
				thursday_grid.AddRow(new RowDefinition { });
				friday_grid.AddRow(new RowDefinition { });
			}

			Utils.AddToGrid(cal_item_grid, monday_grid, 0, 0);
			Utils.AddToGrid(cal_item_grid, tuesday_grid, 1, 0);
			Utils.AddToGrid(cal_item_grid, wednesday_grid, 2, 0);
			Utils.AddToGrid(cal_item_grid, thursday_grid, 3, 0);
			Utils.AddToGrid(cal_item_grid, friday_grid, 4, 0);

			//gray lines between hours
			for(int i = 0; i < amount_hours - 1; i++) {
				Label gray_label = new Label { Text = "", BackgroundColor = Color.LightGray };
				Utils.AddToGrid(ScrollGrid, gray_label, 0, 1 + 2 * i, Grid.GetColumnSpan(ScrollGrid), 1);
			}


			//add calendar_item grids
			//////List<Models.Lesson> test_lessons = new List<Models.Lesson> {
			//////	new Models.Lesson { StartDateTime = DateTime.Today.AddHours(5).AddMinutes(10), EndDateTime = DateTime.Today.AddHours(5).AddMinutes(40) },
			//////	new Models.Lesson { StartDateTime = DateTime.Today.AddHours(7).AddMinutes(10), EndDateTime = DateTime.Today.AddHours(7).AddMinutes(40) },
			//////	new Models.Lesson { StartDateTime = DateTime.Today.AddHours(12).AddMinutes(30), EndDateTime = DateTime.Today.AddHours(14).AddMinutes(0) },
			//////	new Models.Lesson { StartDateTime = DateTime.Today.AddHours(20).AddMinutes(30), EndDateTime = DateTime.Today.AddHours(21).AddMinutes(0) },
			//////};

			if(reservations == null) return;

			//add reservations for week
			var days = new[] { monday_grid, tuesday_grid, wednesday_grid, thursday_grid, friday_grid };
			for(int i = 0; i < 5; i++) {
				var res_list = reservations.Where(r => r.StartDateTime.Day == monday.AddDays(i).Day).ToList();
				if(res_list.Count != 0) {
					AddReservationsToDay(days[i], res_list);


					//foreach(var r in res_list) {
					//	//if(l.StartDateTime.Minute == 0) l.StartDateTime = l.StartDateTime.AddMinutes(1);
					//	//if(l.EndDateTime.Minute == 0) l.EndDateTime = l.EndDateTime.AddMinutes(1);

					//	Grid reservation_grid = new Grid { BackgroundColor = Color.GhostWhite, Margin = 0, RowSpacing = 0, ColumnSpacing = 0, Padding = 0 };
					//	int start = r.StartDateTime.Hour;
					//	int end = r.EndDateTime.Hour + 1;
					//	Utils.AddToGrid(days[i], reservation_grid, 0, start, 1, end - start);

					//	//determine the height of the column for precision of the minutes
					//	double amount_of_minutes = 0;
					//	if(r.StartDateTime.Hour == r.EndDateTime.Hour) amount_of_minutes = (end - start) * 60;
					//	else amount_of_minutes = (end - start) * 60;

					//	double up_percentage = (double)r.StartDateTime.Minute / amount_of_minutes;
					//	double bottom_percentage = (double)(60 - (double)r.EndDateTime.Minute) / amount_of_minutes;

					//	reservation_grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(up_percentage, GridUnitType.Star) });
					//	reservation_grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
					//	reservation_grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(bottom_percentage, GridUnitType.Star) });

					//	Grid real_lesson_grid = new Grid { BindingContext = r, BackgroundColor = Color.Red, Margin = 0, RowSpacing = 0, Padding = 3 };
					//	Label res_room_label = new Label { Text = r.Room.Name + "\r\n(size: " + r.Room.Size + ")", TextColor = Color.GhostWhite };
					//	real_lesson_grid.GestureRecognizers.Add(new TapGestureRecognizer(ShowReservation));
					//	Utils.AddToGrid(real_lesson_grid, res_room_label, 0, 0);
					//	Utils.AddToGrid(reservation_grid, real_lesson_grid, 0, 1);
					//}
				}

				var les_list = lessons.Where(l => l.StartDateTime.Day == monday.AddDays(i).Day).ToList();
				if(les_list.Count != 0) {
					AddLessonsToDay(days[i], les_list);
				}
			}

			//////add reservations for Monday
			////var monday_res_list = reservations.Where(r => r.StartDateTime.Day == monday.Day).ToList();
			////if(monday_res_list.Count != 0) {
			////	foreach(var r in monday_res_list) {
			////		//if(l.StartDateTime.Minute == 0) l.StartDateTime = l.StartDateTime.AddMinutes(1);
			////		//if(l.EndDateTime.Minute == 0) l.EndDateTime = l.EndDateTime.AddMinutes(1);

			////		Grid reservation_grid = new Grid { BackgroundColor = Color.GhostWhite, Margin = 0, RowSpacing = 0, ColumnSpacing = 0, Padding = 0 };
			////		int start = r.StartDateTime.Hour;
			////		int end = r.EndDateTime.Hour + 1;
			////		Utils.AddToGrid(monday_grid, reservation_grid, 0, start, 1, end - start);

			////		//determine the height of the column for precision of the minutes
			////		double amount_of_minutes = 0;
			////		if(r.StartDateTime.Hour == r.EndDateTime.Hour) amount_of_minutes = (end - start) * 60;
			////		else amount_of_minutes = (end - start) * 60;

			////		double up_percentage = (double)r.StartDateTime.Minute / amount_of_minutes;
			////		double bottom_percentage = (double)(60 - (double)r.EndDateTime.Minute) / amount_of_minutes;

			////		reservation_grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(up_percentage, GridUnitType.Star) });
			////		reservation_grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
			////		reservation_grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(bottom_percentage, GridUnitType.Star) });

			////		Grid real_lesson_grid = new Grid { BindingContext = r, BackgroundColor = Color.Red, Margin = 0, RowSpacing = 0, Padding = 3 };
			////		Label res_room_label = new Label { Text = r.Room.Name + "\r\n(size: " + r.Room.Size + ")", TextColor = Color.GhostWhite };
			////		real_lesson_grid.GestureRecognizers.Add(new TapGestureRecognizer(ShowReservation));
			////		Utils.AddToGrid(real_lesson_grid, res_room_label, 0, 0);
			////		Utils.AddToGrid(reservation_grid, real_lesson_grid, 0, 1);
			////	}
			////}

			//////add lessons for Monday
			////var monday_les_list = lessons.Where(r => r.StartDateTime.Day == monday.Day).ToList();
			////if(monday_les_list.Count != 0) {
			////	foreach(var l in monday_les_list) {
			////		//if(l.StartDateTime.Minute == 0) l.StartDateTime = l.StartDateTime.AddMinutes(1);
			////		//if(l.EndDateTime.Minute == 0) l.EndDateTime = l.EndDateTime.AddMinutes(1);

			////		Grid lesson_grid = new Grid { BackgroundColor = Color.GhostWhite, Margin = 0, RowSpacing = 0, ColumnSpacing = 0, Padding = 0 };
			////		int start = l.StartDateTime.Hour;
			////		int end = l.EndDateTime.Hour + 1;
			////		Utils.AddToGrid(monday_grid, lesson_grid, 0, start, 1, end - start);

			////		//determine the height of the column for precision of the minutes
			////		double amount_of_minutes = 0;
			////		if(l.StartDateTime.Hour == l.EndDateTime.Hour) amount_of_minutes = (end - start) * 60;
			////		else amount_of_minutes = (end - start) * 60;

			////		double up_percentage = (double)l.StartDateTime.Minute / amount_of_minutes;
			////		double bottom_percentage = (double)(60 - (double)l.EndDateTime.Minute) / amount_of_minutes;

			////		lesson_grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(up_percentage, GridUnitType.Star) });
			////		lesson_grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
			////		lesson_grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(bottom_percentage, GridUnitType.Star) });

			////		Grid real_lesson_grid = new Grid { BindingContext = l, BackgroundColor = Color.Green, Margin = 0, RowSpacing = 0, Padding = 3 };
			////		Label les_room_label = new Label { Text = l.Subject + "\r\n" + l.Room.Name, TextColor = Color.GhostWhite };
			////		real_lesson_grid.GestureRecognizers.Add(new TapGestureRecognizer(ShowLesson));
			////		Utils.AddToGrid(real_lesson_grid, les_room_label, 0, 0);
			////		Utils.AddToGrid(lesson_grid, real_lesson_grid, 0, 1);
			////	}
			////}


			//Models.Lesson lesson = new Models.Lesson { StartDateTime = DateTime.Today.AddHours(5).AddMinutes(10), EndDateTime = DateTime.Today.AddHours(5).AddMinutes(40) };

			//Grid lesson_grid = new Grid { BackgroundColor = Color.Purple, Margin = 0, RowSpacing = 0, ColumnSpacing = 0, Padding = 0 };
			//int start = lesson.StartDateTime.Hour;
			//int end = lesson.EndDateTime.Hour + 1;
			//Utils.AddToGrid(monday_grid, lesson_grid, 0, start, 1, end - start);

			////determine the height of the column for precision of the minutes
			//double amount_of_minutes = 0;

			//if(lesson.StartDateTime.Hour == lesson.EndDateTime.Hour) amount_of_minutes = (end - start) * 60;
			//else amount_of_minutes = (end - start) * 60;

			//double up_percentage = (double)lesson.StartDateTime.Minute / amount_of_minutes;
			//double bottom_percentage = (double)(60 - (double)lesson.EndDateTime.Minute) / amount_of_minutes;

			//lesson_grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(up_percentage, GridUnitType.Star) });
			//lesson_grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
			//lesson_grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(bottom_percentage, GridUnitType.Star) });

			//Grid real_lesson_grid = new Grid { BackgroundColor = Color.Orange, Margin = 0, RowSpacing = 0, Padding = 0 };
			//Utils.AddToGrid(lesson_grid, real_lesson_grid, 0, 1);
		}

		void AddReservationsToDay(Grid day, List<Models.ReservationTestObject> res_list) {
			foreach(var r in res_list) {
				//if(l.StartDateTime.Minute == 0) l.StartDateTime = l.StartDateTime.AddMinutes(1);
				//if(l.EndDateTime.Minute == 0) l.EndDateTime = l.EndDateTime.AddMinutes(1);

				Grid reservation_grid = new Grid { BackgroundColor = Color.GhostWhite, Margin = 0, RowSpacing = 0, ColumnSpacing = 0, Padding = 0 };
				int start = r.StartDateTime.Hour;
				int end = r.EndDateTime.Hour + 1;
				Utils.AddToGrid(day, reservation_grid, 0, start, 1, end - start);

				//determine the height of the column for precision of the minutes
				double amount_of_minutes = 0;
				if(r.StartDateTime.Hour == r.EndDateTime.Hour) amount_of_minutes = (end - start) * 60;
				else amount_of_minutes = (end - start) * 60;

				double up_percentage = (double)r.StartDateTime.Minute / amount_of_minutes;
				double bottom_percentage = (double)(60 - (double)r.EndDateTime.Minute) / amount_of_minutes;

				reservation_grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(up_percentage, GridUnitType.Star) });
				reservation_grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
				reservation_grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(bottom_percentage, GridUnitType.Star) });

				Grid real_lesson_grid = new Grid { BindingContext = r, BackgroundColor = Color.Red, Margin = 0, RowSpacing = 0, Padding = 3 };
				Label res_room_label = new Label { Text = r.Room.Name + "\r\n(size: " + r.Room.Size + ")", TextColor = Color.GhostWhite };
				real_lesson_grid.GestureRecognizers.Add(new TapGestureRecognizer(ShowReservation));
				Utils.AddToGrid(real_lesson_grid, res_room_label, 0, 0);
				Utils.AddToGrid(reservation_grid, real_lesson_grid, 0, 1);
			}
		}

		void AddLessonsToDay(Grid day, List<Models.Lesson> les_list) {
			foreach(var l in les_list) {
				//if(l.StartDateTime.Minute == 0) l.StartDateTime = l.StartDateTime.AddMinutes(1);
				//if(l.EndDateTime.Minute == 0) l.EndDateTime = l.EndDateTime.AddMinutes(1);

				Grid lesson_grid = new Grid { BackgroundColor = Color.GhostWhite, Margin = 0, RowSpacing = 0, ColumnSpacing = 0, Padding = 0 };
				int start = l.StartDateTime.Hour;
				int end = l.EndDateTime.Hour + 1;
				Utils.AddToGrid(day, lesson_grid, 0, start, 1, end - start);

				//determine the height of the column for precision of the minutes
				double amount_of_minutes = 0;
				if(l.StartDateTime.Hour == l.EndDateTime.Hour) amount_of_minutes = (end - start) * 60;
				else amount_of_minutes = (end - start) * 60;

				double up_percentage = (double)l.StartDateTime.Minute / amount_of_minutes;
				double bottom_percentage = (double)(60 - (double)l.EndDateTime.Minute) / amount_of_minutes;

				lesson_grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(up_percentage, GridUnitType.Star) });
				lesson_grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
				lesson_grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(bottom_percentage, GridUnitType.Star) });

				Grid real_lesson_grid = new Grid { BindingContext = l, BackgroundColor = Color.Green, Margin = 0, RowSpacing = 0, Padding = 3 };
				Label les_label = new Label { Text = l.Subject + "\r\n" + l.Room.Name, TextColor = Color.GhostWhite };
				real_lesson_grid.GestureRecognizers.Add(new TapGestureRecognizer(ShowLesson));
				Utils.AddToGrid(real_lesson_grid, les_label, 0, 0);
				Utils.AddToGrid(lesson_grid, real_lesson_grid, 0, 1);
			}
		}

		void ShowReservation(View view, object obj) {
			Grid grid = view as Grid;
			Models.ReservationTestObject reservation = grid.BindingContext as Models.ReservationTestObject;
			RoomReservationAlertLabel.Text = reservation.Room.Name;
			DayReservationAlertLabel.Text = reservation.StartDateTime.ToString("ddd") + reservation.StartDateTime.ToString(" dd MMM");
			TimeStartTitleReservationAlertLabel.Text = "From";
			TimeStartReservationAlertLabel.Text = reservation.StartDateTime.ToString("HH:mm");
			TimeStartReservationAlertLabel.HorizontalTextAlignment = TextAlignment.Center;
			TimeEndTitleReservationAlertLabel.Text = "Till";
			TimeEndReservationAlertLabel.Text = reservation.EndDateTime.ToString("HH:mm");
			TimeEndTitleReservationAlertLabel.HorizontalTextAlignment = TextAlignment.Center;
			TabGrid.IsVisible = true;
			ReservationAlertFrame.IsVisible = true;
		}

		void ShowLesson(View view, object obj) {
			Grid grid = view as Grid;
			Models.Lesson lesson = grid.BindingContext as Models.Lesson;
			//Navigation.PushAsync(new AlterLessonPage(lesson));
		}

		void TapGridTapped(object obj, EventArgs e) {
			TabGrid.IsVisible = false;
			ReservationAlertFrame.IsVisible = false;
			//LessonAlertFrame.IsVisible = false;
		}

		void ReservationConfirmClicked(object obj, EventArgs e) {

		}

		void ReservationCancelClicked(object obj, EventArgs e) {
			TabGrid.IsVisible = false;
			ReservationAlertFrame.IsVisible = false;
		}

		void DayWeekSwitchClicked() {
			Navigation.PushAsync(new ScheduleDayTestPage1(lessons, reservations, monday.AddDays(2), monday));
			Navigation.RemovePage(this);
		}

		private void NextWeekButton_Clicked(object sender, EventArgs e) {
			Navigation.PushAsync(new GetLessonsPage(monday.AddDays(7), new DateTime()));
			Navigation.RemovePage(this);
		}

		private void PrevWeekButton_Clicked(object sender, EventArgs e) {
			Navigation.PushAsync(new GetLessonsPage(monday.AddDays(-7), new DateTime()));
			Navigation.RemovePage(this);
		}
	}
}