using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainAppMDPageMaster : ContentPage {
		public ListView ListView;
		Models.User user;

		public MainAppMDPageMaster() {
			InitializeComponent();

			BindingContext = new MainAppMDPageMasterViewModel();
			ListView = MenuItemsListView;

			App app = App.Current as App;
			user = app.LoggedInUser;

			if(user.IsStudent) {
				//teacherGrid.IsVisible = false;
				studentGrid.IsVisible = true;
				UserNameLabel.Text = user.FirstName + " " + app.LoggedInUser.LastName;
				UserIdLabel.Text = user.Id;
				ClassLabel.Text = user.Class;
				studentGrid.ColumnDefinitions.RemoveAt(studentGrid.ColumnDefinitions.Count() - 1);
			} else {
				Grid teacherGrid = new Grid { BackgroundColor = Color.Red };
				Label label = new Label { Text = user.Code, TextColor = Color.WhiteSmoke };
				label.FontAttributes = FontAttributes.Bold;
				teacherGrid.Children.Add(label);
				teacherGrid.Padding = 5;
				ListView.Header = teacherGrid;
				//teacherGrid.IsVisible = true;
				studentGrid.IsVisible = false;
				//CodeLabel.Text = user.Code;
			}

		}

		class MainAppMDPageMasterViewModel : INotifyPropertyChanged {
			public ObservableCollection<MainAppMDPageMenuItem> MenuItems { get; set; }

			public MainAppMDPageMasterViewModel() {
				App app = App.Current as App;

				MenuItems = new ObservableCollection<MainAppMDPageMenuItem>(new[]
				{
					new MainAppMDPageMenuItem { Id = 0, Title = "Schedule", TargetType = typeof(GetLessonsPage) },
					new MainAppMDPageMenuItem { Id = 1, Title = "Reservate", TargetType = typeof(ReservatePage) },
					new MainAppMDPageMenuItem { Id = 2, Title = "My Reservations", TargetType = typeof(ReservationsLoadingPage2) },//typeof(MyReservationsPage) },
					new MainAppMDPageMenuItem { Id = 3, Title = "SignOffPage", TargetType = typeof(SignOffPage) },
					
					//not here: sing in page, new user page
				});

				if(!app.LoggedInUser.IsStudent) {
					MenuItems[3] = new MainAppMDPageMenuItem { Id = 3, Title = "My Lessons", TargetType = typeof(MyLessonsPage) };
					MenuItems.Add(new MainAppMDPageMenuItem { Id = 4, Title = "SignOffPage", TargetType = typeof(SignOffPage) });
				}
			}

			#region INotifyPropertyChanged Implementation
			public event PropertyChangedEventHandler PropertyChanged;
			void OnPropertyChanged([CallerMemberName] string propertyName = "") {
				if(PropertyChanged == null)
					return;

				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
			#endregion
		}

		private void UserInfoTapped(object sender, EventArgs e) {
			Navigation.PushAsync(new MyInfoPageStudent());
		}
	}
}