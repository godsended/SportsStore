namespace SportsStore.Models;

public class EFStoreRepository : IStoreRepository
{
    private StoreDbContext context;

    public EFStoreRepository(StoreDbContext context) 
    {
        this.context = context;
    }

    public IQueryable<Product> Products => context.Products;

    public void CreateProduct(Product product)
    {
        context.Add(product);
        context.SaveChangesAsync();
    }

    public void DeleteProduct(Product product)
    {
        context.Remove(product);
        context.SaveChangesAsync();
    }

    public void SaveProduct(Product product)
    {
        context.SaveChangesAsync();
    }
}