using Siteware.Domain.Entities.Base;

namespace Siteware.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
