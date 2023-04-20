using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            get => text;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                text = value;
            }
        }
        public string UserId
        {
            get=>userId; 
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                userId = value;
            }
        }

        public int CompareTo(Comment other)
        {
            return PublicationDate.CompareTo(other.PublicationDate);
        }
    }
}
