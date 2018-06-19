using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloReloaded6.Models {
	class TestRecommendation {
		public string Name { get; set; }
		public string RaccaCauwa { get; set; }

		public TestRecommendation(string name, string racca_cauwa) {
			Name = name;
			RaccaCauwa = racca_cauwa;
		}

		public override string ToString() {
			return Name;
		}
	}
}
