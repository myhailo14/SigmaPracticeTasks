using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Area { get; set; }

        public static int NameComparator(City city1, City city2)
        {
            return string.CompareOrdinal(city1.Name, city2.Name);
        }

        public static int PopulationComparator(City city1, City city2)
        {
            if (city1.Population < city2.Population) return -1;
            if (city1.Population > city2.Population) return 1;
            return 0;
        }
        public static int AreaComparator(City city1, City city2)
        {
            if (city1.Area < city2.Area) return -1;
            if (city1.Area > city2.Area) return 1;
            return 0;
        }

        public City()
        {
            Name = "Default";
            Population = 1;
            Area = 1;
        }

        public City(string name, int population, int area)
        {
            Name = name;
            Population = population;
            Area = area;
        }

        public override string ToString() => $"City info:\n Name - {Name}\n Population - {Population}\n Area - {Area}\n";
    }
}
