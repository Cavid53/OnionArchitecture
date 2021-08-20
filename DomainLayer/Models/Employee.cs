using DomainLayer.Common;

namespace DomainLayer.Models
{
    public class Employee : AuditingEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    }
}
