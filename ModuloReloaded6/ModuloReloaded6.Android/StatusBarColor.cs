using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using ModuloReloaded6.PlatformIndep;

[assembly: Dependency(typeof(ModuloReloaded6.Droid.Helpers.DroidButtonsBar))]
namespace ModuloReloaded6.Droid.Helpers {
	class DroidButtonsBar : IDroidButtonsBar {
		public void SetDroidButtonsBarRed() {
			Android.Graphics.Color c = Android.Graphics.Color.Red;
			((Activity)Forms.Context).Window.SetNavigationBarColor(c);
		}

		public void SetDroidButtonsBarWhite() {
			Android.Graphics.Color c = Android.Graphics.Color.GhostWhite;
			c.G += 2;
			c.R += 2;
			((Activity)Forms.Context).Window.SetNavigationBarColor(c);
		}
	}
}