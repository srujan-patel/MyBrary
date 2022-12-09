using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
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




        OleDbCommand authorsCommand;
        OleDbDataAdapter authorsAdapter;
        DataTable[] authorsTable = new DataTable[4];
        CurrencyManager authorsManager;
        OleDbCommandBuilder authorsBuilder;
        ComboBox[] authorCombo = new ComboBox[4];
        OleDbCommand ISBNauthorsCommand;
        OleDbDataAdapter ISBNAuthorsAdapter;
        DataTable ISBNAuthorsTable;

        OleDbCommand publisherCom;
        OleDbDataAdapter publisherAdapter;
        DataTable publisherTable;


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



                //authors table is only linked using Author_ID table
                authorCombo[0] = author1Combox;
                authorCombo[1] = author2Combo;
                authorCombo[2] = author3Combo;
                authorCombo[3] = author4Combo;
               authorsCommand = new OleDbCommand(Helper.GetAuthorCommand(), booksConnection);
                authorsAdapter = new OleDbDataAdapter();
                authorsAdapter.SelectCommand = authorsCommand;
                for(int i =0; i<4; i++)
                {

                    authorsTable[i] = new DataTable();
                    authorsAdapter.Fill(authorsTable[i]);

                    authorCombo[i].DataSource = authorsTable[i];
                    authorCombo[i].DisplayMember = "Author";
                    authorCombo[i].ValueMember = "Au_ID";
                    authorCombo[i].SelectedIndex = -1;

                }
               
                //publisher is direclty linked with titles table

                publisherCom = new OleDbCommand(Helper.GetPUblisherCommand(), booksConnection);//select alll publishers
                publisherAdapter=new OleDbDataAdapter();
                publisherTable = new DataTable();
                publisherAdapter.SelectCommand = publisherCom;
                publisherAdapter.Fill(publisherTable);

                publisherCombo.DataSource=publisherTable;
                publisherCombo.DisplayMember = "Name";//display name
                publisherCombo.ValueMember = "PUbID";//underlying value is pubid
                publisherCombo.DataBindings.Add("SelectedValue", titlesTable, "PubID"); //bind the selected value in the publisher table to titles table publishers






                SetAppState("View");
                GetAuthors();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


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

               
                    titlesAdapter.Update(titlesTable);
                    titlesTable.DefaultView.Sort="Title";
                    var foundRecords = titlesTable.Select(Helper.GetTitleISBNCommand(savedRecord));
                    titlesManager.Position = titlesTable.DefaultView.Find(foundRecords[0]["Title"]);


                }


                titlesBuilder = new OleDbCommandBuilder(ISBNAuthorsAdapter);
                if (ISBNAuthorsTable.Rows.Count != 0)
                {
                    for(int i=0; i < ISBNAuthorsTable.Rows.Count; i++)
                    {
                        ISBNAuthorsTable.Rows[i].Delete();

                    }

                    ISBNAuthorsAdapter.Update(ISBNAuthorsTable);

                }

                for(int i=0;i<4; i++)
                {
                    if (authorCombo[i].SelectedIndex != -1)
                    {
                        ISBNAuthorsTable.Rows.Add();
                        ISBNAuthorsTable.Rows[ISBNAuthorsTable.Rows.Count-1]["ISBN"]=isbnText.Text;
                        ISBNAuthorsTable.Rows[ISBNAuthorsTable.Rows.Count - 1]["Au_ID"] = authorCombo[i].SelectedValue;
                    }
                }
                ISBNAuthorsAdapter.Update(ISBNAuthorsTable);


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
            GetAuthors();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            titlesManager.Position--;
            GetAuthors();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            titlesManager.Position++;
            GetAuthors();
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            titlesManager.Position = titlesManager.Count-1;
            GetAuthors();
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

                searchForm srchForm = new searchForm(foundRecords, "Titles");
                srchForm.ShowDialog();
                var index = srchForm.Index;
                titlesManager.Position = titlesTable.DefaultView.Find(foundRecords[index]["Title"]); //to display the first result
                GetAuthors();
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

                    author1Combox.Enabled= false;
                    author2Combo.Enabled= false;
                    author3Combo.Enabled= false;
                    author4Combo.Enabled = false;


                    author1Button.Enabled=false;
                    author2Button.Enabled = false;
                    author3Button.Enabled = false;
                    author4Button.Enabled = false;

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



                    author1Combox.Enabled = true;
                    author2Combo.Enabled = true;
                    author3Combo.Enabled = true;
                    author4Combo.Enabled = true;


                    author1Button.Enabled = true;
                    author2Button.Enabled = true;
                    author3Button.Enabled = true;
                    author4Button.Enabled = true;

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

     

        private void GetAuthors()
        {
            for (int i=0; i<4; i++)
            {
                authorCombo[i].SelectedIndex = -1;
            }
            ISBNauthorsCommand = new OleDbCommand(Helper.GetISBNCommand(isbnText.Text), booksConnection);
            ISBNAuthorsAdapter = new OleDbDataAdapter();
            ISBNAuthorsAdapter.SelectCommand = ISBNauthorsCommand;
            ISBNAuthorsTable = new DataTable();
            ISBNAuthorsAdapter.Fill(ISBNAuthorsTable);


            if (ISBNAuthorsTable.Rows.Count == 0)
            {
                return;
            }
            
            for(int i =0; i<ISBNAuthorsTable.Rows.Count; i++)
            {


                authorCombo[i].SelectedValue = ISBNAuthorsTable.Rows[i]["Au_ID"].ToString();


            }

        }

        private void btnauthorx_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            switch(btnClicked.Name){

                case "author1Button":
                    author1Combox.SelectedIndex = -1;
                    break;
                case "author2Button":
                    author2Combo.SelectedIndex = -1;
                    break;

                case "author3Button":
                    author3Combo.SelectedIndex = -1;
                    break;

                case "author4Button":
                    author4Combo.SelectedIndex = -1;
                    break;

            }

        }
        private void authorsButton_Click(object sender, EventArgs e)
        {
            authorsForm athForm=new authorsForm();
            athForm.ShowDialog();
            athForm.Dispose();
            booksConnection.Close();



            string conString = Helper.ConVal("Books");
            booksConnection = new OleDbConnection(conString);
            booksConnection.Open();
            authorsAdapter.SelectCommand = authorsCommand;

            for(int i = 0; i < 4; i++) {

                authorsTable[i] = new DataTable();
                authorsAdapter.Fill(authorsTable[i]);
                authorCombo[i].DataSource = authorsTable[i];
            
            }
            GetAuthors();

        }


        private void publishersButton_Click(object sender, EventArgs e)
        {
            PublisherForm pubForm = new PublisherForm();

            pubForm.ShowDialog();   
            pubForm.Dispose();
            booksConnection.Close();


            string conString = Helper.ConVal("Books");
            booksConnection = new OleDbConnection(conString);
            booksConnection.Open();
            publisherCombo.DataBindings.Clear();
            publisherAdapter.SelectCommand = publisherCom;
            publisherTable=new DataTable();
            publisherAdapter.Fill(publisherTable);

            publisherCombo.DataSource=publisherTable;

            publisherCombo.DisplayMember = "Name";//display name
            publisherCombo.ValueMember = "PUbID";//underlying value is pubid
            publisherCombo.DataBindings.Add("SelectedValue", titlesTable, "PubID"); //bind the selected value in the publisher table to titles table publishers




        }
    }
}
