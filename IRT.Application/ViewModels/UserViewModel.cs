using IRT.Domain.Entities;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
