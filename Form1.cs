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

        private void ModeButton_Click(object sender, EventArgs e)
        {
            if (this.ModeButton.Text == "В этом месяце")
            {
                Program.ThisMonth(app);
                this.ModeButton.Text = "Все";
            }
            else if (this.ModeButton.Text == "Сегодня" || this.ModeButton.Text == "ОК")
            {
                Program.Today(app);
                this.ModeButton.Text = "В этом месяце";
            }
            else if (this.ModeButton.Text == "Все")
            {
                Program.ThisYear(app);
                this.ModeButton.Text = "Сегодня";
            }
            else if (this.ModeButton.Text == "Отменить")
            {
                this.ModeButton.Text = "В этом месяце";
                Program.Today(app);
                this.AddBDButton.Text = "Добавить ДР";
                app.Form.textBox1.Text = "";
                app.Form.textBox1.Enabled = false;
            }
            else if (this.ModeButton.Text == "Назад ")
            {
                app.Form.textBox1.Focus();
                app.Form.label1.Text = "Введите ФИО";
                this.AddBDButton.Text = "Далее";
                this.ModeButton.Text = "Отменить";
                app.Form.textBox1.Text = "";
            }
        }


        private void AddBDButton_Click(object sender, EventArgs e)
        {
            if (this.AddBDButton.Text == "Добавить ДР")
            {
                app.Form.textBox1.Enabled = true;
                app.Form.textBox1.Focus();
                app.Form.label1.Text = "Введите ФИО";
                this.AddBDButton.Text = "Далее";
                this.ModeButton.Text = "Отменить";
                app.Form.Text = "Добавление данных";
            }
            else if (this.AddBDButton.Text == "Далее")
            {
                app.Form.textBox1.Focus();
                app.tName = app.Form.textBox1.Text;
                if (app.ValidInput(name: app.tName))
                {
                    app.Form.label1.Text = "Введите дату рождения\n(в формате ДД.ММ.ГГГГ)";
                    app.Form.textBox1.Text = "";
                    this.AddBDButton.Text = "Далее ";
                    this.ModeButton.Text = "Назад ";
                }
                else
                {
                    app.Form.label1.Text = "Введите корректные ФИО\n(например: Иванов Иван Иванович)";
                    app.Form.textBox1.Focus();
                }
            }
            else if (this.AddBDButton.Text == "Далее ")
            {
                app.tBD = app.Form.textBox1.Text;
                if (app.ValidInput(birthday: app.tBD))
                {
                    app.Form.label1.Text = $"Сохранить \"{app.tName} ({app.tBD})\"?";
                    this.AddBDButton.Text = "Сохранить";
                    this.ModeButton.Text = "Отменить";
                    app.Form.textBox1.Text = "";
                    app.Form.textBox1.Enabled = false;
                }
                else
                {
                    app.Form.label1.Text = "Введите корректную дату рождения в формате ДД.ММ.ГГГГ\n(например: 02.08.1999)";
                    app.Form.textBox1.Focus();
                }
            }
            else if (this.AddBDButton.Text == "Сохранить")
            {
                app.WriteFile("db.csv", app.AddText(app.Lines, app.tName, app.tBD));
                this.AddBDButton.Text = "Добавить ДР";
                this.ModeButton.Text = "ОК";
                this.ModeButton.Enabled = true;
                app.Form.label1.Text = $"Сохранено: \"{ app.tName} ({ app.tBD})\"";
            }
        }
    }
}
