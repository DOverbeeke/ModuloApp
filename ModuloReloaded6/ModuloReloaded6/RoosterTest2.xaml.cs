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
	public partial class RoosterTest2 : ContentPage
	{
		public RoosterTest2 ()
		{
			InitializeComponent ();

			//MyCalendarItem2 item = new MyCalendarItem2(new DateTime(2018, 4, 27, 6, 24, 0), new DateTime(2018, 4, 27, 11, 55, 0), "ICT-Lab", "Omar");
			//Console.WriteLine("item created now give to drawcalendar");
			////MyGrid.DrawCalendar(0, 23, item, 25);
			//MyGrid.DrawCalendarTest();
			MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
			MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
			//grid.AddLine(1, Color.Gray);
			//MyGrid.AddRow(25);
			this.AddLine(2, Color.Gray);
		}

		private void AddLine(int column_span, Color color) {
			var row_def = new RowDefinition();
			MyGrid.RowDefinitions.Add(row_def);
			BoxView bv = new BoxView { BackgroundColor = color, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
			Grid.SetColumn(bv, 0);
			Grid.SetColumnSpan(bv, column_span);
			Grid.SetRow(bv, Grid.GetRow(row_def));
		}

	}
}