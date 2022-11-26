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
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Database Connection Error",MessageBoxButtons.OK, MessageBoxIcon.Error );

            }

            


        }
    }
}
