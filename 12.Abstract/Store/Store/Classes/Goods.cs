using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Classes;

namespace Store.Classes
{
    class Goods : Storage
    {
        /// <summary>
        /// Goods price
        /// </summary>
        public string GoodsPrice
        {
            get => _goodsPrice;
            set
            {
                bool result = Double.TryParse(value, out double isNum);
                if (result)
                {
                    _goodsPrice = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong data!\nValue must be Double ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press Enter key to repeat");
                }
            }
        }

        public string GoodsName { get; set; } 

        public Goods(string receiptSet, string storageTermSet,
            string goodsName, string goodsPrice) : base(receiptSet, storageTermSet)
        {
            GoodsName = goodsName;
            GoodsPrice = goodsPrice;
        }

        private string _goodsPrice;
    }
}
