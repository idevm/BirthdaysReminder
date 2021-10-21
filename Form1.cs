using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BirthdaysReminder
{
    public enum State
    {
        today,
        thisMonth,
        thisYear,
        addingName,
        addingBirthday,
        addingConfirm,
        addingComplete,
        removingByName,
        removingConfirm,
        removingComplete,
        findingByName,
        findingByDate,
        findingComplete
    }

    public partial class Form1 : Form
    {
        public Form1(BDapp app)
        {
            InitializeComponent();
            this.app = app;
        }

        public BDapp app;

        public State state = State.today;

        public string tName = "";

        public string tBD = "";


        private void PreviousButton_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case State.today:
                    break;
                case State.thisMonth:
                    break;
                case State.thisYear:
                    break;
                case State.addingName:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.Today(this);
                    break;
                case State.addingBirthday:
                    state = State.addingName;
                    PreviousButton.Text = "Отменить";
                    NextButton.Text = "Далее";
                    inputBox1.Visible = true;
                    inputBox1.Focus();
                    label1.Text = "Введите ФИО";
                    Text = "Добавление данных";
                    break;
                case State.addingConfirm:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.Today(this);
                    break;
                case State.addingComplete:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.Today(this);
                    break;
                case State.removingByName:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.Today(this);
                    break;
                case State.removingConfirm:
                    if (Program.prsns.Count != 0)
                    {
                        Program.prsns.RemoveAt(0);
                        if (Program.prsns.Count != 0)
                        {
                            label1.Text = $"Удалить {Program.prsns[0].Name}?";
                            NextButton.Text = "Удалить!";
                            PreviousButton.Text = "Нет";
                        }
                        else
                        {
                            app.WriteFile("db.csv", app.UpdateText(app.Persons));
                            state = State.today;
                            PreviousButton.Visible = false;
                            NextButton.Visible = false;
                            inputBox1.Visible = false;
                            Program.Today(this);
                        }
                    }
                    break;
                case State.removingComplete:
                    app.WriteFile("db.csv", app.UpdateText(app.Persons));
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.Today(this);
                    break;
                case State.findingByName:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.Today(this);
                    break;
                case State.findingByDate:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.Today(this);
                    break;
                case State.findingComplete:
                    break;
            }
        }


        private void NextButton_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case State.today:
                    break;
                case State.thisMonth:
                    break;
                case State.thisYear:
                    break;
                case State.addingName:
                    inputBox1.Focus();
                    tName = inputBox1.Text;
                    if (app.ValidInput(name: tName))
                    {
                        state = State.addingBirthday;
                        label1.Text = "Введите дату рождения\n(в формате ДД.ММ.ГГГГ)";
                        inputBox1.Text = "";
                        NextButton.Text = "Далее ";
                        PreviousButton.Text = "Назад ";
                    }
                    else
                    {
                        label1.Text = "Введите корректные ФИО\n(например: Иванов Иван Иванович)";
                        inputBox1.Focus();
                    }
                    break;
                case State.addingBirthday:
                    tBD = inputBox1.Text;
                    if (app.ValidInput(birthday: tBD))
                    {
                        state = State.addingConfirm;
                        label1.Text = $"Сохранить \"{tName} ({tBD})\"?";
                        NextButton.Text = "Сохранить";
                        PreviousButton.Text = "Отменить";
                        inputBox1.Text = "";
                    }
                    else
                    {
                        label1.Text = "Введите корректную дату рождения в формате ДД.ММ.ГГГГ\n(например: 02.08.1999)";
                        inputBox1.Focus();
                    }
                    break;
                case State.addingConfirm:
                    state = State.addingComplete;
                    app.Persons = app.AddPerson(app.Persons, tName, tBD);
                    app.WriteFile("db.csv", app.UpdateText(app.Persons));
                    NextButton.Text = "Добавить еще";
                    PreviousButton.Text = "ОК";
                    label1.Text = $"Сохранено: \"{ tName} ({ tBD})\"";
                    break;
                case State.addingComplete:
                    state = State.addingName;
                    PreviousButton.Text = "Отменить";
                    NextButton.Text = "Далее";
                    inputBox1.Focus();
                    label1.Text = "Введите ФИО";
                    Text = "Добавление данных";
                    break;
                case State.removingByName:
                    string name = inputBox1.Text;
                    Program.prsns = app.FindPersonByName(app.Persons, name);
                    Text = "Удаление данных";
                    if (Program.prsns.Count != 0)
                    {
                        state = State.removingConfirm;
                        label1.Text = $"Удалить {Program.prsns[0].Name}?";
                        NextButton.Text = "Удалить!";
                        PreviousButton.Text = "Нет";
                    }
                    else
                    {
                        label1.Text = "Нет данных для удаления";
                        state = State.today;
                        PreviousButton.Visible = false;
                        NextButton.Visible = false;
                        inputBox1.Visible = false;
                        Program.Today(this);
                    }
                    break;
                case State.removingConfirm:
                    if (Program.prsns.Count != 0)
                    {
                        app.RemovePerson(app.Persons, Program.prsns[0]);
                        Program.prsns.RemoveAt(0);
                        label1.Text = "Удалено";
                        if (Program.prsns.Count != 0)
                        {
                            state = State.removingByName;
                        }
                        else
                        {
                            state = State.removingComplete;
                        }
                    }
                    else
                    {
                        state = State.removingComplete;
                    }
                    NextButton.Text = "ОК";
                    PreviousButton.Text = "Отменить";
                    break;
                case State.removingComplete:
                    app.WriteFile("db.csv", app.UpdateText(app.Persons));
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.Today(this);
                    break;
                case State.findingByName:
                    string txt = inputBox1.Text;
                    app.Text = app.GetText(app.FindPersonByName(app.Persons, txt), Mode.findResults);
                    label1.Text = app.Text;
                    Text = "Результат поиска";
                    break;
                case State.findingByDate:
                    string[] dateArr = inputBox1.Text.Split(".");
                    int d = -1;
                    int m = -1;
                    int y = -1;
                    try
                    {
                        d = int.Parse(dateArr[0]);
                        m = int.Parse(dateArr[1]);
                        y = int.Parse(dateArr[2]);
                    }
                    catch (Exception) { }
                    app.Text = app.GetText(app.FindPersonByDate(app.Persons, d,m,y), Mode.findResults);
                    label1.Text = app.Text;
                    Text = "Результат поиска";
                    break;
                case State.findingComplete:
                    break;
            }
        }


        private void ToolStripMenuItemToday_Click(object sender, EventArgs e)
        {
            state = State.today;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.Today(this);
        }


        private void ToolStripMenuItemThisMonth_Click(object sender, EventArgs e)
        {
            state = State.thisMonth;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ThisMonth(this);
        }


        private void ToolStripMenuItemAThisYear_Click(object sender, EventArgs e)
        {
            state = State.thisYear;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ThisYear(this);
        }


        private void ToolStripMenuItemFindByName_Click(object sender, EventArgs e)
        {
            state = State.findingByName;
            PreviousButton.Visible = true;
            PreviousButton.Text = "Отменить";
            NextButton.Visible = true;
            NextButton.Text = "Найти";
            inputBox1.Visible = true;
            inputBox1.Text = "";
            inputBox1.Focus();
            label1.Text = "Введите имя для поиска и нажмите кнопку 'Найти'";
            Text = "Поиск";
        }


        private void ToolStripMenuItemFindByDate_Click(object sender, EventArgs e)
        {
            state = State.findingByDate;
            PreviousButton.Visible = true;
            PreviousButton.Text = "Отменить";
            NextButton.Visible = true;
            NextButton.Text = "Найти";
            inputBox1.Visible = true;
            inputBox1.Text = "";
            inputBox1.Focus();
            label1.Text = "Введите дату для поиска и нажмите кнопку 'Найти'";
            Text = "Поиск";
        }


        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            state = State.addingName;
            PreviousButton.Visible = true;
            PreviousButton.Text = "Отменить";
            NextButton.Visible = true;
            NextButton.Text = "Далее";
            inputBox1.Visible = true;
            inputBox1.Focus();
            label1.Text = "Введите ФИО";
            Text = "Добавление данных";
        }


        private void ToolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
            state = State.removingByName;
            PreviousButton.Visible = true;
            PreviousButton.Text = "Отменить";
            NextButton.Visible = true;
            NextButton.Text = "Далее";
            inputBox1.Visible = true;
            inputBox1.Focus();
            label1.Text = "Введите ФИО для удаления";
            Text = "Удаление данных";
        }
    }
}
