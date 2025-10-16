// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using Moryx.AbstractionLayer.Products;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Products;

[Display(Name = "MyProduct")]
public class MyProductType : ProductType
{
    protected override ProductInstance Instantiate()
    {
        return new MyProductInstance();
    }
}
