using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
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

namespace PromotionAggeregator.Presentation.ViewModels
{
    public sealed partial class PromotionModel : UserControl
    {
        List<Promotion> promotions;
        public PromotionModel()
        {
            this.InitializeComponent();
            promotions = Context.Instance.Promotions;
        }

        public string Description { get => description.Text; set => description.Text = value; }

        public string Title { get => title.Text; set => title.Text = value; }

    }
}
