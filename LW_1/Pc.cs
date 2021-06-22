using System;
using System.Collections.Generic;
using System.Text;

namespace LW_1
{
    public class Pc
    {
        private PcFactory _pcFactory;
        private Component[] _pc;
        public Pc(PcFactory parFactory)
        {
            _pcFactory = parFactory;
        }
        public Component[] CreatePc()
        {
            _pc = new Component[5];
            _pc[0] = _pcFactory.CreateBox();
            _pc[1] = _pcFactory.CreateHDD();
            _pc[2] = _pcFactory.CreateMainBoard();
            _pc[3] = _pcFactory.CreateMemory();
            _pc[4] = _pcFactory.CreateProcessor();
            return _pc;
        }
    }
}
