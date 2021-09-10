
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
            this.thisMonthButton = new System.Windows.Forms.Button();
            this.AddBDButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // thisMonthButton
            // 
            resources.ApplyResources(this.thisMonthButton, "thisMonthButton");
            this.thisMonthButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.thisMonthButton.Name = "thisMonthButton";
            this.thisMonthButton.UseVisualStyleBackColor = true;
            this.thisMonthButton.Click += new System.EventHandler(this.thisMonthButton_Click);
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.AutoEllipsis = true;
            this.label1.Name = "label1";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AddBDButton);
            this.Controls.Add(this.thisMonthButton);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button thisMonthButton;
        public System.Windows.Forms.Button AddBDButton;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label1;
    }
}

