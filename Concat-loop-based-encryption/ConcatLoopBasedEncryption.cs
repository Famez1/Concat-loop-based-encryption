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
            for (int i = 0; i < n; i++)
            {
                var oddChars = new StringBuilder();
                var evenChars = new StringBuilder();

                for (int j = 0; j < text.Length; j++)
                {
                    if (j % 2 == 0)
                        evenChars.Append(text[j]);
                    else
                        oddChars.Append(text[j]);
                }

                text = oddChars.ToString() + evenChars.ToString();
            }

            return text;
        }

        public string Decrypt(string text, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int halfLength = text.Length / 2;
                int oddLength = (text.Length % 2 == 0) ? halfLength : halfLength + 1;

                var oddChars = text.Substring(0, halfLength);
                var evenChars = text.Substring(halfLength);

                var decrypted = new StringBuilder();

                for (int j = 0; j < oddLength; j++)
                {
                    if (j < evenChars.Length)
                        decrypted.Append(evenChars[j]);
                    if (j < oddChars.Length)
                        decrypted.Append(oddChars[j]);
                }

                text = decrypted.ToString();
            }

            return text;
        }
    }
}

