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
	public partial class RoosterTestPage : ContentPage
	{
		public RoosterTestPage ()
		{
			InitializeComponent ();

			List<IMyCalendarItem> calendar_items = new List<IMyCalendarItem>();
			//calendar_items.Add(new SubjectCalendarItem());
			//calendar_items.Add(new SubjectCalendarItem());
		}
	}
}