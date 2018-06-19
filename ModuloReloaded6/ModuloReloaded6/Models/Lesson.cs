using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloReloaded6.Models {
	public class Lesson {
		public string Id { get; set; }
		public Subject Subject { get; set; }
		[Newtonsoft.Json.JsonProperty("begin_time")]
		public DateTime StartDateTime { get; set; }
		[Newtonsoft.Json.JsonProperty("end_time")]
		public DateTime EndDateTime { get; set; }
		public RoomTestObject Room { get; set; }
		public Teacher Teacher { get; set; }
	}
}


