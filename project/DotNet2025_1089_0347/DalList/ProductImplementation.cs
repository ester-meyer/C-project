using DO;
using DalApi;

using Tools;
namespace Dal;

internal class ProductImplementation:IProduct
{
    public int Create(Product item)
    {
        Product p = item with {Id=DataSource.Config.getCntProduct };
        
        DataSource.Products.Add(p);
        return p.Id;
    }
    public Product Read(int id)
    {
        return DataSource.Products.FirstOrDefault(p => p.Id == id) ?? throw new DalNotExistIdException(id);
    }
    public Product Read(Func<Product, bool> filter)
    {
        return DataSource.Products.FirstOrDefault(p => filter(p)) ?? throw new DalObjectNotExistException("Product");
    }
    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        return filter == null ?
            DataSource.Products.ToList() :
            DataSource.Products.Where(p => filter(p)).ToList();
    }
    public void Update(Product item)
    {
        Delete(item.Id);
        DataSource.Products.Add(item);
    }
    public void Delete(int id)
    {
        Product p = Read(id);
        DataSource.Products.Remove(p);
    }
}
