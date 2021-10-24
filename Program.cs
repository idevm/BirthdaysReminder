using System;
using System.Windows.Forms;

namespace BirthdaysReminder
{
    public class Program
    {
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


        public static void ShowMonth(Form1 form, Mode md = Mode.thisMonth)
        {
            switch (md)
            {
                case Mode.thisMonth:
                    form.Text = "Дни рождения в этом месяце";
                    break;
                case Mode.jan:
                    form.Text = "Дни рождения в январе";
                    break;
                case Mode.feb:
                    form.Text = "Дни рождения в феврале";
                    break;
                case Mode.mar:
                    form.Text = "Дни рождения в марте";
                    break;
                case Mode.apr:
                    form.Text = "Дни рождения в апреле";
                    break;
                case Mode.may:
                    form.Text = "Дни рождения в мае";
                    break;
                case Mode.jun:
                    form.Text = "Дни рождения в июне";
                    break;
                case Mode.jul:
                    form.Text = "Дни рождения в июле";
                    break;
                case Mode.aug:
                    form.Text = "Дни рождения в августе";
                    break;
                case Mode.sep:
                    form.Text = "Дни рождения в сентябре";
                    break;
                case Mode.oct:
                    form.Text = "Дни рождения в октябре";
                    break;
                case Mode.nov:
                    form.Text = "Дни рождения в ноябре";
                    break;
                case Mode.dec:
                    form.Text = "Дни рождения в декабре";
                    break;
            }
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, md), md);
            form.label1.Text = form.app.Text;
        }


        public static void ShowAll(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.all), Mode.all);
            form.label1.Text = form.app.Text;
            form.Text = "Все дни рождения";
        }
    }
}
