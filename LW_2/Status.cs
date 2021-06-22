using System;
using System.Collections.Generic;
using System.Text;

namespace LW_2
{
    class Status
    {
        public string Educational_Institution_Type;
        public string Next_Step;
        public Status(string Educational_Institution_Type, string Next_Step)
        {
            this.Educational_Institution_Type = Educational_Institution_Type;
            this.Next_Step = Next_Step;
        }
    }
}
