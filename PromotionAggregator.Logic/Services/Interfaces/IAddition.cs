using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAggregator.Logic.Interfaces
{
    interface IAddition<T>
    {
        void AddPromotion(T item);
    }
}
