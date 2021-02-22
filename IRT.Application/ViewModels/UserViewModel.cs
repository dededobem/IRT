using IRT.Domain.Entities;

namespace IRT.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel() { }
        public UserViewModel(User user) {
            Name = user.Name;
            Login = user.Login;
            Password = user.Password;
            Email = user.Email;
        }
                
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
