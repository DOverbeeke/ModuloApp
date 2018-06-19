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
	public partial class MyRoosterPage : ContentPage
	{
		public MyRoosterPage ()
		{
			InitializeComponent ();

			MyCalendarItem2 item = new MyCalendarItem2(new DateTime(2018, 4, 28, 9, 30, 0), new DateTime(2018, 4, 28, 11, 30, 0), "ICT-Lab", "Omar");

			BoxView bv = new BoxView { Color = Color.Gray };

			//Color labelbackcolor = Color.Gray;
			//int row = -1;
			//for(int hour = 0; hour < 24; hour++) {
			//	Label newlabel = new Label { Text = hour + ":00", BackgroundColor = labelbackcolor };
			//	MyGrid.Children.Add(newlabel);
			//	Grid.SetColumn(newlabel, 0);
			//	row = row + 2;
			//	Grid.SetRow(newlabel, row);
			//}
		}
	}
}