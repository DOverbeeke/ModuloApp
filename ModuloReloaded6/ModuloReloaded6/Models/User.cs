using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloReloaded6.Models {
	public class User2 {
		public string Id { get; set; }
		public string FirstName { get; set; }
		public List<char> FirstLettersOfName { get; set; }
		public string LastName { get; set; }
		public string Class { get; set; }
		public bool IsStudent { get; set; }
	}
}
