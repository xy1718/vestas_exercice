using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vestas_DevAssessement2

{

    // Simple business object with the information that retrieve the list of product available for sale with (prices, stocks, ...)

    public class Product : IEquatable<Product>
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public int StockPromo_Buy { get; set; }

        public int StockPromo_Pay { get; set; }

        public int LastQuantityPurchased { get; set; }

        public override string ToString()
        {
            return "ProductName: " + ProductName + "   Price: " + Price.ToString() + "   Buy: " + StockPromo_Buy.ToString() + "   Pay: " + StockPromo_Pay.ToString() + "   Purchased: " + LastQuantityPurchased.ToString();
        }

        public override int GetHashCode()
        {
            return ProductID;
        }

        public bool Equals(Product other)
        {
            if (other == null) return false;
            return (this.ProductName.Equals(other.ProductName));
        }

        /// <summary>
        ///     Creation of the test list of products with the required information of prices and stock promotion/discount (type buy x -> pay y)
        /// </summary>
        /// <returns> Retrieve a Product list with information about stock and prices of the items according the example </returns>
        public List<Product> ProductStocksList()
        {

            // Add product items for test to the list.
            List<Product> ProductsList = new List<Product>();

            //The basket can contain any item multiple times. Items are priced as follows:

            //- Apples are 0.25€ each
            ProductsList.Add(new Product() { ProductID = 0, ProductName = "Apple", Price = 0.25, StockPromo_Buy = 1, StockPromo_Pay = 1, LastQuantityPurchased = 0 });

            //- Oranges are 0.30€ each
            ProductsList.Add(new Product() { ProductID = 1, ProductName = "Orange", Price = 0.3, StockPromo_Buy = 1, StockPromo_Pay = 1, LastQuantityPurchased = 0 });

            //- Bananas are 0.15€ each
            ProductsList.Add(new Product() { ProductID = 2, ProductName = "Banana", Price = 0.15, StockPromo_Buy = 1, StockPromo_Pay = 1, LastQuantityPurchased = 0 });

            //- Papayas are €0.50 each, but are available as "get three, pay two"
            ProductsList.Add(new Product() { ProductID = 3, ProductName = "Papaya", Price = 0.5, StockPromo_Buy = 3, StockPromo_Pay = 2, LastQuantityPurchased = 0 });

            return ProductsList;
        }

    }
}