using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace LW_5
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            string format = new string('-', 25);

            IList<City> cities = new List<City>
            {
                new City("Dnipro", 839, 2884000, "Ukraine"),
                new City("Lviv", 182, 721301, "Ukraine"),
                new City("Odessa", 162,993120, "Ukraine"),
                new City("Kharkiv", 350, 1419000, "Ukraine"),
                new City("Tartu", 39, 93124, "Estonia"),
                new City("Tallinn", 159, 426538, "Estonia")
            };
            IList<Country> countries = new List<Country>
            {
                new Country("Ukraine", "Europe", 603628, 44390000, "UAN", "Ukrainian", "Kyiv"),
                new Country("Estonia", "Europe", 45339, 1325000, "EUR", "Estonian", "Tallinn"),
                new Country("Italy","Europe", 301340, 60360000, "EUR", "Italian", "Rome")
            };
            IList<District> districts = new List<District>
            {
                new District("Holosiivskyi", "Kyiv", 253014, 156.4, "Holosiivskyi avenue, 42"),
                new District("Pechersk", "Kyiv", 240000, 27, "M.Omelyanovich-Pavlenko street, 15"),
                new District("Obolon", "Kyiv", 320000, 110.2, "Marshal Tymoshenko street, 16"),
                new District("Podilskiy", "Kyiv", 200617, 34.04, "Contract area, 2"),
                new District("Galician", "Lviv", 54900, 722, "F.Lista street, 1")
            };
            IList<Region> regions = new List<Region>
            {
                new Region("Kyiv region", "Kyiv", 28121),
                new Region("Lviv region", "Lviv", 21833),
                new Region("Odessa region", "Odessa", 33314),
                new Region("Kharkiv region", "Kharkiv", 31418),
                new Region("Kharkiv region", "Kharkiv", 31418)
            };

            //Запис до файлів
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create("cities.xml", settings))
            {
                writer.WriteStartElement("cities");
                foreach (City city in cities)
                {
                    writer.WriteStartElement("City");
                    writer.WriteElementString("Name", city.name);
                    writer.WriteElementString("Area", city.area.ToString());
                    writer.WriteElementString("Population", city.population.ToString());
                    writer.WriteElementString("Country", city.country);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            using (XmlWriter writer = XmlWriter.Create("countries.xml", settings))
            {
                writer.WriteStartElement("countries");
                foreach (Country country in countries)
                {
                    writer.WriteStartElement("Country");
                    writer.WriteElementString("Name", country.name);
                    writer.WriteElementString("Continent", country.continent);
                    writer.WriteElementString("Area", country.area.ToString());
                    writer.WriteElementString("Population", country.population.ToString());
                    writer.WriteElementString("Currency", country.currency);
                    writer.WriteElementString("Language", country.language);
                    writer.WriteElementString("Capital", country.capital);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            using (XmlWriter writer = XmlWriter.Create("districts.xml", settings))
            {
                writer.WriteStartElement("districts");
                foreach (District district in districts)
                {
                    writer.WriteStartElement("District");
                    writer.WriteElementString("Name", district.name);
                    writer.WriteElementString("District_administration_address", district.district_administration_address);
                    writer.WriteElementString("Area", district.area.ToString());
                    writer.WriteElementString("Population", district.population.ToString());
                    writer.WriteElementString("City", district.city);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            using (XmlWriter writer = XmlWriter.Create("regions.xml", settings))
            {
                writer.WriteStartElement("regions");
                foreach (Region region in regions)
                {
                    writer.WriteStartElement("Region");
                    writer.WriteElementString("Name", region.name);
                    writer.WriteElementString("Regional_center", region.regional_center);
                    writer.WriteElementString("Area", region.area.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            // Зчитування з файлів, вивід змісту в консоль
            XmlDocument doc = new XmlDocument();
            doc.Load("cities.xml");
            foreach (XmlNode node in doc.DocumentElement)
            {

                string Name = node["Name"].InnerText;
                double Area = Double.Parse(node["Area"].InnerText);
                int Population = Int32.Parse(node["Population"].InnerText);
                string Country = node["Country"].InnerText;
            }
            Console.WriteLine(format + " CITIES " + format);
            foreach (XmlNode xnode in doc.DocumentElement) {
                foreach (XmlNode childnode in xnode.ChildNodes) {
                    if (childnode.Name == "Name") {
                        Console.WriteLine($"\t{childnode.InnerText}");
                    }
                    if (childnode.Name == "Area") {
                        Console.WriteLine($"Area: {childnode.InnerText}");
                    }
                    if (childnode.Name == "Population") {
                        Console.WriteLine($"Population: {childnode.InnerText}");
                    }
                    if (childnode.Name == "Country") {
                        Console.WriteLine($"Country: {childnode.InnerText}");
                    }
                }
                Console.WriteLine("\n");
            }

            doc.Load("countries.xml");
            foreach (XmlNode node in doc.DocumentElement) {
                string Name = node["Name"].InnerText;
                string Continent = node["Continent"].InnerText;
                double Area = Double.Parse(node["Area"].InnerText);
                int Population = Int32.Parse(node["Population"].InnerText);
                string Currency = node["Currency"].InnerText;
                string Language = node["Language"].InnerText;
                string Capital = node["Capital"].InnerText;
            }
            Console.WriteLine(format + " COUNTRIES " + format);
            foreach (XmlNode xnode in doc.DocumentElement) {
                foreach (XmlNode childnode in xnode.ChildNodes) {
                    if (childnode.Name == "Name") {
                        Console.WriteLine($"\t{childnode.InnerText}");
                    }
                    if (childnode.Name == "Continent") {
                        Console.WriteLine($"Continent: {childnode.InnerText}");
                    }
                    if (childnode.Name == "Area") {
                        Console.WriteLine($"Area: {childnode.InnerText}");
                    }
                    if (childnode.Name == "Population") {
                        Console.WriteLine($"Population: {childnode.InnerText}");
                    }
                    if (childnode.Name == "Currency") {
                        Console.WriteLine($"Currency: {childnode.InnerText}");
                    }
                    if (childnode.Name == "Language") {
                        Console.WriteLine($"Language: {childnode.InnerText}");
                    }
                    if (childnode.Name == "Capital") {
                        Console.WriteLine($"Capital: {childnode.InnerText}");
                    }
                }
                Console.WriteLine("\n");
            }

            doc.Load("districts.xml");
            foreach (XmlNode node in doc.DocumentElement)
            {

                string Name = node["Name"].InnerText;
                string District_administration_address = node["District_administration_address"].InnerText;
                int Population = Int32.Parse(node["Population"].InnerText);
                double Area = Double.Parse(node["Area"].InnerText);
                string City = node["City"].InnerText;
            }
            Console.WriteLine(format + " DISTRICTS " + format);
            foreach (XmlNode xnode in doc.DocumentElement) {
                foreach (XmlNode childnode in xnode.ChildNodes) {
                    if (childnode.Name == "Name") {
                        Console.WriteLine($"\t{childnode.InnerText}");
                    }
                    if (childnode.Name == "District_administration_address") {
                        Console.WriteLine($"District_administration_address: {childnode.InnerText}");
                    }
                    if (childnode.Name == "Population") {
                        Console.WriteLine($"Population: {childnode.InnerText}");
                    }
                    if (childnode.Name == "Area") {
                        Console.WriteLine($"Area: {childnode.InnerText}");
                    }
                    if (childnode.Name == "City") {
                        Console.WriteLine($"City: {childnode.InnerText}");
                    }
                }
                Console.WriteLine("\n");
            }

            doc.Load("regions.xml");
            foreach (XmlNode node in doc.DocumentElement)
            {

                string Name = node["Name"].InnerText;
                double Area = Double.Parse(node["Area"].InnerText);
                string Regional_center = node["Regional_center"].InnerText;
            }
            Console.WriteLine(format + " REGIONS " + format);
            foreach (XmlNode xnode in doc.DocumentElement)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "Name") {
                        Console.WriteLine($"\t{childnode.InnerText}");
                    }
                    if (childnode.Name == "Regional_center") {
                        Console.WriteLine($"Regional_center: {childnode.InnerText}");
                    }
                    if (childnode.Name == "Area") {
                        Console.WriteLine($"Area: {childnode.InnerText}");
                    }
                }
                Console.WriteLine("\n");
            }

            XDocument xmlDocCity = XDocument.Load("cities.xml");
            foreach (XElement citiesEl in xmlDocCity.Element("cities").Elements("City"))
            {
                XElement Name = citiesEl.Element("Name");
                XElement Area = citiesEl.Element("Area");
                XElement Population = citiesEl.Element("Population");
                XElement Country = citiesEl.Element("Country");
            }

            XDocument xmlDocCountry = XDocument.Load("countries.xml");
            foreach (XElement countriesEl in xmlDocCountry.Element("countries").Elements("Country"))
            {
                XElement Name = countriesEl.Element("Name");
                XElement Сontinent = countriesEl.Element("Сontinent");
                XElement Area = countriesEl.Element("Area");
                XElement Population = countriesEl.Element("Population");
                XElement Сurrency = countriesEl.Element("Сurrency");
                XElement Language = countriesEl.Element("Language");
                XElement Capital = countriesEl.Element("Capital");
            }

            XDocument xmlDocDistrict = XDocument.Load("districts.xml");
            foreach (XElement distriictsEl in xmlDocDistrict.Element("districts").Elements("District"))
            {
                XElement Name = distriictsEl.Element("Name");
                XElement District_administration_address = distriictsEl.Element("District_administration_address");
                XElement Area = distriictsEl.Element("Area");
                XElement Population = distriictsEl.Element("Population");
                XElement City = distriictsEl.Element("City");
            }

            XDocument xmlDocRegion = XDocument.Load("regions.xml");
            foreach (XElement regionsEl in xmlDocRegion.Element("regions").Elements("Region"))
            {
                XElement Name = regionsEl.Element("Name");
                XElement Area = regionsEl.Element("Area");
                XElement Regional_center = regionsEl.Element("Regional_center");
            }
            Console.WriteLine(format + "\n");

            //1 Сортування
            Console.WriteLine("1. Мiста, вiдсортовані в алфавітному порядку: ");
            var q1 = xmlDocCity.Descendants("City").Select(x => x.Element("Name").Value).OrderBy(x => x.Trim());
            foreach (var x in q1)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine(format + "\n");

            //2 Фільтрування
            Console.WriteLine("2. Райони міста Київ:");
            IEnumerable<XElement> q2 =
                from x in xmlDocDistrict.Root.Elements("District")
                where (string)x.Element("City") == "Kyiv"
                select x;
            foreach (var x in q2)
            {
                Console.WriteLine(x.Element("Name").Value);
            }
            Console.WriteLine(format + "\n");

            //3 Іnner join
            Console.WriteLine("3. Населення столиць:");
            var q3 = from x in xmlDocCountry.Root.Elements("Country")
                     from y in xmlDocCity.Root.Elements("City")
                     where x.Element("Capital").Value == y.Element("Name").Value
                     select new
                     {
                         Country = x.Element("Name").Value,
                         Capital = y.Element("Name").Value,
                         Capital_population = y.Element("Population").Value
                     };
            foreach (var x in q3) Console.WriteLine(x);
            Console.WriteLine(format + "\n");

            //4. Outer Join
            Console.WriteLine("4. Мови, на яких розмовляють у містах:");
            var q4 = from x in xmlDocCity.Root.Elements("City")
                     join y in xmlDocCountry.Root.Elements("Country") on x.Element("Country").Value equals y.Element("Name").Value into temp
                     from t in temp.DefaultIfEmpty()
                     select new
                     {
                         City = x.Element("Name").Value,
                         Language = ((t == null) ? "\"No such country mentioned\"" : t.Element("Language").Value)
                     };
            foreach (var x in q4) Console.WriteLine(x);
            Console.WriteLine(format + "\n");

            //5. Distinct()
            Console.WriteLine("5. Вивiд назв областей без дублів:");
            var q5 = (from x in xmlDocRegion.Root.Elements("Region") select x.Element("Name").Value).Distinct();
            foreach (var x in q5) Console.WriteLine(x);
            Console.WriteLine(format + "\n");

            //6. Aggregate()
            var q6 = (from x in xmlDocCity.Root.Elements("City") select Int32.Parse(x.Element("Area").Value)).Aggregate((x, y) => x + y);
            Console.WriteLine("6. Площа всiх мicт = " + q6);
            Console.WriteLine(format + "\n");

            //7. Групування + join
            Console.WriteLine("7. Адреси районних адмiнiстрацiй областних центрiв:");
            var q7 = from x in xmlDocRegion.Root.Elements("Region")
                      join y in xmlDocDistrict.Root.Elements("District") on x.Element("Regional_center").Value equals y.Element("City").Value into temp
                      select new { region = x.Element("Name").Value, Group = temp };
            foreach (var x in q7)
            {
                Console.WriteLine(x.region);
                foreach (var y in x.Group)
                    Console.WriteLine("\tDistrict - {0}\t Address of the district admin.: {1}", y.Element("Name").Value, y.Element("District_administration_address").Value);
            }
            Console.WriteLine(format + "\n");
            //8 Умова + Count()
            var q8 = (from x in xmlDocRegion.Root.Elements("Region")
                       where (int)(x.Element("Area")) < 31000
                       select Int32.Parse(x.Element("Area").Value)).Count();
            Console.WriteLine("8. Кількiсть областей, площа яким менша за 31,000 = " + q8);
            Console.WriteLine(format + "\n");

            //9 Group join
            Console.WriteLine("9. Міста, згруповані по мові країни:");
            var q9 = from x in xmlDocCountry.Root.Elements("Country")
                     join y in xmlDocCity.Root.Elements("City") on x.Element("Name").Value equals y.Element("Country").Value into temp
                     select new { lang = x.Element("Language").Value, Group = temp };
            foreach (var x in q9)
            {
                Console.WriteLine(x.lang + "-speaking cities:");
                foreach (var y in x.Group)
                    Console.WriteLine("\t" + y.Element("Name").Value);
            }
            Console.WriteLine(format + "\n");

            //10 All()
            bool q10 = (from x in xmlDocCountry.Root.Elements("Country")
                       select (x.Element("Continent").Value)).All(x =>x == "Europe");
            if (q10)
                Console.WriteLine("10. Only European countries are listed.");
            else
                Console.WriteLine("10. Not only European countries are listed.");
        }
        class City
        {
            public string name { get; set; }
            public double area { get; set; }
            public int population { get; set; }
            public string country { get; set; }
            public City (string name, double area, int population, string country)
            {
                this.name = name;
                this.area = area;
                this.population = population;
                this.country = country;
            }
        }
        class Country
        {
            public string name { get; set; }
            public string continent { get; set; }
            public double area { get; set; }
            public int population { get; set; }
            public string currency { get; set; }
            public string language { get; set; }
            public string capital { get; set; }
            public Country(string name, string continent, double area, int population, string currency, string language, string capital)
            {
                this.name = name;
                this.area = area;
                this.continent = continent;
                this.population = population;
                this.currency = currency;
                this.language = language;
                this.capital = capital;
            }
        }
        class District
        {
            public string name { get; set; }
            public string district_administration_address { get; set; }
            public int population { get; set; }
            public double area { get; set; }
            public string city { get; set; }
            public District(string name, string city, int population, double area, string district_administration_address)
            {
                this.name = name;
                this.district_administration_address = district_administration_address;
                this.area = area;
                this.population = population;
                this.city = city;
            }
        }
        class Region
        {
            public string name { get; set; }
            public double area { get; set; }
            public string regional_center { get; set; }
            public Region(string name, string regional_center, double area)
            {
                this.name = name;
                this.area = area;
                this.regional_center = regional_center;
            }
        }
    }
}
