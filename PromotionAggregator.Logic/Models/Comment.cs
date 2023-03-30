using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAggregator.Logic.Models
{
    internal class Comment
    {
        public string AuthorId {get; set;}
        public DateTime PublicationDate { get; set;}
        public string Text { get; set;}
    }
}
