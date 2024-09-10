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
                FirstName = "����",
                LastName = "������",
                Password = "1234567", // ������ 8 ��������
                Email = "����������@gmail.com"
            };

            Assert.Throws<ArgumentNullException>(() => userService.Register(userRegistrationData));
        }

        [Test]
        public void Register_WhenPasswordLongEnough_DoesNotThrow()
        {
           
            var userRegistrationData = new UserRegistrationData
            {
                FirstName = "����",
                LastName = "�����",
                Password = "12345678", // ����� 8 ��������
                Email = "���������@gmail.com"
            };


            Assert.DoesNotThrow(() => userService.Register(userRegistrationData));


        }

        [Test]
        public void Register_WhenPasswordBigEnough_DoesNotThrow()
        {

            var userRegistrationData = new UserRegistrationData
            {
                FirstName = "����",
                LastName = "������",
                Password = "1234567812", // ������ 8 ��������
                Email = "����������@gmail.com"
            };


            Assert.DoesNotThrow(() => userService.Register(userRegistrationData));


        }
    }
}