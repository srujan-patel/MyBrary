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
    public partial class PublisherForm : Form
    {
        public PublisherForm()
        {
            InitializeComponent();
        }

        OleDbConnection pubConnection;
        OleDbCommand pubCommand;
        OleDbDataAdapter pubAdapter;
        DataTable pubTable;
        CurrencyManager pubManager;
        bool conOK = true;
        public String AppState { get; set; }

        private void PublisherForm_Load(object sender, EventArgs e)
        {

            try

            {
                string conString = Helper.ConVal("Books");
                pubConnection = new OleDbConnection(conString);
                pubConnection.Open();
                pubCommand = new OleDbCommand(Helper.GetPublisherCommand(), pubConnection);
                pubAdapter = new OleDbDataAdapter();
                pubAdapter.SelectCommand = pubCommand;
                pubTable = new DataTable();
                pubAdapter.Fill(pubTable);

                publisherIDText.DataBindings.Add("Text", pubTable, "PubID");
                nameText.DataBindings.Add("Text", pubTable, "Name");
                companyText.DataBindings.Add("Text", pubTable, "Company_Name");
                addressText.DataBindings.Add("Text", pubTable, "Address");
                cityText.DataBindings.Add("Text", pubTable, "City");
                stateText.DataBindings.Add("Text", pubTable, "State");
                zipText.DataBindings.Add("Text", pubTable, "Zip");
                telephoneText.DataBindings.Add("Text", pubTable, "Telephone");
                faxText.DataBindings.Add("Text", pubTable, "Fax");

                pubManager = (CurrencyManager)BindingContext[pubTable];
                SetAppState("View");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conOK = false;
            }

        }


        private void previousButton_Click(object sender, EventArgs e)
        {
            pubManager.Position--;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            pubManager.Position++;
        }

        private void SetAppState(string appState)
        {

            switch (appState)
            {
                case "View":
                    {
                        nameText.ReadOnly = true;
                        companyText.ReadOnly = true;
                        addressText.ReadOnly = true;
                        cityText.ReadOnly = true;
                        stateText.ReadOnly = true;
                        zipText.ReadOnly = true;
                        telephoneText.ReadOnly = true;
                        faxText.ReadOnly = true;
                        commentsText.ReadOnly = true;
                        saveButton.Enabled = false;
                        cancelButton.Enabled = false;
                        previousButton.Enabled = true;
                        nextButton.Enabled = true;
                        editButton.Enabled = true;
                        addButton.Enabled = true;
                        deleteButton.Enabled = true;
                        doneButton.Enabled = true;



                        break;
                    }
                default:
                    {
                        nameText.ReadOnly = false;
                        companyText.ReadOnly = false;
                        addressText.ReadOnly = false;
                        cityText.ReadOnly = false;
                        stateText.ReadOnly = false;
                        zipText.ReadOnly = false;
                        telephoneText.ReadOnly = false;
                        faxText.ReadOnly = false;
                        commentsText.ReadOnly = false;
                        saveButton.Enabled = true;
                        cancelButton.Enabled = true;
                        previousButton.Enabled = false;
                        nextButton.Enabled = false;
                        editButton.Enabled = false;
                        addButton.Enabled = false;
                        deleteButton.Enabled = false;
                        doneButton.Enabled = false;
                        nameText.Focus();

                        break;
                    }
            }

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {

                SetAppState("Edit");
                AppState = "Edit";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in Editing Records", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                pubManager.AddNew();
                SetAppState("Add");
                AppState="Add"; 
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Adding Record Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            SetAppState("View");
        }


        private bool ValidInput()
        {

            bool isOK = true;
            if (nameText.Text.Trim().Equals(""))
            {
                MessageBox.Show("Publisher Name is Required", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameText.Focus();
                isOK = false;
            }

            return isOK;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!ValidInput())
            {
                return;
            }
            try
            {
                pubManager.EndCurrentEdit();
                OleDbCommandBuilder builderCommand = new OleDbCommandBuilder(pubAdapter);
                var savedRecord = nameText.Text;
                pubTable.DefaultView.Sort = "Name";
                pubManager.Position = pubTable.DefaultView.Find(savedRecord);
                pubAdapter.Update(pubTable);



                MessageBox.Show("Record Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetAppState("View");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Record", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult response;
            response = MessageBox.Show("Are you sure you want to delete this record", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (response == DialogResult.No)
            {
                return;
            }
            try
            {

                pubManager.RemoveAt(pubManager.Position);
                OleDbCommandBuilder builderCommand = new OleDbCommandBuilder(pubAdapter);
                pubAdapter.Update(pubTable);
                AppState="Delete"

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Deleting Record Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (e.KeyChar == 13)
            {
                switch (textBox.Name)
                {
                    case "nameText":
                        companyText.Focus();
                        break;
                    case "companyText":
                        addressText.Focus();
                        break;
                    case "addressText":
                        cityText.Focus();
                        break;
                    case "cityText":
                        stateText.Focus();
                        break;
                    case "stateText":
                        zipText.Focus();
                        break;
                    case "zipText":
                        telephoneText.Focus();
                        break;
                    case "telephoneText":
                        faxText.Focus();
                        break;
                    case "faxText":
                        commentsText.Focus();
                        break;
                    case "commentsText":
                        saveButton.Focus();
                        break;



                }

            }

        }

        private void publishersForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (conOK)
            {
                pubConnection.Close();
                pubConnection.Dispose();
                pubCommand.Dispose();
                pubAdapter.Dispose();
                pubTable.Dispose();
            }

        }

        private void firstButton_Click(object sender, EventArgs e)
        {
            pubManager.Position = 0;
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            pubManager.Position = pubManager.Count-1;
        }
    }
}
