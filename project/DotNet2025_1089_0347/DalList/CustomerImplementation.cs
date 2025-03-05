using DO;
using DalApi;
using Tools;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    public int Create(Customer item)
    {
        if (DataSource.Customers.FirstOrDefault(c => c.Id == item.Id) != null)
            throw new DalIdExistsException(item.Id);
        DataSource.Customers.Add(item);
        return item.Id;
    }
    public Customer Read(int id)
    {
        return DataSource.Customers.FirstOrDefault(c => c.Id == id) ?? throw new DalNotExistIdException(id);
    }

    public Customer Read(Func<Customer, bool> filter)
    {
        return DataSource.Customers.FirstOrDefault(c => filter(c)) ?? throw new DalObjectNotExistException("Customer");
    }
    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        return filter == null ?
            DataSource.Customers.ToList() :
            DataSource.Customers.Where(c => filter(c)).ToList();
    }
    public void Update(Customer item)
    {
        Delete(item.Id);
        DataSource.Customers.Add(item);
    }
    public void Delete(int id)
    {
        Customer c = Read(id);
        DataSource.Customers.Remove(c);
    }

}
