using System;
using System.Linq;


namespace Algoritma_1
{
    class Program
    {
        private static Random random = new Random();
        static void Main(string[] args)
        {
            
            GenerateCodes();

            // test icin false donmesi gerek
            Console.WriteLine(check("ABKGD123"));
            // test icin 8 karakter olmama durumu
            Console.WriteLine(check("EFGHKLMNPRTXYZ23"));
            //test için true donmesi gerek
            Console.WriteLine(check("2YTGH5AE"));
        }

         static void GenerateCodes()
        {
            const int length = 8;
            const string chars = "ACDEFGHKLMNPRTXYZ234579";
            string[] uniqeCode = new string[1000];
            string code;

            // 1000 adet kod ureten dongu
            for (int i = 0; i < uniqeCode.Length; i++)
            {

                // 8 karakterli bir kod üreten LINQ sorgusu
                code = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray()) ;

             // Uretilen kodun uniqe olmasını kontrol eder
                if(Array.IndexOf(uniqeCode, code) == -1)
                {
                    uniqeCode[i] = code;

                    // test için
                    Console.WriteLine(uniqeCode[i]);
                }
                else
                {
                    i--;
                    break;
                }
               // Console.WriteLine(uniqeCode[i]);
            }
            
            
        }


        static bool check(string code)
        {
            bool result;
            const int length = 8;
            int counter = 0;
            const string chars = "ACDEFGHKLMNPRTXYZ234579";

            // kodun 8 karakterden olusmasini kontrol eder
            if (code.Length!=length)
            {
                result = false;
            }

            // Kodun bizim karakterlerimizden olusmasini kontrol eder
            for(int i=0;i<code.Length;i++)
            {
                for(int j=0;j<chars.Length;j++)
                {
                    if(code[i]==chars[j])
                    {
                        counter += 1;
                        break;
                    }

                }
            }
            if(counter==8)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }



    }
}
