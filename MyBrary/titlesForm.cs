using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBrary
{
    public partial class titlesForm : Form
    {
        public titlesForm()
        {
            InitializeComponent();
        }

        OleDbConnection booksConnection;
        OleDbCommand titlesCommand;
        OleDbDataAdapter titlesAdapter;
        DataTable titlesTable;
        CurrencyManager titlesManager;
        OleDbCommandBuilder titlesBuilder;
        public int CurrentPosition { get; set; }

        public string AppState { get; set; }


        private void titlesForm_Load(object sender, EventArgs e)
        {
            try
            {
                string conString = Helper.ConVal("Books");
                booksConnection = new OleDbConnection(conString);
                booksConnection.Open();

                titlesCommand = new OleDbCommand(Helper.GetTitlesCommand(), booksConnection);
                titlesAdapter = new OleDbDataAdapter();
                titlesAdapter.SelectCommand = titlesCommand;
                titlesTable = new DataTable();
                titlesAdapter.Fill(titlesTable);

                titlesText.DataBindings.Add("Text", titlesTable, "Title");
                yearText.DataBindings.Add("Text", titlesTable, "Year_Published");
                isbnText.DataBindings.Add("Text", titlesTable, "ISBN");
                descriptionText.DataBindings.Add("Text", titlesTable, "Description");
                notesText.DataBindings.Add("Text", titlesTable, "Notes");
                subjectText.DataBindings.Add("Text", titlesTable, "Subject");
                //commentsText.DataBindings.Add("Text", titlesTable, "Comments");

                titlesManager = (CurrencyManager)BindingContext[titlesTable];
                SetAppState("View");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


        }








        private void publishersButton_Click(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            SetAppState("Edit");
            yearText.DataBindings.Clear();
            AppState = "Edit";

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) { return; }

            try
            {
                var savedRecord = isbnText.Text;
                titlesManager.EndCurrentEdit();
                titlesBuilder = new OleDbCommandBuilder(titlesAdapter);
                if (AppState == "Edit")
                {
                    var titleRow = titlesTable.Select("ISBN='" + savedRecord+"'");
                    if (string.IsNullOrEmpty(yearText.Text)) { titleRow[0]["Year_Published"] = DBNull.Value; }
                    else
                    {
                        titleRow[0]["Year_Published"] = yearText.Text;
                    }
                    titlesAdapter.Update(titlesTable);
                    yearText.DataBindings.Add("Text", titlesTable, "Year_Published");

                }
                else
                {

                    titlesTable.DefaultView.Sort = "Title";
                    titlesManager.Position = titlesTable.DefaultView.Find(savedRecord);
                    titlesAdapter.Update(titlesTable);

                }
                MessageBox.Show("Record Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetAppState("View");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            titlesManager.CancelCurrentEdit();
            if(AppState== "Edit")
            {
                yearText.DataBindings.Add("Text", titlesTable, "Year_Published");


            }

            if (AppState == "Add")
            {
                titlesManager.Position = CurrentPosition;

            }
            SetAppState("View");

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CurrentPosition = titlesManager.Position;
            SetAppState("Add");
            titlesManager.AddNew();
            AppState= "Add";
        }

        private void firstButton_Click(object sender, EventArgs e)
        {
            titlesManager.Position = 0;
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            titlesManager.Position--;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            titlesManager.Position++;
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            titlesManager.Position = titlesManager.Count-1;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            DialogResult response;
    response   =         MessageBox.Show("Are You Sure You Want To Delete This Record?","Delete Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (response == DialogResult.No)
            {
                return;
            }
            try
            {
                titlesManager.RemoveAt(titlesManager.Position);
                titlesBuilder = new OleDbCommandBuilder(titlesAdapter);
                titlesAdapter.Update(titlesTable);
                AppState = "Delete";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Deleting Record", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void authorsButton_Click(object sender, EventArgs e)
        {

        }

        private void findButton_Click(object sender, EventArgs e)
        {

            if (searchText.Text.Equals("") || searchText.Text.Length < 3)
            {
                MessageBox.Show("Invalid Search", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            titlesTable.DefaultView.Sort = "Title";
            var foundRecords = titlesTable.Select(Helper.GetTitlesSearchCommand(searchText.Text));

            if (foundRecords.Length == 0)
            {
                MessageBox.Show("No Record Found", "No Record Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                titlesManager.Position = titlesTable.DefaultView.Find(foundRecords[0]["Title"]);
            }


        }

        private void frmClosing(object sender, FormClosingEventArgs e)
        {
            booksConnection.Close();
            booksConnection.Dispose();
            titlesCommand.Dispose();
            titlesAdapter.Dispose();
            titlesTable.Dispose();

        }

        private void SetAppState(string appState)
        {
            switch (appState)
            {
                case "View":
                    titlesText.ReadOnly= true;
                    yearText.ReadOnly= true;
                    isbnText.ReadOnly= true;
                    
                    descriptionText.ReadOnly= true;
                    notesText.ReadOnly= true;
                    subjectText.ReadOnly= true;
                    firstButton.Enabled= true;
                    lastButton.Enabled= true;
                    prevButton.Enabled= true;
                    nextButton.Enabled= true;
                    editButton.Enabled= true;
                    saveButton.Enabled= false;
                    doneButton.Enabled= true;
                    findButton.Enabled= true;
                    authorsButton.Enabled= true;
                    publishersButton.Enabled= true;
                    cancelButton.Enabled= false;
                    addButton.Enabled= true;
                    deleteButton.Enabled= true;
                    break;

                default:
                    titlesText.ReadOnly = false;
                    yearText.ReadOnly = false;
                    if (appState == "Add")
                    {
                        isbnText.ReadOnly = false;
                    }
                    else
                    {
                        isbnText.ReadOnly = true;
                    }

                    descriptionText.ReadOnly = false;
                    notesText.ReadOnly = false;
                    subjectText.ReadOnly = false;
                    firstButton.Enabled = false;
                    lastButton.Enabled = false;
                    prevButton.Enabled = false;
                    nextButton.Enabled = false;
                    editButton.Enabled = false;
                    saveButton.Enabled = true;
                    doneButton.Enabled = false;
                    findButton.Enabled = false;
                    authorsButton.Enabled = false;
                    publishersButton.Enabled = false;
                    cancelButton.Enabled = true;
                    addButton.Enabled = false;
                    deleteButton.Enabled = false;

                    break;
            }

        }

        private bool ValidateInput()
        {
            string message = "";
            bool isOK=true;

            if (titlesText.Text.Equals(""))
            {
                message = "You must Enter a Title\n";
                isOK = false;
            }

            int inputYear, currentYear;
            if (!yearText.Text.Trim().Equals(""))
            {
                inputYear = Convert.ToInt32(yearText.Text);
                currentYear=DateTime.Now.Year;
                if (inputYear > currentYear)
                {
                    message += "Year Publisehed cannot be greater than current year\n";
                    isOK = false;
                }

            }

            if (!(isbnText.Text.Length == 13))
            {
                message += "Incomplete ISBN";
                isOK = false;   
            }

            //validating publisher
            if (!isOK)
            {
                MessageBox.Show(message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return isOK;

        }

        private void year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar >= '0'||e.KeyChar<= '9' || e.KeyChar==8) {
                e.Handled = false; }
            else
            {
                e.Handled= true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
