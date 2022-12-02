using System;

namespace PersonContactExtractor.Persistance
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreationDateTimeUtc { get; set; }
	}
}