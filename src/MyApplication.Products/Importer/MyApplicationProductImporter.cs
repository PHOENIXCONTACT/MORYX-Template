using System.Collections.Generic;
using System.Threading.Tasks;
using Moryx.AbstractionLayer.Products;
using Moryx.Container;
using Moryx.Logging;
using Moryx.Modules;
using Moryx.Products.Management;

namespace MyApplication.Products;

/// <summary>
/// Imports products for MyApplication
/// </summary>
[ExpectedConfig(typeof(MyApplicationProductImporterConfig))]
[Plugin(LifeCycle.Transient, typeof(IProductImporter), Name = nameof(MyApplicationProductImporter))]
public  class MyApplicationProductImporter :  ProductImporterBase<MyApplicationProductImporterConfig, MyApplicationImportParameters>, ILoggingComponent
{
    /// <inheritdoc />
    public IModuleLogger Logger { get; set; }

    public IProductStorage Storage { get; set; }

    protected override Task<ProductImporterResult> Import(ProductImportContext context, MyApplicationImportParameters parameters)
    {
        var products = new List<ProductType>();

        // TODO: Create objects from parameters, file or endpoint

        return Task.FromResult(new ProductImporterResult { ImportedTypes = products });
    }
}