using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoB.TD.DataAccess
{
    public class TrDBTableCreate
    {
        /// <summary>
        /// This function delets all data from database by deleting all tables
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool DropAllTables(MySqlConnection conn, ref string errorMsg)
        {
            MySqlTransaction myTrans;
            // Start a local transaction
            myTrans = conn.BeginTransaction();
            try
            {
                string dropTables = string.Format(@"drop table trainingdata;
                                                    drop table CommonParameters;
                                                    drop table applicationarea;           
                                                    drop table architecturestyle;          
                                                    drop table architecturestylefeatures;  
                                                    drop table bcconsensus;                
                                                    drop table bcdataaccess;               
                                                    drop table bcdataaccesspolicy;         
                                                    drop table bcdataformat;               
                                                    drop table bclatency;                  
                                                    drop table bcnetworks;                 
                                                    drop table bcnwparticipation;          
                                                    drop table bcperformance;              
                                                    drop table bcscalability;              
                                                    drop table blockchainplatforms;        
                                                    drop table datastoragesystems;         
                                                    drop table nfrsinarchitecture;");
                MySqlCommand cmd = new MySqlCommand(dropTables.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                myTrans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                errorMsg = string.Format("An Exception happend when creating data tables - {0}", ex.Message);
                Console.WriteLine("An Exception happend when creating data tables", ex.Message);
            }
            return false;
        }

        /// <summary>
        /// This function creates tables and inserts master data into tables. 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool CreateDataTables(MySqlConnection conn, ref string errorMsg)
        {
            MySqlTransaction myTrans;
            // Start a local transaction
            myTrans = conn.BeginTransaction();
            try
            {
                //1. Creating ApplicationArea Table and inserting rows
                string aArea = string.Format(@"CREATE TABLE `trdatav1`.`ApplicationArea` (`aaID` INT NOT NULL, `aaName` VARCHAR(150) NOT NULL, `aaNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`aaID`));");
                MySqlCommand cmd = new MySqlCommand(aArea.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string aAreaData = string.Format(@"INSERT INTO ApplicationArea(aaID,aaName,aaNotes) VALUES (1,'Healthcare','Health care systems');
                                                   INSERT INTO ApplicationArea(aaID,aaName,aaNotes) VALUES (2,'CPS','Cyber Physical Systems');
                                                   INSERT INTO ApplicationArea(aaID,aaName,aaNotes) VALUES (3,'VM','Intellgient Transportation');
                                                   INSERT INTO ApplicationArea(aaID,aaName,aaNotes) VALUES (4,'SC','Supply Chain Systems');
                                                   INSERT INTO ApplicationArea(aaID,aaName,aaNotes) VALUES (5,'DS','Document Stores');
                                                   INSERT INTO ApplicationArea(aaID,aaName,aaNotes) VALUES (6,'LM','Log Management');");
                cmd = new MySqlCommand(aAreaData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //2. Creating Blockchain Network Table and inserting rows
                string bcNetwork = string.Format(@"CREATE TABLE `trdatav1`.`BCNetworks` (`bcnID` INT NOT NULL, `bcnName` VARCHAR(150) NOT NULL, `bcnNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcnID`));");
                cmd = new MySqlCommand(bcNetwork.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcnData = string.Format(@"INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES (1,'Pri','Private Blockchains');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES (2,'C-Pri','Customizations done to Private Blockchains solutions like modfying consensus or participation');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES (3,'Pro','Protected Blockchains');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES (4,'C-Pr0','Customizations done to Protected Blockchain solutions like modfying consensus or participation');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES (5,'Con','Consortium Blockchains');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES (6,'C-Con','Customizations done to Consortium Blockchains solutions like modfying consensus or participation');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES (7,'Pub','Public Blockchains');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES (8,'New','Newly Implemented Blockchains from ground up');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES (9,'Oth','Other networks like Gunicorn that are considered as Blockchains');");
                cmd = new MySqlCommand(bcnData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //3. Creating Blockchain Network Participation table and rows.
                string bcNPart = string.Format(@"CREATE TABLE `trdatav1`.`BCNWParticipation` (`bcnpID` INT NOT NULL, `bcnpName` VARCHAR(150) NOT NULL, `bcnpNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcnpID`));");
                cmd = new MySqlCommand(bcNPart.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcNPartData = string.Format(@"INSERT INTO BCNWParticipation(bcnpID,bcnpName,bcnpNotes) VALUES (1,'Open','Open PArticipation as in Public Blockchains');
                                                     INSERT INTO BCNWParticipation(bcnpID,bcnpName,bcnpNotes) VALUES (2,'Perm','Permission required for participating in Blockchain network');
                                                     INSERT INTO BCNWParticipation(bcnpID,bcnpName,bcnpNotes) VALUES (3,'Cri','Participating in Blockchain network is dependent on certain criteria like being a member of socitey');
                                                     INSERT INTO BCNWParticipation(bcnpID,bcnpName,bcnpNotes) VALUES (4,'Oth', 'Other ways of Participating in Blockchain network ');");
                cmd = new MySqlCommand(bcNPartData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //4. Creating Blockchain Consensus table and rows.
                string bcConsensus = string.Format(@"CREATE TABLE `trdatav1`.`BCConsensus` (`bccID` INT NOT NULL, `bccName` VARCHAR(150) NOT NULL, `bccNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bccID`));");
                cmd = new MySqlCommand(bcConsensus.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bccData = string.Format(@"INSERT INTO BCConsensus(bccID,bccName,bccNotes) VALUES (1,'Std','Standard Consensus algorithms that comes with Blockchain solutions');
                                                 INSERT INTO BCConsensus(bccID,bccName,bccNotes) VALUES (2,'Cust','Consensus algorithms  provided with Blockchain solutions are customized by changing code base');
                                                 INSERT INTO BCConsensus(bccID,bccName,bccNotes) VALUES (3,'New','New Consensus algorithms');");
                cmd = new MySqlCommand(bccData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //5. Creating Blockchain Scalability table and rows.
                string bcScalability = string.Format(@"CREATE TABLE `trdatav1`.`BCScalability` (`bcsID` INT NOT NULL, `bcsName` VARCHAR(150) NOT NULL, `bcsNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcsID`));");
                cmd = new MySqlCommand(bcScalability.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcsData = string.Format(@"INSERT INTO BCScalability(bcsID,bcsName,bcsNotes) VALUES (1,'AC','Scalability is achieved using Consensus mechanisms');
                                                 INSERT INTO BCScalability(bcsID,bcsName,bcsNotes) VALUES (2,'AD','Scalability is achieved through the means of underlying Database');
                                                 INSERT INTO BCScalability(bcsID,bcsName,bcsNotes) VALUES (3,'AP','Scalability is achieved using underlying Physical storage');
                                                 INSERT INTO BCScalability(bcsID,bcsName,bcsNotes) VALUES (4,'AO','Scalability is achieved using other means');
                                                 INSERT INTO BCScalability(bcsID,bcsName,bcsNotes) VALUES (5,'NC','Scalability is Not considered at all'); ");
                cmd = new MySqlCommand(bcsData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //6. Creating Blockchain Latency table and rows.
                string bcLatency = string.Format(@"CREATE TABLE `trdatav1`.`BCLatency` (`bclID` INT NOT NULL, `bclName` VARCHAR(150) NOT NULL, `bclNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bclID`));");
                cmd = new MySqlCommand(bcLatency.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bclData = string.Format(@"INSERT INTO BCLatency(bclID,bclName,bclNotes) VALUES (1,'RL','Read Latency time is the time taken to receive reply from blokchain after read submit');
                                                 INSERT INTO BCLatency(bclID,bclName,bclNotes) VALUES (2,'TL','Transaction Latency is amount of time taken for transaction is usable across blockchain network');
                                                 INSERT INTO BCLatency(bclID,bclName,bclNotes) VALUES (3,'NL','Network Latency is amount of latency for data to travel across the network, firewalls from one communication endpoint to another.');
                                                 INSERT INTO BCLatency(bclID,bclName,bclNotes) VALUES (4,'OT','Other uncategorized latencies tha cause delay');");
                cmd = new MySqlCommand(bclData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //7. Creating Blockchain Performance table and rows.
                string bcPerformance = string.Format(@"CREATE TABLE `trdatav1`.`BCPerformance` (`bcprID` INT NOT NULL, `bcprName` VARCHAR(150) NOT NULL, `bcprNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcprID`));");
                cmd = new MySqlCommand(bcPerformance.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcprData = string.Format(@"INSERT INTO BCPerformance(bcprID,bcprName,bcprNotes) VALUES (1,'TP','Transaction Throughput is rate at which valid transactions are committed by blockchain in a time period');
                                                  INSERT INTO BCPerformance(bcprID,bcprName,bcprNotes) VALUES (2,'CL-GD','Geographic distribution of co-locating nodes');
                                                  INSERT INTO BCPerformance(bcprID,bcprName,bcprNotes) VALUES (3,'DP-GD','Geographic distribution of dispersed nodes');
                                                  INSERT INTO BCPerformance(bcprID,bcprName,bcprNotes) VALUES (4,'HE-HW','High end hardware high processor speed with number of cores and memory');
                                                  INSERT INTO BCPerformance(bcprID,bcprName,bcprNotes) VALUES (5,'LW-HW','Low end hardware nomial processor speed with no cores and less memory'); 
                                                  INSERT INTO BCPerformance(bcprID,bcprName,bcprNotes) VALUES (6,'Other','Other performance indicators for blockchain');");
                cmd = new MySqlCommand(bcprData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //8. Creating Data Access from Blockchain.
                string bcDAccess = string.Format(@"CREATE TABLE `trdatav1`.`BCDataAccess` (`bcdaID` INT NOT NULL, `bcdaName` VARCHAR(150) NOT NULL, `bcdaNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcdaID`));");
                cmd = new MySqlCommand(bcDAccess.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcDataAccess = string.Format(@"INSERT INTO BCDataAccess(bcdaID,bcdaName,bcdaNotes) VALUES (1,'BD','Blockchain default APIS to access data from blockchain');
                                                      INSERT INTO BCDataAccess(bcdaID,bcdaName,bcdaNotes) VALUES (2,'BC','Blockchain default APIS  are customized for accessing data from blockchain');
                                                      INSERT INTO BCDataAccess(bcdaID,bcdaName,bcdaNotes) VALUES (3,'BA','Blockchain default APIS  are combined with other DB access engines for accessing data from blockchain');
                                                      INSERT INTO BCDataAccess(bcdaID,bcdaName,bcdaNotes) VALUES (4,'NW','New APIS or Engines for accessing data from blockchain');");
                cmd = new MySqlCommand(bcDataAccess.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;


                //9. Creating Data Access from Blockchain.
                string bcDAPolicy = string.Format(@"CREATE TABLE `trdatav1`.`BCDataAccessPolicy` (`bcdapID` INT NOT NULL, `bcdapName` VARCHAR(150) NOT NULL, `bcdapNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcdapID`));");
                cmd = new MySqlCommand(bcDAPolicy.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcDataAccessPolicy = string.Format(@"INSERT INTO BCDataAccessPolicy(bcdapID,bcdapName,bcdapNotes) VALUES (1,'SC','User defined data access policies in Smart Contract');
                                                            INSERT INTO BCDataAccessPolicy(bcdapID,bcdapName,bcdapNotes) VALUES (2,'KY','User defined data access policies using public Key infrastructure and store the key info in blockchain');
                                                            INSERT INTO BCDataAccessPolicy(bcdapID,bcdapName,bcdapNotes) VALUES (3,'PB','Data Stored is for public');
                                                            INSERT INTO BCDataAccessPolicy(bcdapID,bcdapName,bcdapNotes) VALUES (4,'OT','Data access policy is defined in other ways');");
                cmd = new MySqlCommand(bcDataAccessPolicy.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //10. Blockchain Transaction data formats .
                string bcDAFormat = string.Format(@"CREATE TABLE `trdatav1`.`BCDataFormat` (`bcdfID` INT NOT NULL, `bcdfName` VARCHAR(150) NOT NULL, `bcdfNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcdfID`));");
                cmd = new MySqlCommand(bcDAFormat.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcDataFormat = string.Format(@"INSERT INTO BCDataFormat(bcdfID,bcdfName,bcdfNotes) VALUES (1,'SM','Data is formatted using standard data models like Relational, Key-Value etc.');
                                                      INSERT INTO BCDataFormat(bcdfID,bcdfName,bcdfNotes) VALUES (2, 'JSON', 'Data is formatted using Java Script Object Notation');
                                                      INSERT INTO BCDataFormat(bcdfID,bcdfName,bcdfNotes) VALUES (3, 'XML', 'Data is formatted using XML');
                                                      INSERT INTO BCDataFormat(bcdfID,bcdfName,bcdfNotes) VALUES (4, 'Tuple', 'Data is formatted using Tuple structure like triple, quadruple, pentuple etc..');
                                                      INSERT INTO BCDataFormat(bcdfID,bcdfName,bcdfNotes) VALUES (5, 'Other', 'Data is formatted using other formats');
                                                      INSERT INTO BCDataFormat(bcdfID,bcdfName,bcdfNotes) VALUES (6, 'NF', 'No Format Data is not formatted or not mentioned');");
                cmd = new MySqlCommand(bcDataFormat.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //11. Architecture Styles.
                string bcAStyle = string.Format(@"CREATE TABLE `trdatav1`.`ArchitectureStyle` (`asID` INT NOT NULL, `asName` VARCHAR(150) NOT NULL, `asNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`asID`));");
                cmd = new MySqlCommand(bcAStyle.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcArchStyle = string.Format(@"INSERT INTO ArchitectureStyle(asID,asName,asNotes) VALUES (1,'SOA','Service Oriented Architecture');
                                                     INSERT INTO ArchitectureStyle(asID,asName,asNotes) VALUES (2,'MS','Micro Services based Architecture');
                                                     INSERT INTO ArchitectureStyle(asID,asName,asNotes) VALUES (3,'OF','OpenFog Architecture for IoT');
                                                     INSERT INTO ArchitectureStyle(asID,asName,asNotes) VALUES (4,'CS','Cloud Oriented Architecture');
                                                     INSERT INTO ArchitectureStyle(asID,asName,asNotes) VALUES (5,'OS','Other Styles like Object Oriented, Component Oriented, Layered architectures.');");
                cmd = new MySqlCommand(bcArchStyle.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //12. Features for each Architecture Style.
                string bcASFeature = string.Format(@"CREATE TABLE `trdatav1`.`ArchitectureStyleFeatures` (`asfID` INT NOT NULL, `asfName` VARCHAR(150) NOT NULL, `asfNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`asfID`));");
                cmd = new MySqlCommand(bcASFeature.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcAStFeature = string.Format(@"INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (1,'SOA-Service Descriptions','Service Descriptions for services');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (2,'SOA-Service Contract','Service Contract abstractly describes functionality of service');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (3,'SOA-Service Policy','Service Policy');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (4,'SOA-Service Discovery','Service Discovery enables discovering service'); 
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (5,'SOA-Service Bus','Service Bus is the wrapping service with communication protocols'); 
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (6,'SOA-Service Composition','Services using other services');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (7,'SOA-Service Asynchronous','Asyn Services');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (8,'SOA-Service Orchestration','arranging services');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (9,'SOA-Service Virtualization','Crucual for Scaling');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (10,'SOA-Service Quality','Quality of Service'); 
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (11,'SOA-Interoperability','Inter operability'); 
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (12,'SOA-Location Transparency','Service can be hosted any location');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (13,'MS-Module Boundaries',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (14,'MS-Deployment',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (15,'MS-Technology Diversity',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (16,'MS-Consistency',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (17,'MS-Complexity',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (18,'MS-Diversity',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (19,'OF-Open',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (20,'OF-Autonomy',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (21,'OF-Reliability',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (22,'OF-Serviceability',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (23,'OF-Agility',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (24,'OF-Hierarchy',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (25,'OF-Programmability',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (26,'OF-N-Tier Fog Deployment',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (27,'CS-Data Management',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (28,'CS-Messaging',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (29,'CS-Management',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (30,'CS-Monitoring',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (31,'CS-Resiliency',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (32,'CS-Security',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (33,'OT-Object Oriented',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (34,'OT-Component Oriented',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (35,'OT-ClientServer',' ');
                                                      INSERT INTO ArchitectureStyleFeatures(asfID,asfName,asfNotes) VALUES (36,'Other',' ');");
                cmd = new MySqlCommand(bcAStFeature.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //13. NFRS in Architecture Styles.
                string bcASNfrs = string.Format(@"CREATE TABLE `trdatav1`.`NFRsInArchitecture` (`nfrasID` INT NOT NULL, `nfrasName` VARCHAR(150) NOT NULL, `nfrasNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`nfrasID`));");
                cmd = new MySqlCommand(bcASNfrs.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcNFRArchStyle = string.Format(@"INSERT INTO NFRsInArchitecture(nfrasID,nfrasName,nfrasNotes) VALUES (1,'Scalability','Scalability of data access logic');
                                                        INSERT INTO NFRsInArchitecture(nfrasID,nfrasName,nfrasNotes) VALUES (2,'Performace','Performace of system');
                                                        INSERT INTO NFRsInArchitecture(nfrasID,nfrasName,nfrasNotes) VALUES (3,'Availability','Availability of services or functionality');
                                                        INSERT INTO NFRsInArchitecture(nfrasID,nfrasName,nfrasNotes) VALUES (4,'Security','Security');
                                                        INSERT INTO NFRsInArchitecture(nfrasID,nfrasName,nfrasNotes) VALUES (5,'Configurability','Configuration of services');
                                                        INSERT INTO NFRsInArchitecture(nfrasID,nfrasName,nfrasNotes) VALUES (6,'Resource utilization','usage of resources');
                                                     ");
                cmd = new MySqlCommand(bcNFRArchStyle.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //14. NFRS in Architecture Styles.
                string bcDtStor = string.Format(@"CREATE TABLE `trdatav1`.`DataStorageSystems` (`dsID` INT NOT NULL, `dsName` VARCHAR(150) NOT NULL, `dsNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`dsID`));");
                cmd = new MySqlCommand(bcDtStor.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcDStoSystems = string.Format(@"INSERT INTO DataStorageSystems(dsID,dsName,dsNotes) VALUES (1,'BD','Blockchain Puls other databases');
                                                       INSERT INTO DataStorageSystems(dsID,dsName,dsNotes) VALUES (2,'BS','Blockchain Puls other storage sysems like File or content storage systems');
                                                       INSERT INTO DataStorageSystems(dsID,dsName,dsNotes) VALUES (3,'BC','Blockchain is used to store data');");
                cmd = new MySqlCommand(bcDStoSystems.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //15. NFRS in Architecture Styles.
                string bcBcs = string.Format(@"CREATE TABLE `trdatav1`.`BlockchainPlatforms` (`bpID` INT NOT NULL, `bpName` VARCHAR(150) NOT NULL, `bpNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bpID`));");
                cmd = new MySqlCommand(bcBcs.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bchains = string.Format(@"INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (1,'Bitcoin','https://bitcoin.org/en/how-it-works');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (2,'Chainlink','https://chain.link/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (3,'Concord','http://projectconcord.io/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (4,'Corda / R3','https://www.r3.com/corda-platform/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (5,'Emercoin','https://emercoin.com/en');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (6,'Energy Web Foundation EWF','https://www.energyweb.org/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (7,'Ethereum','https://ethereum.org/en/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (8,'Filecoin','https://filecoin.io/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (9,'Grd','https://www.grd.com/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (10,'HashGraph','https://hedera.com/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (11,'IBM - Hyperledger (Fabric)','https://www.hyperledger.org/use/fabric');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (12,'IoTeX','https://iotex.io/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (13,'Lo3','https://lo3energy.com/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (14,'Microsoft','https://azure.microsoft.com/en-gb/services/blockchain-service/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (15,'MultiChain','https://www.multichain.com/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (16,'Powerledger','https://www.powerledger.io/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (17,'Qtum','https://qtum.org/en');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (18,'Quorum','https://consensys.net/quorum/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (19,'Sia','https://sia.tech/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (20,'Storj','https://www.storj.io/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (21,'Tor','https://en.bitcoin.it/wiki/Tor');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (22,'WaltonChain','http://www.waltonchain.org/en/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (23,'IOTA','https://www.iota.org/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (24,'BigChainDB','https://www.bigchaindb.com/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (25,'Tendermint','https://tendermint.com/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (26,'GRIDNET','https://gridnet.org/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (27,'Custom',' ');	
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES (28,'Others',' ');");
                cmd = new MySqlCommand(bchains.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //14. Common Parameters.
                string cparams = string.Format(@"CREATE TABLE `trdatav1`.`CommonParameters` (`pID` INT NOT NULL, `pName` VARCHAR(500) NOT NULL, `pCitation` VARCHAR(150) NOT NULL, `pRef` VARCHAR(5000) NOT NULL, PRIMARY KEY (`pID`));");
                cmd = new MySqlCommand(cparams.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //14. Training data.
                string trdata = string.Format(@"CREATE TABLE `trdatav1`.`trainingdata`(`pID` INT NOT NULL,  `aaID` INT NOT NULL, `bcnID` INT NOT NULL, `bcnpID` INT NOT NULL, `bccID` INT NOT NULL, `bcsID` INT NOT NULL, `bclID` INT NOT NULL, `bcprID` INT NOT NULL, `bcdaID` INT NOT NULL, `bcdapID` INT NOT NULL, `bcdfID` INT NOT NULL, `asID` INT NOT NULL, `asfID` INT NOT NULL, `nfrasID` INT NOT NULL, `dsID` INT NOT NULL, `bpID` INT NOT NULL, PRIMARY KEY (`pID`),
                                                    CONSTRAINT `paperid`
                                                        FOREIGN KEY (`pID`)
                                                        REFERENCES `trdatav1`.`commonparameters` (`pID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `aareaid`
                                                        FOREIGN KEY (`aaID`)
                                                        REFERENCES `trdatav1`.`ApplicationArea` (`aaID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `bcnetworkid`
                                                        FOREIGN KEY (`bcnID`)
                                                        REFERENCES `trdatav1`.`BCNetworks` (`bcnID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `bcntwkpartid`
                                                        FOREIGN KEY (`bcnpID`)
                                                        REFERENCES `trdatav1`.`BCNWParticipation` (`bcnpID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `bcconsensusid`
                                                        FOREIGN KEY (`bccID`)
                                                        REFERENCES `trdatav1`.`BCConsensus` (`bccID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `bcscalabilityid`
                                                        FOREIGN KEY (`bcsID`)
                                                        REFERENCES `trdatav1`.`BCScalability` (`bcsID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `bclatencyid`
                                                        FOREIGN KEY (`bclID`)
                                                        REFERENCES `trdatav1`.`BCLatency` (`bclID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `bcperfid`
                                                        FOREIGN KEY (`bcprID`)
                                                        REFERENCES `trdatav1`.`BCPerformance` (`bcprID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `bcdacid`
                                                        FOREIGN KEY (`bcdaID`)
                                                        REFERENCES `trdatav1`.`BCDataAccess` (`bcdaID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `bcdapolcid`
                                                        FOREIGN KEY (`bcdapID`)
                                                        REFERENCES `trdatav1`.`BCDataAccessPolicy` (`bcdapID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `bcdataforid`
                                                        FOREIGN KEY (`bcdfID`)
                                                        REFERENCES `trdatav1`.`BCDataFormat` (`bcdfID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `bcarchstyleid`
                                                        FOREIGN KEY (`asID`)
                                                        REFERENCES `trdatav1`.`ArchitectureStyle` (`asID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `bcarstylefeaid`
                                                        FOREIGN KEY (`asfID`)
                                                        REFERENCES `trdatav1`.`ArchitectureStyleFeatures` (`asfID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `bcnfrsinarid`
                                                        FOREIGN KEY (`nfrasID`)
                                                        REFERENCES `trdatav1`.`NFRsInArchitecture` (`nfrasID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `datastorageid`
                                                        FOREIGN KEY (`dsID`)
                                                        REFERENCES `trdatav1`.`DataStorageSystems` (`dsID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `bcplatid`
                                                        FOREIGN KEY (`bpID`)
                                                        REFERENCES `trdatav1`.`BlockchainPlatforms` (`bpID`)
                                                        ON DELETE NO ACTION
                                                        ON UPDATE NO ACTION);");
                cmd = new MySqlCommand(trdata.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;


                myTrans.Commit();
                return true;
            }
            catch(Exception ex)
            {
                myTrans.Rollback();
                errorMsg = string.Format("An Exception happend when creating data tables - {0}", ex.Message);
                Console.WriteLine("An Exception happend when creating data tables", ex.Message);
            }
            return false;
        }
    }
}

