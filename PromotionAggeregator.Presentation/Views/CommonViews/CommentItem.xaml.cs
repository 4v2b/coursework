using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using Windows.UI.Xaml.Controls;

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class CommentItem : UserControl
    {
        public Comment Comment
        {
            set
            {
                name.Text = "@" + value.UserId.Substring(0,8);
                content.Text = value.Text;
                time.Text = value.PublicationDate.ToString();
            }
        }

        public CommentItem()
        {
            this.InitializeComponent();
        }

    }
}
