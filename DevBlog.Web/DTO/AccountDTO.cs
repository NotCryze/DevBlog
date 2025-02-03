namespace DevBlog.Web.DTO
{
    public class AccountDTO(Guid id, string firstName, string lastName, string email, bool isAdmin)
    {
        public Guid Id { get; set; } = id;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string Email { get; set; } = email;
        public bool IsAdmin { get; set; } = isAdmin;
    }
}
