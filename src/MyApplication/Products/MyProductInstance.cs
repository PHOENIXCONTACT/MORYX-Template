// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG

using Moryx.AbstractionLayer.Products;
using System;

namespace MyApplication.Products;

public class MyProductInstance : ProductInstance<MyProductType>
{
    public DateTime ManufacturingDate { get; set; }
}
