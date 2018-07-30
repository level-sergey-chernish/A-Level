using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CarsShop
{
    public partial class CarsRepo
    {
        private double _price;

        private string _color;

        private string _model;
        
        private double Discount(double _num)
        {
            double _discountValue;
            double _percentDiscount = _num;
            _discountValue = _price * _percentDiscount * 0.01;
            return _discountValue;
        }

        private bool StringValidation(string _str, bool _bool)
        {
            string _strValid = _str;
            bool _andNum = _bool;
            bool _result = true;

            if (_andNum)
            {
                Regex _regEx = new Regex(@"^(?!\s)[a-zA-Z 0-9_.-]{2,15}$");
                if ((String.IsNullOrEmpty(_strValid)) ||
                    !_regEx.IsMatch(_strValid))
                {
                    _result = false;
                }
            }
            else
            {
                Regex _regEx = new Regex(@"^(?!\s)[a-zA-Z]{3,10}$");
                if ((String.IsNullOrEmpty(_strValid)) ||
                    !_regEx.IsMatch(_strValid))
                {
                    _result = false;
                }
            }

            return _result;
        }
    }
}
