namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        private string fullName;

        public UserViewModel(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }

        public UserViewModel(int id, string fullName, string email)
        {
            Id = id;
            UserName = fullName;
            Email = email;
        }

        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
