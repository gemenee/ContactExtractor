﻿using System.Collections.Generic;

namespace PersonContactExtractor.Persistance;

public class ResultEntity : BaseEntity
{
    public int DocumentId { get; set; }
    public DocumentEntity Document { get; set; }
    public virtual List<PersonContacts> Persons { get; set; }
}