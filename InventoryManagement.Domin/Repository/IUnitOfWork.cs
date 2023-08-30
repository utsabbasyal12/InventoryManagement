namespace InventoryManagement.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IWholesalerRepository Wholesaler { get; }
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IProductPriceRepository ProductPrice { get; }
        IStockRepository Stock { get; }

        int Save();
    }
}
