using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Classes;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Goods[] goods = new Goods[2];

            var shelf = 0;
            while (true)
            {
                Console.WriteLine("\nPlease, input date of goods receipt:");
                var rDate = Console.ReadLine();
                Console.WriteLine("\nPlease, input store term in days :");
                var sDay = Console.ReadLine();
                Console.WriteLine("\nPlease, input goods name:");
                var gName = Console.ReadLine();
                Console.WriteLine("\nPlease, input price of the goods:");
                var pGoods = Console.ReadLine();
                goods[shelf] = new Goods(rDate, sDay, gName, pGoods);
                if ((!string.IsNullOrWhiteSpace(goods[shelf].ReceiptSet)) &&
                    (!string.IsNullOrWhiteSpace(goods[shelf].StorageTermSet)) &&
                    (!string.IsNullOrWhiteSpace(goods[shelf].GoodsName)) &&
                    (!string.IsNullOrWhiteSpace(goods[shelf].GoodsPrice)))
                {
                    Console.Clear();
                    Console.WriteLine("Do You want to add another goods?\n" +
                        "y - yes; any key - no");
                    var key = Console.ReadLine().ToLower();
                    if (key != "y")
                    {
                        break;
                    }
                    else
                    {
                        if (shelf < goods.Length - 1)
                        {
                            shelf++;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Storage is full!");
                            break;
                        }
                    }
                }
            }
           
            shelf = 1;
            foreach (Goods value in goods)
            {     
                if (value != null)
                {
                    Console.WriteLine("---{0}---", value.GoodsName);
                    Console.WriteLine("Price:{0}UAH", value.GoodsPrice);
                    value.GoodsStoreTermState();
                    Console.WriteLine($"Goods is on shelf #{shelf}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Goods is on shelf #{shelf} is empty");
                }
                shelf++;
            }
        }
    }
}
