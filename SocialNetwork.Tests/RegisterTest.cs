using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private UserService userService;

        [SetUp]
        public void Setup()
        {
            userService = new UserService(); 
        }

        [Test]
        public void Register_WhenPasswordTooShort_ThrowsArgumentNullException()
        {
           
            var userRegistrationData = new UserRegistrationData
            {
                FirstName = "Тест",
                LastName = "Меньше",
                Password = "1234567", // меньше 8 символов
                Email = "тестменьше@gmail.com"
            };

            Assert.Throws<ArgumentNullException>(() => userService.Register(userRegistrationData));
        }

        [Test]
        public void Register_WhenPasswordLongEnough_DoesNotThrow()
        {
           
            var userRegistrationData = new UserRegistrationData
            {
                FirstName = "Тест",
                LastName = "Ровно",
                Password = "12345678", // ровно 8 символов
                Email = "тестровно@gmail.com"
            };


            Assert.DoesNotThrow(() => userService.Register(userRegistrationData));


        }

        [Test]
        public void Register_WhenPasswordBigEnough_DoesNotThrow()
        {

            var userRegistrationData = new UserRegistrationData
            {
                FirstName = "Тест",
                LastName = "Больше",
                Password = "1234567812", // больше 8 символов
                Email = "тестбольше@gmail.com"
            };


            Assert.DoesNotThrow(() => userService.Register(userRegistrationData));


        }
    }
}