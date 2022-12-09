using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBrary
{
    public partial class searchForm : Form
    {
        private DataRow[] dataRows;
        private string formUsed;
        public int Index { get; set; }

        public searchForm(DataRow[] datarow,string formUsed )
        {
            this.dataRows = datarow;
            this.formUsed = formUsed;

            InitializeComponent();
        }

        private void searchForm_Load(object sender, EventArgs e)
        {
            foreach(var result in dataRows)
            {
                searchResultsBox.Items.Add(result[1]);
            }

        }

        private void searchResultsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Index= searchResultsBox.SelectedIndex;
            Close();


        }
    }
}
