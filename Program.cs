using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BirthdaysReminder
{
    public class Program
    {
        public static List<Person> personsToRemove = new();

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BDapp app = new();
            Form1 form = new(app);
            try
            {
                form.app.Persons = app.GetPeopleList(app.ReadFile("db.csv"));
                ShowToday(form);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                form.label1.Text = ex.Message;
                form.PreviousButton.Enabled = false;
            }
            catch (FormatException ex)
            {
                form.label1.Text = ex.Message;
                form.PreviousButton.Enabled = false;
                form.NextButton.Enabled = false;
            }
            Application.Run(form);
        }


        public static void ShowToday(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons));
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения сегодня";
        }


        public static void ShowThisMonth(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.thisMonth), Mode.thisMonth);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в этом месяце";
        }


        public static void ShowJan(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.jan), Mode.jan);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в январе";
        }


        public static void ShowFeb(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.feb), Mode.feb);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в феврале";
        }

        public static void ShowMar(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.mar), Mode.mar);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в марте";
        }


        public static void ShowApr(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.apr), Mode.apr);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в апреле";
        }


        public static void ShowMay(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.may), Mode.may);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в мае";
        }


        public static void ShowJun(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.jun), Mode.jun);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в июне";
        }


        public static void ShowJul(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.jul), Mode.jul);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в июле";
        }


        public static void ShowAug(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.aug), Mode.aug);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в августе";
        }


        public static void ShowSep(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.sep), Mode.sep);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в сентябре";
        }


        public static void ShowOct(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.oct), Mode.oct);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в октябре";
        }


        public static void ShowNov(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.nov), Mode.nov);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в ноябре";
        }


        public static void ShowDec(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.dec), Mode.dec);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в декабре";
        }


        public static void ShowAll(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.all), Mode.all);
            form.label1.Text = form.app.Text;
            form.Text = "Все дни рождения";
        }
    }
}
