using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

using Xamarin.Forms;
using System.Linq;

namespace ModuloReloaded6 {
	public class Utils {
		/// <summary>
		///  0	   1		 2			3			4			5			6
		/// "Mo", "Tu", "We", "Th", "Fr", "Sa", "Su"
		/// </summary>
		/// <returns></returns>
		public static string NumToDay(int day_of_week) {
			string[] days = new string[7] { "Mo", "Tu", "We", "Th", "Fr", "Sa", "Su" };
			return days[day_of_week];
		}

		public static string NumToMonth(int month_in_year) {
			string[] months = new string[12] { "jan", "feb", "mar", "apr", "may", "jun", "jly", "aug", "sep", "okt", "nov", "dec" };
			return months[month_in_year];
		}

		public static void AddLabelToGrid(Grid grid, Label label, int row, int column) {
			Grid.SetRow(label, row);
			Grid.SetColumn(label, column);
			grid.Children.Add(label);
		}

		public static void SetTextColorLabelsInGrid(Grid g, Color color) {
			g.Children
				.Where((c) => c.GetType() == typeof(Label))
				.ToList()
				.ForEach((child) => { var c = child as Label; c.TextColor = color; });
		}

		public static void AddToGrid(Grid grid, View item, int column, int row) {
			Grid.SetColumn(item, column);
			Grid.SetRow(item, row);
			grid.Children.Add(item);
		}
		public static void AddToGrid(Grid grid, View item, int column, int row, int column_span, int row_span) {
			Grid.SetColumn(item, column);
			Grid.SetRow(item, row);
			Grid.SetColumnSpan(item, column_span);
			Grid.SetRowSpan(item, row_span);
			grid.Children.Add(item);
		}

		public static DateTime GetMonday() {
			DateTime day = DateTime.Today;
			for(int i = 0; i < 7; i++) {
				if (day.AddDays(i).DayOfWeek == DayOfWeek.Monday) {
					return day.AddDays(i);
				}
			}
			return day;
		}
	}
}
