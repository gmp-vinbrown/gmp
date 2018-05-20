using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public int SchoolLocationId { get; set; }
        public int RoleId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string Notes { get; set; }
        public DateTime? Created { get; set; }
        public bool Deleted { get; set; }

        public Role Role { get; set; }
        public SchoolLocation SchoolLocation { get; set; }
    }
}
