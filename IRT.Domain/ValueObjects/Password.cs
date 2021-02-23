using IRT.Domain.Extensions;
using System;

namespace IRT.Domain.ValueObjects
{
    public readonly struct Password
    {
        private readonly string _password;
        public Password(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Password is required!");
            _password = password.ToHashMD5();
        }

        public override bool Equals(object obj) => obj is Password passwordObj ? this.Equals(passwordObj) : false;

        public static implicit operator Password(string password) => new Password(password);

        public static implicit operator string(Password password) => password._password;
        public static bool operator ==(Password left, Password right) => left.Equals(right);
        public static bool operator !=(Password left, Password right) => !(left == right);
        public bool Equals(Password other) => _password == other._password;
        public override string ToString() => _password;
        public override int GetHashCode() => _password.GetHashCode(StringComparison.OrdinalIgnoreCase);

    }
}
