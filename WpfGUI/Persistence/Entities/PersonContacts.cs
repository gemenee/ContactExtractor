namespace PersonContactExtractor.Persistance.Entities;

public class PersonContacts : BaseEntity
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public Organization Organization { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public ResultEntity ResultEntity { get; set; }
}