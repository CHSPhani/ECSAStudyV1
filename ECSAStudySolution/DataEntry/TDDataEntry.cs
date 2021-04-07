using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UoB.TD.DataAccess;
using UoB.TD.Models;

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
            System.Windows.Forms.Application.Exit();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Get Folder Path
            FolderBrowserDialog fbDialog = new FolderBrowserDialog();
            fbDialog.ShowDialog();
            string folderPath = fbDialog.SelectedPath;

            List<string> existingfiles = Directory.GetFiles(folderPath, "trainingdetails.xlsx", SearchOption.AllDirectories).ToList<string>();
            foreach (string fileDet in existingfiles)
            {
                System.IO.FileInfo fInfo = new FileInfo(fileDet);
                fInfo.Delete();
            }

            //getdata
            string errorMsg = string.Empty;
            List<TrainingDataModelForExcel> tModels =  MasterDataAccess.GetTrainingData(conn, ref errorMsg);

            //Create Excel
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Workbook excelWorkBook = null;
            try
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(TrainingDataModel));
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelWorkBook = excelApp.Workbooks.Add();
                _Worksheet xlWorksheet = excelWorkBook.Sheets[1];
                Range xlRange = xlWorksheet.UsedRange;

                //Add a new worksheet to workbook with the Datatable name
                Worksheet sheet = excelWorkBook.Sheets.Add();
                sheet.Name = "Paper Citation Details";

                List<string> captions = tModels[0].ToString().Split('^').ToList<string>();
                for (int i = 1; i <= properties.Count; i++)
                {
                    sheet.Cells[1, i] = captions[i - 1];
                }

                int counter = 0;
                for (int i = 1; i < tModels.Count; i++)
                {
                    List<string> values = tModels[i].ToString().Split('^').ToList<string>();
                    for (int j = 1; j <= properties.Count; j++)
                    {
                        sheet.Cells[i + 1, j].Value = values[counter];
                        counter++;
                    }
                    counter = 0;
                }
                sheet.SaveAs(folderPath + "\\trainingdetails.xlsx");

                excelWorkBook.Close();
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("There is a problem while creating Excel sheet. The reason is {0}", ex.Message));
                Console.WriteLine("There is a problem in creating and saving Excel sheet. the Reason is {0}", ex.Message);
                excelWorkBook.Close();
                excelApp.Quit();
            }
            MessageBox.Show("Training details are exported");
        }
    }
}
