using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloReloaded6.Models {
	public class Recommendation {
		[Newtonsoft.Json.JsonProperty("id")]
		public int RoomId { get; set; }
		public string Name { get; set; }
		public int Size { get; set; }
		[Newtonsoft.Json.JsonProperty("begin_time")]
		public DateTime BeginTime { get; set; }
		[Newtonsoft.Json.JsonProperty("end_time")]
		public DateTime EndTime { get; set; }
	}
}
