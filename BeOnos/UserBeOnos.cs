using System;

namespace BeOnos
{
    public class UserBeOnos
    {
        public String Password { private get=> Password; set { BCrypt.Net.BCrypt.HashPassword(Password); } }
        public String PasswordHash { get => (Password); }
        public String Identifier { get; set; }

        public Boolean CheckPassword(String password)
        {
            Boolean passwordsMatch = BCrypt.Net.BCrypt.Verify(password, PasswordHash);
            if (passwordsMatch)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
