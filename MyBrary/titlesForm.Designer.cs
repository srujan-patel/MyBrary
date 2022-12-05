namespace MyBrary
{
    partial class titlesForm
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
            this.titlesText = new System.Windows.Forms.TextBox();
            this.subjectText = new System.Windows.Forms.TextBox();
            this.notesText = new System.Windows.Forms.TextBox();
            this.descriptionText = new System.Windows.Forms.TextBox();
            this.yearText = new System.Windows.Forms.TextBox();
            this.searchText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.findButton = new System.Windows.Forms.Button();
            this.authorsButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.lastButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.firstButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.publishersButton = new System.Windows.Forms.Button();
            this.isbnText = new System.Windows.Forms.MaskedTextBox();
            this.author2Combo = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.author3Combo = new System.Windows.Forms.ComboBox();
            this.author4Combo = new System.Windows.Forms.ComboBox();
            this.publisherCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.author1Combo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.author1Button = new System.Windows.Forms.Button();
            this.author4Button = new System.Windows.Forms.Button();
            this.author2Button = new System.Windows.Forms.Button();
            this.author3Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titlesText
            // 
            this.titlesText.Location = new System.Drawing.Point(169, 19);
            this.titlesText.Margin = new System.Windows.Forms.Padding(4);
            this.titlesText.Name = "titlesText";
            this.titlesText.Size = new System.Drawing.Size(428, 27);
            this.titlesText.TabIndex = 0;
            // 
            // subjectText
            // 
            this.subjectText.Location = new System.Drawing.Point(170, 375);
            this.subjectText.Margin = new System.Windows.Forms.Padding(4);
            this.subjectText.Name = "subjectText";
            this.subjectText.Size = new System.Drawing.Size(427, 27);
            this.subjectText.TabIndex = 1;
            // 
            // notesText
            // 
            this.notesText.Location = new System.Drawing.Point(170, 320);
            this.notesText.Margin = new System.Windows.Forms.Padding(4);
            this.notesText.Name = "notesText";
            this.notesText.Size = new System.Drawing.Size(427, 27);
            this.notesText.TabIndex = 4;
            // 
            // descriptionText
            // 
            this.descriptionText.Location = new System.Drawing.Point(170, 272);
            this.descriptionText.Margin = new System.Windows.Forms.Padding(4);
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(427, 27);
            this.descriptionText.TabIndex = 5;
            // 
            // yearText
            // 
            this.yearText.Location = new System.Drawing.Point(169, 76);
            this.yearText.Margin = new System.Windows.Forms.Padding(4);
            this.yearText.Name = "yearText";
            this.yearText.Size = new System.Drawing.Size(192, 27);
            this.yearText.TabIndex = 7;
            this.yearText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.year_KeyPress);
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(26, 512);
            this.searchText.Margin = new System.Windows.Forms.Padding(4);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(132, 27);
            this.searchText.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Titles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "ISBN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Year Published";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 275);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 323);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Notes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 375);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Subject";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 489);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Search Titles";
            // 
            // findButton
            // 
            this.findButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findButton.Location = new System.Drawing.Point(49, 555);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(87, 29);
            this.findButton.TabIndex = 17;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // authorsButton
            // 
            this.authorsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorsButton.Location = new System.Drawing.Point(313, 573);
            this.authorsButton.Name = "authorsButton";
            this.authorsButton.Size = new System.Drawing.Size(87, 29);
            this.authorsButton.TabIndex = 18;
            this.authorsButton.Text = "&Authors";
            this.authorsButton.UseVisualStyleBackColor = true;
            this.authorsButton.Click += new System.EventHandler(this.authorsButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(526, 526);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(87, 29);
            this.doneButton.TabIndex = 19;
            this.doneButton.Text = "D&one";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(419, 526);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(87, 29);
            this.deleteButton.TabIndex = 20;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // lastButton
            // 
            this.lastButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastButton.Location = new System.Drawing.Point(526, 449);
            this.lastButton.Name = "lastButton";
            this.lastButton.Size = new System.Drawing.Size(87, 29);
            this.lastButton.TabIndex = 21;
            this.lastButton.Text = "Last";
            this.lastButton.UseVisualStyleBackColor = true;
            this.lastButton.Click += new System.EventHandler(this.lastButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextButton.Location = new System.Drawing.Point(419, 449);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(87, 29);
            this.nextButton.TabIndex = 22;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // prevButton
            // 
            this.prevButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevButton.Location = new System.Drawing.Point(313, 449);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(87, 29);
            this.prevButton.TabIndex = 23;
            this.prevButton.Text = "Previous";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // firstButton
            // 
            this.firstButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstButton.Location = new System.Drawing.Point(206, 449);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(87, 29);
            this.firstButton.TabIndex = 24;
            this.firstButton.Text = "First";
            this.firstButton.UseVisualStyleBackColor = true;
            this.firstButton.Click += new System.EventHandler(this.firstButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(313, 526);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(87, 29);
            this.addButton.TabIndex = 25;
            this.addButton.Text = "A&dd New";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(526, 489);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 29);
            this.cancelButton.TabIndex = 26;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(419, 489);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(87, 29);
            this.saveButton.TabIndex = 27;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(313, 489);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(87, 29);
            this.editButton.TabIndex = 28;
            this.editButton.Text = "&Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // publishersButton
            // 
            this.publishersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.publishersButton.Location = new System.Drawing.Point(419, 573);
            this.publishersButton.Name = "publishersButton";
            this.publishersButton.Size = new System.Drawing.Size(87, 29);
            this.publishersButton.TabIndex = 29;
            this.publishersButton.Text = "&Publishers";
            this.publishersButton.UseVisualStyleBackColor = true;
            this.publishersButton.Click += new System.EventHandler(this.publishersButton_Click);
            // 
            // isbnText
            // 
            this.isbnText.BackColor = System.Drawing.Color.Red;
            this.isbnText.ForeColor = System.Drawing.Color.White;
            this.isbnText.Location = new System.Drawing.Point(452, 76);
            this.isbnText.Mask = "A-AAAAAAA-A-A";
            this.isbnText.Name = "isbnText";
            this.isbnText.Size = new System.Drawing.Size(145, 27);
            this.isbnText.TabIndex = 30;
            // 
            // author2Combo
            // 
            this.author2Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.author2Combo.FormattingEnabled = true;
            this.author2Combo.Location = new System.Drawing.Point(456, 127);
            this.author2Combo.Name = "author2Combo";
            this.author2Combo.Size = new System.Drawing.Size(121, 28);
            this.author2Combo.TabIndex = 31;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(172, 127);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 28);
            this.comboBox2.TabIndex = 32;
            // 
            // author3Combo
            // 
            this.author3Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.author3Combo.FormattingEnabled = true;
            this.author3Combo.Location = new System.Drawing.Point(172, 182);
            this.author3Combo.Name = "author3Combo";
            this.author3Combo.Size = new System.Drawing.Size(121, 28);
            this.author3Combo.TabIndex = 33;
            // 
            // author4Combo
            // 
            this.author4Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.author4Combo.FormattingEnabled = true;
            this.author4Combo.Location = new System.Drawing.Point(456, 182);
            this.author4Combo.Name = "author4Combo";
            this.author4Combo.Size = new System.Drawing.Size(121, 28);
            this.author4Combo.TabIndex = 34;
            // 
            // publisherCombo
            // 
            this.publisherCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.publisherCombo.FormattingEnabled = true;
            this.publisherCombo.Location = new System.Drawing.Point(172, 227);
            this.publisherCombo.Name = "publisherCombo";
            this.publisherCombo.Size = new System.Drawing.Size(405, 28);
            this.publisherCombo.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(350, 130);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "Author 2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(350, 185);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 37;
            this.label9.Text = "Author 4";
            // 
            // author1Combo
            // 
            this.author1Combo.AutoSize = true;
            this.author1Combo.Location = new System.Drawing.Point(54, 130);
            this.author1Combo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.author1Combo.Name = "author1Combo";
            this.author1Combo.Size = new System.Drawing.Size(72, 20);
            this.author1Combo.TabIndex = 38;
            this.author1Combo.Text = "Author 1\r\n";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(54, 185);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 20);
            this.label11.TabIndex = 39;
            this.label11.Text = "Author 3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(54, 230);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 20);
            this.label12.TabIndex = 40;
            this.label12.Text = "Publisher";
            // 
            // author1Button
            // 
            this.author1Button.Location = new System.Drawing.Point(295, 130);
            this.author1Button.Name = "author1Button";
            this.author1Button.Size = new System.Drawing.Size(29, 29);
            this.author1Button.TabIndex = 41;
            this.author1Button.Text = "x";
            this.author1Button.UseVisualStyleBackColor = true;
            this.author1Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // author4Button
            // 
            this.author4Button.Location = new System.Drawing.Point(584, 185);
            this.author4Button.Name = "author4Button";
            this.author4Button.Size = new System.Drawing.Size(29, 29);
            this.author4Button.TabIndex = 42;
            this.author4Button.Text = "x";
            this.author4Button.UseVisualStyleBackColor = true;
            this.author4Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // author2Button
            // 
            this.author2Button.Location = new System.Drawing.Point(584, 128);
            this.author2Button.Name = "author2Button";
            this.author2Button.Size = new System.Drawing.Size(29, 29);
            this.author2Button.TabIndex = 43;
            this.author2Button.Text = "x";
            this.author2Button.UseVisualStyleBackColor = true;
            this.author2Button.Click += new System.EventHandler(this.button3_Click);
            // 
            // author3Button
            // 
            this.author3Button.Location = new System.Drawing.Point(294, 182);
            this.author3Button.Name = "author3Button";
            this.author3Button.Size = new System.Drawing.Size(29, 29);
            this.author3Button.TabIndex = 44;
            this.author3Button.Text = "x";
            this.author3Button.UseVisualStyleBackColor = true;
            this.author3Button.Click += new System.EventHandler(this.button4_Click);
            // 
            // titlesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 679);
            this.Controls.Add(this.author3Button);
            this.Controls.Add(this.author2Button);
            this.Controls.Add(this.author4Button);
            this.Controls.Add(this.author1Button);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.author1Combo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.publisherCombo);
            this.Controls.Add(this.author4Combo);
            this.Controls.Add(this.author3Combo);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.author2Combo);
            this.Controls.Add(this.isbnText);
            this.Controls.Add(this.publishersButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.firstButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.lastButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.authorsButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.yearText);
            this.Controls.Add(this.descriptionText);
            this.Controls.Add(this.notesText);
            this.Controls.Add(this.subjectText);
            this.Controls.Add(this.titlesText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "titlesForm";
            this.Text = "Titles Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClosing);
            this.Load += new System.EventHandler(this.titlesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titlesText;
        private System.Windows.Forms.TextBox subjectText;
        private System.Windows.Forms.TextBox notesText;
        private System.Windows.Forms.TextBox descriptionText;
        private System.Windows.Forms.TextBox yearText;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button authorsButton;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button lastButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button firstButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button publishersButton;
        private System.Windows.Forms.MaskedTextBox isbnText;
        private System.Windows.Forms.ComboBox author2Combo;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox author3Combo;
        private System.Windows.Forms.ComboBox author4Combo;
        private System.Windows.Forms.ComboBox publisherCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label author1Combo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button author1Button;
        private System.Windows.Forms.Button author4Button;
        private System.Windows.Forms.Button author2Button;
        private System.Windows.Forms.Button author3Button;
    }
}