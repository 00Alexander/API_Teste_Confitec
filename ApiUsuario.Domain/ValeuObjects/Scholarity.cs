using System;
using System.Collections.Generic;
using System.Text;

namespace ApiUsuario.Domain.ValeuObjects
{
    public readonly struct Scholarity
    {
        private readonly string _text;

        public Scholarity(string scholarity)
        {
            if (scholarity == "INFANTIL" || scholarity == "FUNDAMENTAL" || scholarity == "MEDIO" || scholarity == "SUPERIOR")
            {
                this._text = scholarity;
            }
            else
            {
                throw new Exception("Erro, escolaridade inválida.");
            }


        }

        public override bool Equals(object obj) => obj is Scholarity o && this.Equals(o);

        public bool Equals(Scholarity other) => this._text == other._text;

        public override int GetHashCode() => HashCode.Combine(this._text);
        public static bool operator ==(Scholarity left, Scholarity right) => left.Equals(right);
        public static implicit operator Scholarity(string text) => new Scholarity(text);
        public static implicit operator string(Scholarity obj) => obj._text;
        public static bool operator !=(Scholarity left, Scholarity right) => !(left == right);

        public override string ToString() => this._text;

    }
}
