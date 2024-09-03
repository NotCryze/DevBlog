using DevBlog.Domain.Models;

namespace DevBlog.UnitTest
{
    public class ModelTest
    {
        [Fact(DisplayName = "Create Account")]
        public void Create()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";
            string email = "johndoe@example.com";
            string password = "P@ssw0rd";

            // Act
            Account account = new Account(firstName, lastName, email, password);

            // Assert
            Assert.Equal(firstName, account.FirstName);
            Assert.Equal(lastName, account.LastName);
            Assert.Equal(firstName + " " + lastName, account.FullName);
            Assert.Equal(email, account.Email);
            Assert.Equal(password, account.Password);
            Assert.False(account.IsAdmin);
        }
    }
}