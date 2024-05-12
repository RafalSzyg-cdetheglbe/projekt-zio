using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Reflection.Metadata;
using WebApi.Models.DbEntities.AuditAndContext;
using WebApi.Models.DbEntities.UserEntities;
using WebApi.Models.DTO;
using WebApi.Services.Implementations;

namespace WebApiTests
{
    [TestClass]
    public class UserTests
    {
        private UserService GetUserServiceMockWithSampleData()
        {
            var users = new List<User>
            {
                new User { Id = 1,  Name = "admin1" , Login = "admin1", Password = "admin1", IsActive = true, UserType = UserType.Admin},
                new User { Id = 2,  Name = "admin2" , Login = "admin2", Password = "admin2", IsActive = true, UserType = UserType.Admin},
                new User { Id = 3,  Name = "admin3" , Login = "admin3", Password = "admin3", IsActive = true, UserType = UserType.Admin},
            };

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.AsQueryable().Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.AsQueryable().Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.AsQueryable().ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.AsQueryable().GetEnumerator());

            var mockContext = new Mock<MeteoContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            mockContext.Setup(m => m.Add(It.IsAny<User>()))
                .Callback<User>((entity) => users.Add(entity));
            mockContext.Setup(m => m.Remove(It.IsAny<User>()))
                .Callback<User>((entity) => users.Remove(entity));

            return new UserService(mockContext.Object);
        }

        [TestMethod]
        public void TestGetAllMethod()
        {
            var service = GetUserServiceMockWithSampleData();
            var users = service.GetUsers();

            Assert.AreEqual(3, users.Count);
            Assert.AreEqual("admin1", users[0].Name);
            Assert.AreEqual("admin3", users[2].Name);
        }

        [TestMethod]
        public void TestGetById()
        {
            var service = GetUserServiceMockWithSampleData();
            var user = service.GetUser(1);

            Assert.IsNotNull(user);
            Assert.AreEqual("admin1", user.Name);
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            var service = GetUserServiceMockWithSampleData();
            var isDeleted = service.DeleteUser(1);
            var users = service.GetUsers();

            Assert.IsTrue(isDeleted);
            Assert.IsNotNull(users);
            Assert.AreEqual(users.Count, 2);
        }

        [TestMethod]
        public void AddUserTest()
        {
            var service = GetUserServiceMockWithSampleData();
            var userDto = new UserDTO()
            {
                Id = 4,
                Name = "newUser",
                Login = "newUser",
                Password = "newUser",
                UserType = UserType.Guest,
                IsActive = true
            };

            var id = service.AddUser(userDto);
            var users = service.GetUsers();
            var user = service.GetUser(id);

            Assert.IsNotNull(user);
            Assert.AreEqual(id, 4);
            Assert.IsNotNull(users);
            Assert.AreEqual(users.Count, 4);
        }
    }
}
