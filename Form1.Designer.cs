
namespace BirthdaysReminder
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.inputBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAThisYear = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemChoosenMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemJan = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFeb = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMar = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemApr = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMay = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemJun = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemJul = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAug = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSep = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemOct = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNov = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDec = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemThisMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemToday = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemFind = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFindName = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFindDate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PreviousButton
            // 
            resources.ApplyResources(this.PreviousButton, "PreviousButton");
            this.PreviousButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            resources.ApplyResources(this.NextButton, "NextButton");
            this.NextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextButton.Name = "NextButton";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // inputBox1
            // 
            this.inputBox1.AllowDrop = true;
            resources.ApplyResources(this.inputBox1, "inputBox1");
            this.inputBox1.BackColor = System.Drawing.SystemColors.Control;
            this.inputBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputBox1.Name = "inputBox1";
            this.inputBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputBox1_KeyDown);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.label1);
            this.panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemShow,
            this.toolStripMenuItemFind,
            this.toolStripMenuItemEdit});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // ToolStripMenuItemShow
            // 
            this.ToolStripMenuItemShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAThisYear,
            this.ToolStripMenuItemChoosenMonth,
            this.toolStripMenuItemThisMonth,
            this.toolStripMenuItemToday});
            this.ToolStripMenuItemShow.Name = "ToolStripMenuItemShow";
            resources.ApplyResources(this.ToolStripMenuItemShow, "ToolStripMenuItemShow");
            // 
            // toolStripMenuItemAThisYear
            // 
            this.toolStripMenuItemAThisYear.Name = "toolStripMenuItemAThisYear";
            resources.ApplyResources(this.toolStripMenuItemAThisYear, "toolStripMenuItemAThisYear");
            this.toolStripMenuItemAThisYear.Click += new System.EventHandler(this.ToolStripMenuItemAThisYear_Click);
            // 
            // ToolStripMenuItemChoosenMonth
            // 
            this.ToolStripMenuItemChoosenMonth.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemJan,
            this.ToolStripMenuItemFeb,
            this.ToolStripMenuItemMar,
            this.ToolStripMenuItemApr,
            this.ToolStripMenuItemMay,
            this.ToolStripMenuItemJun,
            this.ToolStripMenuItemJul,
            this.ToolStripMenuItemAug,
            this.ToolStripMenuItemSep,
            this.ToolStripMenuItemOct,
            this.ToolStripMenuItemNov,
            this.ToolStripMenuItemDec});
            this.ToolStripMenuItemChoosenMonth.Name = "ToolStripMenuItemChoosenMonth";
            resources.ApplyResources(this.ToolStripMenuItemChoosenMonth, "ToolStripMenuItemChoosenMonth");
            // 
            // ToolStripMenuItemJan
            // 
            this.ToolStripMenuItemJan.Name = "ToolStripMenuItemJan";
            resources.ApplyResources(this.ToolStripMenuItemJan, "ToolStripMenuItemJan");
            this.ToolStripMenuItemJan.Click += new System.EventHandler(this.ToolStripMenuItemJan_Click);
            // 
            // ToolStripMenuItemFeb
            // 
            this.ToolStripMenuItemFeb.Name = "ToolStripMenuItemFeb";
            resources.ApplyResources(this.ToolStripMenuItemFeb, "ToolStripMenuItemFeb");
            this.ToolStripMenuItemFeb.Click += new System.EventHandler(this.ToolStripMenuItemFeb_Click);
            // 
            // ToolStripMenuItemMar
            // 
            this.ToolStripMenuItemMar.Name = "ToolStripMenuItemMar";
            resources.ApplyResources(this.ToolStripMenuItemMar, "ToolStripMenuItemMar");
            this.ToolStripMenuItemMar.Click += new System.EventHandler(this.ToolStripMenuItemMar_Click);
            // 
            // ToolStripMenuItemApr
            // 
            this.ToolStripMenuItemApr.Name = "ToolStripMenuItemApr";
            resources.ApplyResources(this.ToolStripMenuItemApr, "ToolStripMenuItemApr");
            this.ToolStripMenuItemApr.Click += new System.EventHandler(this.ToolStripMenuItemApr_Click);
            // 
            // ToolStripMenuItemMay
            // 
            this.ToolStripMenuItemMay.Name = "ToolStripMenuItemMay";
            resources.ApplyResources(this.ToolStripMenuItemMay, "ToolStripMenuItemMay");
            this.ToolStripMenuItemMay.Click += new System.EventHandler(this.ToolStripMenuItemMay_Click);
            // 
            // ToolStripMenuItemJun
            // 
            this.ToolStripMenuItemJun.Name = "ToolStripMenuItemJun";
            resources.ApplyResources(this.ToolStripMenuItemJun, "ToolStripMenuItemJun");
            this.ToolStripMenuItemJun.Click += new System.EventHandler(this.ToolStripMenuItemJun_Click);
            // 
            // ToolStripMenuItemJul
            // 
            this.ToolStripMenuItemJul.Name = "ToolStripMenuItemJul";
            resources.ApplyResources(this.ToolStripMenuItemJul, "ToolStripMenuItemJul");
            this.ToolStripMenuItemJul.Click += new System.EventHandler(this.ToolStripMenuItemJul_Click);
            // 
            // ToolStripMenuItemAug
            // 
            this.ToolStripMenuItemAug.Name = "ToolStripMenuItemAug";
            resources.ApplyResources(this.ToolStripMenuItemAug, "ToolStripMenuItemAug");
            this.ToolStripMenuItemAug.Click += new System.EventHandler(this.ToolStripMenuItemAug_Click);
            // 
            // ToolStripMenuItemSep
            // 
            this.ToolStripMenuItemSep.Name = "ToolStripMenuItemSep";
            resources.ApplyResources(this.ToolStripMenuItemSep, "ToolStripMenuItemSep");
            this.ToolStripMenuItemSep.Click += new System.EventHandler(this.ToolStripMenuItemSep_Click);
            // 
            // ToolStripMenuItemOct
            // 
            this.ToolStripMenuItemOct.Name = "ToolStripMenuItemOct";
            resources.ApplyResources(this.ToolStripMenuItemOct, "ToolStripMenuItemOct");
            this.ToolStripMenuItemOct.Click += new System.EventHandler(this.ToolStripMenuItemOct_Click);
            // 
            // ToolStripMenuItemNov
            // 
            this.ToolStripMenuItemNov.Name = "ToolStripMenuItemNov";
            resources.ApplyResources(this.ToolStripMenuItemNov, "ToolStripMenuItemNov");
            this.ToolStripMenuItemNov.Click += new System.EventHandler(this.ToolStripMenuItemNov_Click);
            // 
            // ToolStripMenuItemDec
            // 
            this.ToolStripMenuItemDec.Name = "ToolStripMenuItemDec";
            resources.ApplyResources(this.ToolStripMenuItemDec, "ToolStripMenuItemDec");
            this.ToolStripMenuItemDec.Click += new System.EventHandler(this.ToolStripMenuItemDec_Click);
            // 
            // toolStripMenuItemThisMonth
            // 
            this.toolStripMenuItemThisMonth.Name = "toolStripMenuItemThisMonth";
            resources.ApplyResources(this.toolStripMenuItemThisMonth, "toolStripMenuItemThisMonth");
            this.toolStripMenuItemThisMonth.Click += new System.EventHandler(this.ToolStripMenuItemThisMonth_Click);
            // 
            // toolStripMenuItemToday
            // 
            this.toolStripMenuItemToday.Name = "toolStripMenuItemToday";
            resources.ApplyResources(this.toolStripMenuItemToday, "toolStripMenuItemToday");
            this.toolStripMenuItemToday.Click += new System.EventHandler(this.ToolStripMenuItemToday_Click);
            // 
            // toolStripMenuItemFind
            // 
            this.toolStripMenuItemFind.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFindName,
            this.ToolStripMenuItemFindDate});
            this.toolStripMenuItemFind.Name = "toolStripMenuItemFind";
            resources.ApplyResources(this.toolStripMenuItemFind, "toolStripMenuItemFind");
            // 
            // ToolStripMenuItemFindName
            // 
            this.ToolStripMenuItemFindName.Name = "ToolStripMenuItemFindName";
            resources.ApplyResources(this.ToolStripMenuItemFindName, "ToolStripMenuItemFindName");
            this.ToolStripMenuItemFindName.Click += new System.EventHandler(this.ToolStripMenuItemFindByName_Click);
            // 
            // ToolStripMenuItemFindDate
            // 
            this.ToolStripMenuItemFindDate.Name = "ToolStripMenuItemFindDate";
            resources.ApplyResources(this.ToolStripMenuItemFindDate, "ToolStripMenuItemFindDate");
            this.ToolStripMenuItemFindDate.Click += new System.EventHandler(this.ToolStripMenuItemFindByDate_Click);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAdd,
            this.toolStripMenuItemRemove});
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            resources.ApplyResources(this.toolStripMenuItemEdit, "toolStripMenuItemEdit");
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            resources.ApplyResources(this.toolStripMenuItemAdd, "toolStripMenuItemAdd");
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.ToolStripMenuItemAdd_Click);
            // 
            // toolStripMenuItemRemove
            // 
            this.toolStripMenuItemRemove.Name = "toolStripMenuItemRemove";
            resources.ApplyResources(this.toolStripMenuItemRemove, "toolStripMenuItemRemove");
            this.toolStripMenuItemRemove.Click += new System.EventHandler(this.ToolStripMenuItemRemove_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.inputBox1);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button PreviousButton;
        public System.Windows.Forms.Button NextButton;
        public System.Windows.Forms.TextBox inputBox1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemToday;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemThisMonth;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAThisYear;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFind;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemove;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFindName;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFindDate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemChoosenMonth;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemJan;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFeb;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMar;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemApr;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMay;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemJun;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemJul;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAug;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSep;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOct;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemNov;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDec;
    }
}

