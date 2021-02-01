using BeOn.Models;
using BeOnos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeOnosTest
{
    
    public class UserCheckTestBeOn
    {
        [Test]
        public void IdentifierCheckTest()
        {
            User user = new User() { Name = "user", PasswordHash = "$2y$12$MwRSwqnurfY7yoMb5w2e9OZM00RrZPrL8lWBBV5F85Rys865iTt9u" };
            UserBeOnos userBeOnos = new UserBeOnos() { Identifier = user.Name, Password = user.PasswordHash };
            bool passwordIsValid = userBeOnos.CheckPassword("SCiygh");
            Assert.True(passwordIsValid);
            
        }

    }
}
