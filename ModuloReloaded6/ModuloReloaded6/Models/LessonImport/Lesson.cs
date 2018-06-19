using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloReloaded6.Models.LessonImport {
	public class Lesson {
		public string Class { get; set; } //careful: can contain multiple classes in one string
		[Newtonsoft.Json.JsonProperty("Date")]
		public DateTime Day { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public string Text { get; set; }
		public string Subject { get; set; }
		public string Teacher { get; set; }
		public Room Room { get; set; }
	}
}
