using BeOnAuth;
using NUnit.Framework;
using System.Collections.Generic;

namespace BeOnAuthTest
{
    public class RoleTest
    {
        [Test]
        public void TestChildRole()
        {
            Role childRole = new Role(name: "Child", permission: new Permission { Name = "TestPermission" });
            
            Role parentRole = new Role(name: "Parent", child: childRole);

            Assert.True(parentRole.IsAllowedTo("TestPermission"));
        }

        [Test]
        public void TestChildrenRole()
        {
            List<Role> childRoles = new List<Role> { new Role(name: "Child1"),
                                                     new Role(name: "Child2", child: 
                                                        new Role("Child3", permission: new Permission { Name = "TestPermission" })
                                                     ) };
            
            Role parentRole = new Role(name: "Admin", children: childRoles);

            Assert.True(parentRole.IsAllowedTo("TestPermission"));
            Assert.False(parentRole.IsAllowedTo("FuckYou"));
        }
     }
}
