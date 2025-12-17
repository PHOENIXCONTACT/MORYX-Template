// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moryx.AbstractionLayer.Products;
using Moryx.Container;
using Moryx.Orders;
using Moryx.Orders.Assignment;

namespace MyApplication.Orders;

/// <summary>
/// Product assignment for the MyApplication
/// </summary>
[Plugin(LifeCycle.Singleton, typeof(IProductAssignment), Name = nameof(MyApplicationProductAssignment))]
public class MyApplicationProductAssignment : ProductAssignmentBase<ProductAssignmentConfig>
{
    /// <inheritdoc />
    /// <inheritdoc />
    public override async Task<ProductType> SelectProductAsync(Operation operation, IOperationLogger operationLogger, CancellationToken cancellationToken)
    {
        var productIdentity = (ProductIdentity)operation.Product.Identity;
        var selectedType = await ProductManagement.LoadTypeAsync(productIdentity, cancellationToken);

        if (selectedType == null)
        {
            operationLogger.Log(LogLevel.Error, "Product not found");
            return null;
        }

        return selectedType;
    }
}
