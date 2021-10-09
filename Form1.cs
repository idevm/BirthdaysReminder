using System;
using System.Windows.Forms;

namespace BirthdaysReminder
{
    public partial class Form1 : Form
    {
        public Form1(BDapp app)
        {
            InitializeComponent();
            this.app = app;
        }

        public BDapp app;

        private void ThisMonthButton_Click(object sender, EventArgs e)
        {
            if (this.thisMonthButton.Text == "В этом месяце")
            {
                Program.ThisMonth(app);
                this.thisMonthButton.Text = "Все";
            }
            else if (this.thisMonthButton.Text == "Сегодня" || this.thisMonthButton.Text == "ОК")
            {
                Program.Today(app);
                this.thisMonthButton.Text = "В этом месяце";
            }
            else if (this.thisMonthButton.Text == "Все")
            {
                Program.ThisYear(app);
                this.thisMonthButton.Text = "Сегодня";
            }
            else if (this.thisMonthButton.Text == "Отменить")
            {
                this.thisMonthButton.Text = "В этом месяце";
                Program.Today(app);
                this.AddBDButton.Text = "Добавить ДР";
                app.form.textBox1.Text = "";
                app.form.textBox1.Enabled = false;
            }
            else if (this.thisMonthButton.Text == "Назад ")
            {
                app.form.textBox1.Focus();
                app.form.label1.Text = "Введите ФИО";
                this.AddBDButton.Text = "Далее";
                this.thisMonthButton.Text = "Отменить";
                app.form.textBox1.Text = "";
            }
        }


        private void AddBDButton_Click(object sender, EventArgs e)
        {
            if (this.AddBDButton.Text == "Добавить ДР")
            {
                app.form.textBox1.Enabled = true;
                app.form.textBox1.Focus();
                app.form.label1.Text = "Введите ФИО";
                this.AddBDButton.Text = "Далее";
                this.thisMonthButton.Text = "Отменить";
                app.form.Text = "Добавление данных";

            }
            else if (this.AddBDButton.Text == "Далее")
            {
                app.form.textBox1.Focus();
                app.tName = app.form.textBox1.Text;
                if (app.ValidInput(name: app.tName))
                {
                    app.form.label1.Text = "Введите дату рождения\n(в формате ДД.ММ.ГГГГ)";
                    app.form.textBox1.Text = "";
                    this.AddBDButton.Text = "Далее ";
                    this.thisMonthButton.Text = "Назад ";
                }
                else
                {
                    app.form.label1.Text = "Введите корректные ФИО\n(например: Иванов Иван Иванович)";
                    app.form.textBox1.Focus();
                }
            }
            else if (this.AddBDButton.Text == "Далее ")
            {
                app.tBD = app.form.textBox1.Text;
                if (app.ValidInput(birthday: app.tBD))
                {
                    app.form.label1.Text = $"Сохранить \"{app.tName} ({app.tBD})\"?";
                    this.AddBDButton.Text = "Сохранить";
                    this.thisMonthButton.Text = "Отменить";
                    app.form.textBox1.Text = "";
                    app.form.textBox1.Enabled = false;
                }
                else
                {
                    app.form.label1.Text = "Введите корректную дату рождения в формате ДД.ММ.ГГГГ\n(например: 02.08.1999)";
                    app.form.textBox1.Focus();
                }
            }
            else if (this.AddBDButton.Text == "Сохранить")
            {
                app.WriteFile("db.csv", app.AddText(app.Lines, app.tName, app.tBD));
                this.AddBDButton.Text = "Добавить ДР";
                this.thisMonthButton.Text = "ОК";
                this.thisMonthButton.Enabled = true;
                app.form.label1.Text = $"Сохранено: \"{ app.tName} ({ app.tBD})\"";
            }
        }

    }
}
