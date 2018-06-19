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
	public partial class SignOffPage : ContentPage
	{
		Action quit_mdpage_start_loginpage;

		public SignOffPage (Action quit_mdpage_start_loginpage)
		{
			InitializeComponent ();
			this.quit_mdpage_start_loginpage = quit_mdpage_start_loginpage;
		}

		private void Button_Clicked(object sender, EventArgs e) {
			quit_mdpage_start_loginpage();
		}
	}
}