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
	public partial class WeekRoosterTest1 : ContentPage
	{
		public WeekRoosterTest1() {
			InitializeComponent();

			var item = GetItem();
			Draw(item);
		}

		private void Draw(MyCalendarItem2 item) {
			//columns
			TestGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto }); //new GridLength(10, GridUnitType.Auto) });
			TestGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			TestGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			TestGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			TestGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			TestGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			TestGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			TestGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

			//rows and content
			int begin = 0;
			int end = 24;
			double standard_height = 40;
			Color line_color = Color.LightGray;

			int rowcount = -1;

			//for calendaritem
			double amount_start = (double)item.Start.Minute / 60 * standard_height;
			if(amount_start == 0) amount_start = 1;
			if(amount_start == standard_height) amount_start = standard_height - 1;
			double amount_end = (double)item.End.Minute / 60 * standard_height;
			if(amount_end == 0) amount_end = 1;
			if(amount_end == standard_height) amount_end = standard_height - 1;
			int row_start = item.Start.Hour * 2 - 1; //gets updated in for loop below
			int row_end = item.End.Hour * 2 - 1; //gets updated in for loop below


			for(int hour = begin; hour < end; hour++) {
				// lines
				if(hour != begin) {
					TestGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Absolute) });
					rowcount++;
					Label lbl = new Label { Text = "", BackgroundColor = line_color };
					Grid.SetRow(lbl, rowcount);
					Grid.SetColumn(lbl, 0);
					Grid.SetColumnSpan(lbl, TestGrid.ColumnDefinitions.Count);
					TestGrid.Children.Add(lbl);
				}

				// calendar items
				RowDefinition rd = new RowDefinition { Height = new GridLength(standard_height, GridUnitType.Absolute) };
				TestGrid.RowDefinitions.Add(rd);
				rowcount++;

				Label timelabel = new Label { Text = hour + ":00", TextColor = Color.Gray, Margin = new Thickness(0,0,2,0) };
				Grid.SetColumn(timelabel, 0);
				Grid.SetRow(timelabel, rowcount);
				TestGrid.Children.Add(timelabel);

				if(item.Start.Hour == hour) {
					row_start = rowcount;
				}
				if(item.End.Hour == hour) {
					row_end = rowcount;
				}
			}

			// item
			Grid new_g = new Grid { ColumnSpacing = 0, RowSpacing = 0, Margin = new Thickness(2, 0, 2, 0) };
			if(row_start == row_end) {
				new_g.RowDefinitions.Add(new RowDefinition { Height = new GridLength(amount_start, GridUnitType.Absolute) }); // "empty"
				new_g.RowDefinitions.Add(new RowDefinition { Height = new GridLength(amount_end - amount_start, GridUnitType.Absolute), }); // item
				new_g.RowDefinitions.Add(new RowDefinition { Height = new GridLength(standard_height - amount_end, GridUnitType.Absolute) }); // "empty"

				Label LblForColor = new Label { BackgroundColor = Color.LightSeaGreen };
				Grid.SetColumn(LblForColor, 0);
				Grid.SetRow(LblForColor, 1);
				new_g.Children.Add(LblForColor);

				Label lbl = new Label { Text = item.Content, TextColor = Color.Purple, FontAttributes = FontAttributes.Bold };
				Grid.SetColumn(lbl, 0);
				Grid.SetRow(lbl, 1);
				new_g.Children.Add(lbl);

				Grid.SetColumn(new_g, 1);
				Grid.SetRow(new_g, row_start);
				TestGrid.Children.Add(new_g);
			} else {
				new_g.RowDefinitions.Add(new RowDefinition { Height = new GridLength(amount_start, GridUnitType.Absolute) });
				new_g.RowDefinitions.Add(new RowDefinition { Height = new GridLength(standard_height - amount_start, GridUnitType.Absolute) });
				new_g.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
				new_g.RowDefinitions.Add(new RowDefinition { Height = new GridLength(amount_end, GridUnitType.Absolute) });
				new_g.RowDefinitions.Add(new RowDefinition { Height = new GridLength(standard_height - amount_end, GridUnitType.Absolute) });

				Label lbl = new Label { Text = item.Content, TextColor = Color.Purple, BackgroundColor = Color.LightGreen };
				Grid.SetColumn(lbl, 0);
				Grid.SetRow(lbl, 1);
				Grid.SetRowSpan(lbl, 3);
				new_g.Children.Add(lbl);

				Grid.SetColumn(new_g, 1);
				Grid.SetRow(new_g, row_start);
				Grid.SetRowSpan(new_g, row_end - row_start + 1);
				TestGrid.Children.Add(new_g);
			}
		}

		private MyCalendarItem2 GetItem() {
			return new MyCalendarItem2(new DateTime(2018, 4, 28, 9, 30, 0), new DateTime(2018, 4, 28, 11, 30, 0), "ICT-Lab", "Omar");
			//return new MyCalendarItem2(new DateTime(2018, 4, 28, 9, 9, 0), new DateTime(2018, 4, 28, 9, 47, 0), "ICT-Lab", "Omar");
		}
	}
}