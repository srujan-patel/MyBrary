using MyBrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBrary
{
    public partial class authorsForm : Form
    {
        public authorsForm()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {

                string conString = Helper.ConVal("Books");
                booksConnection = new OleDbConnection(conString);
                booksConnection.Open();
                authorsCommand = new OleDbCommand(Helper.GetAuthorCommand(), booksConnection);
                authorsAdapter = new OleDbDataAdapter();
                authorsAdapter.SelectCommand = authorsCommand;
                authorsTable = new DataTable();
                authorsAdapter.Fill(authorsTable);

                authorIDText.DataBindings.Add("Text", authorsTable, "AU_ID");
                authorNameText.DataBindings.Add("Text", authorsTable, "Author");
                authorYearBornText.DataBindings.Add("Text", authorsTable, "Year_Born");

                authorsManager = (CurrencyManager)BindingContext[authorsTable]; // currency manager holds a list of the records
                SetAppliicationState("View");


            }

            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message, "database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbError = true;    
            }        

        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            authorsManager.Position --;


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            authorsManager.Position++;

        }

        private void frmClosing(object sender, FormClosingEventArgs e)
        {
            if (!dbError) { 
           booksConnection.Close();
            booksConnection.Dispose();
            authorsCommand.Dispose();
            authorsAdapter.Dispose();   
            authorsTable.Dispose();
            }

        }

      

        private void saveButton_Click(object sender, EventArgs e)
        {

            if (!ValdateInput())
            {
                return;
            }
            try
            {
                var savedRecord = authorNameText.Text;

                authorsManager.EndCurrentEdit();
                builderCommand= new OleDbCommandBuilder(authorsAdapter);

                //var authRow = authorsTable.Select("AU_ID= ", authorIDText.Text); //filter statement returns records with the value specified in the braces
                //if (String.IsNullOrEmpty(authorIDText.Text)) { 
                //authRow[0]["Year Born"]=DBNull.Value;
                //        }
                //else
                //{
                //    authRow[0]["Year Born"] = authorYearBornText.Text;
                //}

                //authorYearBornText.DataBindings.Add("Text", authorsTable, "Year_Born");
                //authorsAdapter.Update(authorsTable);
                if (AppState == "Edit") { 
                var authRow = authorsTable.Select("Au_ID = " + authorIDText.Text);

                if (String.IsNullOrEmpty(authorYearBornText.Text))
                    authRow[0]["Year_Born"] = DBNull.Value;
                else
                    authRow[0]["Year_Born"] = authorYearBornText.Text;

                authorsAdapter.Update(authorsTable);
                authorYearBornText.DataBindings.Add("Text", authorsTable, "Year_Born");
                }

                else
                {     
                    authorsTable.DefaultView.Sort = "Author";
                    authorsManager.Position= authorsTable.DefaultView.Find(savedRecord);
                    authorsAdapter.Update(authorsTable);

                }

                MessageBox.Show("Record Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetAppliicationState("View");

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Record", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult response;
            response = MessageBox.Show("Are you sure you want to delete the record", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2); //default option is no
            if (response == DialogResult.No)
            {
                return;
            }

            try 
            {
                //currency manager holds a list of records hence hence we can use the removeat method for removing the records
                AppState = "delete";
                authorsManager.RemoveAt(authorsManager.Position);
                //it removes from the list doesnot update the database
                builderCommand = new OleDbCommandBuilder(authorsAdapter);
                authorsAdapter.Update(authorsTable);


            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error Deleting Record", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void SetAppliicationState(string appState)
        {

            switch (appState)
            {
                case "View":
                    authorNameText.ReadOnly=true;
                    authorYearBornText.ReadOnly=true;
                    btnNext.Enabled = true;
                    previousButton.Enabled = true;
                    saveButton.Enabled = false;
                    cancelButton.Enabled = false;
                    addNewButton.Enabled = true;
                    deleteButton.Enabled = true;
                    doneButton.Enabled = true;
                    authorNameText.TabStop = false;
                    authorYearBornText.TabStop=false;
                    firstButton.Enabled = true;
                    lastButton.Enabled = true;
                    searchButton.Enabled=true;
                    searchText.Enabled=true;
                    break;

                default:
                    authorNameText.ReadOnly = false;
                    authorYearBornText.ReadOnly = false;
                    btnNext.Enabled = false;
                    previousButton.Enabled = false;
                    saveButton.Enabled = true;
                    cancelButton.Enabled = true;
                    addNewButton.Enabled = false;
                    deleteButton.Enabled = false;
                    doneButton.Enabled = false;
                    firstButton.Enabled = false;
                    lastButton.Enabled = false;
                    searchButton.Enabled = false;
                    searchText.Enabled = false;

                    authorNameText.Focus();
                    
                    break;
                    
                

            }

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            authorYearBornText.DataBindings.Clear(); //clear the bindings for changing the year records
            SetAppliicationState("Edit");
            AppState="Edit";

        }

        private void addNewButton_Click(object sender, EventArgs e)
        {

            try
            {   
                CurrentPosition=authorsManager.Position;
                authorsManager.AddNew();

                SetAppliicationState("Add");
                AppState="Add";
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Adding New Record", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
           authorsManager.CancelCurrentEdit();
            if (AppState == "Edit")
            {
                authorYearBornText.DataBindings.Add("Text", authorsTable, "Year_Born");
            }
            if (AppState == "Add")
            {
                authorsManager.Position = CurrentPosition;
            }
           
            SetAppliicationState("View");
        }

        private void authorBornText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
                wrongInputLabel.Visible = false;
            }

            else
            {
                e.Handled = true;
                wrongInputLabel.Visible = true;
            }
        }

        private bool ValdateInput()
        {
            string message = "";
            int inputYear, currentYear;
            bool isOK = true;

            if (authorNameText.Text.Trim().Equals(""))
            {
                message = "Authors name is required" +"\n";
                authorNameText.Focus();
                isOK = false;

            }
            if (!authorYearBornText.Text.Trim().Equals(""))
            {
                inputYear = Convert.ToInt32(authorYearBornText.Text);
                currentYear=DateTime.Now.Year;
                if (inputYear >= currentYear) {

                    message += "Invalid Year";
                    authorYearBornText.Focus();
                    isOK = false;
                }
            }

            if (!isOK)
                {
                MessageBox.Show(message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return isOK;
            
        }

        private void authorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                authorYearBornText.Focus();
            }
        }

        private void firstButton_Click(object sender, EventArgs e)
        {
            authorsManager.Position = 0;
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            authorsManager.Position = authorsManager.Count-1;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchText.Text.Equals("") || searchText.Text.Length < 3)
            {
                MessageBox.Show("Invalid Search", "Invalid Search", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            
            authorsTable.DefaultView.Sort = "Author";
            var foundRecords = authorsTable.Select(Helper.GetAuthorSearchCommand(searchText.Text));

            if (foundRecords.Length==0)
            {
                MessageBox.Show("Nothing Was Found", "Nothing was Found", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            else
            {
                searchForm srchForm = new searchForm(foundRecords, "Authors");
                srchForm.ShowDialog();
                var index = srchForm.Index;

                authorsManager.Position = authorsTable.DefaultView.Find(foundRecords[index]["Author"]);
            }
        }


        OleDbConnection booksConnection;
        OleDbCommand authorsCommand;
        OleDbDataAdapter authorsAdapter;
        DataTable authorsTable;
        CurrencyManager authorsManager;
        OleDbCommandBuilder builderCommand;
        public int CurrentPosition { get; set; }

        bool dbError = false;

        public string AppState { get; set; }


    }

}