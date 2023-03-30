using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAggregator.Logic.Interfaces
{
    internal interface IAddition<T>
    {
        void Add(T item);
    }
}
