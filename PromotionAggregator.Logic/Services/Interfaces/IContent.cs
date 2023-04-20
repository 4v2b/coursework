using System.Collections.Generic;
using PromotionAggregator.Logic.Services;

namespace PromotionAggregator.Logic.Interfaces
{
    interface IContent<T>
    {
        List<T> Search(string matching);

        List<T> Filter(FilterMode filter, double ratingLowerConstraint, int order);
    }
}
