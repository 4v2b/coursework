using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class CommentElement : UserControl
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

        public CommentElement()
        {
            this.InitializeComponent();
        }

    }
}
