namespace MyBrary
{
    partial class searchForm
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
            this.searchResultsBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // searchResultsBox
            // 
            this.searchResultsBox.FormattingEnabled = true;
            this.searchResultsBox.ItemHeight = 16;
            this.searchResultsBox.Location = new System.Drawing.Point(47, 26);
            this.searchResultsBox.Name = "searchResultsBox";
            this.searchResultsBox.Size = new System.Drawing.Size(717, 388);
            this.searchResultsBox.TabIndex = 0;
            this.searchResultsBox.SelectedIndexChanged += new System.EventHandler(this.searchResultsBox_SelectedIndexChanged);
            // 
            // searchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchResultsBox);
            this.Name = "searchForm";
            this.Text = "Search Results";
            this.Load += new System.EventHandler(this.searchForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox searchResultsBox;
    }
}