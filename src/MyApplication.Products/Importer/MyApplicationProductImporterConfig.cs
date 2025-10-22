// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using Moryx.AbstractionLayer.Products;

namespace MyApplication.Products.Importer;

/// <summary>
/// Config for the <see cref="MyApplicationProductImporter"/>
/// </summary>
public class MyApplicationProductImporterConfig : ProductImporterConfig
{
    public override string PluginName => nameof(MyApplicationProductImporter);
}
