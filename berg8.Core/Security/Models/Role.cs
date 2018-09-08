using System.Collections.Generic;

namespace Berg8.Core.Security.Models
{
    public class Role
    {
        public Role() 
        {
            Users = new List<UserRole>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserRole> Users { get; private set; }
    }
}
