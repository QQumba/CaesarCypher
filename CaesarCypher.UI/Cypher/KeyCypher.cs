using System;
using System.Text;

namespace CaesarCypher.UI.Cypher
{
    public class KeyCypher : ICypher
    {
        private readonly Alphabet _alphabet;

        public KeyCypher(int key)
        {
            _alphabet = new Alphabet(key);
        }

        public string Encrypt(string text)
        {
            var sb = new StringBuilder();
            foreach (var c in text)
            {
                sb.Append(_alphabet.Contains(c) ? Encrypt(c) : c);
            }

            return sb.ToString();
        }

        public string Decrypt(string text)
        {
            var sb = new StringBuilder();
            foreach (var c in text)
            {
                sb.Append(_alphabet.Contains(c) ? Decrypt(c) : c);
            }

            return sb.ToString();
        }

        private char Encrypt(char c)
        {
            var isUpper = char.IsUpper(c);
            
            var index = Array.IndexOf(_alphabet.Normal, c.ToString().ToLower()[0]);
            var clampedIndex = _alphabet.ClampIndex(index);
            var encryptedChar = _alphabet.Encrypted[clampedIndex];

            return isUpper ? encryptedChar.ToString().ToUpper()[0] : encryptedChar;
        }

        private char Decrypt(char c)
        {
            var isUpper = char.IsUpper(c);
            
            var index = Array.IndexOf(_alphabet.Encrypted, c.ToString().ToLower()[0]);
            var clampedIndex = _alphabet.ClampIndex(index);
            var encryptedChar = _alphabet.Normal[clampedIndex];

            return isUpper ? encryptedChar.ToString().ToUpper()[0] : encryptedChar;
        }
    }
}