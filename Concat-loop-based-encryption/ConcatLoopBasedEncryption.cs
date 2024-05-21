using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concat_loop_based_encryption
{
    internal class ConcatLoopBasedEncryption
    {
        public string Encrypt(string text, int n)
        {
            char[] chars = text.ToCharArray();

            for (int i = 0; i < n; i++)
            {
                char[] temp = new char[chars.Length];

                for (int j = 0; j < chars.Length; j++)
                {
                    temp[j] = chars[(j + chars.Length / 2) % chars.Length];
                }
                chars = temp;
            }
            return new string(chars);
        }

        public string Decrypt(string text, int n)
        {
            char[] chars = text.ToCharArray();

            for (int i = 0; i < n; i++)
            {
                char[] temp = new char[chars.Length];

                for (int j = 0; j < chars.Length; j++)
                {
                    temp[(j + chars.Length / 2) % chars.Length] = chars[j];
                }
                chars = temp;
            }

            return new string(chars);
        }
    }
}

