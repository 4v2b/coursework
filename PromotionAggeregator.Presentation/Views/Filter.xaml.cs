using PromotionAggregator.Logic.Context;
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
    public sealed partial class Filter : UserControl
    {
        private FilterMode _mode = FilterMode.None;
        private int _period = 0;
        private int _rating = -1;


        public IdentityUser IdentityUser { get; set; }

        public Filter()
        {
            this.InitializeComponent();
        }

        public event EventHandler<List<Promotion>> OnFilterClick;


        private void ResetClick(object sender, RoutedEventArgs e)
        {
            OnFilterClick?.Invoke(sender, Context.Instance.Promotions);
        }

        private void FilterClick(object sender, RoutedEventArgs e)
        {
            List<Promotion> list = IdentityUser.Filter(_mode, _rating, _period);
            OnFilterClick?.Invoke(sender, list);
        }

        private void Tap(object sender, TappedRoutedEventArgs e)
        {
            StackPanel panel;
            SymbolIcon icon;
            if ((sender as Grid).Name.Equals("type"))
            {
                panel = checkBoxes1;
                icon = symbol1;
            }
            else if((sender as Grid).Name.Equals("period"))
            {
                panel = checkBoxes2;
                icon = symbol2;
            }
            else if((sender as Grid).Name.Equals("rating"))
            {
                panel = checkBoxes3;
                icon = symbol3;
            }
            else
            {
                panel = null;
                icon = null;
            }
            if (panel.Visibility == Visibility.Visible)
            {
                panel.Visibility = Visibility.Collapsed;
                icon.Symbol = Symbol.Add;
            }
            else
            {
                panel.Visibility = Visibility.Visible;
                icon.Symbol = Symbol.Remove;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radio = (sender as RadioButton);
            if(radio.GroupName == "typeGroup")
            {
                _mode = Enum.Parse<FilterMode>(radio.Tag as string);
            }
            else if(radio.GroupName == "periodGroup")
            {
                _period = int.Parse(radio.Tag as string);
            }
            else if(radio.GroupName == "ratingGroup")
            {
                _rating = int.Parse(radio.Tag as string);
            }
        }
    }
}
