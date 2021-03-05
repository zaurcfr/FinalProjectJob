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
            List<Employee> employees = new List<Employee>();
            List<Employer> employers = new List<Employer>();

            #region EmployeeAndEmployer

            Employee employee1 = new Employee
            {
                Name = "Zaur",
                Surname = "Jafarov",
                Age = 19,
                PhoneNumber = "+994553467069",
                City = City.Baku,
                Email = "zaurcfr@gmail.com",
                Username = "zaurcfr",
                Password = "zaur123"
            };
            Employee employee2 = new Employee
            {
                Name = "Sweet",
                Surname = "Johnson",
                Age = 28,
                PhoneNumber = "+994558763267",
                City = City.LosAngeles,
                Email = "sweetj@gmail.com",
                Username = "sweet",
                Password = "johnsonboy1"
            };
            Employee employee3 = new Employee
            {
                Name = "Ken",
                Surname = "Rosenberg",
                Age = 30,
                PhoneNumber = "+994706754857",
                City = City.Baku,
                Email = "rosenberg@gmail.com",
                Username = "krose",
                Password = "kenrosie91"
            };
            Employee employee4 = new Employee
            {
                Name = "Sonny",
                Surname = "Forelli",
                Age = 32,
                PhoneNumber = "+994774567824",
                City = City.Baku,
                Email = "sonny_forelli@gmail.com",
                Username = "sonnyf",
                Password = "forelli1m"
            };
            Employee employee5 = new Employee
            {
                Name = "Salvatore",
                Surname = "Leone",
                Age = 43,
                PhoneNumber = "+994554987395",
                City = City.NewYork,
                Email = "bossleone@gmail.com",
                Username = "salvatoretheboss",
                Password = "salvatore123"
            };
            Employee employee6 = new Employee
            {
                Name = "Employee",
                Surname = "Employee",
                Age = 20,
                PhoneNumber = "+994551234567",
                City = City.Baku,
                Email = "employee@gmail.com",
                Username = "employee",
                Password = "employee"
            };
            employees.Add(employee1);
            employees.Add(employee2);
            employees.Add(employee3);
            employees.Add(employee4);
            employees.Add(employee5);
            employees.Add(employee6);
            CV cv1 = new CV
            {
                Profession = "Developer",
                SchoolNO = "THL",
                Score = 522,
                Skills = "C++, C#",
                Companies = "Step IT, SMTH",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                Languages = "Azerbaijani,English,Turkish",
                Certificate = true,
                GitHub = "github.com/zaurcfr",
                LinkedIn = "linkedin.com/zaurcfr"
            };
            CV cv2 = new CV
            {
                Profession = "Marketing",
                SchoolNO = "LA School",
                Score = 674,
                Skills = "smth",
                Companies = "Marketing Comp.",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                Languages = "English,Russian",
                Certificate = true,
                GitHub = "github.com/sweetj",
                LinkedIn = "linkedin.com/sweetj"
            };
            CV cv3 = new CV
            {
                Profession = "Marketing",
                SchoolNO = "Law School",
                Score = 690,
                Skills = "Lawyer skills",
                Companies = "Lawyer Comp.",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                Languages = "Azerbaijani,Turkish,English,Russian",
                Certificate = true,
                GitHub = "github.com/krosie",
                LinkedIn = "linkedin.com/krosie"
            };
            CV cv4 = new CV
            {
                Profession = "Designer",
                SchoolNO = "Design School",
                Score = 456,
                Skills = "Photoshop",
                Companies = "Design Comp.",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                Languages = "Azerbaijani,English",
                Certificate = true,
                GitHub = "github.com/sonnyf",
                LinkedIn = "linkedin.com/sonnyf"
            };
            CV cv5 = new CV
            {
                Profession = "Writing",
                SchoolNO = "NY School",
                Score = 543,
                Skills = "Some Writing skills",
                Companies = "Writer Comp.",
                StartTime = new DateTime(2015, 10, 5),
                EndTime = new DateTime(2019, 5, 3),
                Languages = "Azerbaijani,English,Russian,Mexicano",
                Certificate = true,
                GitHub = "github.com/salvatore",
                LinkedIn = "linkedin.com/salvatore"
            };
            CV cv6 = new CV
            {
                Profession = "Informasion Technologies",
                SchoolNO = "IT School",
                Score = 538,
                Skills = "Network, Windows Server",
                Companies = "IT Comp.",
                StartTime = new DateTime(2018, 07, 13),
                EndTime = new DateTime(2020, 12, 12),
                Languages = "Azerbaijani,English,Russian",
                Certificate = true,
                GitHub = "github.com/sweetj",
                LinkedIn = "linkedin.com/sweetj"
            };
            employee1.AddCV(cv1);
            employee2.AddCV(cv2);
            employee3.AddCV(cv3);
            employee4.AddCV(cv4);
            employee5.AddCV(cv5);
            employee6.AddCV(cv6);
            //fh.WriteUsersToFile("Employees.json", employees);

            Employer employer1 = new Employer
            {
                Name = "Zaur",
                Surname = "Jafarov",
                Age = 19,
                PhoneNumber = "+994553467069",
                City = City.Baku,
                Email = "zaurcfr13@gmail.com",
                Username = "zaurcfr13",
                Password = "zaur12345"
            };
            Employer employer2 = new Employer
            {
                Name = "Tommy",
                Surname = "Vercetti",
                Age = 31,
                PhoneNumber = "+994554117788",
                City = City.Baku,
                Email = "tommyvercetti@gmail.com",
                Username = "vercetti",
                Password = "harwoodbutcher"
            };
            Employer employer3 = new Employer
            {
                Name = "Carl",
                Surname = "Johnson",
                Age = 28,
                PhoneNumber = "+994559857649",
                City = City.LosAngeles,
                Email = "carljohnson@gmail.com",
                Username = "cj",
                Password = "johnsonboy2"
            };
            Employer employer4 = new Employer
            {
                Name = "Claude",
                Surname = "Speed",
                Age = 25,
                PhoneNumber = "+994558741383",
                City = City.NewYork,
                Email = "speedclaude@gmail.com",
                Username = "claude",
                Password = "catalina"
            };
            Employer employer5 = new Employer
            {
                Name = "Employer",
                Surname = "Employer",
                Age = 20,
                PhoneNumber = "+994558747932",
                City = City.Baku,
                Email = "employer@gmail.com",
                Username = "employer",
                Password = "employer"
            };
            employers.Add(employer1);
            employers.Add(employer2);
            employers.Add(employer3);
            employers.Add(employer4);
            employers.Add(employer5);
            Vacancy vacancy1 = new Vacancy
            {
                VacancyName = "IT",
                City = City.Baku,
                MinAge = 18,
                MaxAge = 30,
                StartTime = new DateTime(2021, 03, 06, 09, 00, 00),
                EndTime = new DateTime(2021, 03, 06, 18, 00, 00),
                Salary = 1000,
                Experience = 3,
                Email = "zaurcfr13@gmail.com",
                JobDetails = "Web developer teleb olunur. Cay ve kofe pulsuz",
                Requirements = "HTML, CSS, JS bilikleri"
            };
            Vacancy vacancy2 = new Vacancy
            {
                VacancyName = "Marketing",
                City = City.Baku,
                MinAge = 18,
                MaxAge = 30,
                StartTime = new DateTime(2021, 03, 06, 09, 00, 00),
                EndTime = new DateTime(2021, 03, 06, 18, 00, 00),
                Salary = 800,
                Experience = 3,
                Email = "tommyvercetti@gmail.com",
                JobDetails = "[Details about Marketing]",
                Requirements = "[Requirements about Marketing]"
            }; ;
            Vacancy vacancy3 = new Vacancy
            {
                VacancyName = "Design",
                City = City.LosAngeles,
                MinAge = 18,
                MaxAge = 30,
                StartTime = new DateTime(2021, 03, 06, 09, 00, 00),
                EndTime = new DateTime(2021, 03, 06, 18, 00, 00),
                Salary = 800,
                Experience = 3,
                Email = "carljohnson@gmail.com",
                JobDetails = "[Details about Design]",
                Requirements = "[Requirements about Design]"
            }; ;
            Vacancy vacancy4 = new Vacancy
            {
                VacancyName = "Writing",
                City = City.NewYork,
                MinAge = 18,
                MaxAge = 30,
                StartTime = new DateTime(2021, 03, 06, 09, 00, 00),
                EndTime = new DateTime(2021, 03, 06, 18, 00, 00),
                Salary = 800,
                Experience = 3,
                Email = "speedclaude@gmail.com",
                JobDetails = "[Details about Writing]",
                Requirements = "[Requirements about Writing]"
            }; ;
            Vacancy vacancy5 = new Vacancy
            {
                VacancyName = "IT",
                City = City.Baku,
                MinAge = 18,
                MaxAge = 30,
                StartTime = new DateTime(2021, 03, 06, 09, 00, 00),
                EndTime = new DateTime(2021, 03, 06, 18, 00, 00),
                Salary = 800,
                Experience = 3,
                Email = "employer@gmail.com",
                JobDetails = "[Details about IT]",
                Requirements = "[Requirements about IT]"
            };
            employer1.AddVacancy(vacancy1);
            employer2.AddVacancy(vacancy2);
            employer3.AddVacancy(vacancy3);
            employer4.AddVacancy(vacancy4);
            employer5.AddVacancy(vacancy5);
            //fh.WriteUsersToFile("Employers.json", employers);

            #endregion


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
                Menu.PrintMenu();
                Console.WriteLine("Choose your option: ");
                string choiceLogIn = Console.ReadLine();
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
                                        Console.ReadLine();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
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
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        Console.ReadLine();
                                    }
                                    break;
                                case "4":
                                    //Delete all CVs
                                    Console.Clear();
                                    Console.WriteLine("Are you sure ? (y/n)");
                                    string sure = Console.ReadLine();
                                    if (sure == "y") FindEmployee(employees, username).DeleteAllCVs();
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
                                        Console.Clear();
                                        FindEmployee(employees, username).showCVs();
                                        Console.WriteLine("Which CV you want to update ?\nEnter an ID:");
                                        int idForUpdateCV = int.Parse(Console.ReadLine());
                                        Menu.UpdateMenuForCV();
                                        Console.WriteLine("Choose an option which you want to update: ");
                                        string choiceForUpdateCV = Console.ReadLine();
                                        switch (choiceForUpdateCV)
                                        {
                                            case "1":
                                                Console.WriteLine("Enter new profession: ");
                                                string updatedProfession = Console.ReadLine();
                                                FindEmployee(employees, username).UpdateProfession(idForUpdateCV,updatedProfession);
                                                break;
                                            default:
                                                break;
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
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
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(ex.Message);
                                        Console.ReadLine();
                                    }
                                    break;
                                case "3":
                                    //Delete vacancy
                                    Console.Clear();
                                    FindEmployer(employers, username).showVacancies();
                                    Console.WriteLine("Enter ID: ");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    try { FindEmployer(employers, username).DeleteVacancy(id); }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;
                                case "4":
                                    //Delete all vacancies
                                    Console.Clear();
                                    Console.WriteLine("Are you sure ? (y/n)");
                                    string sure = Console.ReadLine();
                                    if (sure == "y") FindEmployer(employers, username).DeleteAllVacancies();
                                    else if (sure == "n") break;
                                    else
                                    {
                                        Console.WriteLine("Wrong Input");
                                        Console.ReadLine();
                                    }
                                    break;
                                case "5":
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
                                        Console.ReadLine();
                                    }
                                    break;
                                case "6":
                                    //Show Favorites
                                    Console.Clear();
                                    FindEmployer(employers, username).ShowFavoriteCVs();
                                    Console.ReadLine();
                                    break;
                                case "7":
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
                                                FindEmployer(employers, username).Accept(FindEmployeeByID(employees, IdOfCV), IdOfCV);
                                                Console.WriteLine("CV Accepted successfully!");
                                                Console.ReadLine();
                                                break;
                                            case "2":
                                                FindEmployer(employers, username).Refuse(FindEmployeeByID(employees, IdOfCV), IdOfCV);
                                                Console.WriteLine("CV Refused!");
                                                Console.ReadLine();
                                                break;
                                            case "0":
                                                break;
                                            default:
                                                Console.WriteLine("Wrong Input");
                                                break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                case "8":
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



    #region Test

    //Console.WriteLine(employee);
    //employee.showCVs();
    //employee.CreateCV("Computer Science", "123", 123, "Helpdesk, Python", "STMHSTM", new DateTime(2011, 01, 01), DateTime.Now, "Azerbaijani, English", true, "git", "link");
    //employee.showCVs();

    //try
    //{
    //    employee.DeleteCV(3);
    //}
    //catch (Exception ex)
    //{
    //    Console.WriteLine(ex.Message);
    //}
    //employee.showCVs();

    //employee.UpdateProfession(2, "Cyber Sec");
    //employee.UpdateSchool(2, "123");
    //employee.UpdateScore(2, 700);
    //employee.UpdateSkills(2, "C++,C#,C");
    //employee.UpdateProfession(3, "Cyber Sec");
    //employee.UpdateProfession(4, "Cyber Sec");
    //employee.showCVs();



    //Console.WriteLine(employer);
    //employer.showVacancies();
    //employer.AddVacancy(".NET Developer", "Baku", 18, 30, new DateTime(2011, 01, 01, 09, 00, 00), new DateTime(2011, 01, 01, 18, 00, 00), 2000, 3, "zaur@gmail.com", ".Net Dev axtarilir", "C# bilikleri");
    //employer.DeleteAllVacancies();
    //employer.DeleteVacancy(1);
    //employer.UpdateVacancyName(1, "SMTH");
    //employer.UpdateCity(1, "NY");
    //employer.UpdateMinAge(1, 25);
    //employer.UpdateMaxAge(1, 50);

    //employer.showVacancies();

    //CV cv1 = new CV
    //{
    //    Profession = "Cyber Security",
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
    //employee.AddCv(cv1);
    //employee.showCVs();
    //employer.Accept(cv1);


    //employee.Bid(2);
    //employer.Accept(employee, 2);
    //employer.ShowAcceptedCVs();


    //Vacancy vacancy = new Vacancy();
    //employer.SearchByCategory(Category.IT);
    //employer.SearchByCity("Baku");
    //employer.SearchBySalary(500, 1500);
    //employer.SearchByExperience(2);
    //employer.ShowSearchList();


    //employee.Bid(1);
    //employer.Accept(employee,1);
    //employer.ShowAcceptedCVs();

    //try
    //{
    //    employer.DeleteVacancy(4);
    //}
    //catch (Exception ex)
    //{
    //    Console.WriteLine(ex.Message);
    //    using (var fs = new FileStream("error_log.txt",FileMode.OpenOrCreate))
    //    {
    //        using (var sw=new StreamWriter(fs))
    //        {
    //            sw.WriteLine($"Error Message: {ex.Message}");
    //        }
    //    }
    //}

    //if (SignIN(employee, "zaur", "zaur12"))
    //{
    //    Console.WriteLine("Welcome");
    //}

    //employer.AddToFavoritesCV(employee, 1);
    //employer.ShowFavoriteCVs();

    //employee.AddToFavoritesVacancy(employer, 1);
    //employee.ShowFavoriteVacancies();

    //employer.IncreaseView(1);
    //employer.IncreaseView(3);
    //employer.IncreaseView(3);
    //employer.IncreaseView(3);
    //employer.OrderByView();


    //employee.Bid(1);
    //employer.Accept(employee, 1);
    //employer.Refuse(employee, 1);
    //Statistics statistics = new Statistics();
    //statistics.CalculateTotalVacancies(employer);
    //statistics.CalculateTotalAcceptedCVs(employer);
    //statistics.CalculateTotalRefusedCVs(employer);
    //statistics.CalculateTotalCVs(employee);
    //statistics.CalculateTotalBids(employee);

    #endregion
}




