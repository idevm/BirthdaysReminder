using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirthdaysReminder
{
    public class Program
    {
        public static string DayNow { get; } = DateTime.Now.Day.ToString().Length == 2
    ? DateTime.Now.Day.ToString()
    : "0" + DateTime.Now.Day.ToString();

        public static string MonthNow { get; } = DateTime.Now.Month.ToString().Length == 2
            ? DateTime.Now.Month.ToString()
            : "0" + DateTime.Now.Month.ToString();

        public static int YearNow { get; set; } = DateTime.Now.Year;

        public static string[] Lines { get; set; }

        public static List<Dictionary<string, string>> People { get; set; } = new();

        public static string Text { get; set; }

        public static Form1 form = new Form1();

        public static string tName;
        public static string tBD;

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Lines = ReadFile("db.csv");
                People = GetPeopleList(Lines);
                Text = GetTextToday(People);
                ShowText(Text);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                ShowText(ex.Message);
                form.thisMonthButton.Enabled = false;
            }
            catch (FormatException ex)
            {
                ShowText(ex.Message);
                form.thisMonthButton.Enabled = false;
                form.AddBDButton.Enabled = false;
            }
            Application.Run(form);
        }

        public static void ShowText(string txt)
        {
           form.label1.Text = txt;
        }


        public static string GetTextFromUser()
        {
            return Console.ReadLine();
        }


        public static string[] ReadFile(string path)
        {
            try
            {
                return System.IO.File.ReadAllLines(path);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                System.IO.FileNotFoundException noFile = new("�� ������ ���� � �������, � ������: " + ex.Message);
                throw noFile;
            }
        }


        public static void WriteFile(string path, string txt)
        {
            System.IO.File.AppendAllText(path, txt);
        }


        public static List<Dictionary<string, string>> GetPeopleList(string[] lines, string mode = "today")
        {
            if (lines == null || lines.Length == 0)
            {
                throw new FormatException("������: ���������� ������");
            }
            List<Dictionary<string, string>> people = new();
            foreach (string line in lines)
            {
                try
                {
                    string[] values = line.Split(";");
                    if (values.Length != 6)
                    {
                        throw new FormatException($"������������ ������ �������: ������ � ������  {Array.IndexOf(lines, line) + 1}");
                    }
                    string name = values[2];
                    if (name.Length <= 0)
                    {
                        throw new FormatException($"����������� ��� � ������ {Array.IndexOf(lines, line) + 1}");
                    }
                    string day = values[4].Split(".")[0];
                    if (!int.TryParse(day, out int num) || day.Length != 2 || num > 31)
                    {
                        throw new FormatException($"������������ ������ ��� � ������ {Array.IndexOf(lines, line) + 1}");
                    }
                    string month = values[4].Split(".")[1];
                    if (!int.TryParse(month, out num) || month.Length != 2 || num > 12)
                    {
                        throw new FormatException($"������������ ������ ������ � ������ {Array.IndexOf(lines, line) + 1}");
                    }
                    string year = values[4].Split(".")[2];
                    if (!int.TryParse(year, out num) || year.Length != 4 || num > YearNow)
                    {
                        throw new FormatException($"������������ ������ ���� � ������ {Array.IndexOf(lines, line) + 1}");
                    }
                    if (mode == "today")
                    {
                        if (month == MonthNow && day == DayNow)
                        {
                            Dictionary<string, string> man = new();
                            man.Add("name", name);
                            man.Add("day", day);
                            man.Add("month", month);
                            man.Add("year", year);
                            people.Add(man);
                        }
                    }
                    else if(mode == "all")
                    {
                            Dictionary<string, string> man = new();
                            man.Add("name", name);
                            man.Add("day", day);
                            man.Add("month", month);
                            man.Add("year", year);
                            people.Add(man);
                    }
                    else
                    {
                        if (month == MonthNow)
                        {
                            Dictionary<string, string> man = new();
                            man.Add("name", name);
                            man.Add("day", day);
                            man.Add("month", month);
                            man.Add("year", year);
                            people.Add(man);
                        }
                    }
                }
                catch (FormatException ex)
                {
                    FormatException badFormat = new("���� ������ ���������� ��� ������ ������ �� ������������� ��������������!\n" + ex.Message);
                    throw badFormat;
                }
            }
            return people;
        }


        public static string GetTextToday(List<Dictionary<string, string>> people)
        {
            string text;
            if (people.Count > 1)
            {
                text = $"Сегодня {DayNow}.{MonthNow} отмечают день рождения:\n\n";
                foreach (Dictionary<string, string> man in people)
                {
                    text += $"\t{man["name"]} ({ GetAge(man["year"])})\n";
                }
            }
            else
            {
                text = people.Count == 1
                    ? $"Сегодня {DayNow}.{MonthNow} отмечает день рождения\n\n\t{ people[0]["name"]} ({GetAge(people[0]["year"])})\n"
                    : $"Сегодня {DayNow}.{MonthNow} никто не отмечает день рождения";
            }
            return text;
        }


        public static string GetTextThisMonth(List<Dictionary<string, string>> people)
        {
            string text;
            if (people.Count > 1)
            {
                text = $"В этом месяце отмечают дни рождения:\n\n";
                foreach (Dictionary<string, string> man in people)
                {
                    text += $"\t{man["name"]} ({man["day"]}.{man["month"]})\n";
                }
            }
            else
            {
                text = people.Count == 1
                    ? $"В этом месяце отмечает день рождения\n\n\t{people[0]["name"]} ({people[0]["day"]}.{people[0]["month"]})\n"
                    : $"В этом месяце никто не отмечает день рождения";
            }
            return text;
        }


        public static string GetTextAll(List<Dictionary<string, string>> people)
        {
            string text;
                text = $"Все дни рождения:\n\n";
                foreach (Dictionary<string, string> man in people)
                {
                    text += $"\t{man["name"]} ({man["day"]}.{man["month"]}.{man["year"]})\n";
                }
            return text;
        }


        public static string GetAge(string year)
        {
            int age = YearNow - int.Parse(year);
            string str = age.ToString();
            if (age % 5 == 0 && age >= 50)
            {
                str = "юбилей: " + str;
            }
            if ((str.EndsWith('2') || str.EndsWith('3') || str.EndsWith('4')) && (!str.StartsWith('1') || str.Length == 3))
            {
                str += " года";
            }
            else if (str.EndsWith('1') && (!str.StartsWith('1') || str.Length == 1 || str.Length == 3))
            {

                str += " год";
            }
            else
            {
                str += " лет";
            }
            return str;
        }


        public static string AddText(string[] lines, string name, string birthday)
        {
            if (lines == null)
            {
                lines = Array.Empty<string>();
            }
            string num = "1";
            if (lines.Length != 0)
            {
                num = (int.Parse(lines[lines.Length - 1].Split(";")[0]) + 1).ToString();
            }
            try
            {
                if (!ValidInput(name: name))
                {
                    throw new FormatException("������� ���������� ��� (�������� ������ ���� ��������)");
                }
                if (!ValidInput(birthday: birthday))
                {
                    throw new FormatException("������� ���������� ���� �������� (�������� 02.08.1999)");
                }
            }
            catch (FormatException ex)
            {
                FormatException badInput = new("������� ������������ ������\n" + ex.Message);
                throw badInput;
            }
            string result = $"{num};;{name.ToUpper()};;{birthday};\n";
            return result;
        }


        public static bool ValidInput(string name = "nameParam", string birthday = "birthdayParam")
        {
            if (name == "nameParam" && birthday == "birthdayParam")
            {
                return false;
            }
            if (name != "nameParam")
            {
                if (name.Length <= 0)
                {
                    return false;
                }
            }
            if (birthday != "birthdayParam")
            {
                if (birthday.Length <= 0 || birthday.Split(".").Length != 3)
                {
                    return false;
                }
                string day = birthday.Split(".")[0];
                string month = birthday.Split(".")[1];
                string year = birthday.Split(".")[2];
                if (!int.TryParse(day, out int d)
                || day.Length != 2
                || d > 31
                || !int.TryParse(month, out int m)
                || month.Length != 2
                || m > 12
                || !int.TryParse(year, out int y)
                || year.Length != 4
                || y > YearNow)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
