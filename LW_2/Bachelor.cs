using System;
using System.Collections.Generic;
using System.Text;

namespace LW_2
{
    class Bachelor : ILearner
    {
        public static Status BachelorStatus = new Status("University", "Master");

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
            return string.Format($"Інформація про Бакалавра:\n{BachelorStatus.Educational_Institution_Type} : {Educational_Institution} \n" +
                $"Форма навчання: {Education_form}\nНаступний етап навчання: {BachelorStatus.Next_Step}\n");
        }
    }
}
