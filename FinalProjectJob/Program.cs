using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProjectJob
{
    class Program
    {
        public static string SignIN(List<Employee> employees, List<Employer> employers, string username, string password)
        {
            foreach (var item in employees)
            {
                if (item.Username == username)
                {
                    if (item.Password == password)
                    {
                        return "employee";
                    }
                }
            }
            foreach (var item in employers)
            {
                if (item.Username == username)
                {
                    if (item.Password == password)
                    {
                        return "employer";
                    }
                }
            }
            return "";
        }
        static void SendNottificationToEmployee(Employee employee, string choice)
        {
            if (choice == "accept")
            {
                employee.Nottifications.Add($"Your CV was accepted!");
            }
            else if (choice == "refuse")
            {
                employee.Nottifications.Add("Your CV was refused!");
            }
            else
            {
                Console.WriteLine("Wrong Input!");
            }
        }

        static Employee FindEmployee(List<Employee> employees, string username)
        {
            Employee employee = new Employee();
            foreach (var item in employees)
            {
                if (item.Username == username)
                {
                    return item;
                }
            }
            return employee;
        }
        static Employer FindEmployer(List<Employer> employers, string username)
        {
            Employer employer = new Employer();
            foreach (var item in employers)
            {
                if (item.Username == username)
                {
                    return item;
                }
            }
            return employer;
        }
        static Employer FindEmployerByVacancyID(List<Employer> employers, int id)
        {
            Employer employer = new Employer();
            foreach (var itemEmployer in employers)
            {
                foreach (var itemVacancy in itemEmployer.vacancies)
                {
                    if (id == itemVacancy.ID)
                    {
                        return itemEmployer;
                    }
                }
            }
            return employer;
        }
        static Employee FindEmployeeByID(List<Employee> employees, int id)
        {
            Employee employee = new Employee();
            foreach (var itemEmployee in employees)
            {
                foreach (var item in itemEmployee.CVs)
                {
                    if (id == item.ID)
                    {
                        return itemEmployee;
                    }
                }
            }
            return employee;
        }


        static void Main(string[] args)
        {
            FileHelper fh = new FileHelper();
            List<Employee> employees = fh.ReadEmployeesFromFile("Employees.json");
            List<Employer> employers = fh.ReadEmployersFromFile("Employers.json");

            #region EmployeeAndEmployer

            //Employee employee1 = new Employee
            //{
            //    Name = "Zaur",
            //    Surname = "Jafarov",
            //    Age = 19,
            //    PhoneNumber = "+994553467069",
            //    City = City.Baku,
            //    Email = "zaurcfr@gmail.com",
            //    Username = "zaurcfr",
            //    Password = "zaur123"
            //};
            //Employee employee2 = new Employee
            //{
            //    Name = "Sweet",
            //    Surname = "Johnson",
            //    Age = 28,
            //    PhoneNumber = "+994558763267",
            //    City = City.LosAngeles,
            //    Email = "sweetj@gmail.com",
            //    Username = "sweet",
            //    Password = "johnsonboy1"
            //};
            //Employee employee3 = new Employee
            //{
            //    Name = "Ken",
            //    Surname = "Rosenberg",
            //    Age = 30,
            //    PhoneNumber = "+994706754857",
            //    City = City.Baku,
            //    Email = "rosenberg@gmail.com",
            //    Username = "krose",
            //    Password = "kenrosie91"
            //};
            //Employee employee4 = new Employee
            //{
            //    Name = "Sonny",
            //    Surname = "Forelli",
            //    Age = 32,
            //    PhoneNumber = "+994774567824",
            //    City = City.Baku,
            //    Email = "sonny_forelli@gmail.com",
            //    Username = "sonnyf",
            //    Password = "forelli1m"
            //};
            //Employee employee5 = new Employee
            //{
            //    Name = "Salvatore",
            //    Surname = "Leone",
            //    Age = 43,
            //    PhoneNumber = "+994554987395",
            //    City = City.NewYork,
            //    Email = "bossleone@gmail.com",
            //    Username = "salvatoretheboss",
            //    Password = "salvatore123"
            //};
            //Employee employee6 = new Employee
            //{
            //    Name = "Employee",
            //    Surname = "Employee",
            //    Age = 20,
            //    PhoneNumber = "+994551234567",
            //    City = City.Baku,
            //    Email = "employee@gmail.com",
            //    Username = "employee",
            //    Password = "employee"
            //};
            //employees.Add(employee1);
            //employees.Add(employee2);
            //employees.Add(employee3);
            //employees.Add(employee4);
            //employees.Add(employee5);
            //employees.Add(employee6);
            //CV cv1 = new CV
            //{
            //    Profession = "Developer",
            //    SchoolNO = "THL",
            //    Score = 522,
            //    Skills = "C++, C#",
            //    Companies = "Step IT, SMTH",
            //    StartTime = DateTime.Now,
            //    EndTime = DateTime.Now,
            //    Languages = "Azerbaijani,English,Turkish",
            //    Certificate = true,
            //    GitHub = "github.com/zaurcfr",
            //    LinkedIn = "linkedin.com/zaurcfr"
            //};
            //CV cv2 = new CV
            //{
            //    Profession = "Marketing",
            //    SchoolNO = "LA School",
            //    Score = 674,
            //    Skills = "smth",
            //    Companies = "Marketing Comp.",
            //    StartTime = DateTime.Now,
            //    EndTime = DateTime.Now,
            //    Languages = "English,Russian",
            //    Certificate = true,
            //    GitHub = "github.com/sweetj",
            //    LinkedIn = "linkedin.com/sweetj"
            //};
            //CV cv3 = new CV
            //{
            //    Profession = "Marketing",
            //    SchoolNO = "Law School",
            //    Score = 690,
            //    Skills = "Lawyer skills",
            //    Companies = "Lawyer Comp.",
            //    StartTime = DateTime.Now,
            //    EndTime = DateTime.Now,
            //    Languages = "Azerbaijani,Turkish,English,Russian",
            //    Certificate = true,
            //    GitHub = "github.com/krosie",
            //    LinkedIn = "linkedin.com/krosie"
            //};
            //CV cv4 = new CV
            //{
            //    Profession = "Designer",
            //    SchoolNO = "Design School",
            //    Score = 456,
            //    Skills = "Photoshop",
            //    Companies = "Design Comp.",
            //    StartTime = DateTime.Now,
            //    EndTime = DateTime.Now,
            //    Languages = "Azerbaijani,English",
            //    Certificate = true,
            //    GitHub = "github.com/sonnyf",
            //    LinkedIn = "linkedin.com/sonnyf"
            //};
            //CV cv5 = new CV
            //{
            //    Profession = "Writing",
            //    SchoolNO = "NY School",
            //    Score = 543,
            //    Skills = "Some Writing skills",
            //    Companies = "Writer Comp.",
            //    StartTime = new DateTime(2015, 10, 5),
            //    EndTime = new DateTime(2019, 5, 3),
            //    Languages = "Azerbaijani,English,Russian,Mexicano",
            //    Certificate = true,
            //    GitHub = "github.com/salvatore",
            //    LinkedIn = "linkedin.com/salvatore"
            //};
            //CV cv6 = new CV
            //{
            //    Profession = "Informasion Technologies",
            //    SchoolNO = "IT School",
            //    Score = 538,
            //    Skills = "Network, Windows Server",
            //    Companies = "IT Comp.",
            //    StartTime = new DateTime(2018, 07, 13),
            //    EndTime = new DateTime(2020, 12, 12),
            //    Languages = "Azerbaijani,English,Russian",
            //    Certificate = true,
            //    GitHub = "github.com/sweetj",
            //    LinkedIn = "linkedin.com/sweetj"
            //};
            //employee1.AddCV(cv1);
            //employee2.AddCV(cv2);
            //employee3.AddCV(cv3);
            //employee4.AddCV(cv4);
            //employee5.AddCV(cv5);
            //employee6.AddCV(cv6);

            //Employer employer1 = new Employer
            //{
            //    Name = "Zaur",
            //    Surname = "Jafarov",
            //    Age = 19,
            //    PhoneNumber = "+994553467069",
            //    City = City.Baku,
            //    Email = "zaurcfr13@gmail.com",
            //    Username = "zaurcfr13",
            //    Password = "zaur12345"
            //};
            //Employer employer2 = new Employer
            //{
            //    Name = "Tommy",
            //    Surname = "Vercetti",
            //    Age = 31,
            //    PhoneNumber = "+994554117788",
            //    City = City.Baku,
            //    Email = "tommyvercetti@gmail.com",
            //    Username = "vercetti",
            //    Password = "harwoodbutcher"
            //};
            //Employer employer3 = new Employer
            //{
            //    Name = "Carl",
            //    Surname = "Johnson",
            //    Age = 28,
            //    PhoneNumber = "+994559857649",
            //    City = City.LosAngeles,
            //    Email = "carljohnson@gmail.com",
            //    Username = "cj",
            //    Password = "johnsonboy2"
            //};
            //Employer employer4 = new Employer
            //{
            //    Name = "Claude",
            //    Surname = "Speed",
            //    Age = 25,
            //    PhoneNumber = "+994558741383",
            //    City = City.NewYork,
            //    Email = "speedclaude@gmail.com",
            //    Username = "claude",
            //    Password = "catalina"
            //};
            //Employer employer5 = new Employer
            //{
            //    Name = "Employer",
            //    Surname = "Employer",
            //    Age = 20,
            //    PhoneNumber = "+994558747932",
            //    City = City.Baku,
            //    Email = "employer@gmail.com",
            //    Username = "employer",
            //    Password = "employer"
            //};
            //employers.Add(employer1);
            //employers.Add(employer2);
            //employers.Add(employer3);
            //employers.Add(employer4);
            //employers.Add(employer5);
            //Vacancy vacancy1 = new Vacancy
            //{
            //    VacancyName = "IT",
            //    City = City.Baku,
            //    MinAge = 18,
            //    MaxAge = 30,
            //    StartTime = new DateTime(2021, 03, 06, 09, 00, 00),
            //    EndTime = new DateTime(2021, 03, 06, 18, 00, 00),
            //    Salary = 1000,
            //    Experience = 3,
            //    Email = "zaurcfr13@gmail.com",
            //    JobDetails = "Web developer teleb olunur. Cay ve kofe pulsuz",
            //    Requirements = "HTML, CSS, JS bilikleri"
            //};
            //Vacancy vacancy2 = new Vacancy
            //{
            //    VacancyName = "Marketing",
            //    City = City.Baku,
            //    MinAge = 18,
            //    MaxAge = 30,
            //    StartTime = new DateTime(2021, 03, 06, 09, 00, 00),
            //    EndTime = new DateTime(2021, 03, 06, 18, 00, 00),
            //    Salary = 800,
            //    Experience = 3,
            //    Email = "tommyvercetti@gmail.com",
            //    JobDetails = "[Details about Marketing]",
            //    Requirements = "[Requirements about Marketing]"
            //}; ;
            //Vacancy vacancy3 = new Vacancy
            //{
            //    VacancyName = "Design",
            //    City = City.LosAngeles,
            //    MinAge = 18,
            //    MaxAge = 30,
            //    StartTime = new DateTime(2021, 03, 06, 09, 00, 00),
            //    EndTime = new DateTime(2021, 03, 06, 18, 00, 00),
            //    Salary = 800,
            //    Experience = 3,
            //    Email = "carljohnson@gmail.com",
            //    JobDetails = "[Details about Design]",
            //    Requirements = "[Requirements about Design]"
            //}; ;
            //Vacancy vacancy4 = new Vacancy
            //{
            //    VacancyName = "Writing",
            //    City = City.NewYork,
            //    MinAge = 18,
            //    MaxAge = 30,
            //    StartTime = new DateTime(2021, 03, 06, 09, 00, 00),
            //    EndTime = new DateTime(2021, 03, 06, 18, 00, 00),
            //    Salary = 800,
            //    Experience = 3,
            //    Email = "speedclaude@gmail.com",
            //    JobDetails = "[Details about Writing]",
            //    Requirements = "[Requirements about Writing]"
            //}; ;
            //Vacancy vacancy5 = new Vacancy
            //{
            //    VacancyName = "IT",
            //    City = City.LosAngeles,
            //    MinAge = 18,
            //    MaxAge = 30,
            //    StartTime = new DateTime(2021, 03, 06, 09, 00, 00),
            //    EndTime = new DateTime(2021, 03, 06, 18, 00, 00),
            //    Salary = 800,
            //    Experience = 3,
            //    Email = "employer@gmail.com",
            //    JobDetails = "[Details about IT]",
            //    Requirements = "[Requirements about IT]"
            //};
            //employer1.AddVacancy(vacancy1);
            //employer2.AddVacancy(vacancy2);
            //employer3.AddVacancy(vacancy3);
            //employer4.AddVacancy(vacancy4);
            //employer5.AddVacancy(vacancy5);

            #endregion

            fh.WriteEmployeesToFile("Employees.json", employees);
            fh.WriteEmployersToFile("Employers.json", employers);
            //foreach (var item in employees) fh.WriteCVsToFile("CV.json", item.CVs);
            //foreach (var item in employers) fh.WriteVacanciesToFile("Vacancies.json", item.vacancies);

            string username;
            string password;
            int count = 0;
            string choiceEmployeeMenu;
            string choiceEmployerMenu;
            string vacancyName;
            string city;

            bool b = true;
            while (b)
            {
                Console.Clear();
                bool l = true;
                while (l)
                {
                    Console.Clear();
                    Console.WriteLine("Enter your username: ");
                    username = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    password = Console.ReadLine();
                    bool ee = true;
                    bool er = true;

                    Console.Clear();
                    if (SignIN(employees, employers, username, password) == "employee")
                    {
                        while (ee)
                        {
                            Console.Clear();
                            Menu.PrintMenuForEmployees();
                            choiceEmployeeMenu = Console.ReadLine();
                            switch (choiceEmployeeMenu)
                            {
                                case "1":
                                    //Show your CVs
                                    Console.Clear();
                                    FindEmployee(employees, username).showCVs();
                                    Console.ReadLine();
                                    break;
                                case "2":
                                    //Create new CV
                                    try
                                    {
                                        Console.WriteLine("Enter profession: ");
                                        string profession = Console.ReadLine();
                                        Console.WriteLine("Enter school: ");
                                        string school = Console.ReadLine();
                                        Console.WriteLine("Enter score: ");
                                        int score = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Write about your skills: ");
                                        string skills = Console.ReadLine();
                                        Console.WriteLine("Write about companies which you worked: ");
                                        string companies = Console.ReadLine();
                                        Console.WriteLine("Start time: (mm/dd/yyyy)");
                                        DateTime startTime = Convert.ToDateTime(Console.ReadLine());
                                        Console.WriteLine("End time: (mm/dd/yyyy)");
                                        DateTime endTime = Convert.ToDateTime(Console.ReadLine());
                                        Console.WriteLine("Enter languages that you know: ");
                                        string languages = Console.ReadLine();
                                        Console.WriteLine("Do you have any certificate: (true/false)");
                                        bool certificate = Convert.ToBoolean(Console.ReadLine());
                                        Console.WriteLine("Your Github link: ");
                                        string github = Console.ReadLine();
                                        Console.WriteLine("Your LinkedIn account link: ");
                                        string linkedin = Console.ReadLine();
                                        var newCV = FindEmployee(employees, username).CreateCV(profession, school, score, skills, companies, startTime, endTime, languages, certificate, github, linkedin);
                                        FindEmployee(employees, username).AddCV(newCV);
                                        FindEmployee(employees, username).showCVs();
                                        fh.WriteCVsToFile("CV.json", newCV);
                                        fh.WriteEmployeesToFile("Employees.json", employees);
                                        Console.ReadLine();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        fh.WriteExceptionsToFile(ex);
                                        Console.ReadLine();
                                    }
                                    break;
                                case "3":
                                    //Delete CV
                                    try
                                    {
                                        Console.Clear();
                                        FindEmployee(employees, username).showCVs();
                                        Console.WriteLine("Enter ID: ");
                                        int id = int.Parse(Console.ReadLine());
                                        FindEmployee(employees, username).DeleteCV(id);
                                        fh.WriteEmployeesToFile("Employees.json", employees);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        fh.WriteExceptionsToFile(ex);
                                        Console.ReadLine();
                                    }
                                    break;
                                case "4":
                                    //Delete all CVs
                                    Console.Clear();
                                    Console.WriteLine("Are you sure ? (y/n)");
                                    string sure = Console.ReadLine();
                                    if (sure == "y")
                                    {
                                        FindEmployee(employees, username).DeleteAllCVs();
                                        fh.WriteEmployeesToFile("Employees.json", employees);
                                    }
                                    else if (sure == "n") break;
                                    else
                                    {
                                        Console.WriteLine("Wrong Input");
                                        Console.ReadLine();
                                    }
                                    break;
                                case "5":
                                    //Update CV
                                    try
                                    {
                                        bool updateCV = true;
                                        while (updateCV)
                                        {

                                            Console.Clear();
                                            FindEmployee(employees, username).showCVs();
                                            Console.WriteLine("Which CV you want to update ?\nEnter an ID:");
                                            int idForUpdateCV = int.Parse(Console.ReadLine());
                                            Console.Clear();
                                            Menu.UpdateMenuForCV();
                                            Console.WriteLine("Choose an option which you want to update: ");
                                            string choiceForUpdateCV = Console.ReadLine();
                                            switch (choiceForUpdateCV)
                                            {
                                                case "1":
                                                    Console.WriteLine("Enter new profession: ");
                                                    string updatedProfession = Console.ReadLine();
                                                    FindEmployee(employees, username).UpdateProfession(idForUpdateCV, updatedProfession);
                                                    break;
                                                case "2":
                                                    Console.WriteLine("Enter new school: ");
                                                    string updatedSchool = Console.ReadLine();
                                                    FindEmployee(employees, username).UpdateSchool(idForUpdateCV, updatedSchool);
                                                    break;
                                                case "3":
                                                    Console.WriteLine("Enter new score: ");
                                                    int updatedScore = int.Parse(Console.ReadLine());
                                                    FindEmployee(employees, username).UpdateScore(idForUpdateCV, updatedScore);
                                                    break;
                                                case "4":
                                                    Console.WriteLine("Enter new skill: ");
                                                    string updatedSkills = Console.ReadLine();
                                                    FindEmployee(employees, username).UpdateSkills(idForUpdateCV, updatedSkills);
                                                    break;
                                                case "5":
                                                    Console.WriteLine("Enter new companies: ");
                                                    string updatedCompanies = Console.ReadLine();
                                                    FindEmployee(employees, username).UpdateCompanies(idForUpdateCV, updatedCompanies);
                                                    break;
                                                case "6":
                                                    Console.WriteLine("Enter new start time(mm/dd/yyyy): ");
                                                    DateTime updatedStartTime = DateTime.Parse(Console.ReadLine());
                                                    FindEmployee(employees, username).UpdateStartTime(idForUpdateCV, updatedStartTime);
                                                    break;
                                                case "7":
                                                    Console.WriteLine("Enter new end time(mm/dd/yyyy): ");
                                                    DateTime updatedEndTime = DateTime.Parse(Console.ReadLine());
                                                    FindEmployee(employees, username).UpdateEndTime(idForUpdateCV, updatedEndTime);
                                                    break;
                                                case "8":
                                                    Console.WriteLine("Enter new languages: ");
                                                    string updatedLanguage = Console.ReadLine();
                                                    FindEmployee(employees, username).UpdateLanguage(idForUpdateCV, updatedLanguage);
                                                    break;
                                                case "9":
                                                    Console.WriteLine("Enter new certificate(true/false): ");
                                                    bool updatedCertificae = bool.Parse(Console.ReadLine());
                                                    FindEmployee(employees, username).UpdateCertificate(idForUpdateCV, updatedCertificae);
                                                    break;
                                                case "10":
                                                    Console.WriteLine("Enter new Github link: ");
                                                    string updatedGithub = Console.ReadLine();
                                                    FindEmployee(employees, username).UpdateGithub(idForUpdateCV, updatedGithub);
                                                    break;
                                                case "11":
                                                    Console.WriteLine("Enter new LinkedIn link: ");
                                                    string updatedLinkedIn = Console.ReadLine();
                                                    FindEmployee(employees, username).UpdateLinkedIn(idForUpdateCV, updatedLinkedIn);
                                                    break;
                                                case "0":
                                                    updateCV = false;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        fh.WriteEmployeesToFile("Employees.json", employees);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        fh.WriteExceptionsToFile(ex);
                                        Console.ReadLine();
                                    }
                                    break;
                                case "6":
                                    //Show Vacancies
                                    Console.Clear();
                                    foreach (var item in employers)
                                    {
                                        item.showVacancies();
                                    }
                                    Menu.PrintVacancyAndCVMenu();
                                    Console.WriteLine("Choose an option: ");
                                    string choiceForVacancy = Console.ReadLine();
                                    switch (choiceForVacancy)
                                    {
                                        case "1":
                                            try
                                            {
                                                Console.WriteLine("Enter ID of vacancy you want to bid: ");
                                                int IDBid = int.Parse(Console.ReadLine());
                                                FindEmployee(employees, username).showCVs();
                                                Console.WriteLine("Which CV you want to bid ?");
                                                int choiceCV = int.Parse(Console.ReadLine());
                                                FindEmployee(employees, username).Bid(FindEmployerByVacancyID(employers, IDBid), choiceCV, IDBid);
                                                Console.WriteLine("Vacancy added to your bid list succesfully!");
                                                Console.ReadLine();
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                fh.WriteExceptionsToFile(ex);
                                                Console.ReadLine();
                                            }
                                            break;
                                        case "2":
                                            try
                                            {
                                                Console.WriteLine("Enter ID of vacancy you want to add to your favorites: ");
                                                int IDFav = Convert.ToInt32(Console.ReadLine());
                                                FindEmployee(employees, username).AddToFavoritesVacancy(FindEmployerByVacancyID(employers, IDFav), IDFav);
                                                Console.WriteLine("Vacancy added to your favorites succesfully!");
                                                Console.ReadLine();
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                fh.WriteExceptionsToFile(ex);
                                                Console.ReadLine();
                                            }
                                            break;
                                        case "0":
                                            break;
                                        default:
                                            Console.WriteLine("Wrong Input!");
                                            Console.ReadLine();
                                            break;
                                    }
                                    break;
                                case "7":
                                    //Show Bid list
                                    Console.Clear();
                                    FindEmployee(employees, username).ShowBidList();
                                    Console.ReadLine();
                                    break;
                                case "8":
                                    //Remove Bid
                                    Console.Clear();
                                    FindEmployee(employees, username).ShowBidList();
                                    Console.WriteLine("Enter ID of vacancy you want to remove bid: ");
                                    int ID = int.Parse(Console.ReadLine());
                                    FindEmployee(employees, username).RemoveBid(ID);
                                    Console.WriteLine("Your bid removed succesfully");
                                    Console.ReadLine();
                                    break;
                                case "9":
                                    //Show Favorites
                                    Console.Clear();
                                    FindEmployee(employees, username).ShowFavoriteVacancies();
                                    Console.ReadLine();
                                    break;
                                case "10":
                                    //Nottification
                                    Console.Clear();
                                    FindEmployee(employees, username).ShowNottifications();
                                    Console.ReadLine();
                                    break;
                                case "11":
                                    //Filtering System
                                    try
                                    {
                                        Console.Clear();
                                        Menu.PrintCategories();
                                        Console.WriteLine("0.All");
                                        Console.WriteLine("Choose category: ");
                                        string categoryFilter = Console.ReadLine();
                                        foreach (var item in employers)
                                        {
                                            if (categoryFilter == "1") item.SearchByCategory(Category.IT);
                                            else if (categoryFilter == "2") item.SearchByCategory(Category.Marketing);
                                            else if (categoryFilter == "3") item.SearchByCategory(Category.Design);
                                            else if (categoryFilter == "4") item.SearchByCategory(Category.Business);
                                            else if (categoryFilter == "5") item.SearchByCategory(Category.Writing);
                                            else item.SearchByCategory(Category.Unassigned);
                                        }
                                        Menu.PrintCities();
                                        Console.WriteLine("0.All");
                                        Console.WriteLine("Choose city: ");
                                        string cityFilter = Console.ReadLine();
                                        foreach (var item in employers)
                                        {
                                            if (cityFilter == "1") item.SearchByCity(City.Baku);
                                            else if (cityFilter == "2") item.SearchByCity(City.Ganja);
                                            else if (cityFilter == "3") item.SearchByCity(City.Sumgait);
                                            else if (cityFilter == "4") item.SearchByCity(City.Kazakh);
                                            else if (cityFilter == "5") item.SearchByCity(City.NewYork);
                                            else if (cityFilter == "6") item.SearchByCity(City.LosAngeles);
                                            else if (cityFilter == "7") item.SearchByCity(City.Manchester);
                                            else item.SearchByCity(City.Unassigned);
                                        }
                                        Console.WriteLine("Enter minimum, maximum salary (min max): ");
                                        int minimumSalary = int.Parse(Console.ReadLine());
                                        int maximumSalary = int.Parse(Console.ReadLine());
                                        foreach (var item in employers)
                                        {
                                            item.SearchBySalary(minimumSalary, maximumSalary);
                                        }
                                        Console.Clear();
                                        foreach (var item in employers)
                                        {
                                            item.ShowSearchList();
                                        }
                                        Console.ReadLine();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        fh.WriteExceptionsToFile(ex);
                                    }
                                    break;
                                case "0":
                                    ee = false;
                                    l = false;
                                    break;
                                default:

                                    break;
                            }
                        }
                    }
                    else if (SignIN(employees, employers, username, password) == "employer")
                    {
                        while (er)
                        {
                            Console.Clear();
                            Menu.PrintMenuForEmployers();
                            choiceEmployerMenu = Console.ReadLine();
                            switch (choiceEmployerMenu)
                            {
                                case "1":
                                    //Show your vacancies
                                    Console.Clear();
                                    FindEmployer(employers, username).showVacancies();
                                    Console.ReadLine();
                                    break;
                                case "2":
                                    //Create new vacancy
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter vacancy category: ");
                                        Menu.PrintCategories();
                                        string choiceCategory = Console.ReadLine();
                                        if (choiceCategory == "1") vacancyName = Category.IT;
                                        else if (choiceCategory == "2") vacancyName = Category.Marketing;
                                        else if (choiceCategory == "3") vacancyName = Category.Design;
                                        else if (choiceCategory == "4") vacancyName = Category.Business;
                                        else if (choiceCategory == "5") vacancyName = Category.Writing;
                                        else vacancyName = Category.Unassigned;
                                        Console.WriteLine("Enter city: ");
                                        Menu.PrintCities();
                                        string choiceCity = Console.ReadLine();
                                        if (choiceCity == "1") city = City.Baku;
                                        else if (choiceCity == "2") city = City.Ganja;
                                        else if (choiceCity == "3") city = City.Sumgait;
                                        else if (choiceCity == "4") city = City.Kazakh;
                                        else if (choiceCity == "5") city = City.NewYork;
                                        else if (choiceCity == "6") city = City.LosAngeles;
                                        else if (choiceCity == "7") city = City.Manchester;
                                        else city = City.Unassigned;
                                        Console.WriteLine("Enter minimum age: ");
                                        int minAge = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter maximum age: ");
                                        int maxAge = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter start time: ");
                                        DateTime startTime = DateTime.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter end time: ");
                                        DateTime endTime = DateTime.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter salary: ");
                                        int salary = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter required experience(year)");
                                        int experience = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter email: ");
                                        string email = Console.ReadLine();
                                        Console.WriteLine("Enter job details: ");
                                        string jobDetails = Console.ReadLine();
                                        Console.WriteLine("Enter requirements: ");
                                        string requirements = Console.ReadLine();
                                        var newVacancy = FindEmployer(employers, username).CreateVacancy(vacancyName, city, minAge, maxAge, startTime, endTime, salary, experience, email, jobDetails, requirements);
                                        FindEmployer(employers, username).AddVacancy(newVacancy);
                                        FindEmployer(employers, username).showVacancies();
                                        fh.WriteVacanciesToFile("Vacancies.json", newVacancy);
                                        fh.WriteEmployersToFile("Employers.json", employers);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(ex.Message);
                                        fh.WriteExceptionsToFile(ex);
                                        Console.ReadLine();
                                    }
                                    break;
                                case "3":
                                    //Delete vacancy
                                    try
                                    {
                                        Console.Clear();
                                        FindEmployer(employers, username).showVacancies();
                                        Console.WriteLine("Enter ID: ");
                                        int id = int.Parse(Console.ReadLine());
                                        FindEmployer(employers, username).DeleteVacancy(id);
                                        fh.WriteEmployersToFile("Employers.json", employers);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        fh.WriteExceptionsToFile(ex);
                                        Console.ReadLine();
                                    }
                                    break;
                                case "4":
                                    //Delete all vacancies
                                    Console.Clear();
                                    Console.WriteLine("Are you sure ? (y/n)");
                                    string sure = Console.ReadLine();
                                    if (sure == "y")
                                    {
                                        FindEmployer(employers, username).DeleteAllVacancies();
                                        fh.WriteEmployersToFile("Employers.json", employers);
                                    }
                                    else if (sure == "n") break;
                                    else
                                    {
                                        Console.WriteLine("Wrong Input");
                                        Console.ReadLine();
                                    }
                                    break;
                                case "5":
                                    //Update vacancy
                                    try
                                    {
                                        bool updateVacancy = true;
                                        while (updateVacancy)
                                        {

                                            Console.Clear();
                                            FindEmployer(employers, username).showVacancies();
                                            Console.WriteLine("Which Vacancy you want to update ?\nEnter an ID:");
                                            int idForUpdateVacancy = int.Parse(Console.ReadLine());
                                            Console.Clear();
                                            Menu.UpdateMenuForVacancy();
                                            Console.WriteLine("Choose an option which you want to update: ");
                                            string choiceForUpdateVacancy = Console.ReadLine();
                                            switch (choiceForUpdateVacancy)
                                            {
                                                case "1":
                                                    Console.WriteLine("Enter new vacancy category: ");
                                                    Menu.PrintCategories();
                                                    string choiceCategory = Console.ReadLine();
                                                    if (choiceCategory == "1") FindEmployer(employers, username).UpdateVacancyName(idForUpdateVacancy, Category.IT);
                                                    else if (choiceCategory == "2") FindEmployer(employers, username).UpdateVacancyName(idForUpdateVacancy, Category.Marketing);
                                                    else if (choiceCategory == "3") FindEmployer(employers, username).UpdateVacancyName(idForUpdateVacancy, Category.Design);
                                                    else if (choiceCategory == "4") FindEmployer(employers, username).UpdateVacancyName(idForUpdateVacancy, Category.Business);
                                                    else if (choiceCategory == "5") FindEmployer(employers, username).UpdateVacancyName(idForUpdateVacancy, Category.Writing);
                                                    else FindEmployer(employers, username).UpdateVacancyName(idForUpdateVacancy, Category.Unassigned);
                                                    break;
                                                case "2":
                                                    Console.WriteLine("Enter new city: ");
                                                    Menu.PrintCities();
                                                    string choiceCity = Console.ReadLine();
                                                    if (choiceCity == "1") FindEmployer(employers, username).UpdateCity(idForUpdateVacancy, City.Baku);
                                                    else if (choiceCity == "2") FindEmployer(employers, username).UpdateCity(idForUpdateVacancy, City.Ganja);
                                                    else if (choiceCity == "3") FindEmployer(employers, username).UpdateCity(idForUpdateVacancy, City.Sumgait);
                                                    else if (choiceCity == "4") FindEmployer(employers, username).UpdateCity(idForUpdateVacancy, City.Kazakh);
                                                    else if (choiceCity == "5") FindEmployer(employers, username).UpdateCity(idForUpdateVacancy, City.NewYork);
                                                    else if (choiceCity == "6") FindEmployer(employers, username).UpdateCity(idForUpdateVacancy, City.LosAngeles);
                                                    else if (choiceCity == "7") FindEmployer(employers, username).UpdateCity(idForUpdateVacancy, City.Manchester);
                                                    else FindEmployer(employers, username).UpdateCity(idForUpdateVacancy, City.Unassigned);
                                                    break;
                                                case "3":
                                                    Console.WriteLine("Enter new minimum age: ");
                                                    int updatedMinAge = int.Parse(Console.ReadLine());
                                                    FindEmployer(employers, username).UpdateMinAge(idForUpdateVacancy, updatedMinAge);
                                                    break;
                                                case "4":
                                                    Console.WriteLine("Enter new maximum age: ");
                                                    int updatedMaxAge = int.Parse(Console.ReadLine());
                                                    FindEmployer(employers, username).UpdateMaxAge(idForUpdateVacancy, updatedMaxAge);
                                                    break;
                                                case "5":
                                                    Console.WriteLine("Enter new start time(mm/dd/yyyy): ");
                                                    DateTime updatedStartTime = DateTime.Parse(Console.ReadLine());
                                                    FindEmployer(employers, username).UpdateStartTime(idForUpdateVacancy, updatedStartTime);
                                                    break;
                                                case "6":
                                                    Console.WriteLine("Enter new end time(mm/dd/yyyy): ");
                                                    DateTime updatedEndTime = DateTime.Parse(Console.ReadLine());
                                                    FindEmployer(employers, username).UpdateEndTime(idForUpdateVacancy, updatedEndTime);
                                                    break;
                                                case "7":
                                                    Console.WriteLine("Enter new salary: ");
                                                    int updatedSalary = int.Parse(Console.ReadLine());
                                                    FindEmployer(employers, username).UpdateSalary(idForUpdateVacancy, updatedSalary);
                                                    break;
                                                case "8":
                                                    Console.WriteLine("Enter new experience(year): ");
                                                    int updatedExperience = int.Parse(Console.ReadLine());
                                                    FindEmployer(employers, username).UpdateExperience(idForUpdateVacancy, updatedExperience);
                                                    break;
                                                case "9":
                                                    Console.WriteLine("Enter new email: ");
                                                    string updatedEmail = Console.ReadLine();
                                                    FindEmployer(employers, username).UpdateEmail(idForUpdateVacancy, updatedEmail);
                                                    break;
                                                case "10":
                                                    Console.WriteLine("Enter new job details: ");
                                                    string updatedJobDetails = Console.ReadLine();
                                                    FindEmployer(employers, username).UpdateJobDetails(idForUpdateVacancy, updatedJobDetails);
                                                    break;
                                                case "11":
                                                    Console.WriteLine("Enter new requirements: ");
                                                    string updatedRequirements = Console.ReadLine();
                                                    FindEmployer(employers, username).UpdateRequirements(idForUpdateVacancy, updatedRequirements);
                                                    break;
                                                case "0":
                                                    updateVacancy = false;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        fh.WriteEmployersToFile("Employers.json", employers);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        fh.WriteExceptionsToFile(ex);
                                        Console.ReadLine();
                                    }
                                    break;
                                case "6":
                                    //Show all employees
                                    Console.Clear();
                                    foreach (var item in employees)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    try
                                    {
                                        Console.WriteLine("Choose an ID to see CV: ");
                                        int ID = int.Parse(Console.ReadLine());
                                        FindEmployeeByID(employees, ID).showCVs();
                                        Console.WriteLine("Do you want to add this employee to your favorites ? (y/n)");
                                        string choiceForCV = Console.ReadLine();
                                        switch (choiceForCV)
                                        {
                                            case "y":
                                                FindEmployer(employers, username).AddToFavoritesCV(FindEmployeeByID(employees, ID), ID);
                                                Console.WriteLine("Employee succesfully added to your favorites!");
                                                Console.ReadLine();
                                                break;
                                            case "n":
                                                break;
                                            default:
                                                Console.WriteLine("Wrong Input!");
                                                break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        fh.WriteExceptionsToFile(ex);
                                        Console.ReadLine();
                                    }
                                    break;
                                case "7":
                                    //Show Favorites
                                    Console.Clear();
                                    FindEmployer(employers, username).ShowFavoriteCVs();
                                    Console.ReadLine();
                                    break;
                                case "8":
                                    //Incoming CVs
                                    try
                                    {
                                        Console.Clear();
                                        FindEmployer(employers, username).ShowIncomingCVs();
                                        Console.WriteLine("Enter ID of CV: ");
                                        int IdOfCV = int.Parse(Console.ReadLine());
                                        Menu.PrintAcceptRefuseMenu();
                                        string choiceAR = Console.ReadLine();
                                        switch (choiceAR)
                                        {
                                            case "1":
                                                var emp = FindEmployeeByID(employees, IdOfCV);
                                                FindEmployer(employers, username).Accept(emp, IdOfCV);
                                                SendNottificationToEmployee(emp, "accept");
                                                Console.WriteLine("CV Accepted successfully!");
                                                Console.ReadLine();
                                                break;
                                            case "2":
                                                emp = FindEmployeeByID(employees, IdOfCV);
                                                FindEmployer(employers, username).Refuse(emp, IdOfCV);
                                                SendNottificationToEmployee(emp, "refuse");
                                                Console.WriteLine("CV Refused!");
                                                Console.ReadLine();
                                                break;
                                            case "0":
                                                break;
                                            default:
                                                Console.WriteLine("Wrong Input");
                                                break;
                                        }
                                        fh.WriteEmployersToFile("Employers.json", employers);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        fh.WriteExceptionsToFile(ex);
                                        Console.ReadLine();
                                    }
                                    break;
                                case "9":
                                    //Accepted CVs
                                    Console.Clear();
                                    FindEmployer(employers, username).ShowAcceptedCVs();
                                    Console.ReadLine();
                                    break;
                                case "0":
                                    er = false;
                                    l = false;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        count++;
                        if (count < 3)
                        {
                            Console.WriteLine($"{3 - count} chance(s) left");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            l = false;
                        }
                    }
                }
            }
        }
    }



}




