using System;
using System.Collections.Generic;
using System.Linq;

namespace LW_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>
            {
                new City{name = "Kyiv",    area = 839,   population = 2884000, country ="Ukraine"},
                new City{name = "Lviv",    area = 182,   population = 721301,  country ="Ukraine"},
                new City{name = "Odessa",  area = 162,   population = 993120,  country ="Ukraine"},
                new City{name = "Kharkiv", area = 350,   population = 1419000, country ="Ukraine"},
                new City{name = "Tartu",   area = 39,  population = 93124,   country ="Estonia"},
                new City{name = "Tallinn", area = 159, population = 426538,  country ="Estonia"}
            };
            List<Country> countries = new List<Country>
            {
                new Country{name = "Ukraine", continent = "Europe", area = 603628, population = 44390000, currency = "UAN", language = "Ukrainian", capital= "Kyiv"},
                new Country{name = "Estonia", continent = "Europe", area = 45339,  population = 1325000,  currency = "EUR", language = "Estonian",  capital= "Tallinn"},
                new Country{name = "Italy",   continent = "Europe", area = 301340,  population = 60360000,  currency = "EUR", language = "Italian",  capital= "Rome"}
            };
            List<District> districts = new List<District>
            {
                new District{name = "Holosiivskyi", city ="Kyiv", population = 253014, area = 156.4, district_administration_address ="Holosiivskyi avenue, 42"},
                new District{name = "Pechersk",     city ="Kyiv", population = 240000, area = 27,    district_administration_address ="M.Omelyanovich-Pavlenko street, 15"},
                new District{name = "Obolon",       city ="Kyiv", population = 320000, area = 110.2, district_administration_address ="Marshal Tymoshenko street, 16"},
                new District{name = "Podilskiy",    city ="Kyiv", population = 200617, area = 34.04, district_administration_address ="Contract area, 2"},
                new District{name = "Galician",     city ="Lviv", population = 54900, area = 722, district_administration_address ="F.Lista street, 1"}
            };
            List<Region> regions = new List<Region>
            {
                new Region{name = "Kyiv region",    regional_center = "Kyiv",    area = 28121},
                new Region{name = "Lviv region",    regional_center = "Lviv",    area = 21833},
                new Region{name = "Odessa region",  regional_center = "Odessa",  area = 33314},
                new Region{name = "Kharkiv region", regional_center = "Kharkiv", area = 31418}
            };
            Console.WriteLine("1.\n");
            // 1. Вибір всіх країн; вивід їх назв та континентів
            var q1 = from x in countries
                     select x;
            foreach (var x in q1)
                Console.WriteLine("Country: {0}\tContinent: {1}", x.name, x.continent);

            Console.WriteLine(new string('-', 80) + Environment.NewLine + "2.\n");

            // 2. Вибір всіх міст України, сортування в алфавітному порядку; вивiд їх назв та площ
            var q2 = from x in cities
                     where x.country == "Ukraine"
                     orderby x.name ascending
                     select x;
            foreach (var x in q2)
                Console.WriteLine("City: {0}\tArea: {1}", x.name, x.area);

            Console.WriteLine(new string('-', 80) + Environment.NewLine + "3.\n");

            //
            // 3. Вибір всіх районів з площею менше 150, сортування в алфаіфтному порядку; вивід їх назв та площ
            var q3 = districts.Where((x) => { return x.area < 150; }).OrderBy(x => x.name);
            foreach (var x in q3) 
                Console.WriteLine("City: {0}\t    Area: {1}", x.name, x.area);

            Console.WriteLine(new string('-', 80) + Environment.NewLine + "4.\n");

            // 4. Inner Join, вибір назв столичних районів для всіх країн та назв самих країн
            var q4 = from x in countries
                     from y in districts
                     where x.capital == y.city
                     select new { country = x.name, capital_region = y.name };
            foreach (var x in q4)
                Console.WriteLine("Country: {0}\tDistrict: {1}", x.country, x.capital_region);

            Console.WriteLine(new string('-', 80) + Environment.NewLine + "5.\n");

            //
            //5. Вибір назв для всіх областей та площ їх обласних центрів
            var q5 = regions.Join(cities, x => x.regional_center, y => y.name, 
             (x, y) => new { region = x.name, regional_center_area = y.area });
            foreach (var x in q5)
                Console.WriteLine("Region: {0}\tArea of regional center: {1}", x.region, x.regional_center_area);

            Console.WriteLine(new string('-', 80) + Environment.NewLine + "6.\n");

            // 6. Вибір міст,згрупованих по країнам (з групи створюємо новий об'єкт)
            var q6 = from x in cities
                      group x by x.country into g
                      select new {Key = g.Key, Values = g};
            foreach (var x in q6)
            {
                Console.Write( "Сities of the country {0}: ", x.Key);
                foreach (var y in x.Values)
                    Console.Write(y.name + " || ");
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine(new string('-', 80) + Environment.NewLine + "7.\n");

            //
            // 7. Вибір країн, згрупованих по валюті (з групи створюємо новий об'єкт)
            var q7 = countries.GroupBy(x => x.currency)
                        .Select(g => new { Currency = g.Key, Countries = g.Select(x => x) });
            foreach (var x in q7)
            {
                Console.Write("Сities with the currency {0}: ", x.Currency);
                foreach (var y in x.Countries)
                    Console.Write(y.name + " || ");
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine(new string('-', 80) + Environment.NewLine + "8.\n");

            //
            //8. Перевірити методом All чи всі представлені країни розташовано на континенті Європа
            bool q8 = countries.All(u => u.continent == "Europe");
            if (q8)
                Console.WriteLine("Only European countries are listed.");
            else
                Console.WriteLine("Not only European countries are listed.");

            Console.WriteLine(new string('-', 80) + Environment.NewLine + "9.\n");

            // 9. Відкладене виконання запиту. Вибір областей, назва яких починається на букву П в алфавітному порядку; вивід назв та населення
           
            var q9 = from x in districts 
                     where x.name.ToUpper().StartsWith("P")
                     orderby x.name ascending
                     select x;
            foreach (var x in q9)
                Console.WriteLine("District: {0}\tPopulation: {1}", x.name, x.population);

            foreach (var district in districts)
                if(district.name == "Pechersk")
                    district.population += 1;

            Console.Write(Environment.NewLine);
            foreach (var x in q9)
                Console.WriteLine("District: {0}\tPopulation: {1}", x.name, x.population);

            Console.WriteLine(new string('-', 80) + Environment.NewLine + "10.\n");

            // 10. Термінове виконання запиту. Обрахунок кількості регіонів, площа яких менша за 31000
            var q10 = (from x in regions
                     where x.area < 31000
                     select x).Count();
            Console.WriteLine("Number of regions with an area of less than 31,000 = " + q10);

            foreach (var region in regions)
                if (region.name == "Kharkiv region")
                    region.area -= 500;
            Console.WriteLine("Number of regions with an area of less than 31,000 = " + q10);

            Console.WriteLine(new string('-', 80) + Environment.NewLine + "11.\n");

            //*методи розширення*
            // 11. Агрегація. Сума площ естонських міст

            var q11 = cities.Where((cities) => { return cities.country == "Estonia"; }).Select(x => x.area).Aggregate((x, y) => x + y);
            Console.WriteLine("The sum of the areas of Estonian cities = " + q11);

            Console.WriteLine(new string('-', 80) + Environment.NewLine + "12.\n");

            // 12. Group join. Адреси районних адміністрацій областних центрів
            var q12 = from x in regions
                      join y in districts on x.regional_center equals y.city into temp
                      select new { name = x.name, Group = temp };
            foreach (var x in q12)
            {
                Console.WriteLine(x.name);
                foreach (var y in x.Group)
                    Console.WriteLine("\tDistrict - {0}\t Address of the district admin.: {1}", y.name, y.district_administration_address);
            }

            Console.WriteLine(new string('-', 80) + Environment.NewLine + "13.\n");

            //
            // 13. Group join. Міста, згруповані по мові країни.
            var q13 = countries.GroupJoin(cities, x => x.name, y => y.country,
                        (x, y) => new  
                        {
                            Language = x.language,
                            City = y.Select(p => p.name)
                        });
            foreach (var team in q13)
            {
                Console.WriteLine(team.Language + "-speaking cities:");
                foreach (string city in team.City) {
                    Console.WriteLine("\t" + city);
                }
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 80) + Environment.NewLine + "14.\n");

            // 14. ToDictionary(). Словник [Країна : столиця]
            var q14 = (from x in countries select x).ToDictionary(x => x.name, x => x.capital);
            foreach (var x in q14) 
                Console.WriteLine(x);

            Console.WriteLine(new string('-', 80) + Environment.NewLine + "15.\n");

            // 15. Поміщення логіки в окремий метод переводу квадратних км в гектари. Агрегація суми площ міст
            var q15 = (cities.Select(x => x.area)).Select(square_km_into_ha).Aggregate((x, y) => x + y);

                Console.WriteLine("Total area of all cities in hectares = " + q15);

            Console.ReadKey();
        }
        static double square_km_into_ha(double x)
        {
            return x*100;
        }
    }
}
