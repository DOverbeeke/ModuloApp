using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyWeekRoosterPage : ContentPage {
		double grid_height_origin;
		double grid_scale_origin;

		public MyWeekRoosterPage() {
			InitializeComponent();

			double line_height = 1;
			double row_height = 32;
			int starting_hour = 0;
			int amount_of_hours_to_show = 24;
			int hour_division = 4; // here, 6 means divisions of 10 minutes; 20 means divisions of 3 minutes

			var column_count = 8;

			Color grid_color = Color.LightGray;


			for(int col = 0; col < column_count; col++) {
				MyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			}

			int row = -1;
			// initialize calendar GRID
			for(int hour = starting_hour; hour < amount_of_hours_to_show; hour++) {
				row++;
				// add row for line
				if(hour != starting_hour) {
					//add row
					MyGrid.RowDefinitions.Add(new RowDefinition { Height = line_height,  });
					//give line the gridcolor
					BoxView bv = new BoxView { BackgroundColor = grid_color, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
					MyGrid.Children.Add(bv);
					Grid.SetColumn(bv, 0);
					Grid.SetColumnSpan(bv, column_count);
					Grid.SetRow(bv, row);
				}
				// add rows for empty space
				for(int division_count = 1; division_count <= hour_division; division_count++) {
					row++;
					// add row
					MyGrid.RowDefinitions.Add(new RowDefinition { Height = row_height / hour_division });
					// add label like 6:00, 7:00, 8:00, etc.
					if(division_count == 1) {
						Label time_label = new Label { Text = hour + ":00" };
						MyGrid.Children.Add(time_label);
						if(hour == starting_hour)
							row -= 1;
						Grid.SetColumn(time_label, 0);
						Grid.SetRow(time_label, row);
						Grid.SetRowSpan(time_label, hour_division);
					}
				}
			}


			//// draw calendar horizontal gridlines
			//for(int hour = starting_hour; hour < amount_of_hours_to_show; hour++) {
			//	if(hour > starting_hour & hour < amount_of_hours_to_show) {
			//		BoxView bv = new BoxView { BackgroundColor = grid_color, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
			//		MyGrid.Children.Add(bv);
			//		Grid.SetColumn(bv, 0);
			//		Grid.SetColumnSpan(bv, column_count);
			//		int row = hour * hour_division + 1;
			//		Grid.SetRow(bv, row);
			//	}
			//}

			//// draw calendar timestamps like 6:00, 7:00, 8:00, ...
			//for(int hour = starting_hour; hour < amount_of_hours_to_show; hour++) {
			//	Label time_label = new Label { Text = hour + ":00" };
			//	MyGrid.Children.Add(time_label);
			//	int row = hour * hour_division + 2; // if hour_division==6 and hour==1, row should be 6+linerow+1 = 8
			//	if(hour == starting_hour)
			//		row -= 1;
			//	Grid.SetColumn(time_label, 0);
			//	Grid.SetRow(time_label, row);
			//	Grid.SetRowSpan(time_label, hour_division);
			//}

			grid_height_origin = StackLayout2.Height;
			grid_scale_origin = StackLayout2.Scale;
			
			Console.WriteLine(StackLayout2.Height);
		}

		private void PinchGestureRecognizer_PinchUpdated(object sender, PinchGestureUpdatedEventArgs e) {
			Console.WriteLine(e.Scale + "     " + e.Scale / grid_scale_origin + "    " + StackLayout2.Height);
			//StackLayout2.Scale = e.Scale * grid_scale_origin;
			//StackLayout2.HeightRequest = e.Scale / grid_scale_origin * grid_height_origin;
			foreach (var st in MyGrid.RowDefinitions) {
				st.Height = st.Height.Value + 1;
			}
		}
	}
}