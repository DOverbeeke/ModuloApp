using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScheduleTestPage1 : ContentPage {
		public ScheduleTestPage1() {
			InitializeComponent();



			//raster
			CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
			for(int column = 0; column < 8; column++) {
				CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			}

		}

		void AddToGrid(Grid grid, View item, int column, int row) {
			Grid.SetColumn(item, column);
			Grid.SetRow(item, row);
			grid.Children.Add(item);
		}
		void AddToGrid(Grid grid, View item, int column, int row, int column_span, int row_span) {
			Grid.SetColumn(item, column);
			Grid.SetRow(item, row);
			Grid.SetColumnSpan(item, column_span);
			Grid.SetRowSpan(item, row_span);
			grid.Children.Add(item);
		}


		void DayWeekSwitchClicked(object sender, EventArgs e) {
			for(int row = 0; row < 10; row++) {
				CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
				Label label = new Label { Text = String.Format("r{0}c{1}", row.ToString(), CalendarGrid.ColumnDefinitions.Count - 1) };
				AddToGrid(CalendarGrid, label, CalendarGrid.ColumnDefinitions.Count - 1, row);
			}
		}
	} 
}