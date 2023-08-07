using Moryx.AbstractionLayer.Products;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Products
{
    [Display(Name = "MyProduct")]
    public class MyProductType : ProductType
    {
        protected override ProductInstance Instantiate()
        {
            return new MyProductInstance();
        }
    }
}
