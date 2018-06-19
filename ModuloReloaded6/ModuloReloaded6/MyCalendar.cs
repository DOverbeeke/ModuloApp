using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {

	static class GridExtensions {

		public static void DrawCalendarTest(this Grid grid) {
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			//grid.AddLine(1, Color.Gray);
			grid.AddRow(25);
			grid.AddLine(0, Color.Gray);
		}

		public static void DrawCalendar(this Grid grid, int hour_start, int hour_end, MyCalendarItem2 item, double standard_rowheight) {
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

			//Console.WriteLine("columns added");

			BoxView bv = new BoxView();
			Grid.SetColumn(bv, 1);
			bool count_rows_for_bv = false;
			int rowspan_bv = 1;
			for(int hour = hour_start; hour <= hour_end; hour++) {
				Console.WriteLine("hour: " + hour);

				if(hour != hour_start) {
					grid.AddLine(hour, Color.Gray);
					if(count_rows_for_bv)
						rowspan_bv++;
				}

				if(item.Start.Hour == hour) {
					rowspan_bv = grid.AddItemStart(bv, item, standard_rowheight);
					count_rows_for_bv = true;
				} else if(item.End.Hour == hour) {
					grid.AddItemEnd(bv, rowspan_bv, item, standard_rowheight);
					count_rows_for_bv = false;
				} else {
					grid.AddRow(standard_rowheight);
					if(count_rows_for_bv)
						rowspan_bv++;
				}
			}
		}

		public static void AddLine(this Grid grid, int column_span, Color color) {
			var row_def = new RowDefinition();
			grid.RowDefinitions.Add(row_def);
			BoxView bv = new BoxView { BackgroundColor = color };
			Grid.SetColumn(bv, 0);
			Grid.SetColumnSpan(bv, column_span);
			Grid.SetRow(bv, Grid.GetRow(row_def));
		}

		private static int AddItemStart(this Grid grid, BoxView bv, MyCalendarItem2 item, double standard_rowheight) {
			double new_rowheight1 = standard_rowheight * item.Start.Minute / 60;
			int count = 0;
			if (new_rowheight1 > 0) {
				double new_rowheight2 = standard_rowheight - new_rowheight1;
				AddRow(grid, new_rowheight1);
				count++;
			}
			RowDefinition rd = new RowDefinition { Height = new_rowheight1 };
			AddRow(grid, rd);
			Grid.SetRow(bv, Grid.GetRow(rd));
			count++;
			
			return count;
		}

		private static void AddItemEnd(this Grid grid, BoxView bv, int rowspan_bv, MyCalendarItem2 item, double standard_rowheight) {
			double new_rowheight1 = 1 + (standard_rowheight - 1) * item.End.Minute / 59;
			double new_rowheight2 = standard_rowheight - new_rowheight1;
			AddRow(grid, new_rowheight1);
			AddRow(grid, new_rowheight2);
			Grid.SetRowSpan(bv, rowspan_bv + 1);
		}

		public static void AddRow(this Grid grid, double height) {
			grid.RowDefinitions.Add(new RowDefinition { Height = height });
		}
		public static void AddRow(this Grid grid, RowDefinition row) {
			grid.RowDefinitions.Add(row);
		}

	}

	public class MyCalendarItem2 {
		private DateTime start;
		private DateTime end;
		private string content;

		public MyCalendarItem2(DateTime start, DateTime end, string subject, string teacher) {
			this.start = start;
			this.end = end;
			this.content = " " + subject + "\r\n " + teacher;
		}

		public DateTime Start {
			get {
				return start;
			}
		}
		public DateTime End {
			get {
				return end;
			}
		}

		public string Content {
			get {
				return content;
			}
		}
	}

	//class MyCalendar {
	//	private void SetupDayGrid(Grid grid) {

	//	}
	//	private void FillInDayGrid(Grid grid, List<IMyCalendarItem> items) {

	//	}

	//	// setup a day (with no overlapping items)
	//	public static void SetupDayCalendarNoOverlappingItems(Grid grid, List<IMyCalendarItem> items) {

	//	}
	//}

	interface IMyCalendar {
		void Draw();
	}
	class MyCalendar : IMyCalendar {
		public MyCalendar() {

		}

		public void Draw() {
			throw new NotImplementedException();
		}
	}
	abstract class AMyCalendarDecorator : IMyCalendar {
		private IMyCalendar parent;

		public AMyCalendarDecorator(IMyCalendar parent) {
			this.parent = parent;
		}

		public void Draw() {
			parent.Draw();
		}
	}


	interface IMyCalendarItem {
		DateTime Start { get; }
		DateTime End { get; }
		string Content { get; }
	}

	class SubjectCalendarItem : IMyCalendarItem {
		private DateTime start;
		private DateTime end;
		private string content;

		public SubjectCalendarItem(DateTime start, DateTime end, string subject, string teacher) {
			this.start = start;
			this.end = end;
			this.content = subject + "\r\n" + teacher;
		}

		public DateTime Start {
			get {
				return start;
			}
		}
		public DateTime End {
			get {
				return end;
			}
		}

		public string Content {
			get {
				return content;
			}
		}
	}
}
