using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloReloaded6.Models {
	public class Notice {
		public enum Status { Notified, AnswerRequired, Answered };

		public DateTime IssuedDateTime;
		public string Title;
		public string Message;
		public Status State;
	}
}
