using DO;
namespace Dal;

internal static class DataSource
{

    internal static List<Product> Products = new List<Product>();
    internal static List<Customer> Customers = new List<Customer>();
    internal static List<Sale> Sales = new List<Sale>();
    internal static class Config
    {
        internal const int initCntSale = 100;
        private static int cntSale = initCntSale;
        public static int getCntSale
        {
            get
            {
                return cntSale++;
            }
        }


        internal const int initCntProduct = 200;
        private static int cntProduct = initCntProduct;
        public static int getCntProduct
        {
            get
            {
                return cntProduct++;
            }
        }
    }
}


