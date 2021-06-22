using System;
using System.Collections.Generic;
using System.Text;

namespace LW_1
{
    public class HomeBox : Box
    {
        public override string Info()
        {
            return "Home box";
        }
    }

    public class HomeProcessor : Processor
    {

        public override string Info()
        {
            return "Home process";
        }
    }

    public class HomeMainBoard : MainBoard
    {
        public override string Info()
        {
            return "Home board";
        }
    }
    public class HomeHDD : HDD
    {

        public override string Info()
        {
            return "Home hdd";
        }
    }

    public class HomeMemory : Memory
    {
        public override string Info()
        {
            return "Home memory";
        }
    }
}
