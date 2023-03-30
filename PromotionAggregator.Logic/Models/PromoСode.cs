namespace PromotionAggregator.Logic.Models
{
    internal class PromoСode : Promotion
    {
        public PromoСode(string code)
        {
            Code = code;
        }
        public string Code { get; set; }
    }
}
