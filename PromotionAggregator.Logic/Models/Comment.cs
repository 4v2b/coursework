using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAggregator.Logic.Models
{
    internal class Comment
    {
        private string text;

        public Comment(string text, DateTime date)
        {
            PublicationDate = date;
            Text = text;
        }

        public DateTime PublicationDate { get; private set;}
        public string Text { get; private set;}
    }
}
