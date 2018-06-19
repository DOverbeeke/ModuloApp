using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainAppMDPage : MasterDetailPage {
		public MainAppMDPage() {
			InitializeComponent();
			MasterPage.ListView.ItemSelected += ListView_ItemSelected;
			//Navigation.RemovePage(Navigation.NavigationStack[0]);
		}

		private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
			var item = e.SelectedItem as MainAppMDPageMenuItem;
			if(item == null)
				return;

			Page page;
			if(item.TargetType == typeof(SignOffPage)) {
				page = new SignOffPage(() => { Navigation.PushAsync(new SignInPage()); Navigation.RemovePage(this); });
			} else if (item.TargetType == typeof(GetLessonsPage)) {
				page = new GetLessonsPage(Utils.GetMonday(), new DateTime());
			} else {
				page = (Page)Activator.CreateInstance(item.TargetType);
			}

			page.Title = item.Title;

			Detail = new NavigationPage(page) { BarBackgroundColor = Color.Red };
			IsPresented = false;

			MasterPage.ListView.SelectedItem = null;
		}
	}
}