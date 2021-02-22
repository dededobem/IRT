using System;
using System.Collections.Generic;
using System.Text;

namespace IRT.Domain.ValueObjects
{
    public readonly struct Email
    {
        private readonly string _email;
        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("E-mail is required!");
                _email = email;
        }

        public override bool Equals(object obj) => obj is Email emailObj ? this.Equals(emailObj) : false;

        public static implicit operator Email(string email) => new Email(email);

        public static implicit operator string(Email email) => email._email;
        public static bool operator ==(Email left, Email right) => left.Equals(right);
        public static bool operator !=(Email left, Email right) => !(left == right);
        public bool Equals(Email other) => _email == other._email;
        public override string ToString() => _email;
        public override int GetHashCode() => _email.GetHashCode(StringComparison.OrdinalIgnoreCase);
    }
}
