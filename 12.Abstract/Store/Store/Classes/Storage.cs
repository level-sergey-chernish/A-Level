using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Classes;

namespace Store.Classes
{
    public abstract class Storage
    {
        /// <summary>
        /// Date of receipt of goods to storage
        /// </summary>
        public virtual string ReceiptSet
        {
            get => _receiptSet;
            set
            {
                bool result = DateTime.TryParse(value, out DateTime isDate);
                if (result) {
                    _receiptSet = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong data!\nValue must be in date format dd/mm/yyyy\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press Enter key to repeat");
                }
            }
        }

        /// <summary>
        /// Term of store of the goods
        /// </summary>
        public virtual string StorageTermSet
        { 
            get => _storageTermSet;
            set
            {
                bool result = int.TryParse(value, out int isNum);
                if (result) {
                    _storageTermSet = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong data!\nValue must be integer ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press Enter key to repeat");
                }
            }
        }

        public Storage(string receiptSet, string storageTermSet)
        {
            ReceiptSet = receiptSet;
            StorageTermSet = storageTermSet;
        }


        /// <summary>
        /// Calculate "is goods fine to store?";
        /// </summary>
        protected void _GoodsStoreTermState()
        {
            DateTime receiptDate, currentDate, storageTermEndDate;
            double deltaDate;
            receiptDate = Convert.ToDateTime(ReceiptSet);
            storageTermEndDate = receiptDate.AddDays(Convert.ToInt32(StorageTermSet));
            currentDate = DateTime.Now;
            deltaDate = Math.Abs(Math.Round((currentDate - storageTermEndDate).TotalDays));
            if (currentDate > storageTermEndDate)
            {
                Console.WriteLine("This goods was accepted on {0:dd/MM/yyyy}", receiptDate);
                Console.WriteLine("This goods was good up to {0:dd/MM/yyyy}", storageTermEndDate);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Goods is not good now - it is bad {deltaDate} days\n" +
                    $"You can to get diarrhea!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("This goods was accepted on {0:dd/MM/yyyy}", receiptDate);
                Console.WriteLine("Goods will be fresh near {0} days up to {1:dd/MM/yyyy}", deltaDate, storageTermEndDate);
            }

        }

        public void GoodsStoreTermState()
        {
            _GoodsStoreTermState();
        }

        private string _receiptSet;
        private string _storageTermSet;

    }
}