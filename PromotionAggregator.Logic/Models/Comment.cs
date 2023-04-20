using System;

namespace PromotionAggregator.Logic.Models
{
    public class Comment: IComparable<Comment>
    {
        private string text;
        private string userId;

        public Comment(string text, DateTime date, string userId)
        {
            PublicationDate = date;
            Text = text;
            UserId = userId;
        }

        public DateTime PublicationDate { get; private set;}

        public string Text
        {
            get => throw new NotImplementedException();
            private set
            {
                throw new NotImplementedException();
            }
        }
        public string UserId
        {
            get=> throw new NotImplementedException(); 
            private set
            {
                throw new NotImplementedException();
            }
        }

        public int CompareTo(Comment other)
        {
            throw new NotImplementedException();
        }
    }
}
