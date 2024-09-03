using DevBlog.Domain.Models;

namespace DevBlog.UnitTest
{
    public class AccountModelTest
    {
        [Fact(DisplayName = "Create Account")]
        public void Create()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";
            string email = "johndoe@example.com";
            string password = "P@ssw0rd";
            string expectedFullName = "John Doe";

            // Act
            Account account = new Account(firstName, lastName, email, password);

            // Assert
            Assert.Equal(firstName, account.FirstName);
            Assert.Equal(lastName, account.LastName);
            Assert.Equal(expectedFullName, account.FullName);
            Assert.Equal(email, account.Email);
            Assert.Equal(password, account.Password);
            Assert.False(account.IsAdmin);
        }

        [Fact(DisplayName = "Create Admin Account")]
        public void CreateAdmin()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";
            string email = "johndoe@example.com";
            string password = "P@ssw0rd";
            bool isAdmin = true;
            string expectedFullName = "John Doe";

            // Act
            Account account = new Account(firstName, lastName, email, password, isAdmin);

            // Assert
            Assert.Equal(firstName, account.FirstName);
            Assert.Equal(lastName, account.LastName);
            Assert.Equal(expectedFullName, account.FullName);
            Assert.Equal(email, account.Email);
            Assert.Equal(password, account.Password);
            Assert.True(account.IsAdmin);
        }
    }
}