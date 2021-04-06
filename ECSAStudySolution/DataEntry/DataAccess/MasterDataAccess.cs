using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoB.TD.Models;

namespace UoB.TD.DataAccess
{
    public class MasterDataAccess
    {
        public static List<TrainingDataModelForExcel> GetTrainingData(MySqlConnection conn, ref string errorMsg)
        {
            List<TrainingDataModelForExcel> tModel = new List<TrainingDataModelForExcel>();
            TrainingDataModelForExcel tM1 = new TrainingDataModelForExcel() { PId = "PID", AaID = "Application Area Id", BcnID = "Blockchain Network Id", BcnpID = "BC Network Participation ID",
                                                BccID = "Blockchain Consensus Id",
                                                BcsID = "BC Scalability ID", BclID = "BC Latency ID", BcprID = "BC Performance Id", BcdaID = "BC Data Access ID", BcdapID = "BC Data Access Policy ID",
                                                bcdfID = "BC Data Format", AsID = "Architecture Style Id", NfrasID = "NFRs in Architecture Id", DsID = "Data Storage Id",
                                                BpID = "Blockchain Platform Id", RsID = "Results Obtained"};
            tModel.Add(tM1);
            try
            {
                string sql = string.Format(" SELECT * FROM trainingdata");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TrainingDataModelForExcel tM = new TrainingDataModelForExcel();
                    tM.PId = rdr[0].ToString();
                    tM.AaID = rdr[1].ToString();
                    tM.BcnID = rdr[2].ToString();
                    tM.BcnpID = rdr[3].ToString();
                    tM.BccID = rdr[4].ToString();
                    tM.BcsID = rdr[5].ToString();
                    tM.BclID = rdr[6].ToString();
                    tM.BcprID = rdr[7].ToString();
                    tM.BcdaID = rdr[8].ToString();
                    tM.BcdapID = rdr[9].ToString();
                    tM.bcdfID = rdr[10].ToString();
                    tM.AsID = rdr[11].ToString();
                    tM.NfrasID = rdr[12].ToString();
                    tM.DsID = rdr[13].ToString();
                    tM.BpID = IdToNumericValues.GetNumericValuesForBPId(rdr[14].ToString()).ToString();
                    tM.RsID = rdr[15].ToString();
                    tModel.Add(tM);
                }
                rdr.Close();
                cmd = null;
            }
            catch(Exception ex)
            {
                errorMsg = string.Format("Exception happened when getting training data from database. Reason is {0}", ex.Message);
            }
            return tModel;
        }
        public static bool SaveCommonDetails (CommonDataSaveModel cModel, TrainingDataModel tModel, MySqlConnection conn, ref string errorMsg)
        {
            MySqlTransaction myTrans;
            // Start a local transaction

            myTrans = conn.BeginTransaction();
            try
            {
                string savingSql = string.Format("INSERT INTO commonparameters(pID,pName,pCitation,pRef) VALUES ({0},'{1}','{2}','{3}')", cModel.PId, cModel.PName, cModel.PCitation, cModel.PRef);
                MySqlCommand cmd = new MySqlCommand(savingSql.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                
                
                string savingSql1 = string.Format("INSERT INTO trainingdata(pID, AaID, BcnID, BcnpID, BccID, BcsID, BclID, BcprID, BcdaID, BcdapID, bcdfID, AsID, NfrasID, DsID, BpID, rsID) VALUES " +
                                            "({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')", tModel.PId, tModel.AaID, tModel.BcnID, tModel.BcnpID, tModel.BccID,
                                            tModel.BcsID, tModel.BclID, tModel.BcprID, tModel.BcdaID, tModel.BcdapID, tModel.bcdfID, tModel.AsID, tModel.NfrasID, tModel.DsID, tModel.BpID, tModel.RsID);
                MySqlCommand cmd2 = new MySqlCommand(savingSql1.ToString(), conn);
                cmd2.Transaction = myTrans;
                cmd2.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                
                myTrans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                errorMsg = string.Format("Exception happened when saving common models. Reason is {0}", ex.Message);
            }
            return false; 
        }
        public static int GetNextPID(MySqlConnection conn)
        {
            int id = -1;
            try
            {
                string sql = string.Format("SELECT Max(PID) FROM commonparameters");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (!string.IsNullOrEmpty(rdr[0].ToString()))
                    {
                        id = Int32.Parse(rdr[0].ToString());
                    }
                    else
                    {
                        id = 0;
                    }
                }
                rdr.Close();
                cmd = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception while inserting data. Details are {0}", ex.Message));
            }
            return id;
        }

        public static List<string> GetValueSetForATable(string table, string colName, MySqlConnection conn)
        {
            List<string> valueSet = new List<string>();
            try
            {
                string query = string.Format("SELECT {0} from {1}", colName, table);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    valueSet.Add(rdr[0].ToString());
                }
                rdr.Close();
                cmd = null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("Exception while getting for {0} from table {1}. Details are {2}", colName,table, ex.Message));
            }
            return valueSet;
        }

        public static string GetIDForAValue(string table, string valColName, string IdColName, string val, MySqlConnection conn)
        {
            string idForvalue = string.Empty;
            try
            {
                string query = string.Format("SELECT {0} from {1} where {2}='{3}'", IdColName, table, valColName, val);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    idForvalue = rdr[0].ToString();
                }
                rdr.Close();
                cmd = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception while getting for {0} from table {1}. Details are {2}", valColName, table, ex.Message));
            }
            return idForvalue;
        }
    }
}
