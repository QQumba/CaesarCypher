using System;
using System.Linq;

namespace CaesarCypher.UI.Cypher
{
    public class Alphabet
    {
        private readonly char[] _normal;
        private readonly char[] _encrypted;

        public Alphabet(int key)
        {
            _normal = CreateAlphabet();
            _encrypted = new char[Length];
            Shift(key);
        }
        
        public Alphabet(char keyChar)
        {
            _normal = CreateAlphabet();
            _encrypted = new char[Length];
            ShiftToChar(keyChar);
        }

        public int Length => 33;
        public char[] Encrypted => _encrypted;
        public char[] Normal => _normal;

        public bool Contains(char c)
        {
            var lc = c.ToString().ToLower()[0];
            
            return lc >= 'а' && lc <= 'я' || lc == 'ё';
        }

        private char[] CreateAlphabet()
        {
            var al = new char [33];

            var c = 'а';
            for (int i = 0; i < al.Length; i++)
            {
                if (c == 'ж')
                {
                    al[i] = 'ё';
                    i++;
                }

                al[i] = c;
                c = (char) (c + 1);
            }

            return al;
        }

        private void Shift(int key)
        {
            char c = default;
            for (int i = 0; i < _encrypted.Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    if (_encrypted.Contains(_normal[j]) == false)
                    {
                        c = _normal[j];
                        break;
                    }
                }

                _encrypted[ClampIndex(i - key)] = c;
            }
        }

        private void ShiftToChar(char keyChar)
        {
            var index = Array.IndexOf(_normal, keyChar.ToString().ToLower()[0]);
            char c = default;
            for (int i = 0; i < _encrypted.Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    if (_encrypted.Contains(_normal[j]) == false)
                    {
                        c = _normal[j];
                        break;
                    }
                }

                _encrypted[ClampIndex(i - index)] = c;
            }
        }

        private int ClampIndex(int index)
        {
            if (index < 0)
            {
                return Length + index;
            }
            
            return index % Length;
        }
    }
}