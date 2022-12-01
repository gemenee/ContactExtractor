using System.Collections.Generic;

namespace PersonContactExtractor.Persistance.Entities;

public class ResultEntity : BaseEntity
{
    public DocumentEntity Document { get; set; }
    public List<PersonContacts> Persons { get; set; }
}