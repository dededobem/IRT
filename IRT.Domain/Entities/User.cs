using IRT.Domain.ValueObjects;
using System;

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
            Login = Login ?? throw new Exception("Login is required!");
        }
    }
}
