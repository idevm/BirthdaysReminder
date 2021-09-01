using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirthdaysReminder
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            try
            {
                string[] lines = System.IO.File.ReadAllLines("db.csv", System.Text.Encoding.Default);
                string message = "";
                string dayNow = DateTime.Now.Day.ToString();
                if (dayNow.Length < 2)
                {
                    dayNow = "0" + dayNow;
                }
                string monthNow = DateTime.Now.Month.ToString();
                if (monthNow.Length < 2)
                {
                    monthNow = "0" + monthNow;
                }
                int yearNow = DateTime.Now.Year;
                List<string[]> people = new List<string[]>();
                foreach (string line in lines)
                {
                    string[] values = line.Split(";");
                    string name = values[2];
                    string year = values[4].Split(".")[2];
                    string month = values[4].Split(".")[1];
                    string day = values[4].Split(".")[0];
                    if (month == monthNow && day == dayNow)
                    {
                        people.Add(new string[] { name, day, month, year });
                    }
                }
                if (people.Count > 1)
                {
                    message = $"Сегодня {dayNow}.{monthNow} отмечают день рождения:\n\n";
                    foreach (string[] man in people)
                    {
                        message += "\t" + man[0] + " (" + GetAge(yearNow, man[3]) + ")\n";
                    }
                }
                else if (people.Count == 1)
                {
                    message = $"Сегодня {dayNow}.{monthNow} отмечает день рождения\n\n" + "\t" + people[0][0] + " (" + GetAge(yearNow, people[0][3]) + ")\n";

                }
                else
                {
                    message = $"Сегодня {dayNow}.{monthNow} никто не отмечает день рождения";
                }
                form.label1.Text = message;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                form.label1.Text = "Не найден файл с данными, а именно: " + ex.Message;
            }
            Application.Run(form);
        }

        public static string GetAge(int yearNow, string year)
        {
            string age = (yearNow - int.Parse(year)).ToString();
            if (int.Parse(age) % 5 == 0)
            {
                age = "юбилей: " + age;
            }
            if ((age.EndsWith('2') || age.EndsWith('3') || age.EndsWith('4')) && !age.StartsWith('1'))
            {
                age += " года";
            }
            else if (age.EndsWith('1') && (!age.StartsWith('1') || age.Length == 1))
            {
                age += " год";
            }
            else
            {
                age += " лет";
            }
            return age;
        }

    }
}
