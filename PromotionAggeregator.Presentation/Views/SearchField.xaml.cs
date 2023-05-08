using PromotionAggeregator.Presentation.Services;
using PromotionAggeregator.Presentation.ViewModels;
using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using System.Collections;
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
        private TextBlock resultIndicator;

        public IdentityUser Identity { get; set; }

        public SearchField()
        {
            this.InitializeComponent();
            Identity = new IdentityUser();
            Identity.Notify += ShowCount;
        }

        private void ShowCount(int count)
        {
            resultIndicator = Init.GetMessageButton(count);
        }

        public event EventHandler<ArrayList> OnSearchClick;

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            if (!string.IsNullOrEmpty(searchField.Text))
            {
                ArrayList list = Init.Convert(Identity.Search(searchField.Text));
                    arrayList.Add(resultIndicator);
                    arrayList.AddRange(list);

            }
            else arrayList.AddRange(Init.Convert(Context.Instance.Promotions));
            this.OnSearchClick?.Invoke(sender,arrayList);
        }

    }
}
