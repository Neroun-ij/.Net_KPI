using System;

namespace LW_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Абстрактна фабрика
            HomePcFactory homePcFactory = new HomePcFactory();
            OfficePcFactory officePcFactory = new OfficePcFactory();

            Pc HomePc = new Pc(homePcFactory);
            Component[] homeComponents = HomePc.CreatePc();

            var war = string.Empty;
            Console.WriteLine("Home PC");
            foreach (Component el in homeComponents)
            {
                war = el.Info();
                Console.WriteLine(war);
            }


            Pc OfficePc = new Pc(officePcFactory);
            Component[] officeComponents = OfficePc.CreatePc();
            Console.WriteLine("\nOffice PC");
            foreach (Component el in officeComponents)
            {
                war = el.Info();
                Console.WriteLine(war);
            }

            Console.ReadKey();
        }
    }
}
