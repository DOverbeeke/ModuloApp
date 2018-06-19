using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterUserInfoPage : ContentPage {
		public RegisterUserInfoPage() {
			InitializeComponent();

			List<string> classes = new List<string>() {
				"BO-COM","BO-DINF","BO-INF","BO-TI","CMD1A","CMD1B","CMD1C","CMD1D","CMD1E","CMD1F","CMD1G","CMD1H","CMD2A","CMD2B","CMD2C","CMD2D","CMD2E","CMD3A","CMD3B","CMD3C","CMD3D","CMD3X","CMD4A","CMD4B","CMD4C","CMD4D","CMD-BO","COD2","COD3","COD4","COD-AD3","COV1A","COV1B","COV1C","COV1D","COV1E","COV1F","COV1G","COV1V","COV2A","COV2B","COV2C","COV2D","COV2E","COV3A","COV3B","COV3C","COV3D","COV3E","COV3F","COV3-HP","COV4A","COV4B","COV4C","COV4D","COV4E","COV4F","COV4G","COV5X","COV6X","COV-AD3","DCMD1A","DCMD2A","DCMD3A","DCMD4A","DINF1","DINF2","DINF3","DINF4","INF1A","INF1B","INF1C","INF1D","INF1E","INF1F","INF1G","INF1H","INF1I","INF1J","INF1K","INF1L","INF2A","INF2B","INF2C","INF2D","INF2E","INF2F","INF3A","INF3B","INF3C","INF3D","INF4A","INF4B","INF4C","KEU AAR01","KEU ANI01","KEU BET01","KEU FAM01K","KEU FSO01K","KEU HUV01H","KEU INF01K","KEU IPR01K","KEU JAV01K","KEU LEG01K","KEU LEX01K","KEU MOD01K","KEU NWB01K","KEU OVC01K","KEU RTV01K","KEU RUC01K","KEU SO201K","KEU SOU01K","KEU SPW01K","KEU STB01K","KEU STN01K","KEU VIE01K","KEU VIS01K","KEU WPB01K","MIN DIP01","MIN EDT01","MIN ENS02","MIN GET01","MIN IBR01","MIN IED03","MIN IED1A","MIN IED1B","MIN ILB01","MIN JOU01","MIN PRS01","MIN SLA01","MIN SMO","MIN UID01","MINBOD02","MINBOD02A","MINBOD02B","MINIED1A","MINIED1B","MINIED1C","RESCMD","TENT","TI1A","TI1B","TI1C","TI2A","TI2B","TI3A","TI3B","TI4A","TI4B","uitloop lokaal","RESINF","CMDLABEXP","CMDLABVD","CMDLABIAD"
			};
			foreach(string c in classes) {
				ClassPicker.Items.Add(c);
			}
		}

		private void Button_Clicked(object sender, EventArgs e) {
			//var md = new MainAppMDPage();
			//Navigation.mod
			Navigation.PushAsync(new MainAppMDPage());
			//Navigation.PopAsync();
			//var md = new MainAppMDPage();
			//md.Master = new MainAppMDPageMaster();
			//md.Detail = new RoosterTest3();
			//Navigation.InsertPageBefore(md, this);
			Navigation.RemovePage(this);
		}

		private void ClassPicker_SelectedIndexChanged(object sender, EventArgs e) {
			ClassButton.IsEnabled = true;
			ClassButton.BorderColor = Color.Red;
			ClassButton.TextColor = Color.White;
			ClassButton.BackgroundColor = Color.Red;
		}
	}
}