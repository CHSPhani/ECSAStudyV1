using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UoB.TD.DataAccess;

namespace UoB.TD
{
    public partial class TDDataEntry : Form
    {
        MySqlConnection conn = null;
        public TDDataEntry()
        {
            InitializeComponent();
            conn = ConnectToDb.Instance.conn;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMDCreate_Click(object sender, EventArgs e)
        {
            string errorDetails = string.Empty;
            if (TrDBTableCreate.CreateDataTables(conn, ref errorDetails))
                MessageBox.Show("Tables are created and Master data is inserted into trdatav1 database");
            else
                MessageBox.Show(errorDetails);
        }

        private void btnDeleteDAta_Click(object sender, EventArgs e)
        {
            DialogResult dResult =  MessageBox.Show("Are you sure to delete master data and tables", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dResult.ToString().Equals("No"))
                return;
            string errorDetails = string.Empty;
            if (TrDBTableCreate.DropAllTables(conn,ref errorDetails))
                MessageBox.Show("All Master tables are deleted from trdatav1 database");
            else
                MessageBox.Show(errorDetails);
            
        }

        private void btnTDEntry_Click(object sender, EventArgs e)
        {
            TrainingData trData = new TrainingData(conn);
            trData.ShowDialog();
        }
    }
}
