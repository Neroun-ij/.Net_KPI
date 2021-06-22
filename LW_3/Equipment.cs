using LW_3.Rent;
using System;
using System.Collections.Generic;
using System.Text;

namespace LW_3
{
    class Equipment
    {
        protected IRent Rent;
        public float Price;
        public Equipment(float price)
        {
            Rent = new Standart_rent();
            Price = price;
        }
        public void SetRent(IRent newRentType)
        {
            Rent = newRentType;
        }
        public void CountRent()
        {
            Console.WriteLine("\nОрендувати обладнання на {0} днiв, за умови \"{1}\" буде коштувати: {2}\n", Rent.Days, Rent.Type, Rent.Count(Price));
        }
    }
}
