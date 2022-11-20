using System;

namespace PersonContactExtractor.Persistance.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDateTimeUtc { get; set; }
    }
}