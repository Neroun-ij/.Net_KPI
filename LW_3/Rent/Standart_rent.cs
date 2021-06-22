using System;
using System.Collections.Generic;
using System.Text;

namespace LW_3.Rent
{
    class Standart_rent : IRent
    {
        public float Days { get; set; }
        public string Type
        {
            get { return "Стандартна оренда"; }
        }

        public Standart_rent(int days = 1)
        {
            this.Days = days;
        }

        public float Count(float price)
        {
            return Days * price;
        }
    }
}
