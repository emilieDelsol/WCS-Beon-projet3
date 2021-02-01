using BeOnos;
using NUnit.Framework;
using System;

namespace BeOnosTest
{
    public class UserTest
    {
        [Test]
        public void TestCheckPassword()
        {
            UserBeOnos user = new UserBeOnos
            {
                Password = "test"
            };

            Boolean passwordsMatch = user.CheckPassword("test");

            Assert.True(passwordsMatch);
        }
    }
}