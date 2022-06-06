using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace ApiUsuario.Domain.ValeuObjects
{
   public readonly struct Email : IEquatable<Email>
    {
        private readonly string _text;

        public Email(string email)
        {
            Regex rgx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!rgx.IsMatch(email))
            {
                throw new ArgumentException("Por favor, informe um email válido.");
            }

            this._text = email;
        }

        public override bool Equals(object obj) => obj is Email o && this.Equals(o);

        public bool Equals(Email other) => this._text == other._text;

        public override int GetHashCode() => HashCode.Combine(this._text);
        public static bool operator ==(Email left, Email right) => left.Equals(right);
        public static implicit operator Email(string text) => new Email(text);
        public static implicit operator string(Email obj) => obj._text;
        public static bool operator !=(Email left, Email right) => !(left == right);

        public override string ToString() => this._text;


    }
}
