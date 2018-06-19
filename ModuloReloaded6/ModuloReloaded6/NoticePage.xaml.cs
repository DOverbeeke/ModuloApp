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
	public partial class NoticePage : ContentPage
	{
		public NoticePage (Models.Notice notice)
		{
			InitializeComponent ();

			Title.Text = notice.Title;
			Date.Text = notice.IssuedDateTime.ToString("dd-MM-yyyy HH:mm");
			Message.Text = notice.Message;
			Status.Text = "\r\nStatus: " + notice.State.ToString();
		}
	}
}