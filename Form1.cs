﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirthdaysReminder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void thisMonthButton_Click(object sender, EventArgs e)
        {
            if (this.thisMonthButton.Text == "В этом месяце")
            {
                Program.Lines = Program.ReadFile("db.csv");
                Program.People = Program.GetPeopleList(Program.Lines, "thisMonth");
                Program.Text = Program.GetTextThisMonth(Program.People);
                Program.ShowText(Program.Text);
                Program.form.Text = "Дни рождения в этом месяце";
                this.thisMonthButton.Text = "Сегодня";
            }
            else if (this.thisMonthButton.Text == "Сегодня")
            {
                Program.Lines = Program.ReadFile("db.csv");
                Program.People = Program.GetPeopleList(Program.Lines);
                Program.Text = Program.GetTextToday(Program.People);
                Program.ShowText(Program.Text);
                Program.form.Text = "Дни рождения сегодня";
                this.thisMonthButton.Text = "В этом месяце";
            }
            else if (this.thisMonthButton.Text == "Отменить")
            {
                this.thisMonthButton.Text = "В этом месяце";
                Program.Lines = Program.ReadFile("db.csv");
                Program.People = Program.GetPeopleList(Program.Lines);
                Program.Text = Program.GetTextToday(Program.People);
                Program.ShowText(Program.Text);
                Program.form.Text = "Дни рождения сегодня";
                this.AddBDButton.Text = "Добавить ДР";
                Program.form.textBox1.Text = "";
                Program.form.textBox1.Enabled = false;
            }
            else if (this.thisMonthButton.Text == "Назад ")
            {
                Program.form.textBox1.Focus();
                Program.form.label1.Text = "Введите ФИО";
                this.AddBDButton.Text = "Далее";
                this.thisMonthButton.Text = "Отменить";
                Program.form.textBox1.Text = "";
            }
        }


        private void AddBDButton_Click(object sender, EventArgs e)
        {
            if (this.AddBDButton.Text == "Добавить ДР")
            {
                Program.form.textBox1.Enabled = true;
                Program.form.textBox1.Focus();
                Program.form.label1.Text = "Введите ФИО";
                this.AddBDButton.Text = "Далее";
                this.thisMonthButton.Text = "Отменить";
            }
            else if (this.AddBDButton.Text == "Далее")
            {
                Program.form.textBox1.Focus();
                Program.tName = Program.form.textBox1.Text;
                if (Program.ValidInput(name: Program.tName))
                {
                    Program.form.label1.Text = "Введите ДР";
                    Program.form.textBox1.Text = "";
                    this.AddBDButton.Text = "Далее ";
                    this.thisMonthButton.Text = "Назад ";
                }
                else
                {
                    Program.form.label1.Text = "Введите корректные ФИО";
                    Program.form.textBox1.Focus();
                }
            }
            else if (this.AddBDButton.Text == "Далее ")
            {
                Program.tBD = Program.form.textBox1.Text;
                if (Program.ValidInput(birthday: Program.tBD))
                {
                    Program.form.label1.Text = $"Сохранить {Program.tName} ({Program.tBD})?";
                    this.AddBDButton.Text = "Сохранить";
                    this.thisMonthButton.Text = "Отменить";
                    Program.form.textBox1.Text = "";
                    Program.form.textBox1.Enabled = false;
                }
                else
                {
                    Program.form.label1.Text = "Введите корректную ДР";
                    Program.form.textBox1.Focus();
                }
            }
            else if (this.AddBDButton.Text == "Сохранить")
            {
                Program.WriteFile("db.csv", Program.AddText(Program.Lines, Program.tName, Program.tBD));
                this.AddBDButton.Text = "Добавить ДР";
                this.thisMonthButton.Text = "В этом месяце";
                Program.form.label1.Text = $"Сохранено: { Program.tName} ({ Program.tBD})";
                Program.form.Text = "Дни рождения сегодня";
            }
        }

    }
}
