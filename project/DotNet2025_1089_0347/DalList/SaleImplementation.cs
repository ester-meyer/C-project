using DO;
using DalApi;
using Tools;
namespace Dal;

internal class SaleImplementation : ISale
{
    public int Create(Sale item)
    {
        Sale s = item with { Id = DataSource.Config.getCntSale };
        DataSource.Sales.Add(s);
        return item.Id;
    }
    public Sale Read(int id)
    {
        return DataSource.Sales.FirstOrDefault(s => s.Id == id) ?? throw new DalNotExistIdException(id);
    }
    public Sale Read(Func<Sale, bool> filter)
    {
        return DataSource.Sales.FirstOrDefault(s => filter(s)) ?? throw new DalObjectNotExistException("Sale");
    }
    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        return filter == null ?
            DataSource.Sales.ToList() :
            DataSource.Sales.Where(s => filter(s)).ToList();
    }
    public void Update(Sale item)
    {
        Delete(item.Id);
        DataSource.Sales.Add(item);
    }
    public void Delete(int id)
    {
        Sale s = Read(id);
        DataSource.Sales.Remove(s);
    }
}
