using Microsoft.AspNetCore.Identity;
using System;

namespace Vehicle.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }
        public Guid ImageId { get; set; }
        public int DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}
