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

        public string tName = "";

        public string tBD = "";

        private void ModeButton_Click(object sender, EventArgs e)
        {
            if (this.ModeButton.Text == "В этом месяце")
            {
                Program.ThisMonth(this);
                this.ModeButton.Text = "Все";
            }
            else if (this.ModeButton.Text == "Сегодня" || this.ModeButton.Text == "ОК")
            {
                Program.Today(this);
                this.ModeButton.Text = "В этом месяце";
            }
            else if (this.ModeButton.Text == "Все")
            {
                Program.ThisYear(this);
                this.ModeButton.Text = "Сегодня";
            }
            else if (this.ModeButton.Text == "Отменить")
            {
                this.ModeButton.Text = "В этом месяце";
                Program.Today(this);
                this.AddBDButton.Text = "Добавить ДР";
                textBox1.Text = "";
                textBox1.Enabled = false;
            }
            else if (this.ModeButton.Text == "Назад ")
            {
                textBox1.Focus();
                label1.Text = "Введите ФИО";
                this.AddBDButton.Text = "Далее";
                this.ModeButton.Text = "Отменить";
                textBox1.Text = "";
            }
        }


        private void AddBDButton_Click(object sender, EventArgs e)
        {
            if (this.AddBDButton.Text == "Добавить ДР")
            {
                textBox1.Enabled = true;
                textBox1.Focus();
                label1.Text = "Введите ФИО";
                this.AddBDButton.Text = "Далее";
                this.ModeButton.Text = "Отменить";
                Text = "Добавление данных";
            }
            else if (this.AddBDButton.Text == "Далее")
            {
                textBox1.Focus();
                tName = textBox1.Text;
                if (app.ValidInput(name: tName))
                {
                    label1.Text = "Введите дату рождения\n(в формате ДД.ММ.ГГГГ)";
                    textBox1.Text = "";
                    this.AddBDButton.Text = "Далее ";
                    this.ModeButton.Text = "Назад ";
                }
                else
                {
                    label1.Text = "Введите корректные ФИО\n(например: Иванов Иван Иванович)";
                    textBox1.Focus();
                }
            }
            else if (this.AddBDButton.Text == "Далее ")
            {
                tBD = textBox1.Text;
                if (app.ValidInput(birthday: tBD))
                {
                    label1.Text = $"Сохранить \"{tName} ({tBD})\"?";
                    this.AddBDButton.Text = "Сохранить";
                    this.ModeButton.Text = "Отменить";
                    textBox1.Text = "";
                    textBox1.Enabled = false;
                }
                else
                {
                    label1.Text = "Введите корректную дату рождения в формате ДД.ММ.ГГГГ\n(например: 02.08.1999)";
                    textBox1.Focus();
                }
            }
            else if (this.AddBDButton.Text == "Сохранить")
            {
                app.Persons = app.AddPerson(app.Persons, tName, tBD);
                app.WriteFile("db.csv", app.UpdateText(app.Persons));
                this.AddBDButton.Text = "Добавить ДР";
                this.ModeButton.Text = "ОК";
                this.ModeButton.Enabled = true;
                label1.Text = $"Сохранено: \"{ tName} ({ tBD})\"";
            }
        }
    }
}
