using System;
using System.Collections.Generic;
using System.Text;
namespace BeOnos
{

        public class User
        {
            public String Password { private get; set; }
            public String PasswordHash { get => BCrypt.Net.BCrypt.HashPassword(Password); }
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
