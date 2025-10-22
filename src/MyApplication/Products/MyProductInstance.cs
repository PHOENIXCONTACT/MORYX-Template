// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using Moryx.AbstractionLayer.Products;
using System;

namespace MyApplication.Products;

public class MyProductInstance : ProductInstance<MyProductType>
{
    public DateTime ManufacturingDate { get; set; }
}
