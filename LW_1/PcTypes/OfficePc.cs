using System;
using System.Collections.Generic;
using System.Text;

namespace LW_1
{
    public class OfficeBox : Box
    {
        public override string Info()
        {
            return "office box";
        }
    }

    public class OfficeProcessor : Processor
    {

        public override string Info()
        {
            return "office process";
        }
    }

    public class OfficeMainBoard : MainBoard
    {
        public override string Info()
        {
            return "office board";
        }
    }
    public class OfficeHDD : HDD
    {

        public override string Info()
        {
            return "office hdd";
        }
    }

    public class OfficeMemory : Memory
    {
        public override string Info()
        {
            return "office memory";
        }
    }
}
