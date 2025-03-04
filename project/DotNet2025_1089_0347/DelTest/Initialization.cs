using DalApi;
using DO;

namespace DelTest;

public class Initialization
{

    private static IDal? s_dal;
    public static void Initialize()
    {
        s_dal = DalApi.Factory.Get;
        createProducts();
        createCustomers();
        createSales();
    }
    private static void createProducts()
    {
        s_dal.Product.Create(new Product( "מכשיר ריצה", Categories.מכשירים, 3000,10));
        s_dal.Product.Create(new Product("משקולת 5 קילו", Categories.אביזרי_כושר, 50,30));
        s_dal.Product.Create(new Product("תיק ספורט", Categories.אקססוריז, 70,30));
        s_dal.Product.Create(new Product("חולצת ספורט", Categories.ביגוד, 70,25));
        s_dal.Product.Create(new Product("נעלי נייק גברים", Categories.נעליים, 300,25));
    }
    private static void createCustomers()
    {
        s_dal.Customer.Create(new Customer(9848444,"משה כהן", "ירושלים מלכי ישראל 8", "0548500864"));
        s_dal.Customer.Create(new Customer(6989655,"חיים יהודה", "אשדוד אבן-גברול 12", "0583296863"));
    }
    private static void createSales()
    {
        Product current = s_dal.Product.ReadAll()[1];
        s_dal.Sale.Create(new Sale(2,current.Id,90,true,new DateOnly(2024,11,1),new DateOnly(2024,12,1),0));
        current = s_dal.Product.ReadAll()[3];
        s_dal.Sale.Create(new Sale(3, current.Id, 180, false, new DateOnly(2025, 1, 1), new DateOnly(2025, 2, 1), 0));
    }
}
