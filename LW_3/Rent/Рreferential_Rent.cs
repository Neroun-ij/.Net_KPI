using System;
using System.Collections.Generic;
using System.Text;

namespace LW_3.Rent
{
    class Рreferential_Rent : IRent
    {
        public float Days { get; set; }
        public string Type
        {
            get { return "Пiльгова оренда"; }
        }

        public Рreferential_Rent(int days = 7)
        {
            if (days < 7)
            {
                throw new Exception("Пiльгова оренда доступна лише вiд 7 днiв оренди!");
            }
            else
            {
                this.Days = days;
            }
            
        }

        public float Count(float price)
        {
            return Days * price * 0.9f;
        }
    }
}
