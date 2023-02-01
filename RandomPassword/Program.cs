using System;

namespace ConsoleApp21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetRandomPassword(6, 8, true, true));
            Console.WriteLine();
            Console.WriteLine(GetRandomPassword(8, 8, false, true));
            Console.WriteLine();
            Console.WriteLine(GetRandomPassword(6, 8, true, false));
            Console.WriteLine();
            //Console.WriteLine(GetRandomPassword(8, 8, false, false));

        }

        static string GetRandomPassword(int minLength, int maxLength, bool includeLetters, bool includeNumbers)
        {   

            Random random = new Random();
            int passwordLegth;
            string password = "";
            string name;
     
            if (maxLength < minLength)
            {
                throw new ArgumentException($"{nameof(minLength)} cant be greater than {nameof(maxLength)}.");
            }

            if (minLength == 0 && maxLength == 0)
            {
                throw new ArgumentException("");
            }

            if (!includeLetters && !includeNumbers)
            {
                throw new ArgumentException("");
            }

                passwordLegth = random.Next(minLength, maxLength);

            if (includeLetters && includeNumbers)
            {

                for (int i = 0; i < passwordLegth; i++)
                {
                    int rendom =random.Next(48,122);

                    if((rendom>57 && rendom<65) || (rendom > 90 && rendom < 97))
                    {
                        i--;
                        continue;
                    }

                    name = password.Insert(i, Convert.ToChar(rendom).ToString());
                    password = name;
                }
            }


            if (includeLetters && !includeNumbers)
            {
                for (int i = 0; i < passwordLegth; i++)
                {
                    int rendom = random.Next(65, 122);

                    if (rendom > 90 && rendom < 97)
                    {
                        i--;
                        continue;
                    }
                    name = password.Insert(i, Convert.ToChar(rendom).ToString());
                    password = name;
                }
            }

            if (includeNumbers && !includeLetters)
            {
                for (int i = 0; i < passwordLegth; i++)
                {
                    string rendomNumber = random.Next(0, 9).ToString();

                    name = password.Insert(i, rendomNumber);
                    password = name;
                }
            }

            return password;
        }
    }
}