using System;
using System.Collections.Generic;
using System.Text;

namespace LW_2
{
    class Schoolchild : ILearner
    {
        public static Status SchoolchildStatus = new Status("School", "Bachelor");

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
            return string.Format($"Інформація про Школяра:\n{SchoolchildStatus.Educational_Institution_Type} : {Educational_Institution} \n" +
                $"Форма навчання: {Education_form}\nНаступний етап навчання: {SchoolchildStatus.Next_Step}\n");
        }
    }
}
