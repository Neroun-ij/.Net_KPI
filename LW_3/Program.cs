using LW_3.Rent;
using System;

namespace LW_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Equipment Сamera = new Equipment(1200);
            Equipment Reflector = new Equipment(300);
            Equipment Flash = new Equipment(590);

            bool alive = true;
            while (alive)
            {
                Console.WriteLine("\nОберiть номер обладнання: \n1.Фотоапарат - {0} грн/добу \n2.Свiтловiдбивач - {1} грн/добу \n3.Спалах - {2} грн/добу\n",
                                  Сamera.Price, Reflector.Price, Flash.Price);
                int Equipment = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nОберiть спосiб оренди обладнання: \n1.Стандартне\n2.Штрафне\n3.Пiльгове \n");
                int RentType = Convert.ToInt32(Console.ReadLine());
                
                if(RentType == 3)
                {
                    Console.WriteLine("\nЗауважте, що пiльгова оренда доступна лише вiд 7 днiв!");
                }
                Console.WriteLine("Введiть к-ть днiв оренди обладнання: ");
                int RentDays = Convert.ToInt32(Console.ReadLine());

                switch (Equipment)
                {
                    case 1:
                        if (RentType == 2) {
                            Сamera.SetRent(new Рentaly_Rent(RentDays));
                        }
                        else if (RentType == 3) {
                            Сamera.SetRent(new Рreferential_Rent(RentDays));
                        }
                        else {
                            Сamera.SetRent(new Standart_rent(RentDays));
                        }
                        Сamera.CountRent();
                        break;
                    case 2:
                        if (RentType == 2) {
                            Reflector.SetRent(new Рentaly_Rent(RentDays));
                        }
                        else if (RentType == 3) {
                            Reflector.SetRent(new Рreferential_Rent(RentDays));
                        }
                        else {
                            Reflector.SetRent(new Standart_rent(RentDays));
                        }
                        Reflector.CountRent();
                        break;
                    case 3:
                        if (RentType == 2) {
                            Flash.SetRent(new Рentaly_Rent(RentDays));
                        }
                        else if (RentType == 3) {
                            Flash.SetRent(new Рreferential_Rent(RentDays));
                        }
                        else {
                            Flash.SetRent(new Standart_rent(RentDays));
                        }
                        Flash.CountRent();
                        continue;
                }
            }
            Console.ReadKey();
        }
    }
}
 