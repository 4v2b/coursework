using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace PromotionAggregator.Logic.Interfaces
{
    interface IContent<T>
    {
        List<T> Search(string matching);

        List<T> Filter(int filter, int order);
    }
}
