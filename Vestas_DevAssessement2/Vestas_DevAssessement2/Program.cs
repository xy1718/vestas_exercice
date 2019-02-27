using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vestas_DevAssessement2
{
    //**+ luis.anjos@outlook.com
    // Coding exercise 
    // Write a simple program that calculates the price of a shopping basket.

    class CodingExercise
    {
        static void Main(string[] args)
        {

            ///The output should be displayed similar to what you would expect to see on a receipt.
            //Example input:
            //Apple
            //Apple
            //Orange
            //Apple
            //Papaya
            //Banana
            //Papaya
            //Papaya
            //Example Output:
            //Total: 2.2€

            #region INPUT - Data entry and basic validation

            // Local instance of the product class in order to handle prices and discount information      
            Product objProduct = new Product();

            // UI welcome splash      
            Console.WriteLine("List of products to sell:");
            Console.WriteLine();

            // Products available to sell 
            List<Product> lstProductsToSell = objProduct.ProductStocksList();

            foreach (Product item in lstProductsToSell)
            {
                Console.WriteLine(item.ToString());
            }

            // Given a list of shopping, calculate the total cost of those items.
            List<Product> lstShoppingList = new List<Product>();

            // UI data entry
            Console.WriteLine();
            Console.WriteLine("Input the shopping list (product by product):");
            Console.WriteLine("-- To calculate the total costs, leave the empty string and do ENTER again --");
            Console.WriteLine();

            // Items are presented one at a time, each of it in one line, as a list, identified by their name (Apples,Bananas).
            //The basket can contain any item multiple times.

            string ProductItemInput;
            do
            {
                ProductItemInput = Console.ReadLine();

                // Fill the shopping list with valid products
                if (lstProductsToSell.Exists(x => x.ProductName.Contains(ProductItemInput)))
                {
                    // Get the index/ID of the product to simplify the calculations 
                    int index = lstProductsToSell.FindIndex(x => x.ProductName == ProductItemInput);
                    // Add valid product in the shopping list
                    lstShoppingList.Add(new Product() { ProductName = ProductItemInput, ProductID = index });

                }
                else
                    Console.WriteLine("Please input a valid product name!!!!!");

            } while (ProductItemInput.ToString() != String.Empty);

            #endregion

            #region OUTPUT - Total cost calculation 

            double totalCost = 0;

            // Processing shopping list; counting items purchased
            foreach (Product item in lstShoppingList)
            {
                // to avoid UI data entry weakness 
                if (item.ProductName != String.Empty)
                    // Updating the property with the last quantity purchased to calc the itens of the current basket 
                    lstProductsToSell[item.ProductID].LastQuantityPurchased = lstProductsToSell[item.ProductID].LastQuantityPurchased + 1;

            }

            // Calc totals costs

            foreach (Product item in lstProductsToSell)
            {
                // If exist any promo discount related with the quantities purchased
                if (item.StockPromo_Buy > 1)
                {
                    //  Calc the discount quantity 
                    int quantityDiscountPromo = item.StockPromo_Buy - item.StockPromo_Pay;

                    // If the item is able to apply the promo/discount
                    if (item.LastQuantityPurchased >= item.StockPromo_Buy)
                        //TODO: is need a round function to avoid run time errors
                        totalCost = totalCost + (item.Price * (item.LastQuantityPurchased - (item.LastQuantityPurchased / item.StockPromo_Buy) * quantityDiscountPromo));
                    else
                        totalCost = totalCost + (item.Price * item.LastQuantityPurchased);
                }
                else
                    totalCost = totalCost + (item.Price * item.LastQuantityPurchased);

                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Total cost of this shopping basket:");
            Console.WriteLine(totalCost.ToString());
            Console.ReadKey();

            #endregion

        }

    }
}
