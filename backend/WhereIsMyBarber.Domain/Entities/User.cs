using WhereIsMyBarber.Domain.Enum;

namespace WhereIsMyBarber.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string HashedPassword { get; set; } = "";
        public string Phone { get; set; } = "";
        public UserType Type { get; set; }
    }
}