
using System.Collections.Generic;

namespace PromotionAggregator.Logic.Context
{
    internal class JsonSerializer<T>
    {
        public static void Serialize(string path, List<T> items)
        {

        }
        
        public static List<T> Deserialize(string path)
        {
            return new List<T>();
        }
    }
}
