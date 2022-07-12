using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher.Algorithm
{
    class Caesar
    {
        int _numberInAlphabet;
        string _alphabet;
        public Caesar(string alphabet)
        {
            _alphabet = alphabet;
            _numberInAlphabet = _alphabet.Length;
        }
        public string GetEncryptedMessage(string message, int bias)
        {
            string result = "";
            for (int i = 0; i < message.Length; i++)
            {
                char current = message[i];
                if(current == ' ')
                {
                    result += " ";
                    continue;
                }
                int position = _alphabet.IndexOf(current);
                if(position != -1)
                {
                    int d = position + bias;
                    if (d >= _numberInAlphabet) d = d - _numberInAlphabet;
                    result += _alphabet[d];
                }
            }
            return result;
        }
        public string GetDencryptedMessage(string message, int bias)
        {
            string result = "";
            for (int i = 0; i < message.Length; i++)
            {
                char current = message[i];
                if (current == ' ')
                {
                    result += " ";
                    continue;
                }
                int position = _alphabet.IndexOf(current);
                if (position != -1)
                {
                    int d = position - bias;
                    if (d <= 0) d = _numberInAlphabet + d;
                    result += _alphabet[d];
                }
            }
            return result;
        }
    }
}
