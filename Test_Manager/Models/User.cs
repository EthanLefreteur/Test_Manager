using Microsoft.AspNetCore.Identity;

namespace Test_Manager.Models
{
    public class User : IdentityUser
    {
        public string fname { get; set; }
        public string lname { get; set; }
    }
}
