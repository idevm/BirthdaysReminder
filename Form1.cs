using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BirthdaysReminder
{
    public enum State
    {
        today,
        month,
        allBDs,
        addingName,
        addingBirthday,
        addingConfirm,
        addingComplete,
        inputNameToTemove,
        removingByName,
        removingConfirm,
        removingComplete,
        findingByName,
        findingByDate
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
                case State.addingName:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.ShowToday(this);
                    break;
                case State.addingBirthday:
                    state = State.addingName;
                    PreviousButton.Text = "Отменить";
                    NextButton.Text = "Далее";
                    inputBox1.Visible = true;
                    inputBox1.Focus();
                    label1.Text = "Введите ФИО для добавления в список";
                    Text = "Добавление данных";
                    break;
                case State.addingConfirm:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.ShowToday(this);
                    break;
                case State.addingComplete:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.ShowToday(this);
                    break;
                case State.inputNameToTemove:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.ShowToday(this);
                    break;
                case State.removingByName:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.ShowToday(this);
                    break;
                case State.removingConfirm:
                    if (Program.personsToRemove.Count != 0)
                    {
                        Program.personsToRemove.RemoveAt(0);
                        if (Program.personsToRemove.Count != 0)
                        {
                            label1.Text = $"Удалить {Program.personsToRemove[0].Name}?";
                            PreviousButton.Text = "Нет";
                            NextButton.Text = "Да";
                        }
                        else
                        {
                            app.WriteFile("db.csv", app.UpdateText(app.Persons));
                            state = State.today;
                            PreviousButton.Visible = false;
                            NextButton.Visible = false;
                            inputBox1.Visible = false;
                            Program.ShowToday(this);
                        }
                    }
                    break;
                case State.removingComplete:
                    app.WriteFile("db.csv", app.UpdateText(app.Persons));
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.ShowToday(this);
                    break;
                case State.findingByName:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.ShowToday(this);
                    break;
                case State.findingByDate:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.ShowToday(this);
                    break;
            }
        }


        private void NextButton_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case State.addingName:
                    tName = inputBox1.Text;
                    if (app.ValidInput(name: tName))
                    {
                        state = State.addingBirthday;
                        label1.Text = "Введите дату рождения\n(в формате ДД.ММ.ГГГГ)";
                        inputBox1.Text = "";
                        inputBox1.Focus();
                        NextButton.Text = "Далее ";
                        PreviousButton.Text = "Назад ";
                    }
                    else
                    {
                        label1.Text = "Введите корректные ФИО\n(например: 'Иванов Иван Иванович')";
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
                        inputBox1.Enabled = false;
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
                    NextButton.Text = "Добавить";
                    PreviousButton.Text = "ОК";
                    label1.Text = $"Сохранено: \"{ tName} ({ tBD})\"";
                    break;
                case State.addingComplete:
                    state = State.addingName;
                    PreviousButton.Text = "Отменить";
                    NextButton.Text = "Далее";
                    inputBox1.Enabled = true;
                    inputBox1.Focus();
                    label1.Text = "Введите ФИО";
                    Text = "Добавление данных";
                    break;
                case State.inputNameToTemove:
                    string name = inputBox1.Text;
                    inputBox1.Enabled = false;
                    Program.personsToRemove = app.FindPersonByName(app.Persons, name);
                    Text = "Удаление данных";
                    if (Program.personsToRemove.Count != 0)
                    {
                        label1.Text = $"Удалить {Program.personsToRemove[0].Name} ({app.ToString(Program.personsToRemove[0].Birthday)}.{app.ToString(Program.personsToRemove[0].Birthmonth)}.{app.ToString(Program.personsToRemove[0].Birthyear)})?";
                        PreviousButton.Text = "Нет";
                        NextButton.Text = "Да";
                        state = State.removingConfirm;
                    }
                    else
                    {
                        label1.Text = "Нет данных для удаления";
                        PreviousButton.Text = "Отменить";
                        NextButton.Text = "ОК";
                        state = State.removingComplete;
                    }
                    break;
                case State.removingByName:
                    if (Program.personsToRemove.Count != 0)
                    {
                        state = State.removingConfirm;
                        label1.Text = $"Удалить {Program.personsToRemove[0].Name} ({app.ToString(Program.personsToRemove[0].Birthday)}.{app.ToString(Program.personsToRemove[0].Birthmonth)}.{app.ToString(Program.personsToRemove[0].Birthyear)})?";
                        PreviousButton.Text = "Нет";
                        NextButton.Text = "Да";
                    }
                    else
                    {
                        label1.Text = "Нет данных для удаления";
                        state = State.today;
                        PreviousButton.Visible = false;
                        NextButton.Visible = false;
                        inputBox1.Visible = false;
                        Program.ShowToday(this);
                    }
                    break;
                case State.removingConfirm:
                    if (Program.personsToRemove.Count != 0)
                    {
                        app.RemovePerson(app.Persons, Program.personsToRemove[0]);
                        label1.Text = $"Удалено: {Program.personsToRemove[0].Name} ({app.ToString(Program.personsToRemove[0].Birthday)}.{app.ToString(Program.personsToRemove[0].Birthmonth)}.{app.ToString(Program.personsToRemove[0].Birthyear)})";
                        Program.personsToRemove.RemoveAt(0);
                        if (Program.personsToRemove.Count != 0)
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
                    PreviousButton.Text = "Отменить";
                    NextButton.Text = "ОК";
                    break;
                case State.removingComplete:
                    app.WriteFile("db.csv", app.UpdateText(app.Persons));
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.ShowToday(this);
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
            }
        }


        private void ToolStripMenuItemToday_Click(object sender, EventArgs e)
        {
            state = State.today;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowToday(this);
        }


        private void ToolStripMenuItemThisMonth_Click(object sender, EventArgs e)
        {
            state = State.month;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowThisMonth(this);
        }


        private void ToolStripMenuItemAThisYear_Click(object sender, EventArgs e)
        {
            state = State.allBDs;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowAll(this);
        }


        private void ToolStripMenuItemFindByName_Click(object sender, EventArgs e)
        {
            state = State.findingByName;
            PreviousButton.Visible = true;
            PreviousButton.Text = "Отменить";
            NextButton.Visible = true;
            NextButton.Text = "Найти";
            inputBox1.Visible = true;
            inputBox1.Enabled = true;
            inputBox1.Text = "";
            inputBox1.Focus();
            label1.Text = "Введите имя для поиска и нажмите кнопку 'Найти'\n(например: 'Иванов Иван Иванович')";
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
            inputBox1.Enabled = true;
            inputBox1.Text = "";
            inputBox1.Focus();
            label1.Text = "Введите дату для поиска и нажмите кнопку 'Найти'\n(например: '31.12' или '01.01.2001')";
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
            inputBox1.Enabled = true;
            inputBox1.Text = "";
            inputBox1.Focus();
            label1.Text = "Введите ФИО для добавления в список\n(например: 'Иванов Иван Иванович')";
            Text = "Добавление данных";
        }


        private void ToolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
            state = State.inputNameToTemove;
            PreviousButton.Visible = true;
            PreviousButton.Text = "Отменить";
            NextButton.Visible = true;
            NextButton.Text = "Далее";
            inputBox1.Visible = true;
            inputBox1.Enabled = true;
            inputBox1.Text = "";
            inputBox1.Focus();
            label1.Text = "Введите ФИО для удаления";
            Text = "Удаление данных";
        }


        private void InputBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NextButton_Click(sender, e);
            }
        }

        private void ToolStripMenuItemJan_Click(object sender, EventArgs e)
        {
            state = State.month;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowJan(this);
        }

        private void ToolStripMenuItemFeb_Click(object sender, EventArgs e)
        {
            state = State.month;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowFeb(this);
        }

        private void ToolStripMenuItemMar_Click(object sender, EventArgs e)
        {
            state = State.month;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowMar(this);
        }

        private void ToolStripMenuItemApr_Click(object sender, EventArgs e)
        {
            state = State.month;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowApr(this);
        }

        private void ToolStripMenuItemMay_Click(object sender, EventArgs e)
        {
            state = State.month;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowMay(this);
        }

        private void ToolStripMenuItemJun_Click(object sender, EventArgs e)
        {
            state = State.month;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowJun(this);
        }

        private void ToolStripMenuItemJul_Click(object sender, EventArgs e)
        {
            state = State.month;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowJul(this);
        }

        private void ToolStripMenuItemAug_Click(object sender, EventArgs e)
        {
            state = State.month;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowAug(this);
        }

        private void ToolStripMenuItemSep_Click(object sender, EventArgs e)
        {
            state = State.month;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowSep(this);
        }

        private void ToolStripMenuItemOct_Click(object sender, EventArgs e)
        {
            state = State.month;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowOct(this);
        }

        private void ToolStripMenuItemNov_Click(object sender, EventArgs e)
        {
            state = State.month;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowNov(this);
        }

        private void ToolStripMenuItemDec_Click(object sender, EventArgs e)
        {
            state = State.month;
            PreviousButton.Visible = false;
            NextButton.Visible = false;
            inputBox1.Visible = false;
            Program.ShowDec(this);
        }
    }
}
