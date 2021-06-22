using System;
using System.Collections.Generic;
using System.Text;

namespace LW_1
{
    public abstract class PcFactory
    {
        public abstract Box CreateBox();
        public abstract Processor CreateProcessor();
        public abstract MainBoard CreateMainBoard();
        public abstract HDD CreateHDD();
        public abstract Memory CreateMemory();
    }

    public class HomePcFactory : PcFactory
    {
        public override Box CreateBox()
        {
            return new HomeBox();
        }
        public override Processor CreateProcessor()
        {
            return new HomeProcessor();
        }
        public override MainBoard CreateMainBoard()
        {
            return new HomeMainBoard();
        }
        public override HDD CreateHDD()
        {
            return new HomeHDD();
        }
        public override Memory CreateMemory()
        {
            return new HomeMemory();
        }
    }

    public class OfficePcFactory : PcFactory
    {
        public override Box CreateBox()
        {
            return new OfficeBox();
        }
        public override Processor CreateProcessor()
        {
            return new OfficeProcessor();
        }
        public override MainBoard CreateMainBoard()
        {
            return new OfficeMainBoard();
        }
        public override HDD CreateHDD()
        {
            return new OfficeHDD();
        }
        public override Memory CreateMemory()
        {
            return new OfficeMemory();
        }
    }
}
