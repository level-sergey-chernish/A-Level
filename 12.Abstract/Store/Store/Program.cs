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
            Storage[] strg = new Storage[2];

            var goods1 = new Goods("03/03/2018", "23", "Sugar", "45");
            Console.WriteLine("---{0}---", goods1.GoodsName);
            Console.WriteLine("Price:{0}", goods1.GoodsPrice);
            goods1.GoodsStoreTermState();
            Console.WriteLine();

            var goods2 = new Goods("8/5/2018", "4", "Bread", "10.6");
            Console.WriteLine("---{0}---", goods2.GoodsName);
            Console.WriteLine("Price:{0}", goods2.GoodsPrice);
            goods2.GoodsStoreTermState();
            Console.WriteLine();

        }
    }
}
