using PromotionAggeregator.Presentation.Services;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class SearchField : UserControl
    {
        private Dictionary<string, Category> categories;

        public IdentityUser Identity { get; set; }

        public SearchField()
        {
            categories = CategoriesMap.CategoryMap;
            this.InitializeComponent();
        }

        public event EventHandler<List<Promotion>> SearchClicked;

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            if (searchField.Text != string.Empty)
            {
                this.SearchClicked?.Invoke(sender, Identity.Search(searchField.Text));
            }
        }

        private void CategoryClick(object sender, ItemClickEventArgs e)
        {
            var pair = (KeyValuePair<string, Category>)e.ClickedItem;
            this.SearchClicked?.Invoke(sender, Identity.GetPromotionsInCategory(pair.Value));
        }
    }
}
