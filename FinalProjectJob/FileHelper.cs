using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectJob
{
    class FileHelper
    {
        public void WriteEmployeesToFile(string fileName, List<Employee> employees)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(fileName))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, employees);
                }
            }
        }
        public void ReadEmployeesFromFile(string fileName)
        {
            List<Employee> employees = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(fileName))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    employees = serializer.Deserialize<List<Employee>>(jr);
                }
                foreach (var item in employees)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void WriteEmployersToFile(string fileName, List<Employer> employers)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(fileName))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, employers);
                }
            }
        }
        public void ReadEmployersFromFile(string fileName)
        {
            List<Employer> employers = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(fileName))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    employers = serializer.Deserialize<List<Employer>>(jr);
                }
                foreach (var item in employers)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void WriteVacanciesToFile(string fileName, List<Vacancy> vacancies)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(fileName))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, vacancies);
                }
            }
        }
        public void ReadVacanciesFromFile(string fileName)
        {
            List<Vacancy> vacancies = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(fileName))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    vacancies = serializer.Deserialize<List<Vacancy>>(jr);
                }
                foreach (var item in vacancies)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void WriteCVsToFile(string fileName, List<CV> CVs)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(fileName))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, CVs);
                }
            }
        }
        public void ReadCVsFromFile(string fileName)
        {
            List<CV> CVs = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(fileName))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    CVs = serializer.Deserialize<List<CV>>(jr);
                }
                foreach (var item in CVs)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void WriteExceptionsToFile(Exception ex)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("ErrorLog.json", true))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, ex);
                }
            }
        }
        public void WriteVacanciesToBidList(string fileName,Vacancy vacancy)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(fileName,true))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, vacancy);
                }
            }
        }
        public void ReadVacanciesFromBidList(string fileName)
        {
            List<Vacancy> vacancies = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(fileName))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    vacancies = serializer.Deserialize<List<Vacancy>>(jr);
                }
                foreach (var item in vacancies)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
