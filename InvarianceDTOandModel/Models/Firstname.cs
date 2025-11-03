using System;
using System.Text.RegularExpressions;

namespace ValidateTheNameModelBinding.Models
{
    public class Firstname
    {
        public string Value { get; }

        public Firstname(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Firstname cannot be empty.");

            if (value.Length < 2 || value.Length > 20)
                throw new ArgumentException("Firstname must be between 2 and 20 characters.");

            if (!Regex.IsMatch(value, @"^[A-Za-zÆØÅæøå]+$"))
                throw new ArgumentException("Firstname must contain only letters.");

            Value = value.Trim();
        }

        public override string ToString() => Value;
    }
}
