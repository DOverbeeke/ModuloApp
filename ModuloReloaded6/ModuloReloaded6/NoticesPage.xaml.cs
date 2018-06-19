using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoticesPage : ContentPage {
		private Grid VisibleMessageStatusGrid;

		public NoticesPage() {
			InitializeComponent();

			List<Models.Notice> notices = Models.MockAPIResultToModelConvertor.ConvertToNotices("notices!");
			//LView.ItemsSource = notices;
			ShowNotices2(notices);
		}

		private void ShowNotices(List<Models.Notice> notices) {
			
		}

		private void ShowNotices2(List<Models.Notice> notices) {
			//GridNotices.RowSpacing = 50;

			foreach(var n in notices) {
				//title
				//date
				//hidden message
				//hidden status


				if(GridNotices.RowDefinitions.Count < notices.Count)
					GridNotices.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

				Grid TitleDateRestGrid = new Grid {
					RowDefinitions = new RowDefinitionCollection {
						new RowDefinition { Height = 1 },
						new RowDefinition { Height = GridLength.Auto },
						new RowDefinition { Height = GridLength.Auto },
						new RowDefinition { Height = GridLength.Auto }
					}
				};

				//seperation bar
				BoxView bv = new BoxView {
					HorizontalOptions = LayoutOptions.Fill,
					VerticalOptions = LayoutOptions.Fill,
					BackgroundColor = Color.LightGray
				};
				Grid.SetColumn(bv, 0);
				Grid.SetRow(bv, 0);
				TitleDateRestGrid.Children.Add(bv);


				//title
				Label title = new Label { Text = n.Title, FontAttributes = FontAttributes.Bold, TextColor = Color.DimGray };
				title.FontSize = Device.GetNamedSize(NamedSize.Large, title);
				Utils.AddLabelToGrid(TitleDateRestGrid, title, 1, 0);

				//date
				Label date = new Label {
					Text = n.IssuedDateTime.ToString("dd-MM-yyyy HH:mm"),
					TextColor = Color.DarkGray,
					FontAttributes = FontAttributes.Italic
				};
				date.FontSize = Device.GetNamedSize(NamedSize.Small, date);
				Utils.AddLabelToGrid(TitleDateRestGrid, date, 2, 0);

				//hidden message + status
				Grid MessageStatusGrid = new Grid {
					IsVisible = false,
					RowDefinitions = new RowDefinitionCollection {
						new RowDefinition { Height = GridLength.Auto },
						new RowDefinition { Height = GridLength.Auto }
					}
				};

				Label message = new Label { Text = "\r\n" + n.Message + "\r\n", TextColor = Color.Gray };
				message.FontSize = Device.GetNamedSize(NamedSize.Medium, message);
				Utils.AddLabelToGrid(MessageStatusGrid, message, 0, 0);

				Label status = new Label {
					Text = "Status: " + n.State.ToString(),
					FontAttributes = FontAttributes.Italic,
					TextColor = Color.DarkGray
				};
				status.FontSize = Device.GetNamedSize(NamedSize.Small, status);
				Utils.AddLabelToGrid(MessageStatusGrid, status, 1, 0);

				var tgr = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
				tgr.TappedCallback = (sender, args) => {
					if(VisibleMessageStatusGrid != null) {
						if(VisibleMessageStatusGrid == MessageStatusGrid) {
							if(VisibleMessageStatusGrid.IsVisible) VisibleMessageStatusGrid.IsVisible = false;
							else VisibleMessageStatusGrid.IsVisible = true;
						} else {
							VisibleMessageStatusGrid.IsVisible = false;
							VisibleMessageStatusGrid = MessageStatusGrid;
							VisibleMessageStatusGrid.IsVisible = true;
						}
					} else {
						VisibleMessageStatusGrid = MessageStatusGrid;
						VisibleMessageStatusGrid.IsVisible = true;
					}
				};
				TitleDateRestGrid.GestureRecognizers.Add(tgr);

				Grid.SetColumn(MessageStatusGrid, 0);
				Grid.SetRow(MessageStatusGrid, 3);
				TitleDateRestGrid.Children.Add(MessageStatusGrid);

				Grid.SetColumn(TitleDateRestGrid, 0);
				Grid.SetRow(TitleDateRestGrid, notices.IndexOf(n));
				GridNotices.Children.Add(TitleDateRestGrid);
			}
		}
	}
}