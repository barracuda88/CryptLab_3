using System;
using System.IO;
using System.Text;

namespace CryptLab3
{
    internal class Program
    {
        

        private static void IncreaseN(byte[] N)
        {
            bool F = true;
            int pos = N.Length - 1;
            while (F)
            {
                if (pos < 0)
                {
                    pos = N.Length - 1;
                }
                if (N[pos] < 255)
                {
                    N[pos] += 1;
                    F = false;
                }
                else
                {
                    N[pos] = 0;
                    pos--;
                }

            }
        }

       
        private static void Main(string[] args)
        {
            SHA256 sHA256 = new SHA256();
            string datastr = "Hello";
            string hashStr = "";
            var hash = sHA256.SHA256Encrypt(Encoding.Default.GetBytes(datastr));
            for (int i = 0; i < 32; i++)
            {
                hashStr += string.Format("{0:X1}", hash[i]);
            }

            Console.WriteLine(hashStr);
            var w = Encoding.Default.GetBytes(datastr);
            byte[] x = new byte[64];
            for (int i = 0; i < w.Length; i++)
            {
                if (i > 64) break;
                x[i] = w[i];

            }
            hashStr = "";
            bool f = true;
            while (f)
            {
                IncreaseN(x);
                var hash0 = sHA256.SHA256Encrypt(x);
                var sum = 0;
                for(int j = 0; j<2; j++)
                {
                    
                
                    sum += hash0[j];
                    Console.WriteLine(sum);
                   
                }
                if(sum == 0)
                {
                    f = false;
                    for (int i = 0; i < 32; i++)
                    {
                        hashStr += string.Format("{0:X1}", hash0[i]);
                    }
                }
            }
            Console.WriteLine(hashStr);


        }
    }
}
