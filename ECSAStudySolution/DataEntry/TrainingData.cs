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
using UoB.TD.Models;

namespace UoB.TD
{
    public partial class TrainingData : Form
    {
        MySqlConnection conn; 
        public TrainingData()
        {
            InitializeComponent();
        }
        public TrainingData(MySqlConnection conn):this()
        {
            this.conn = conn; 
            //application area
            foreach (string s in MasterDataAccess.GetValueSetForATable("applicationarea", "aaName", conn))
            {
                cmbAArea.Items.Add(s);
            }
            //blockchain network 
            foreach (string s in MasterDataAccess.GetValueSetForATable("BCNetworks", "bcnName", conn))
            {
                cmbBcType.Items.Add(s);
            }
            //Network participation 
            foreach (string s in MasterDataAccess.GetValueSetForATable("BCNWParticipation", "bcnpName", conn))
            {
                cmbNwPart.Items.Add(s);
            }
            //Consensus 
            foreach (string s in MasterDataAccess.GetValueSetForATable("BCConsensus", "bccName", conn))
            {
                cmbConsensus.Items.Add(s);
            }
            //Scalability 
            foreach (string s in MasterDataAccess.GetValueSetForATable("BCScalability", "bcsName", conn))
            {
                cmbScalability.Items.Add(s);
            }
            //Latency 
            foreach (string s in MasterDataAccess.GetValueSetForATable("BCLatency", "bclName", conn))
            {
                cmbLatency.Items.Add(s);
            }
            //Performance 
            foreach (string s in MasterDataAccess.GetValueSetForATable("BCPerformance", "bcprName", conn))
            {
                cmbPerf.Items.Add(s);
            }
            // Data Access 
            foreach (string s in MasterDataAccess.GetValueSetForATable("BCDataAccess", "bcdaName", conn))
            {
                cmbDataAccess.Items.Add(s);
            }
            //Data Access Policy 
            foreach (string s in MasterDataAccess.GetValueSetForATable("BCDataAccessPolicy", "bcdapName", conn))
            {
                cmbDap.Items.Add(s);
            }
            //Data format 
            foreach (string s in MasterDataAccess.GetValueSetForATable("BCDataFormat", "bcdfName", conn))
            {
                cmbDataFormat.Items.Add(s);
            }
            //Arch Style 
            foreach (string s in MasterDataAccess.GetValueSetForATable("ArchitectureStyle", "asName", conn))
            {
                cmbAs.Items.Add(s);
            }
            
            //NFR in ARchitecture 
            foreach (string s in MasterDataAccess.GetValueSetForATable("NFRsInArchitecture", "nfrasName", conn))
            {
                cmbAsNFR.Items.Add(s);
            }
            //Data Storage Platform 
            foreach (string s in MasterDataAccess.GetValueSetForATable("DataStorageSystems", "dsName", conn))
            {
                cmbDS.Items.Add(s);
            }
            //Blockchain platform 
            foreach (string s in MasterDataAccess.GetValueSetForATable("BlockchainPlatforms", "bpName", conn))
            {
                cmbBcPlat.Items.Add(s);
            }
            //Results Obtained 
            foreach (string s in MasterDataAccess.GetValueSetForATable("resultsobtained", "rsName", conn))
            {
                cmbarFeatures.Items.Add(s);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errorMsg = string.Empty;
            if (string.IsNullOrEmpty(tbPaperName.Text) || string.IsNullOrEmpty(tbCitaton.Text) || string.IsNullOrEmpty(tbRef.Text))
                MessageBox.Show("Please enter Common details for Paper");
            else
            {
                int nextPid = MasterDataAccess.GetNextPID(conn)+1;
                CommonDataSaveModel cmdModel = new CommonDataSaveModel();
                cmdModel.PId = nextPid;
                if (!string.IsNullOrEmpty(tbPaperName.Text))
                    cmdModel.PName = tbPaperName.Text;
                if (!string.IsNullOrEmpty(tbCitaton.Text))
                    cmdModel.PCitation = tbCitaton.Text;
                if (!string.IsNullOrEmpty(tbRef.Text))
                    cmdModel.PRef = tbRef.Text;

                TrainingDataModel tdModel = new TrainingDataModel();
                tdModel.PId = nextPid;
                if (!string.IsNullOrEmpty(cmbAArea.SelectedItem.ToString()))
                    tdModel.AaID = MasterDataAccess.GetIDForAValue("applicationarea", "aaName", "aaID", cmbAArea.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbBcType.SelectedItem.ToString()))
                    tdModel.BcnID = MasterDataAccess.GetIDForAValue("BCNetworks", "bcnName", "bcnID", cmbBcType.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbNwPart.SelectedItem.ToString()))
                    tdModel.BcnpID = MasterDataAccess.GetIDForAValue("BCNWParticipation", "bcnpName", "bcnpID", cmbNwPart.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbConsensus.SelectedItem.ToString()))
                    tdModel.BccID = MasterDataAccess.GetIDForAValue("BCConsensus", "bccName", "BccID", cmbConsensus.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbScalability.SelectedItem.ToString()))
                    tdModel.BcsID = MasterDataAccess.GetIDForAValue("BCScalability", "bcsName", "BcsID", cmbScalability.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbLatency.SelectedItem.ToString()))
                    tdModel.BclID = MasterDataAccess.GetIDForAValue("BCLatency", "bclName", "BclID", cmbLatency.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbPerf.SelectedItem.ToString()))
                    tdModel.BcprID = MasterDataAccess.GetIDForAValue("BCPerformance", "bcprName", "BcprID", cmbPerf.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbDataAccess.SelectedItem.ToString()))
                    tdModel.BcdaID = MasterDataAccess.GetIDForAValue("BCDataAccess", "bcdaName", "BcdaID", cmbDataAccess.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbDap.SelectedItem.ToString()))
                    tdModel.BcdapID = MasterDataAccess.GetIDForAValue("BCDataAccessPolicy", "bcdapName", "BcdapID", cmbDap.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbDataFormat.SelectedItem.ToString()))
                    tdModel.bcdfID = MasterDataAccess.GetIDForAValue("BCDataFormat", "bcdfName", "bcdfID", cmbDataFormat.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbAs.SelectedItem.ToString()))
                    tdModel.AsID = MasterDataAccess.GetIDForAValue("ArchitectureStyle", "asName", "AsID", cmbAs.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbAsNFR.SelectedItem.ToString()))
                    tdModel.NfrasID = MasterDataAccess.GetIDForAValue("NFRsInArchitecture", "nfrasName", "NfrasID", cmbAsNFR.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbDS.SelectedItem.ToString()))
                    tdModel.DsID = MasterDataAccess.GetIDForAValue("DataStorageSystems", "dsName", "DsID", cmbDS.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbBcPlat.SelectedItem.ToString()))
                    tdModel.BpID = MasterDataAccess.GetIDForAValue("BlockchainPlatforms", "bpName", "BpID", cmbBcPlat.SelectedItem.ToString(), conn);

                if (!string.IsNullOrEmpty(cmbarFeatures.SelectedItem.ToString()))
                    tdModel.RsID = MasterDataAccess.GetIDForAValue("resultsobtained", "rsName", "rsID", cmbarFeatures.SelectedItem.ToString(), conn);

                if (!MasterDataAccess.SaveCommonDetails(cmdModel, tdModel, conn, ref errorMsg))
                    MessageBox.Show(string.Format("PRoblem in saving taraining data. The Reason is {0}", errorMsg));
                else
                    MessageBox.Show("Data Inserted sucessfully");
                this.Close();
            }

        }
    }
}
