using System.Collections.Generic;

namespace PersonContactExtractor.Persistance.Entities;

public class ResultEntity
{
    public DocumentEntity Document { get; set; }
    public List<Person> Persons { get; set; }
}

public class ResultPersonContacts
{
    public int PersonId { get; set; }
    public int ResultEntityId { get; set; }
}