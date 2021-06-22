using System;
using System.Collections.Generic;
using System.Text;

namespace LW_3.Rent
{
    class Рentaly_Rent : IRent
    {
        public float Days { get; set; }
        public string Type
        {
            get { return "Штрафна оренда"; }
        }

        public Рentaly_Rent(int days = 1)
        {
            this.Days = days;
        }

        public float Count(float price)
        {
            return Days * price * 1.1f;
        }
    }
}
