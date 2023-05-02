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

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class SearchField : UserControl
    {
        public SearchField()
        {
            this.InitializeComponent();
        }

        public string Text { get => searchField.Text; }

        public event RoutedEventHandler OnSearchClick;

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if(this.OnSearchClick != null)
            {
                this.OnSearchClick(sender, e);
            }

        }

    }
}
