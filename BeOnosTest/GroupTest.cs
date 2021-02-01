using BeOnos;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BeOnosTest
{
    public class GroupTest
    {
        [Test]
        public void TestPermission()
        {
            Group group = new Group
            {
                Roles = new List<Role> {
                    new Role {
                        Name = "Admin",
                        Permissions = new List<Permission> { new Permission { Name = "test" } }
                    }
                }
            };

            Boolean groupAllowed = group.IsAllowedTo("test");

            Assert.True(groupAllowed);
        }
    }
}
