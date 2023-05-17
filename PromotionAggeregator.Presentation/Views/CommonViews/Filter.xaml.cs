using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


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

        public event EventHandler<List<Promotion>> FilterClicked;

        public event EventHandler ResetClicked;


        private void ResetClick(object sender, RoutedEventArgs e)
        {
            ResetClicked?.Invoke(sender, null);
        }

        private void FilterClick(object sender, RoutedEventArgs e)
        {
            List<Promotion> list = IdentityUser.Filter(_mode, _rating, _period);
            FilterClicked?.Invoke(sender, list);
        }

        private void SetFilterOptions(object sender, TappedRoutedEventArgs e)
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

        private void RadioButtonCheck(object sender, RoutedEventArgs e)
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
