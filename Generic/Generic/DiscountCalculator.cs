using System;

namespace Generic
{
    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public float CalculateDiscount(TProduct product)
        {
            return product.Price;
        }
    }

    public abstract class Product
    {
        public float Price { get; set; }
    }
}
