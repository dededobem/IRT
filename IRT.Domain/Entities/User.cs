using IRT.Domain.ValueObjects;
using System;
using System.Net.Mail;

namespace IRT.Domain.Entities
{
    public class User : EntityBase
    {        
        public User(Guid id, string name, string login, Email email, string password) : base(id)
        {
            Name = name;
            Login = login;
            Email = email;
            Password = new Password(password);
            Validate();
        }

        protected User() { }

        public string Name { get; private set; }
        public string Login { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }

        private void Validate()
        {
            Name = Name.ToString() == "" ? throw new Exception("Name is required!") : Name;
            Login = Login == "" ? throw new Exception("Login is required!") : Login;
            Email = IsValidEmail(Email) ? Email : throw new Exception("Incorrect e-mail format!");
            Password = Password == "" ? throw new Exception("Password is required!") : Password;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
