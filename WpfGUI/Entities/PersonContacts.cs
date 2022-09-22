using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonContactExtractor.Entities
{
	public class PersonContacts
	{
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string? LastName { get; set; }
		public Organization? Organization { get; set; }
		public string? Phone { get; set; }
		public string? Email { get; set; }
	}
}