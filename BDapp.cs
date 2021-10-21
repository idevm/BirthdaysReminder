﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdaysReminder
{
    public enum Mode
    {
        today,
        thisMonth,
        thisYear,
        findResults
    }


    public class BDapp
    {
        private List<Person> persons = new();
        private string text;

        public int DayNow { get; set; } = DateTime.Now.Day;

        public int MonthNow { get; set; } = DateTime.Now.Month;

        public int YearNow { get; set; } = DateTime.Now.Year;

        public List<Person> Persons { get => persons; set => persons = value; }

        public string Text { get => text; set => text = value; }


        public void WriteFile(string path, string txt)
        {
            System.IO.File.WriteAllText(path, txt);
        }


        public List<string> ReadFile(string path)
        {
            try
            {
                List<string> lines = new();
                lines.AddRange(System.IO.File.ReadAllLines(path));
                return lines;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                System.IO.FileNotFoundException noFile = new(
                    "Не найден файл с данными, а именно: " + ex.Message);
                throw noFile;
            }
        }


        public List<Person> GetPeopleList(List<string> lines)
        {
            if (lines == null || lines.Count == 0)
            {
                throw new FormatException("Ошибка: отсутсвуют данные");
            }
            List<Person> persons = new();
            foreach (string line in lines)
            {
                try
                {
                    string[] values = line.Split(";");
                    if (values.Length != 6)
                    {
                        throw new FormatException($"Неправильный формат таблицы: ошибка в строке  {lines.IndexOf(line) + 1}");
                    }
                    string name = values[2];
                    if (name.Length <= 0)
                    {
                        throw new FormatException($"Отсутствует имя в строке {lines.IndexOf(line) + 1}");
                    }
                    string day = values[4].Split(".")[0];
                    if (!int.TryParse(day, out int num)
                        || day.Length != 2
                        || num > 31)
                    {
                        throw new FormatException($"Неправильный формат дня в строке {lines.IndexOf(line) + 1}");
                    }
                    string month = values[4].Split(".")[1];
                    if (!int.TryParse(month, out num)
                        || month.Length != 2
                        || num > 12)
                    {
                        throw new FormatException($"Неправильный формат месяца в строке {lines.IndexOf(line) + 1}");
                    }
                    string year = values[4].Split(".")[2];
                    if (!int.TryParse(year, out num)
                        || year.Length != 4
                        || num > YearNow)
                    {
                        throw new FormatException($"Неправильный формат года в строке {lines.IndexOf(line) + 1}");
                    }
                    Person p = new(name);
                    p.Birthday = int.Parse(day);
                    p.Birthmonth = int.Parse(month);
                    p.Birthyear = int.Parse(year);
                    p.number = int.Parse(values[0] ?? "0");
                    persons.Add(p);
                }
                catch (FormatException ex)
                {
                    FormatException badFormat = new("База данных повреждена или формат данных не соответствует установленному!\n" + ex.Message);
                    throw badFormat;
                }
            }
            return persons;
        }


        public List<Person> PeopleListFilter(
            List<Person> persons,
            Mode tm = Mode.today)
        {
            List<Person> filteredList = new();
            foreach (Person pers in persons)
            {
                switch (tm)
                {
                    case Mode.today:
                        if (pers.Birthmonth == MonthNow
                            && pers.Birthday == DayNow)
                        {
                            filteredList.Add(pers);
                        }
                        break;
                    case Mode.thisMonth:
                        if (pers.Birthmonth == MonthNow)
                        {
                            filteredList.Add(pers);
                        }
                        break;
                    case Mode.thisYear:
                        return persons;
                }
            }
            return filteredList;
        }


        public string GetText(List<Person> persons, Mode tm = Mode.today)
        {
            StringBuilder text = new("");
            if (persons.Count > 1)
            {
                switch (tm)
                {
                    case Mode.today:
                        text.Append($"Сегодня {ToString(DayNow)}.{ToString(MonthNow)} отмечают день рождения:\n\n");
                        foreach (Person p in persons)
                        {
                            text.Append($"\t{p.Name} ({p.GetAge(YearNow)})\n");
                        }
                        break;
                    case Mode.thisMonth:
                        text.Append($"В этом месяце отмечают день рождения:\n\n");
                        foreach (Person p in persons)
                        {
                            text.Append($"\t{p.Name} ({ToString(p.Birthday)}.{ToString(p.Birthmonth)})\n");
                        }
                        break;
                    case Mode.thisYear:
                        text.Append($"В этом году отмечают день рождения:\n\n");
                        foreach (Person p in persons)
                        {
                            text.Append($"\t{p.Name} ({ToString(p.Birthday)}.{ToString(p.Birthmonth)})\n");
                        }
                        break;
                    case Mode.findResults:
                        text.Append($"Результат поиска:\n\n");
                        foreach (Person p in persons)
                        {
                            text.Append($"\t{p.Name} ({ToString(p.Birthday)}.{ToString(p.Birthmonth)})\n");
                        }
                        break;
                }
            }
            else
            {
                switch (tm)
                {
                    case Mode.today:
                        text.Append(persons.Count == 1
                            ? $"Сегодня {ToString(DayNow)}.{ToString(MonthNow)} отмечает день рождения\n\n\t{ persons[0].Name} ({persons[0].GetAge(YearNow)})\n"
                            : $"Сегодня {ToString(DayNow)}.{ToString(MonthNow)} никто не отмечает день рождения");
                        break;
                    case Mode.thisMonth:
                        text.Append(persons.Count == 1
                            ? $"В этом месяце отмечает день рождения\n\n\t{persons[0].Name} ({ToString(persons[0].Birthday)}.{ToString(persons[0].Birthmonth)})\n"
                            : $"В этом месяце никто не отмечает день рождения");
                        break;
                    case Mode.thisYear:
                        text.Append(persons.Count == 1
                            ? $"В этом году отмечает день рождения\n\n\t{persons[0].Name} ({ToString(persons[0].Birthday)}.{ToString(persons[0].Birthmonth)})\n"
                            : $"В этом году никто не отмечает день рождения");
                        break;
                    case Mode.findResults:
                        text.Append(persons.Count == 1
                            ? $"Результат поиска:\n\n\t{persons[0].Name} ({ToString(persons[0].Birthday)}.{ToString(persons[0].Birthmonth)})\n"
                            : $"Совпадений не найдено");
                        break;
                }
            }
            return text.ToString();
        }


        public List<Person> AddPerson(
            List<Person> persons,
            string name,
            string birthday)
        {
            if (persons == null)
            {
                persons = new();
            }
            int num = 1;
            if (persons.Count != 0)
            {
                num = persons.Count + 1;
            }
            try
            {
                if (!ValidInput(name: name))
                {
                    throw new FormatException("Введите корректные ФИО (например Иванов Иван Иванович)");
                }
                if (!ValidInput(birthday: birthday))
                {
                    throw new FormatException("Введите корректную дату рождения (например 02.08.1999)");
                }
            }
            catch (FormatException ex)
            {
                FormatException badInput = new("Введены некорректные данные\n" + ex.Message);
                throw badInput;
            }
            Person p = new(name.ToUpper());
            p.Birthday = int.Parse(birthday.Substring(0, 2));
            p.Birthmonth = int.Parse(birthday.Substring(3, 2));
            p.Birthyear = int.Parse(birthday.Substring(6, 4));
            p.number = num;
            persons.Add(p);
            return persons;
        }


        public List<Person> RemovePerson(
            List<Person> persons,
            Person personToRemove)
        {
            if (persons == null || persons.Count == 0)
            {
                throw new FormatException("Ошибка: отсутсвуют данные");
            }
            if (personToRemove == null)
            {
                return persons;
            }
            persons.Remove(personToRemove);
            return persons;
        }


        public List<Person> FindPersonByName(List<Person> persons, string name)
        {
            if (persons == null || persons.Count == 0)
            {
                throw new FormatException("Ошибка: отсутсвуют данные");
            }
            return persons.FindAll(x => x.Name.Contains(name));
        }


        public List<Person> FindPersonByDate(
            List<Person> persons,
            int day = -1,
            int month = -1,
            int year = -1)
        {
            if (persons == null || persons.Count == 0)
            {
                throw new FormatException("Ошибка: отсутсвуют данные");
            }
            return persons.FindAll(x =>
            {
                return (ToString(x.Birthday) == ToString(day) || day == -1)
                && (ToString(x.Birthmonth) == ToString(month) || month == -1)
                && (ToString(x.Birthyear) == ToString(year) || year == -1)
                && day + month + year != -3;
            });
        }


        public string UpdateText(List<Person> persons)
        {
            if (persons == null || persons.Count == 0)
            {
                throw new FormatException("Ошибка: отсутсвуют данные");
            }
            StringBuilder text = new();
            try
            {
                persons.Sort();
            }
            catch (ArgumentException)
            {
                throw;
            }
            for (int i = 0; i < persons.Count; i++)
            {
                persons[i].number = i + 1;
            }
            foreach (Person p in persons)
            {
                text.Append($"{p.number};;{p.Name};;{ToString(p.Birthday)}.{ToString(p.Birthmonth)}.{p.Birthyear};\n");
            }
            return text.ToString();
        }


        public bool ValidInput(
            string name = "nameParam",
            string birthday = "birthdayParam")
        {
            if (name == "nameParam" && birthday == "birthdayParam")
            {
                return false;
            }
            if (name != "nameParam")
            {
                if (name.Length < 1)
                {
                    return false;
                }
            }
            if (birthday != "birthdayParam")
            {
                if (birthday.Length < 1 || birthday.Split(".").Length != 3)
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


        public string ToString(int num)
        {
            return num.ToString().Length >= 2
                ? num.ToString()
                : "0" + num.ToString();
        }
    }
}