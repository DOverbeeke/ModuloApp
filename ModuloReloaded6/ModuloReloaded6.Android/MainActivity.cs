using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ModuloReloaded6.Droid
{
	[Activity (Label = "ModuloReloaded6", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new ModuloReloaded6.App ());

			Window.SetStatusBarColor(Android.Graphics.Color.DarkRed);
			//Android.Graphics.Color c = Android.Graphics.Color.GhostWhite;
			//c.G += 2;
			//c.R += 2;
			//Window.SetNavigationBarColor(c);
			
			////Window.SetNavigationBarColor(Android.Graphics.Color.Red);
		}
	}
}

