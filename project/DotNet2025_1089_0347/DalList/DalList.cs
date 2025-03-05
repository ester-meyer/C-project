using DalApi;

namespace Dal
{
    sealed public class DalList:IDal
    {
        private static readonly DalList instance = new DalList();
        public static DalList Instance => instance;
        private DalList()
        {
            
        }
        public ICustomer Customer => new CustomerImplementation();
        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();
    }
}
