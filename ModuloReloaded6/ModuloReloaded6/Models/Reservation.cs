using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace ModuloReloaded6.Models {
	public class Reservation {
		public enum Status { CanceledByTeacher, CanceledByOwner, DueTime, Resolved };

		public string UserID { get; set; }
		public string RoomID { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public Status ResStatus { get; set; }
		//public List<User> Authorized { get; set; }
		//public List<User> Unauthorized { get; set; }
	}

	public class ReservationTestObject {
		public string Id { get; set; }
		[Newtonsoft.Json.JsonProperty("user_id")]
		public string UserID { get; set; }
		[Newtonsoft.Json.JsonProperty("room_id")]
		public string RoomId { get; set; }
		[Newtonsoft.Json.JsonProperty("begin_time")]
		public DateTime StartDateTime { get; set; }
		[Newtonsoft.Json.JsonProperty("end_time")]
		public DateTime EndDateTime { get; set; }
		//[Newtonsoft.Json.JsonProperty("room")]
		public RoomTestObject Room { get; set; }
		[Newtonsoft.Json.JsonProperty("people_amount")]
		public int AmountOfPeople { get; set; }
	}

	public class RoomTestObject {
		public string Name { get; set; }
		public string Size { get; set; }
	}
}
