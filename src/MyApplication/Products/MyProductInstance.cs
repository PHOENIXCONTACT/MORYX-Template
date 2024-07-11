using Moryx.AbstractionLayer.Products;
using System;

namespace MyApplication.Products;

public class MyProductInstance : ProductInstance<MyProductType>
{
    public DateTime ManufacturingDate { get; set; }
}
