using PromotionAggregator.Logic.Interfaces;
using PromotionAggregator.Logic.Models;
using System;
using Windows.Security.Cryptography.Core;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;
using System.Net.Mail;
using Newtonsoft.Json;

namespace PromotionAggregator.Logic.Services
{
    public abstract class User : IAddition
    {
        [JsonProperty]
        private string email;

        [JsonProperty]
        private string password;


        public User(string email, string password, bool isHash = false)
        {
            Id = Guid.NewGuid().ToString();
            Email = email;
            if (isHash)
                this.password = password;
            else Password = password;
        }

        public User() { }

        [JsonIgnore]
        public string Email
        {
            get => email;
            private set
            {
                try
                {
                    new MailAddress(value);
                }
                catch
                {
                    throw new ArgumentException("Невірний формат електронної пошти");
                }
                email = value;
            }
        }

        [JsonProperty]
        public string Id { get; private set; }

        [JsonIgnore]
        public string Password
        {
            private set
            {
                if (!string.IsNullOrEmpty(value) 
                    && value?.Length > 7 
                    && value.IndexOf(' ') == -1)
                        password = HashPassword(value);
                else throw new ArgumentException("Пароль має бути довжиною щонайменше 8 символів і не містити пробіли");
            }
            get => password;
        }

        private static string HashPassword(string password)
        {
            IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(password, BinaryStringEncoding.Utf8);
            HashAlgorithmProvider hashProvider = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha256);
            IBuffer hashedBuffer = hashProvider.HashData(buffer);
            string hashedPassword = CryptographicBuffer.EncodeToHexString(hashedBuffer);

            return hashedPassword;
        }

        public bool CheckPassword(string password)
        {
            return Password.Equals(HashPassword(password));
        }

        public void AddPromotion(Promotion promotion)
        {
            if(promotion!=null)
                Context.Context.Instance.Promotions.Add(promotion);
            else throw new ArgumentNullException();
        }

    }
}
