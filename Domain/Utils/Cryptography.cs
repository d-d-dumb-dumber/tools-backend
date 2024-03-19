﻿using System.Security.Cryptography;
using System.Text;

namespace Domain.Utils
{
    public static class Cryptography
    {
        private const string PEPPER_ENVIRONMENT_KEY = "PEPPER";
        private const string SEPARATOR_TOKEN = "-";
        private static readonly Random _random = new ();
        
        public static string GenerateSalt(uint size)
        {
            StringBuilder str_build = new ();
            
            for (int i = 0; i < size; i++)
            {
                bool isNumber = _random.Next() % 2 == 0;
                bool isUpperCase = _random.Next() % 2 != 0;
                double seed = _random.NextDouble();
                char value;
                
                if (isNumber)
                {
                    int shift = Convert.ToInt32(Math.Floor(10 * seed));
                    value = Convert.ToChar(shift + 48);
                }
                else
                {
                    if (isUpperCase)
                    {
                        int shift = Convert.ToInt32(Math.Floor(25 * seed));
                        value = Convert.ToChar(shift + 65);
                    }
                    else
                    {
                        int shift = Convert.ToInt32(Math.Floor(25 * seed));
                        value = Convert.ToChar(shift + 97);
                    }
                }
                str_build.Append(value);
            }

            return str_build.ToString();
        }

        public static string EncryptPassword(string password, string salt)
        {
            password.ValidateStringArgumentNotNullOrEmpty(nameof(password));
            string pepper = Environment.GetEnvironmentVariable(PEPPER_ENVIRONMENT_KEY) ?? string.Empty;
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt + pepper);
            byte[] hashBytes = SHA512.HashData(passwordBytes);
            string hash = BitConverter.ToString(hashBytes).Replace(SEPARATOR_TOKEN, string.Empty);

            return hash;
        }
    }
}