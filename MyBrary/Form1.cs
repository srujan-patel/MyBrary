using MyBrary;
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
    public partial class authorsForm : Form
    {
        public authorsForm()
        {
            InitializeComponent();
        }

        OleDbConnection booksConnection;
        OleDbCommand authorsCommand;
        OleDbDataAdapter authorsAdapter;
        DataTable authorsTable;
        CurrencyManager authorsManager;
        bool dbError=false;
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

                authorsManager = (CurrencyManager)BindingContext[authorsTable];
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
                    authorNameText.Focus();
                    
                    break;

                

            }

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            SetAppliicationState("Edit");
        }

        private void addNewButton_Click(object sender, EventArgs e)
        {

            try
            {
                SetAppliicationState("Add");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Adding New Record", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
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
    }
}