using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonContactExtractor.Entities
{
	public class Organization
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Subdivision { get; set; }
	}
}