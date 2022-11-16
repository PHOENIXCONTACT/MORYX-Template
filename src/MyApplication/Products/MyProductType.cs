using Moryx.AbstractionLayer.Products;

namespace MyApplication.Products
{
    public class MyProductType : ProductType
    {
        protected override ProductInstance Instantiate()
        {
            return new MyProductInstance();
        }
    }
}
