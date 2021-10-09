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
            try
            {
                Today(app);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                app.ShowText(ex.Message);
                app.Form.ModeButton.Enabled = false;
            }
            catch (FormatException ex)
            {
                app.ShowText(ex.Message);
                app.Form.ModeButton.Enabled = false;
                app.Form.AddBDButton.Enabled = false;
            }
            Application.Run(app.Form);
        }

        public static void Today(BDapp app)
        {
            app.Lines = app.ReadFile("db.csv");
            app.People = app.GetPeopleList(app.Lines);
            app.Text = app.GetText(app.People);
            app.ShowText(app.Text);
            app.Form.Text = "Дни рождения сегодня";
        }

        public static void ThisMonth(BDapp app)
        {
            app.Lines = app.ReadFile("db.csv");
            app.People = app.GetPeopleList(app.Lines, TimeMode.thisMonth);
            app.Text = app.GetText(app.People, TimeMode.thisMonth);
            app.ShowText(app.Text);
            app.Form.Text = "Дни рождения в этом месяце";
        }

        public static void ThisYear(BDapp app)
        {
            app.Lines = app.ReadFile("db.csv");
            app.People = app.GetPeopleList(app.Lines, TimeMode.thisYear);
            app.Text = app.GetText(app.People, TimeMode.thisYear);
            app.ShowText(app.Text);
            app.Form.Text = "Все дни рождения";
        }
    }
}
