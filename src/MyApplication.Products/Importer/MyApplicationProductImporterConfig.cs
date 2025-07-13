// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG

using Moryx.AbstractionLayer.Products;

namespace MyApplication.Products;

/// <summary>
/// Config for the <see cref="MyApplicationProductImporter"/>
/// </summary>
public class MyApplicationProductImporterConfig : ProductImporterConfig
{
    public override string PluginName => nameof(MyApplicationProductImporter);
}
