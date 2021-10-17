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
                Today(form);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                form.label1.Text = ex.Message;
                form.ModeButton.Enabled = false;
            }
            catch (FormatException ex)
            {
                form.label1.Text = ex.Message;
                form.ModeButton.Enabled = false;
                form.AddBDButton.Enabled = false;
            }
            Application.Run(form);
        }

        public static void Today(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons));
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения сегодня";
        }

        public static void ThisMonth(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.thisMonth), Mode.thisMonth);
            form.label1.Text = form.app.Text;
            form.Text = "Дни рождения в этом месяце";
        }

        public static void ThisYear(Form1 form)
        {
            form.app.Text = form.app.GetText(form.app.PeopleListFilter(form.app.Persons, Mode.thisYear), Mode.thisYear);
            form.label1.Text = form.app.Text;
            form.Text = "Все дни рождения";
        }
    }
}
