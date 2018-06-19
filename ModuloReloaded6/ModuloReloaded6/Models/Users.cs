using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloReloaded6.Models {
	public class User {
		public string Id { get; set; }
		public string StudentNumber { get; set; }
		public string FirstName { get; set; }
		public char[] Initials { get; set; }
		public string LastName { get; set; }
		public string Class { get; set; }
		public string Code { get; set; }
		public bool IsStudent { get; set; }
	}

	//public class StudentUser : IUser {
	//	public string Id { get; set; }
	//	public string StudentNumber { get; set; }
	//	public string FirstName { get; set; }
	//	public char[] Initials { get; set; }
	//	public string LastName { get; set; }
	//	public string Class { get; set; }
	//	public bool IsStudent { get; set; }
	//}

	//public class TeacherUser : IUser {
	//	public string Id { get; set; }
	//	public string Code { get; set; }
	//	public bool IsStudent { get; set; }
	//}
}
