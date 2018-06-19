using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestListViewPage : ContentPage {

		public TestListViewPage() {
			InitializeComponent();

			var test_recomms = new List<Models.TestRecommendation> {
				new Models.TestRecommendation("name1", "racca1"),
				new Models.TestRecommendation("name2", "racca2"),
				new Models.TestRecommendation("name3", "racca3"),
				new Models.TestRecommendation("name4", "racca4"),
				new Models.TestRecommendation("name5", "racca5"),
				new Models.TestRecommendation("name6", "racca6"),
				new Models.TestRecommendation("name7", "racca7"),
			};
			LView.ItemsSource = test_recomms;
		}
	}

}