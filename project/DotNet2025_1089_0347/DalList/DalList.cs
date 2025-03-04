using DalApi;

namespace DalList
{
    sealed internal class DalList:IDal
    {
        public static DalList Instance { get; } = new DalList();
        private DalList()
        {
            
        }
        public ICustomer Customer => new CustomerImplementation();
        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();
    }
}
