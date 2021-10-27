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
        removingAll,
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

        public int ndx = 1;

        public List<Person> personsToRemove = new();

        public int personsToRemoveCount = 0;


        private void ManageForm(State st, Mode md = Mode.thisMonth)
        {
            switch (st)
            {
                case State.today:
                    state = State.today;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.ShowToday(this);
                    break;
                case State.month:
                    state = State.month;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.ShowMonth(this, md);
                    break;
                case State.allBDs:
                    state = State.allBDs;
                    PreviousButton.Visible = false;
                    NextButton.Visible = false;
                    inputBox1.Visible = false;
                    Program.ShowAll(this);
                    break;
                case State.addingName:
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
                    break;
                case State.addingBirthday:
                    state = State.addingBirthday;
                    label1.Text = "Введите дату рождения\n(в формате ДД.ММ.ГГГГ)";
                    inputBox1.Text = "";
                    inputBox1.Focus();
                    NextButton.Text = "Далее ";
                    PreviousButton.Text = "Назад ";
                    break;
                case State.addingConfirm:
                    state = State.addingConfirm;
                    label1.Text = $"Сохранить \"{tName} ({tBD})\"?";
                    NextButton.Text = "Сохранить";
                    PreviousButton.Text = "Отменить";
                    inputBox1.Text = "";
                    inputBox1.Enabled = false;
                    break;
                case State.addingComplete:
                    state = State.addingComplete;
                    NextButton.Text = "Добавить";
                    PreviousButton.Text = "ОК";
                    label1.Text = $"Сохранено: \"{ tName} ({ tBD})\"";
                    break;
                case State.inputNameToTemove:
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
                    break;
                case State.removingByName:
                    state = State.removingByName;
                    PreviousButton.Text = "Отменить";
                    NextButton.Text = "ОК";
                    break;
                case State.removingConfirm:
                    state = State.removingConfirm;
                    label1.Text = $"Совпадение с '{tName}' {ndx++} из {personsToRemoveCount}:\n\nУдалить {personsToRemove[0].Name} ({app.ToString(personsToRemove[0].Birthday)}.{app.ToString(personsToRemove[0].Birthmonth)}.{app.ToString(personsToRemove[0].Birthyear)})?";
                    PreviousButton.Text = "Нет";
                    NextButton.Text = "Да";
                    break;
                case State.removingComplete:
                    state = State.removingComplete;
                    PreviousButton.Text = "Отменить";
                    NextButton.Text = "ОК";
                    break;
                case State.removingAll:
                    state = State.removingAll;
                    PreviousButton.Visible = true;
                    PreviousButton.Text = "Отменить";
                    PreviousButton.Focus();
                    NextButton.Visible = true;
                    NextButton.Text = "Удалить";
                    inputBox1.Visible = true;
                    inputBox1.Enabled = false;
                    inputBox1.Text = "";
                    label1.Text = "Удалить все записи?\nБаза данных будет очищена";
                    Text = "Удаление всех данных";
                    break;
                case State.findingByName:
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
                    Text = "Поиск по имени";
                    break;
                case State.findingByDate:
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
                    Text = "Поиск по дате";
                    break;
            }
        }


        private void PreviousButton_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case State.addingName:
                    ManageForm(State.today);
                    break;
                case State.addingBirthday:
                    ManageForm(State.addingName);
                    break;
                case State.addingConfirm:
                    ManageForm(State.today);
                    break;
                case State.addingComplete:
                    ManageForm(State.today);
                    break;
                case State.inputNameToTemove:
                    ManageForm(State.today);
                    break;
                case State.removingByName:
                    ManageForm(State.today);
                    break;
                case State.removingConfirm:
                    if (personsToRemove.Count != 0)
                    {
                        personsToRemove.RemoveAt(0);
                        if (personsToRemove.Count != 0)
                        {
                            ManageForm(State.removingConfirm);
                        }
                        else
                        {
                            app.WriteFile("db.csv", app.UpdateText(app.Persons));
                            ManageForm(State.today);
                        }
                    }
                    break;
                case State.removingComplete:
                    ManageForm(State.today);
                    break;
                case State.removingAll:
                    ManageForm(State.today);
                    break;
                case State.findingByName:
                    ManageForm(State.today);
                    break;
                case State.findingByDate:
                    ManageForm(State.today);
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
                        ManageForm(State.addingBirthday);
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
                        ManageForm(State.addingConfirm);
                    }
                    else
                    {
                        label1.Text = "Введите корректную дату рождения в формате ДД.ММ.ГГГГ\n(например: 02.08.1999)";
                        inputBox1.Focus();
                    }
                    break;
                case State.addingConfirm:
                    ManageForm(State.addingComplete);
                    app.Persons = app.AddPerson(app.Persons, tName, tBD);
                    app.WriteFile("db.csv", app.UpdateText(app.Persons));
                    break;
                case State.addingComplete:
                    ManageForm(State.addingName);
                    break;
                case State.inputNameToTemove:
                    tName = inputBox1.Text;
                    ndx = 1;
                    inputBox1.Enabled = false;
                    personsToRemove = app.FindPersonByName(app.Persons, tName);
                    personsToRemoveCount = personsToRemove.Count;
                    if (personsToRemove.Count != 0)
                    {
                        ManageForm(State.removingConfirm);
                    }
                    else
                    {
                        label1.Text = "Нет данных для удаления";
                        ManageForm(State.removingComplete);
                    }
                    break;
                case State.removingByName:
                    if (personsToRemove.Count != 0)
                    {
                        ManageForm(State.removingConfirm);
                    }
                    else
                    {
                        label1.Text = "Нет данных для удаления";
                        ManageForm(State.today);
                    }
                    break;
                case State.removingConfirm:
                    if (personsToRemove.Count != 0)
                    {
                        app.RemovePerson(app.Persons, personsToRemove[0]);
                        label1.Text = $"Удалено: {personsToRemove[0].Name} ({app.ToString(personsToRemove[0].Birthday)}.{app.ToString(personsToRemove[0].Birthmonth)}.{app.ToString(personsToRemove[0].Birthyear)})";
                        personsToRemove.RemoveAt(0);
                        if (personsToRemove.Count != 0)
                        {
                            ManageForm(State.removingByName);
                        }
                        else
                        {
                            ManageForm(State.removingComplete);
                        }
                    }
                    else
                    {
                        ManageForm(State.removingComplete);
                    }
                    break;
                case State.removingComplete:
                    app.WriteFile("db.csv", app.UpdateText(app.Persons));
                    ManageForm(State.today);
                    break;
                case State.removingAll:
                    app.Persons = new();
                    app.WriteFile("db.csv", app.UpdateText(app.Persons));
                    ManageForm(State.allBDs);
                    break;
                case State.findingByName:
                    tName = inputBox1.Text;
                    label1.Text = app.GetText(app.FindPersonByName(app.Persons, tName), Mode.findResults);
                    Text = "Результат поиска по имени";
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
                    label1.Text = app.GetText(app.FindPersonByDate(app.Persons, d,m,y), Mode.findResults);
                    Text = "Результат поиска по дате";
                    break;
            }
        }


        private void ToolStripMenuItemToday_Click(object sender, EventArgs e)
        {
            ManageForm(State.today);
        }


        private void ToolStripMenuItemThisMonth_Click(object sender, EventArgs e)
        {
            ManageForm(State.month);
        }


        private void ToolStripMenuItemAThisYear_Click(object sender, EventArgs e)
        {
            ManageForm(State.allBDs);
        }


        private void ToolStripMenuItemFindByName_Click(object sender, EventArgs e)
        {
            ManageForm(State.findingByName);
        }


        private void ToolStripMenuItemFindByDate_Click(object sender, EventArgs e)
        {
            ManageForm(State.findingByDate);
        }


        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            ManageForm(State.addingName);
        }


        private void ToolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
            ManageForm(State.inputNameToTemove);
        }


        private void ToolStripMenuItemRemoveAll_Click(object sender, EventArgs e)
        {
            ManageForm(State.removingAll);
        }


        private void ToolStripMenuItemJan_Click(object sender, EventArgs e)
        {
            ManageForm(State.month, Mode.jan);
        }


        private void ToolStripMenuItemFeb_Click(object sender, EventArgs e)
        {
            ManageForm(State.month, Mode.feb);
        }


        private void ToolStripMenuItemMar_Click(object sender, EventArgs e)
        {
            ManageForm(State.month, Mode.mar);
        }


        private void ToolStripMenuItemApr_Click(object sender, EventArgs e)
        {
            ManageForm(State.month, Mode.apr);
        }


        private void ToolStripMenuItemMay_Click(object sender, EventArgs e)
        {
            ManageForm(State.month, Mode.may);
        }


        private void ToolStripMenuItemJun_Click(object sender, EventArgs e)
        {
            ManageForm(State.month, Mode.jun);
        }


        private void ToolStripMenuItemJul_Click(object sender, EventArgs e)
        {
            ManageForm(State.month, Mode.jul);
        }


        private void ToolStripMenuItemAug_Click(object sender, EventArgs e)
        {
            ManageForm(State.month, Mode.aug);
        }


        private void ToolStripMenuItemSep_Click(object sender, EventArgs e)
        {
            ManageForm(State.month, Mode.sep);
        }


        private void ToolStripMenuItemOct_Click(object sender, EventArgs e)
        {
            ManageForm(State.month, Mode.oct);
        }


        private void ToolStripMenuItemNov_Click(object sender, EventArgs e)
        {
            ManageForm(State.month, Mode.nov);
        }


        private void ToolStripMenuItemDec_Click(object sender, EventArgs e)
        {
            ManageForm(State.month, Mode.dec);
        }


        private void InputBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) NextButton_Click(sender, e);
        }
    }
}
