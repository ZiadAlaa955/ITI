using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmarking.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
