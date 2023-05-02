using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace PromotionAggregator.Logic.Services
{

    public class Authentication
    {
        private static readonly string adminEmail = "admin.promotion.aggregator@mail.com";

        public static User SignIn(string email, string password)
        {
            try
            {
                new MailAddress(email);
            }
            catch
            {
                throw new ArgumentException("Невірний формат електронної пошти");
            }
            List<User> users = Context.Context.Instance.Users;
            User user = users.Find(x => x.Email.Equals(email));
            if (user == null)
                throw new ArgumentException("Користувач з такою електронною поштою не існує");
            if(user.CheckPassword(password))
                return user;
            throw new ArgumentException("Невірний пароль");

        }

       public static User Register(string email, string password, string repeatPassword)
       {
            List<User> users = Context.Context.Instance.Users;

            if (users.Exists(x => x.Email.Equals(email)))
                throw new ArgumentException("Користувач з такою електронною поштою вже існує");
            if (!password.Equals(repeatPassword))
                throw new ArgumentException("Паролі не збігаються");
            User user;
            if(email.Equals(adminEmail))
                user = new Admin(email, password);
            else user = new AuthorisedUser(email, password);
            users.Add(user);
            return user;
       }
     
    }
}
