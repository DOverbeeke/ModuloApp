using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlterLessonPage : ContentPage {
		public AlterLessonPage(Models.Lesson lesson) {
			InitializeComponent();

			label.Text = "subject: " + lesson.Subject.Name;
		}
	}
}