using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

ConcatLoopBasedEncryption concat = new();

Console.WriteLine(concat.Encrypt("012341", 1));
Console.WriteLine(concat.Decrypt("341012", 2));

class ConcatLoopBasedEncryption
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


