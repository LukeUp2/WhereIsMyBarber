
using WhereIsMyBarber.Communication.Enums;

namespace WhereIsMyBarber.Communication.Requests
{
    public class RequestRegisterUser
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Phone { get; set; } = "";
        public UserType Type { get; set; }
    }
}