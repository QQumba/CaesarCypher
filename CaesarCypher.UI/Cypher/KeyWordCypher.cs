using System;
using System.Text;

namespace CaesarCypher.UI.Cypher
{
    public class KeyWordCypher : ICypher
    {
        private readonly Alphabet[] _alphabets;
        private int _currentAlphabet;

        public KeyWordCypher(string keyWord)
        {
            _alphabets = new Alphabet[keyWord.Length];
            _currentAlphabet = -1;

            for (var i = 0; i < keyWord.Length; i++)
            {
                _alphabets[i] = new Alphabet(keyWord[i]);

                foreach (var e in _alphabets[i].Encrypted)
                {
                    Console.Write(e);
                }

                Console.WriteLine();
            }
        }

        public Alphabet Current => _currentAlphabet == -1 ? Next() : _alphabets[_currentAlphabet];

        public string Encrypt(string text)
        {
            var sb = new StringBuilder();
            foreach (var c in text)
            {
                if (Current.Contains(c))
                {
                    sb.Append(Encrypt(c));
                    Next();
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public string Decrypt(string text)
        {
            var sb = new StringBuilder();
            foreach (var c in text)
            {
                if (Current.Contains(c))
                {
                    sb.Append(Decrypt(c));
                    Next();
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        private char Encrypt(char c)
        {
            var isUpper = char.IsUpper(c);

            var index = Array.IndexOf(Current.Normal, c.ToString().ToLower()[0]);
            var clampedIndex = Current.ClampIndex(index);
            var encryptedChar = Current.Encrypted[clampedIndex];

            return isUpper ? encryptedChar.ToString().ToUpper()[0] : encryptedChar;
        }

        private char Decrypt(char c)
        {
            var isUpper = char.IsUpper(c);

            var index = Array.IndexOf(Current.Encrypted, c.ToString().ToLower()[0]);
            var clampedIndex = Current.ClampIndex(index);
            var encryptedChar = Current.Normal[clampedIndex];

            return isUpper ? encryptedChar.ToString().ToUpper()[0] : encryptedChar;
        }

        private Alphabet Next()
        {
            _currentAlphabet++;
            if (_currentAlphabet == _alphabets.Length)
            {
                _currentAlphabet = 0;
            }

            return _alphabets[_currentAlphabet];
        }
    }
}