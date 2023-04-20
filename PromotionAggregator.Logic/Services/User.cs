using PromotionAggregator.Logic.Interfaces;
using PromotionAggregator.Logic.Models;
using System;

namespace PromotionAggregator.Logic.Services
{
    public abstract class User : IAddition
    {
        private string email;
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

        public string Email
        {
            get => throw new NotImplementedException();
            private set => throw new NotImplementedException();
        }

        public string Id { get; private set; }

        public string Password
        {
            get => throw new NotImplementedException();
            private set => throw new NotImplementedException();
        }

        private static string HashPassword(string password)
        {
            throw new NotImplementedException();
        }

        public bool CheckPassword(string password)
        {
            throw new NotImplementedException();
        }

        public void AddPromotion(Promotion promotion)
        {
            throw new NotImplementedException();
        }

    }
}
