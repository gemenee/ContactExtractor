namespace PersonContactExtractor.Persistance;

public class PersonContacts : BaseEntity
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? Position { get; set; }
    public OrganizationEntity? Organization { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public virtual ResultEntity ResultEntity { get; set; }
}