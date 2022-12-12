namespace MyBrary
{
    partial class GoogleSearch
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
            this.outputBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inputText = new System.Windows.Forms.TextBox();
            this.messageText = new System.Windows.Forms.TextBox();
            this.displayListBox = new System.Windows.Forms.CheckedListBox();
            this.availabilityListBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maxResults = new System.Windows.Forms.NumericUpDown();
            this.searchCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.selectDisplayButton = new System.Windows.Forms.Button();
            this.clearDisplayButton = new System.Windows.Forms.Button();
            this.selectAvailabilityButton = new System.Windows.Forms.Button();
            this.clearAvailabilityButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.maxResults)).BeginInit();
            this.SuspendLayout();
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(29, 139);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputBox.Size = new System.Drawing.Size(583, 300);
            this.outputBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(82, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(116, 44);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search ";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input String";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "API Message";
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(122, 70);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(470, 22);
            this.inputText.TabIndex = 4;
            // 
            // messageText
            // 
            this.messageText.Location = new System.Drawing.Point(122, 101);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(470, 22);
            this.messageText.TabIndex = 5;
            // 
            // displayListBox
            // 
            this.displayListBox.FormattingEnabled = true;
            this.displayListBox.Location = new System.Drawing.Point(640, 70);
            this.displayListBox.Name = "displayListBox";
            this.displayListBox.Size = new System.Drawing.Size(182, 123);
            this.displayListBox.TabIndex = 6;
            // 
            // availabilityListBox
            // 
            this.availabilityListBox.FormattingEnabled = true;
            this.availabilityListBox.Location = new System.Drawing.Point(640, 310);
            this.availabilityListBox.Name = "availabilityListBox";
            this.availabilityListBox.Size = new System.Drawing.Size(182, 106);
            this.availabilityListBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(637, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Display Parameters";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(637, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Availability Info";
            // 
            // maxResults
            // 
            this.maxResults.Location = new System.Drawing.Point(455, 38);
            this.maxResults.Name = "maxResults";
            this.maxResults.Size = new System.Drawing.Size(120, 22);
            this.maxResults.TabIndex = 10;
            // 
            // searchCombo
            // 
            this.searchCombo.FormattingEnabled = true;
            this.searchCombo.Location = new System.Drawing.Point(298, 37);
            this.searchCombo.Name = "searchCombo";
            this.searchCombo.Size = new System.Drawing.Size(121, 24);
            this.searchCombo.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Search For";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(452, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Max Results";
            // 
            // selectDisplayButton
            // 
            this.selectDisplayButton.Location = new System.Drawing.Point(666, 199);
            this.selectDisplayButton.Name = "selectDisplayButton";
            this.selectDisplayButton.Size = new System.Drawing.Size(116, 26);
            this.selectDisplayButton.TabIndex = 14;
            this.selectDisplayButton.Text = "Select All";
            this.selectDisplayButton.UseVisualStyleBackColor = true;
            this.selectDisplayButton.Click += new System.EventHandler(this.selectDisplayButton_Click);
            // 
            // clearDisplayButton
            // 
            this.clearDisplayButton.Location = new System.Drawing.Point(666, 231);
            this.clearDisplayButton.Name = "clearDisplayButton";
            this.clearDisplayButton.Size = new System.Drawing.Size(116, 26);
            this.clearDisplayButton.TabIndex = 15;
            this.clearDisplayButton.Text = "Clear All";
            this.clearDisplayButton.UseVisualStyleBackColor = true;
            this.clearDisplayButton.Click += new System.EventHandler(this.clearDisplayButton_Click);
            // 
            // selectAvailabilityButton
            // 
            this.selectAvailabilityButton.Location = new System.Drawing.Point(666, 422);
            this.selectAvailabilityButton.Name = "selectAvailabilityButton";
            this.selectAvailabilityButton.Size = new System.Drawing.Size(116, 26);
            this.selectAvailabilityButton.TabIndex = 16;
            this.selectAvailabilityButton.Text = "Select All";
            this.selectAvailabilityButton.UseVisualStyleBackColor = true;
            this.selectAvailabilityButton.Click += new System.EventHandler(this.selectAvailabilityButton_Click);
            // 
            // clearAvailabilityButton
            // 
            this.clearAvailabilityButton.Location = new System.Drawing.Point(666, 454);
            this.clearAvailabilityButton.Name = "clearAvailabilityButton";
            this.clearAvailabilityButton.Size = new System.Drawing.Size(116, 26);
            this.clearAvailabilityButton.TabIndex = 17;
            this.clearAvailabilityButton.Text = "Clear All";
            this.clearAvailabilityButton.UseVisualStyleBackColor = true;
            this.clearAvailabilityButton.Click += new System.EventHandler(this.clearAvailabilityButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(298, 467);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(76, 27);
            this.doneButton.TabIndex = 18;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // GoogleSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 506);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.clearAvailabilityButton);
            this.Controls.Add(this.selectAvailabilityButton);
            this.Controls.Add(this.clearDisplayButton);
            this.Controls.Add(this.selectDisplayButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.searchCombo);
            this.Controls.Add(this.maxResults);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.availabilityListBox);
            this.Controls.Add(this.displayListBox);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.outputBox);
            this.Name = "GoogleSearch";
            this.Text = "Google Search";
            this.Load += new System.EventHandler(this.GoogleSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.TextBox messageText;
        private System.Windows.Forms.CheckedListBox displayListBox;
        private System.Windows.Forms.CheckedListBox availabilityListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown maxResults;
        private System.Windows.Forms.ComboBox searchCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button selectDisplayButton;
        private System.Windows.Forms.Button clearDisplayButton;
        private System.Windows.Forms.Button selectAvailabilityButton;
        private System.Windows.Forms.Button clearAvailabilityButton;
        private System.Windows.Forms.Button doneButton;
    }
}