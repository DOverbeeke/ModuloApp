using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloReloaded6.Models {
	class APIResultToModelConvertor {
		public static List<Reservation> ConvertToReservations(string APIResult) {
			return new List<Reservation>() {
			};
		}
		public static List<Lesson> ConvertToLessons(string APIResult) {
			return new List<Lesson>() {
			};
		}
		//public static List<Recommendation> ConvertToRecommendations(string APIResult) {
		//	return new List<Recommendation>() {
		//	};
		//}
		public static List<Reservation> ConvertToNotices(string APIResult) {
			return new List<Reservation>() {
			};
		}
		public static StudentUserInfo ConvertToStudentUserInfo(string APIResult) {
			return new StudentUserInfo { };
	}
		public static TeacherUserInfo ConvertToTeacherUserInfo(string APIResult) {
			return new TeacherUserInfo { };
		}
	}


	class MockAPIResultToModelConvertor {
		public static List<Reservation> ConvertToReservations(string APIResult) {
			return new List<Reservation>() {
				new Reservation { UserID = "CurrentUser", RoomID = "WD1.105", StartDateTime = DateTime.Now.AddDays(-3), EndDateTime = DateTime.Now.AddDays(-3).AddHours(4), ResStatus = Reservation.Status.Resolved },
				new Reservation { UserID = "CurrentUser", RoomID = "H5.012", StartDateTime = DateTime.Now.AddDays(-1), EndDateTime = DateTime.Now.AddDays(-1).AddHours(4), ResStatus = Reservation.Status.Resolved },
				new Reservation { UserID = "CurrentUser", RoomID = "H3.006", StartDateTime = DateTime.Now.AddDays(0), EndDateTime = DateTime.Now.AddDays(0).AddHours(4), ResStatus = Reservation.Status.CanceledByOwner },
				new Reservation { UserID = "CurrentUser", RoomID = "H2.103", StartDateTime = DateTime.Now.AddDays(2), EndDateTime = DateTime.Now.AddDays(2).AddHours(4), ResStatus = Reservation.Status.CanceledByTeacher },
				new Reservation { UserID = "CurrentUser", RoomID = "WD1.106", StartDateTime = DateTime.Now.AddDays(2), EndDateTime = DateTime.Now.AddDays(2).AddHours(4), ResStatus = Reservation.Status.DueTime },
				new Reservation { UserID = "CurrentUser", RoomID = "WD1.005", StartDateTime = DateTime.Now.AddDays(3), EndDateTime = DateTime.Now.AddDays(3).AddHours(4), ResStatus = Reservation.Status.DueTime },
			};
		}
		public static List<Lesson> ConvertToLessons(string APIResult) {
			return new List<Lesson>() {
				//new Lesson { Subject = "Development", StartDateTime = DateTime.Now.AddDays(0), EndDateTime = DateTime.Now.AddDays(0).AddHours(2.5), RoomName = "H5.315", Teacher = "Italy1" },
				//new Lesson { Subject = "Analyse", StartDateTime = DateTime.Now.AddDays(0), EndDateTime = DateTime.Now.AddDays(0).AddHours(1.5), RoomName = "H4.315", Teacher = "Italy2" },
				//new Lesson { Subject = "Skills", StartDateTime = DateTime.Now.AddDays(1), EndDateTime = DateTime.Now.AddDays(1).AddHours(1), RoomName = "WD2.315", Teacher = "Adam Perzohn" },
				//new Lesson { Subject = "SLC", StartDateTime = DateTime.Now.AddDays(1), EndDateTime = DateTime.Now.AddDays(1).AddHours(1.5), RoomName = "WD3.315", Teacher = "Manusje van Alles" },
				//new Lesson { Subject = "Ontwerpen", StartDateTime = DateTime.Now.AddDays(2), EndDateTime = DateTime.Now.AddDays(2).AddHours(2.5), RoomName = "PZ.315", Teacher = "Ida Vrijlant" },
				//new Lesson { Subject = "Business Management", StartDateTime = DateTime.Now.AddDays(2).AddHours(3), EndDateTime = DateTime.Now.AddDays(2).AddHours(4.5), RoomName = "GD.315", Teacher = "Jan Kerel" },
				//new Lesson { Subject = "Persoonlijke Behandeling", StartDateTime = DateTime.Now.AddDays(4), EndDateTime = DateTime.Now.AddDays(4).AddHours(4.5), RoomName = "ZMA5.315", Teacher = "Anna F. Waterbed" },
			};
		}
		//public static List<Recommendation> ConvertToRecommendations(string APIResult) {
		//	return new List<Recommendation>() {
		//		new Recommendation { Room = "H.04.432", BeginTime = DateTime.Now.AddHours(0), EndTime = DateTime.Now.AddHours(4) },
		//		new Recommendation { Room = "H.04.333", BeginTime = DateTime.Now.AddHours(0), EndTime = DateTime.Now.AddHours(3.3) },
		//		new Recommendation { Room = "H.04.334", BeginTime = DateTime.Now.AddHours(0), EndTime = DateTime.Now.AddHours(3.1) },
		//		new Recommendation { Room = "WD.01.201", BeginTime = DateTime.Now.AddHours(0), EndTime = DateTime.Now.AddHours(2) },
		//		new Recommendation { Room = "WD.01.107", BeginTime = DateTime.Now.AddHours(1), EndTime = DateTime.Now.AddHours(4) },
		//		new Recommendation { Room = "WD.03.222", BeginTime = DateTime.Now.AddHours(2), EndTime = DateTime.Now.AddHours(4) },
		//		new Recommendation { Room = "H.01.115", BeginTime = DateTime.Now.AddHours(2.5), EndTime = DateTime.Now.AddHours(3.5) },
		//		new Recommendation { Room = "WD.01.107", BeginTime = DateTime.Now.AddHours(2), EndTime = DateTime.Now.AddHours(3) },
		//		new Recommendation { Room = "H.04.337", BeginTime = DateTime.Now.AddHours(3), EndTime = DateTime.Now.AddDays(1).AddHours(2) },
		//		new Recommendation { Room = "H.04.337", BeginTime = DateTime.Now.AddHours(3), EndTime = DateTime.Now.AddHours(2) },
		//		new Recommendation { Room = "H.04.337", BeginTime = DateTime.Now.AddHours(3), EndTime = DateTime.Now.AddHours(2) },
		//		new Recommendation { Room = "H.04.337", BeginTime = DateTime.Now.AddHours(3), EndTime = DateTime.Now.AddHours(2) },
		//		new Recommendation { Room = "H.04.337", BeginTime = DateTime.Now.AddHours(3), EndTime = DateTime.Now.AddHours(2) },
		//		new Recommendation { Room = "H.04.337", BeginTime = DateTime.Now.AddHours(3), EndTime = DateTime.Now.AddHours(2) },
		//		new Recommendation { Room = "H.04.337", BeginTime = DateTime.Now.AddHours(3), EndTime = DateTime.Now.AddHours(2) },
		//		new Recommendation { Room = "H.04.337", BeginTime = DateTime.Now.AddHours(3), EndTime = DateTime.Now.AddHours(2) },
		//		new Recommendation { Room = "H.04.337", BeginTime = DateTime.Now.AddHours(3), EndTime = DateTime.Now.AddHours(2) },
		//		new Recommendation { Room = "H.04.337", BeginTime = DateTime.Now.AddHours(3), EndTime = DateTime.Now.AddHours(2) },
		//		new Recommendation { Room = "H.04.337", BeginTime = DateTime.Now.AddHours(3), EndTime = DateTime.Now.AddHours(2) },
		//	};
		//}
		public static List<Notice> ConvertToNotices(string APIResult) {
			return new List<Notice>() {
				new Notice { IssuedDateTime = DateTime.Now.AddDays(-1), Title = "1 day ago", Message = "1 day ago", State = Notice.Status.Notified },
				new Notice { IssuedDateTime = DateTime.Now.AddDays(-2), Title = "2 day ago", Message = "2 days ago", State = Notice.Status.Notified },
				new Notice { IssuedDateTime = DateTime.Now.AddDays(-3), Title = "Reservation Cancel?", Message = "Your reservation starts in half an hour.\r\n\r\nWould you like to cancel it?", State = Notice.Status.AnswerRequired },
				new Notice { IssuedDateTime = DateTime.Now.AddDays(-4), Title = "4 day ago", Message = "4 days ago", State = Notice.Status.Notified },
				new Notice { IssuedDateTime = DateTime.Now.AddDays(-5), Title = "5 day ago", Message = "5 days ago", State = Notice.Status.Notified },
				new Notice { IssuedDateTime = DateTime.Now.AddDays(-6), Title = "Reservation Cancel?", Message = "Your reservation starts in half an hour.\r\n\r\nWould you like to cancel it?", State = Notice.Status.Answered },
				new Notice { IssuedDateTime = DateTime.Now.AddDays(-7), Title = "7 day ago", Message = "7 days ago", State = Notice.Status.Notified },
				new Notice { IssuedDateTime = DateTime.Now.AddDays(-8), Title = "Welcome back!", Message = "We're pleased to announce the school has been finished! You're welcome to resume your courses!", State = Notice.Status.Notified },
				new Notice { IssuedDateTime = DateTime.Now.AddDays(-9), Title = "Building delay", Message = "Unfortunately, rebuilding the school takes a day longer, so " + DateTime.Now.AddDays(-8).ToString("dd-MM-yyyy") + " there won't be any classes.", State = Notice.Status.Notified },
				new Notice { IssuedDateTime = DateTime.Now.AddDays(-10), Title = "Burn", Message = "The school burned down. We'll be rebulding this holiday.", State = Notice.Status.Notified },
			};

		}
	}
}
