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
	public partial class MyReservationsPage : ContentPage
	{
		List<Models.Reservation> reservations;

		public MyReservationsPage ()
		{
			InitializeComponent ();
			//get reservations from api;
			//show reservations;

			reservations = Models.MockAPIResultToModelConvertor.ConvertToReservations("hi! :D");

			//get reservations from api;
			// select * from reservations r, users u where r.user_id = u.user_id and u.user_id = [insert user_id sent by app]

			// add columns
			//g.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
			//g.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

			// add rows and reservations
			foreach(var r in reservations) {
				g.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

				//List<Label> labels = new List<Label>() {
				////new Label { Text = r.UserID },
				//new Label { Text = r.RoomID },
				//new Label { Text = r.StartDateTime.ToString("dd-MM-yyyy HH:mm") },
				//new Label { Text = r.EndDateTime.ToString("dd-MM-yyyy HH:mm") },
				Label label = new Label {
					Text = r.RoomID + "\r\n" +
					r.StartDateTime.ToString("dd-MM-yyyy HH:mm") + "\r\n" +
					r.EndDateTime.ToString("dd-MM-yyyy HH:mm") + "\r\n",
					FontSize = 20,
				};
				//};

				//for (int i = 0; i < labels.Count; i++) {
				//	Label label = labels[i];

					switch(r.ResStatus) {
						case Models.Reservation.Status.CanceledByOwner:
						label.TextColor = Color.Red;
						break;
						case Models.Reservation.Status.CanceledByTeacher:
						label.TextColor = Color.Red;
						break;
						case Models.Reservation.Status.DueTime:
						//nuttin'
						break;
						case Models.Reservation.Status.Resolved:
						label.TextColor = Color.LightGray;
						break;
					}

					TapGestureRecognizer tgr = new TapGestureRecognizer();
					tgr.Tapped += (sender, e) => { Navigation.PushAsync(new ReservationDetailPage(r)); };
					label.GestureRecognizers.Add(tgr);

					Grid.SetRow(label, g.RowDefinitions.Count - 1);
					g.Children.Add(label);

				//}
			}
		}

	}
}