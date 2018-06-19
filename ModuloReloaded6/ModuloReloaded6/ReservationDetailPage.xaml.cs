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
	public partial class ReservationDetailPage : ContentPage
	{
		public ReservationDetailPage (Models.Reservation reservation)
		{
			InitializeComponent ();

			bool add_cancel_button = false;

			List<Label> labels = new List<Label>() {
					//new Label { Text = r.UserID },
					new Label { Text = reservation.RoomID },
					new Label { Text = reservation.StartDateTime.ToString("dd-MM-yyyy HH:mm") },
					new Label { Text = reservation.EndDateTime.ToString("dd-MM-yyyy HH:mm") },
			};
			Label status_label = new Label();
			switch(reservation.ResStatus) {
				case Models.Reservation.Status.CanceledByOwner:
				status_label.Text = "Canceled by you";
				break;
				case Models.Reservation.Status.CanceledByTeacher:
				status_label.Text = "Canceled by teacher";
				break;
				case Models.Reservation.Status.DueTime:
				status_label.Text = "Due in " + reservation.EndDateTime.Subtract(DateTime.Now);
				add_cancel_button = true;
				break;
				case Models.Reservation.Status.Resolved:
				status_label.Text = "Resolved";
				break;
				default:
				status_label.Text = "How did you get this text???";
				break;
			}
			labels.Add(status_label);

			labels.ForEach(l => {
				l.FontSize = 20;
				l.HorizontalTextAlignment = TextAlignment.Center;
				stacklayout.Children.Add(l);
			});

			if(add_cancel_button) {
				Button cancel_b = new Button {
					Text = "Cancel reservation",
					TextColor = Color.GhostWhite,
					BackgroundColor = Color.Red,
					HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, false),
				};
				cancel_b.Clicked += (sender, e) => { Navigation.RemovePage(this); };
				stacklayout.Children.Add(cancel_b);
			}

		}

	}
}