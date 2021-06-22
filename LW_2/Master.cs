using System;
using System.Collections.Generic;
using System.Text;

namespace LW_2
{
    class Master : ILearner
    {
        public static Status MasterStatus = new Status("University", "---");

        string Educational_Institution;
        string Education_form;
        public void SetEducational_Institution(string title)
        {
            this.Educational_Institution = title;
        }
        public void SetEducation_form(string form)
        {
            this.Education_form = form;
        }
        public override string ToString()
        {
            return string.Format($"Інформація про Магістра:\n{MasterStatus.Educational_Institution_Type} : {Educational_Institution} \n" +
                 $"Форма навчання: {Education_form}\nНаступний етап навчання: {MasterStatus.Next_Step}\n");
        }
    }
}
