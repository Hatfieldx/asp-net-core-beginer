

namespace lesson1
{
    public class Company
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int EmployeCount { get; set; }

        public override string ToString()
        {
            return $"Company {Name}, from {Country}. Employe are working {EmployeCount}";
        }

        public Company(string name, string country, int pplcount)
        {
            Name = name;
            Country = country;
            EmployeCount = pplcount;
        }
    }
}
