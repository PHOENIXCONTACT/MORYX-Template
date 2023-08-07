using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moryx.AbstractionLayer.Products;
using Moryx.Container;
using Moryx.Logging;
using Moryx.Orders;
using Moryx.Orders.Assignment;

namespace MyApplication.Orders
{
    /// <summary>
    /// Product assignment for the MyApplication
    /// </summary>
    [Plugin(LifeCycle.Singleton, typeof(IProductAssignment), Name = nameof(MyApplicationProductAssignment))]
    public class MyApplicationProductAssignment : ProductAssignmentBase<ProductAssignmentConfig>
    {
        /// <inheritdoc />
        /// <inheritdoc />
        public override Task<IProductType> SelectProduct(Operation operation, IOperationLogger operationLogger)
        {
            var productIdentity = (ProductIdentity)operation.Product.Identity;
            var selectedType = ProductManagement.LoadType(productIdentity);

            if (selectedType == null)
            {
                operationLogger.Log(LogLevel.Error, "Product not found");
                return null;
            }

            return Task.FromResult(selectedType);
        }
    }
}