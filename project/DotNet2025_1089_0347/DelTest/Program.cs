using DalApi;
using DO;

namespace DelTest
{
    internal class Program
    {
        private static IDal s_dal = DalApi.Factory.Get;
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");
            Initialization.Initialize();

            int select = printMainMenu();
            while (select != 0)
            {
                switch (select)
                {
                    case 1:
                        ProductCrud(printSubMenu("product"));
                        break;
                    case 2:
                        SaleCrud(printSubMenu("sale"));
                        break;
                    case 3:
                        CustomerCrud(printSubMenu("customer"));
                        break;
                    default:
                        Console.WriteLine("Wrong selection, please select again");
                        break;
                }

                select = printMainMenu();
            }
        }

        private static int printMainMenu()
        {
            Console.WriteLine("For product press 1");
            Console.WriteLine("For sale press 2");
            Console.WriteLine("For customrer press 3");
            Console.WriteLine("To exit press 0");

            int select;
            if (!int.TryParse(Console.ReadLine(), out select))
                select = -1;
            return select;
        }
        private static int printSubMenu(string item)
        {

            Console.WriteLine($"To add {item} press 1");
            Console.WriteLine($"To update {item} press 2");
            Console.WriteLine($"To read {item} press 3");
            Console.WriteLine($"To read all {item}s press 4");
            Console.WriteLine($"To delete {item} press 5");
            Console.WriteLine("To go back press 0");
            int select;
            if (!int.TryParse(Console.ReadLine(), out select))
                select = -1;
            return select;
        }

        public static void SaleCrud(int subSelect)
        {
            switch (subSelect)
            {
                case 1:
                    s_dal.Sale.Create(CreateSale());
                    break;
                case 2:
                    s_dal.Sale.Update(CreateSale());
                    break;
                case 3:
                    Console.WriteLine(s_dal.Sale.Read(GetId("sale")));
                    break;
                case 4:
                    PrintAll<Sale>(s_dal.Sale);
                    break;
                case 5:
                    s_dal.Sale.Delete(GetId("sale"));
                    break;
                default:
                    Console.WriteLine("Wrong selection, please select again");
                    break;
            }
        }
        public static void ProductCrud(int subSelect)
        {
            switch (subSelect)
            {
                case 1:
                    s_dal.Product.Create(CreateProduct());
                    break;
                case 2:
                    s_dal.Product.Update(CreateProduct());
                    break;
                case 3:
                    Console.WriteLine(s_dal.Product.Read(GetId("product"))); 
                    break;
                case 4:
                    PrintAll<Product>(s_dal.Product);
                    break;
                case 5:
                    s_dal.Product.Delete(GetId("product"));
                    break;
                default:
                    Console.WriteLine("Wrong selection, please select again");
                    break;
            }
        }

        public static void CustomerCrud(int subSelect)
        {
            switch (subSelect)
            {
                case 1:
                    s_dal.Customer.Create(CreateCustomer());
                    break;
                case 2:
                    s_dal.Customer.Update(CreateCustomer());
                    break;
                case 3:
                    Console.WriteLine(s_dal.Customer.Read(GetId("customer"))); 
                    break;
                case 4:
                    PrintAll<Customer>(s_dal.Customer);
                    break;
                case 5:
                    s_dal.Customer.Delete(GetId("customer"));
                    break;
                default:
                    Console.WriteLine("Wrong selection, please select again");
                    break;
            }
        }
        public static void PrintAll<T>(ICrud<T> item)
        {
            foreach (T i in item.ReadAll())
            {
                Console.WriteLine(i);
            }
        }
        public static Product CreateProduct()
        {
            Console.WriteLine("enter name");
            string name = Console.ReadLine();
            Categories category;
            do
            {
                Console.WriteLine("enter category");

            } while (!Enum.TryParse(Console.ReadLine(), out category));

            double price;
            do
            {
                Console.WriteLine("enter price");
            } while (!double.TryParse(Console.ReadLine(), out price));
            int amountInStock;
            do
            {
                Console.WriteLine("enter amount in stock");
            } while (!int.TryParse(Console.ReadLine(), out amountInStock));
            return new Product(name, category, price, amountInStock);

        }
        public static Sale CreateSale()
        {
            int productId;
            do
            {
                Console.WriteLine("enter product id");
            } while (!int.TryParse(Console.ReadLine(), out productId));

            int amount;
            do
            {
                Console.WriteLine("enter amount");
            } while (!int.TryParse(Console.ReadLine(), out amount));


            double totalPrice;
            do
            {
                Console.WriteLine("enter total price");
            } while (!double.TryParse(Console.ReadLine(), out totalPrice));
            bool forClubCustomers;
            do
            {
                Console.WriteLine("is it for club customers? enter true/false");
            } while (!bool.TryParse(Console.ReadLine(), out forClubCustomers));
            DateOnly start;
            do
            {
                Console.WriteLine("enter start date");
            } while (!DateOnly.TryParse(Console.ReadLine(), out start));
            DateOnly end;
            do
            {
                Console.WriteLine("enter end date");
            } while (!DateOnly.TryParse(Console.ReadLine(), out end));
            return new Sale(productId, amount, totalPrice, forClubCustomers, start, end,0);
        }
        public static Customer CreateCustomer()
        {
            int id;
            do
            {
                Console.WriteLine("enter id");
            } while (!int.TryParse(Console.ReadLine(), out id));

            string name = Console.ReadLine();
            string address = Console.ReadLine();
            string phoneNumber = Console.ReadLine();

            return new Customer(id, name, address, phoneNumber);
        }

        public static int GetId(string item)
        {
            int id;
            do
            {
                Console.WriteLine($"enter {item} id");
            } while (!int.TryParse(Console.ReadLine(), out id));
            return id;
        }

    }
}