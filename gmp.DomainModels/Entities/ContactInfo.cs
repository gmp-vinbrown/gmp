
namespace gmp.DomainModels.Entities
{
    public partial class ContactInfo : AuditableEntity
    {
        public int ContactInfoId { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }
    }
}
