using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeleteToReservationsPage : ContentPage {
		public DeleteToReservationsPage() {
			InitializeComponent();
		}

		protected override void OnAppearing() {
			base.OnAppearing();

			Navigation.PushAsync(new ReservationsLoadingPage2());
			Navigation.RemovePage(this);
		}
	}
}