
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
            this.ModeButton = new System.Windows.Forms.Button();
            this.AddBDButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // thisMonthButton
            // 
            resources.ApplyResources(this.ModeButton, "thisMonthButton");
            this.ModeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ModeButton.Name = "thisMonthButton";
            this.ModeButton.UseVisualStyleBackColor = true;
            this.ModeButton.Click += new System.EventHandler(this.ModeButton_Click);
            // 
            // AddBDButton
            // 
            resources.ApplyResources(this.AddBDButton, "AddBDButton");
            this.AddBDButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddBDButton.Name = "AddBDButton";
            this.AddBDButton.UseVisualStyleBackColor = true;
            this.AddBDButton.Click += new System.EventHandler(this.AddBDButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Name = "textBox1";
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
            this.label1.Name = "label1";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AddBDButton);
            this.Controls.Add(this.ModeButton);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button ModeButton;
        public System.Windows.Forms.Button AddBDButton;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
    }
}

