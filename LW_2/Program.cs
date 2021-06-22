using System;

namespace LW_2
{
    public enum LearnerType
    {
        Schoolchild,
        Bachelor,
        Master
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ILearner Schoolchild = LearnersFactory.GetPlanetoryObject(LearnerType.Schoolchild);
            Schoolchild.SetEducational_Institution("Спеціалізована школа №181 ім. І.Д. Кудрі");
            Schoolchild.SetEducation_form("Денна");
            Console.WriteLine(Schoolchild);

            ILearner Bachelor = LearnersFactory.GetPlanetoryObject(LearnerType.Bachelor);
            Bachelor.SetEducational_Institution("Київський політехнічний інститут імені Ігоря Сікорського");
            Bachelor.SetEducation_form("Очна");
            Console.WriteLine(Bachelor);

            ILearner Master = LearnersFactory.GetPlanetoryObject(LearnerType.Master);
            Master.SetEducational_Institution("Київський політехнічний інститут імені Ігоря Сікорського");
            Master.SetEducation_form("Заочна");
            Console.WriteLine(Master);

            ILearner Schoolchild2 = LearnersFactory.GetPlanetoryObject(LearnerType.Schoolchild);
            Schoolchild2.SetEducational_Institution("Києво-Печерський ліцей №171");
            Schoolchild2.SetEducation_form("Денна");

            Console.WriteLine(Schoolchild2);

            Console.ReadKey();
        }
    }
}
