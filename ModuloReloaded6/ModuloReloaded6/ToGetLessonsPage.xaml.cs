using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToGetLessonsPage : ContentPage {
		public ToGetLessonsPage() {
			InitializeComponent();
			Navigation.PushAsync(new GetLessonsPage(Utils.GetMonday(), new DateTime()));
			Navigation.RemovePage(this);
		}
	}
}