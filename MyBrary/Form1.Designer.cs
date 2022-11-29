namespace MyBrary
{
    partial class authorsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.authorIDLabel = new System.Windows.Forms.Label();
            this.authorNameLabel = new System.Windows.Forms.Label();
            this.authorYearBornLabel = new System.Windows.Forms.Label();
            this.authorIDText = new System.Windows.Forms.TextBox();
            this.authorNameText = new System.Windows.Forms.TextBox();
            this.authorYearBornText = new System.Windows.Forms.TextBox();
            this.previousButton = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addNewButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            this.wrongInputLabel = new System.Windows.Forms.Label();
            this.lastButton = new System.Windows.Forms.Button();
            this.firstButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // authorIDLabel
            // 
            this.authorIDLabel.AutoSize = true;
            this.authorIDLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorIDLabel.Location = new System.Drawing.Point(80, 92);
            this.authorIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.authorIDLabel.Name = "authorIDLabel";
            this.authorIDLabel.Size = new System.Drawing.Size(99, 23);
            this.authorIDLabel.TabIndex = 0;
            this.authorIDLabel.Text = "Author ID";
            // 
            // authorNameLabel
            // 
            this.authorNameLabel.AutoSize = true;
            this.authorNameLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorNameLabel.Location = new System.Drawing.Point(80, 163);
            this.authorNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.authorNameLabel.Name = "authorNameLabel";
            this.authorNameLabel.Size = new System.Drawing.Size(132, 23);
            this.authorNameLabel.TabIndex = 1;
            this.authorNameLabel.Text = "Author Name";
            // 
            // authorYearBornLabel
            // 
            this.authorYearBornLabel.AutoSize = true;
            this.authorYearBornLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorYearBornLabel.Location = new System.Drawing.Point(80, 240);
            this.authorYearBornLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.authorYearBornLabel.Name = "authorYearBornLabel";
            this.authorYearBornLabel.Size = new System.Drawing.Size(102, 23);
            this.authorYearBornLabel.TabIndex = 2;
            this.authorYearBornLabel.Text = "Birth Year";
            // 
            // authorIDText
            // 
            this.authorIDText.BackColor = System.Drawing.Color.Red;
            this.authorIDText.ForeColor = System.Drawing.Color.White;
            this.authorIDText.Location = new System.Drawing.Point(221, 89);
            this.authorIDText.Name = "authorIDText";
            this.authorIDText.ReadOnly = true;
            this.authorIDText.Size = new System.Drawing.Size(157, 31);
            this.authorIDText.TabIndex = 3;
            this.authorIDText.TabStop = false;
            // 
            // authorNameText
            // 
            this.authorNameText.Location = new System.Drawing.Point(221, 160);
            this.authorNameText.Name = "authorNameText";
            this.authorNameText.Size = new System.Drawing.Size(283, 31);
            this.authorNameText.TabIndex = 4;
            this.authorNameText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.authorName_KeyPress);
            // 
            // authorYearBornText
            // 
            this.authorYearBornText.Location = new System.Drawing.Point(221, 240);
            this.authorYearBornText.Name = "authorYearBornText";
            this.authorYearBornText.Size = new System.Drawing.Size(141, 31);
            this.authorYearBornText.TabIndex = 5;
            this.authorYearBornText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.authorBornText_KeyPress);
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(162, 314);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(111, 40);
            this.previousButton.TabIndex = 6;
            this.previousButton.Text = "Previous";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(346, 314);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(111, 40);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(84, 370);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(111, 40);
            this.editButton.TabIndex = 8;
            this.editButton.Text = "&Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(267, 370);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(111, 40);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(431, 370);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(111, 40);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addNewButton
            // 
            this.addNewButton.Location = new System.Drawing.Point(84, 433);
            this.addNewButton.Name = "addNewButton";
            this.addNewButton.Size = new System.Drawing.Size(111, 40);
            this.addNewButton.TabIndex = 11;
            this.addNewButton.Text = "&Add New";
            this.addNewButton.UseVisualStyleBackColor = true;
            this.addNewButton.Click += new System.EventHandler(this.addNewButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(267, 433);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(111, 40);
            this.deleteButton.TabIndex = 12;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(434, 433);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(111, 40);
            this.doneButton.TabIndex = 13;
            this.doneButton.Text = "D&one";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // wrongInputLabel
            // 
            this.wrongInputLabel.AutoSize = true;
            this.wrongInputLabel.ForeColor = System.Drawing.Color.Red;
            this.wrongInputLabel.Location = new System.Drawing.Point(395, 240);
            this.wrongInputLabel.Name = "wrongInputLabel";
            this.wrongInputLabel.Size = new System.Drawing.Size(118, 23);
            this.wrongInputLabel.TabIndex = 14;
            this.wrongInputLabel.Text = "Wrong Input";
            this.wrongInputLabel.Visible = false;
            // 
            // lastButton
            // 
            this.lastButton.Location = new System.Drawing.Point(506, 314);
            this.lastButton.Name = "lastButton";
            this.lastButton.Size = new System.Drawing.Size(100, 40);
            this.lastButton.TabIndex = 15;
            this.lastButton.Text = "Last";
            this.lastButton.UseVisualStyleBackColor = true;
            this.lastButton.Click += new System.EventHandler(this.lastButton_Click);
            // 
            // firstButton
            // 
            this.firstButton.Location = new System.Drawing.Point(26, 314);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(100, 40);
            this.firstButton.TabIndex = 16;
            this.firstButton.Text = "First";
            this.firstButton.UseVisualStyleBackColor = true;
            this.firstButton.Click += new System.EventHandler(this.firstButton_Click);
            // 
            // authorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 565);
            this.Controls.Add(this.firstButton);
            this.Controls.Add(this.lastButton);
            this.Controls.Add(this.wrongInputLabel);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addNewButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.authorYearBornText);
            this.Controls.Add(this.authorNameText);
            this.Controls.Add(this.authorIDText);
            this.Controls.Add(this.authorYearBornLabel);
            this.Controls.Add(this.authorNameLabel);
            this.Controls.Add(this.authorIDLabel);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "authorsForm";
            this.Text = "Authors Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label authorIDLabel;
        private System.Windows.Forms.Label authorNameLabel;
        private System.Windows.Forms.Label authorYearBornLabel;
        private System.Windows.Forms.TextBox authorIDText;
        private System.Windows.Forms.TextBox authorNameText;
        private System.Windows.Forms.TextBox authorYearBornText;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addNewButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label wrongInputLabel;
        private System.Windows.Forms.Button lastButton;
        private System.Windows.Forms.Button firstButton;
    }
}

