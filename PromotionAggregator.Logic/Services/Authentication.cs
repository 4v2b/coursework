using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace PromotionAggregator.Logic.Services
{

    public class Authentication
    {
        private const string ADMIN_EMAIL = "admin.promotion.aggregator@mail.com";

        public static User SignIn(string email, string password)
        {
            try
            {
                new MailAddress(email);
            }
            catch
            {
                throw new ArgumentException();
            }
            List<User> users = Context.Context.Instance.Users;
            User user = users.Find(x => x.Email.Equals(email));
            if (user != null && user.CheckPassword(password))
                return user;
            throw new ArgumentException();
        }

       public static User Register(string email, string password, string repeatPassword)
       {
            List<User> users = Context.Context.Instance.Users;

            if (users.Exists(x => x.Email.Equals(email)) || !password.Equals(repeatPassword))
                throw new ArgumentException();
            User user;
            if(email.Equals(ADMIN_EMAIL))
                user = new Admin(email, password);
            else user = new AuthorisedUser(email, password);
            users.Add(user);
            return user;
       }
     
    }
}
