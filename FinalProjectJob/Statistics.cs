using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectJob
{
    class Statistics
    {
        public Employee employee { get; set; }
        public Employer employer { get; set; }


        public void CalculateTotalVacancies(Employer employer)
        {
            var count = employer.vacancies.Count();
            Console.WriteLine(count);
        }
        public void CalculateTotalAcceptedCVs(Employer employer)
        {
            var count = employer.AcceptedCVs.Count();
            Console.WriteLine(count);
        }
        public void CalculateTotalRefusedCVs(Employer employer)
        {
            var count = employer.RefusedCVs.Count();
            Console.WriteLine(count);
        }

        public void CalculateTotalCVs(Employee employee)
        {
            var count = employee.CVs.Count();
            Console.WriteLine(count);
        }
        public void CalculateTotalBids(Employee employee)
        {
            var count = employee.BidList.Count();
            Console.WriteLine(count);
        }
    }
}
