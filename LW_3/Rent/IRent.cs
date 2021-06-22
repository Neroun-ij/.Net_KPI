using System;
using System.Collections.Generic;
using System.Text;

namespace LW_3.Rent
{
    interface IRent
    {
        float Days { get; set; }
        string Type { get; }
        float Count(float price);
    }
}
