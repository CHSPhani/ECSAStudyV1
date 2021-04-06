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
                                                    drop table nfrsinarchitecture;
                                                    drop table ResultsObtained");
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
                string aArea = string.Format(@"CREATE TABLE `trdatav1`.`ApplicationArea` (`aaID` VARCHAR(3) NOT NULL, `aaName` VARCHAR(150) NOT NULL, `aaNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`aaID`));");
                MySqlCommand cmd = new MySqlCommand(aArea.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string aAreaData = string.Format(@"INSERT INTO ApplicationArea(aaID,aaName,aaNotes) VALUES ('HC','Healthcare','Health care systems');
                                                   INSERT INTO ApplicationArea(aaID,aaName,aaNotes) VALUES ('CPS','CPS','Cyber Physical Systems');
                                                   INSERT INTO ApplicationArea(aaID,aaName,aaNotes) VALUES ('VM','Vehicle Monitoring','Intellgient Transportation');
                                                   INSERT INTO ApplicationArea(aaID,aaName,aaNotes) VALUES ('SC','Supply Chain','Supply Chain Systems');
                                                   INSERT INTO ApplicationArea(aaID,aaName,aaNotes) VALUES ('STR','Store','Blockchain used to Store Documents, File, Content etc');
                                                   INSERT INTO ApplicationArea(aaID,aaName,aaNotes) VALUES ('LM','Log Management','Log Management');");
                cmd = new MySqlCommand(aAreaData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //2. Creating Blockchain Network Table and inserting rows
                string bcNetwork = string.Format(@"CREATE TABLE `trdatav1`.`BCNetworks` (`bcnID`  VARCHAR(3) NOT NULL, `bcnName` VARCHAR(150) NOT NULL, `bcnNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcnID`));");
                cmd = new MySqlCommand(bcNetwork.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcnData = string.Format(@"INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES ('PRI','Private','Private Blockchains');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES ('CPI','Customized-Private','Customizations done to Private Blockchains solutions like modfying consensus or participation');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES ('PRO','Protected','Protected Blockchains');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES ('CPO','Customized-Protected','Customizations done to Protected Blockchain solutions like modfying consensus or participation');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES ('CON','Consortium','Consortium Blockchains');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES ('CCN','Customized-Consortium','Customizations done to Consortium Blockchains solutions like modfying consensus or participation');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES ('PUB','Public','Public Blockchains');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES ('NEW','New Implementation','Newly Implemented Blockchains from ground up');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES ('FED','Federated Blockchain','Different Blockchain networks are considered as a unit');
                                                 INSERT INTO BCNetworks(bcnID,bcnName,bcnNotes) VALUES ('OTH','Others','Other networks like Gunicorn that are considered as Blockchains');");
                cmd = new MySqlCommand(bcnData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //3. Creating Blockchain Network Participation table and rows.
                string bcNPart = string.Format(@"CREATE TABLE `trdatav1`.`BCNWParticipation` (`bcnpID`  VARCHAR(3) NOT NULL, `bcnpName` VARCHAR(150) NOT NULL, `bcnpNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcnpID`));");
                cmd = new MySqlCommand(bcNPart.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcNPartData = string.Format(@"INSERT INTO BCNWParticipation(bcnpID,bcnpName,bcnpNotes) VALUES ('OPN','Open','Open PArticipation as in Public Blockchains');
                                                     INSERT INTO BCNWParticipation(bcnpID,bcnpName,bcnpNotes) VALUES ('PRM','Permmission Required','Permission required for participating in Blockchain network');
                                                     INSERT INTO BCNWParticipation(bcnpID,bcnpName,bcnpNotes) VALUES ('CRI','Criteria Dependent','Participating in Blockchain network is dependent on certain criteria like being a member of socitey');
                                                     INSERT INTO BCNWParticipation(bcnpID,bcnpName,bcnpNotes) VALUES ('OTH','Others', 'Other ways of Participating in Blockchain network ');");
                cmd = new MySqlCommand(bcNPartData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //4. Creating Blockchain Consensus table and rows.
                string bcConsensus = string.Format(@"CREATE TABLE `trdatav1`.`BCConsensus` (`bccID` VARCHAR(3) NOT NULL, `bccName` VARCHAR(150) NOT NULL, `bccNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bccID`));");
                cmd = new MySqlCommand(bcConsensus.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bccData = string.Format(@"INSERT INTO BCConsensus(bccID,bccName,bccNotes) VALUES ('STD','Standard','Standard Consensus algorithms that comes with Blockchain solutions');
                                                 INSERT INTO BCConsensus(bccID,bccName,bccNotes) VALUES ('CST','Customized Algorithms','Consensus algorithms  provided with Blockchain solutions are customized by changing code base');
                                                 INSERT INTO BCConsensus(bccID,bccName,bccNotes) VALUES ('NEW','New Implementations','New Consensus algorithms');");
                cmd = new MySqlCommand(bccData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //5. Creating Blockchain Scalability table and rows.
                string bcScalability = string.Format(@"CREATE TABLE `trdatav1`.`BCScalability` (`bcsID` VARCHAR(3) NOT NULL, `bcsName` VARCHAR(150) NOT NULL, `bcsNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcsID`));");
                cmd = new MySqlCommand(bcScalability.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcsData = string.Format(@"INSERT INTO BCScalability(bcsID,bcsName,bcsNotes) VALUES ('AC','Achieved via Consensus','Scalability is achieved using Consensus mechanisms');
                                                 INSERT INTO BCScalability(bcsID,bcsName,bcsNotes) VALUES ('AD','Achieved via Database','Scalability is achieved through the means of underlying Database');
                                                 INSERT INTO BCScalability(bcsID,bcsName,bcsNotes) VALUES ('PS','Achieved via  Physical','Scalability is achieved using underlying Physical storage');
                                                 INSERT INTO BCScalability(bcsID,bcsName,bcsNotes) VALUES ('AO','Achieved via Other','Scalability is achieved using other means');
                                                 INSERT INTO BCScalability(bcsID,bcsName,bcsNotes) VALUES ('NC','Not Considered','Scalability is Not considered at all'); ");
                cmd = new MySqlCommand(bcsData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //6. Creating Blockchain Latency table and rows.
                string bcLatency = string.Format(@"CREATE TABLE `trdatav1`.`BCLatency` (`bclID` VARCHAR(3) NOT NULL, `bclName` VARCHAR(150) NOT NULL, `bclNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bclID`));");
                cmd = new MySqlCommand(bcLatency.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bclData = string.Format(@"INSERT INTO BCLatency(bclID,bclName,bclNotes) VALUES ('RL','Read Latency','Read Latency time is the time taken to receive reply from blokchain after read submit');
                                                 INSERT INTO BCLatency(bclID,bclName,bclNotes) VALUES ('TL','Transaction Latency','Transaction Latency is amount of time taken for transaction is usable across blockchain network');
                                                 INSERT INTO BCLatency(bclID,bclName,bclNotes) VALUES ('NL','Network Latency','Network Latency is amount of latency for data to travel across the network, firewalls from one communication endpoint to another.');
                                                 INSERT INTO BCLatency(bclID,bclName,bclNotes) VALUES ('OT','Other','Other uncategorized latencies tha cause delay');");
                cmd = new MySqlCommand(bclData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //7. Creating Blockchain Performance table and rows.
                string bcPerformance = string.Format(@"CREATE TABLE `trdatav1`.`BCPerformance` (`bcprID` VARCHAR(3) NOT NULL, `bcprName` VARCHAR(150) NOT NULL, `bcprNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcprID`));");
                cmd = new MySqlCommand(bcPerformance.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcprData = string.Format(@"INSERT INTO BCPerformance(bcprID,bcprName,bcprNotes) VALUES ('TTP','Transaction Throughput ','Transaction Throughput is rate at which valid transactions are committed by blockchain in a time period');
                                                  INSERT INTO BCPerformance(bcprID,bcprName,bcprNotes) VALUES ('CGD','Colocted Geographic distribution ','Geographic distribution of co-locating nodes');
                                                  INSERT INTO BCPerformance(bcprID,bcprName,bcprNotes) VALUES ('DGD','Dispersed Geographic distribution ','Geographic distribution of dispersed nodes');
                                                  INSERT INTO BCPerformance(bcprID,bcprName,bcprNotes) VALUES ('HHW','High End Hardware','High end hardware high processor speed with number of cores and memory');
                                                  INSERT INTO BCPerformance(bcprID,bcprName,bcprNotes) VALUES ('LHW','Low End Hardware','Low end hardware nomial processor speed with no cores and less memory'); 
                                                  INSERT INTO BCPerformance(bcprID,bcprName,bcprNotes) VALUES ('OTH','Other Factors','Other performance indicators for blockchain');");
                cmd = new MySqlCommand(bcprData.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //8. Creating Data Access from Blockchain.
                string bcDAccess = string.Format(@"CREATE TABLE `trdatav1`.`BCDataAccess` (`bcdaID` VARCHAR(3) NOT NULL, `bcdaName` VARCHAR(150) NOT NULL, `bcdaNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcdaID`));");
                cmd = new MySqlCommand(bcDAccess.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcDataAccess = string.Format(@"INSERT INTO BCDataAccess(bcdaID,bcdaName,bcdaNotes) VALUES ('BD','Blockchain Default','Blockchain default APIS to access data from blockchain');
                                                      INSERT INTO BCDataAccess(bcdaID,bcdaName,bcdaNotes) VALUES ('BC','Blockchain + Customized','Blockchain default APIS  are customized for accessing data from blockchain');
                                                      INSERT INTO BCDataAccess(bcdaID,bcdaName,bcdaNotes) VALUES ('BA','Blockchain + DB','Blockchain default APIS  are combined with other DB access engines for accessing data from blockchain');
                                                      INSERT INTO BCDataAccess(bcdaID,bcdaName,bcdaNotes) VALUES ('NW','New APIS','New APIS or Engines for accessing data from blockchain');");
                cmd = new MySqlCommand(bcDataAccess.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;


                //9. Creating Data Access from Blockchain.
                string bcDAPolicy = string.Format(@"CREATE TABLE `trdatav1`.`BCDataAccessPolicy` (`bcdapID` VARCHAR(3) NOT NULL, `bcdapName` VARCHAR(150) NOT NULL, `bcdapNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcdapID`));");
                cmd = new MySqlCommand(bcDAPolicy.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcDataAccessPolicy = string.Format(@"INSERT INTO BCDataAccessPolicy(bcdapID,bcdapName,bcdapNotes) VALUES ('SC','Smart Contract','User defined data access policies in Smart Contract');
                                                            INSERT INTO BCDataAccessPolicy(bcdapID,bcdapName,bcdapNotes) VALUES ('KY','Key Infrastructure','User defined data access policies using public Key infrastructure and store the key info in blockchain');
                                                            INSERT INTO BCDataAccessPolicy(bcdapID,bcdapName,bcdapNotes) VALUES ('PB','Public','Data Stored is for public');
                                                            INSERT INTO BCDataAccessPolicy(bcdapID,bcdapName,bcdapNotes) VALUES ('OT','Other','Data access policy is defined in other ways');");
                cmd = new MySqlCommand(bcDataAccessPolicy.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //10. Blockchain Transaction data formats .
                string bcDAFormat = string.Format(@"CREATE TABLE `trdatav1`.`BCDataFormat` (`bcdfID` VARCHAR(3) NOT NULL, `bcdfName` VARCHAR(150) NOT NULL, `bcdfNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bcdfID`));");
                cmd = new MySqlCommand(bcDAFormat.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcDataFormat = string.Format(@"INSERT INTO BCDataFormat(bcdfID,bcdfName,bcdfNotes) VALUES ('SM','Standard Model','Data is formatted using standard data models like Relational, Key-Value etc.');
                                                      INSERT INTO BCDataFormat(bcdfID,bcdfName,bcdfNotes) VALUES ('SC','Smart Contract','Data is formatted using Smart contract features like structures');
                                                      INSERT INTO BCDataFormat(bcdfID,bcdfName,bcdfNotes) VALUES ('JSN', 'JSON', 'Data is formatted using Java Script Object Notation');
                                                      INSERT INTO BCDataFormat(bcdfID,bcdfName,bcdfNotes) VALUES ('XML', 'XML', 'Data is formatted using XML');
                                                      INSERT INTO BCDataFormat(bcdfID,bcdfName,bcdfNotes) VALUES ('TPL', 'Tuple', 'Data is formatted using Tuple structure like triple, quadruple, pentuple etc..');
                                                      INSERT INTO BCDataFormat(bcdfID,bcdfName,bcdfNotes) VALUES ('OTH', 'Other', 'Data is formatted using other formats');
                                                      INSERT INTO BCDataFormat(bcdfID,bcdfName,bcdfNotes) VALUES ('NF', 'No Format', 'No Format Data is not formatted or not mentioned');");
                cmd = new MySqlCommand(bcDataFormat.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //11. Architecture Styles.
                string bcAStyle = string.Format(@"CREATE TABLE `trdatav1`.`ArchitectureStyle` (`asID` VARCHAR(3) NOT NULL, `asName` VARCHAR(150) NOT NULL, `asNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`asID`));");
                cmd = new MySqlCommand(bcAStyle.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcArchStyle = string.Format(@"INSERT INTO ArchitectureStyle(asID,asName,asNotes) VALUES ('SOA','SOA','Service Oriented Architecture');
                                                     INSERT INTO ArchitectureStyle(asID,asName,asNotes) VALUES ('MS','Micro Services','Micro Services based Architecture');
                                                     INSERT INTO ArchitectureStyle(asID,asName,asNotes) VALUES ('OF','Open Fog','OpenFog Architecture for IoT');
                                                     INSERT INTO ArchitectureStyle(asID,asName,asNotes) VALUES ('EDG','Edge Computing','Edge Computing Architecture for IoT');
                                                     INSERT INTO ArchitectureStyle(asID,asName,asNotes) VALUES ('LAY','Layered Architecture','Layered Architecture');
                                                     INSERT INTO ArchitectureStyle(asID,asName,asNotes) VALUES ('CO','Cloud Oriented','Cloud Oriented Architecture');
                                                     INSERT INTO ArchitectureStyle(asID,asName,asNotes) VALUES ('OS','Others ','Other Styles like Object Oriented, Component Oriented,Edge, Layered architectures.');");
                cmd = new MySqlCommand(bcArchStyle.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                
                //12. NFRS in Architecture Styles.
                string bcASNfrs = string.Format(@"CREATE TABLE `trdatav1`.`NFRsInArchitecture` (`nfrasID` VARCHAR(3) NOT NULL, `nfrasName` VARCHAR(150) NOT NULL, `nfrasNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`nfrasID`));");
                cmd = new MySqlCommand(bcASNfrs.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcNFRArchStyle = string.Format(@"INSERT INTO NFRsInArchitecture(nfrasID,nfrasName,nfrasNotes) VALUES ('SCL','Scalability','Scalability of data access logic');
                                                        INSERT INTO NFRsInArchitecture(nfrasID,nfrasName,nfrasNotes) VALUES ('PRF','Performace','Performace of system');
                                                        INSERT INTO NFRsInArchitecture(nfrasID,nfrasName,nfrasNotes) VALUES ('AVI','Availability','Availability of services or functionality');
                                                        INSERT INTO NFRsInArchitecture(nfrasID,nfrasName,nfrasNotes) VALUES ('SEC','Security','Security');
                                                        INSERT INTO NFRsInArchitecture(nfrasID,nfrasName,nfrasNotes) VALUES ('CNG','Configurability','Configuration of services');
                                                        INSERT INTO NFRsInArchitecture(nfrasID,nfrasName,nfrasNotes) VALUES ('RES','Resource utilization','usage of resources');
                                                     ");
                cmd = new MySqlCommand(bcNFRArchStyle.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //13. NFRS in Architecture Styles.
                string bcDtStor = string.Format(@"CREATE TABLE `trdatav1`.`DataStorageSystems` (`dsID` VARCHAR(3) NOT NULL, `dsName` VARCHAR(150) NOT NULL, `dsNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`dsID`));");
                cmd = new MySqlCommand(bcDtStor.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcDStoSystems = string.Format(@"INSERT INTO DataStorageSystems(dsID,dsName,dsNotes) VALUES ('BD','Blockchain+DB','Blockchain Puls other databases');
                                                       INSERT INTO DataStorageSystems(dsID,dsName,dsNotes) VALUES ('BS','Blockchain + Storage','Blockchain Puls other storage sysems like File or content storage systems');
                                                       INSERT INTO DataStorageSystems(dsID,dsName,dsNotes) VALUES ('BC','Blockchain','Blockchain is used to store data');");
                cmd = new MySqlCommand(bcDStoSystems.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

              
                //14.Blockchains.
                string bcBcs = string.Format(@"CREATE TABLE `trdatav1`.`BlockchainPlatforms` (`bpID` VARCHAR(3) NOT NULL, `bpName` VARCHAR(150) NOT NULL, `bpNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`bpID`));");
                cmd = new MySqlCommand(bcBcs.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bchains = string.Format(@"INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('BTC','Bitcoin','https://bitcoin.org/en/how-it-works');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('CHL','Chainlink','https://chain.link/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('CCD','Concord','http://projectconcord.io/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('CRD','Corda / R3','https://www.r3.com/corda-platform/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('ECN','Emercoin','https://emercoin.com/en');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('EWF','Energy Web Foundation EWF','https://www.energyweb.org/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('ETH','Ethereum','https://ethereum.org/en/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('FCN','Filecoin','https://filecoin.io/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('GRD','Grd','https://www.grd.com/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('HGH','HashGraph','https://hedera.com/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('IBM','IBM - Hyperledger (Fabric)','https://www.hyperledger.org/use/fabric');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('IOT','IoTeX','https://iotex.io/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('LO3','Lo3','https://lo3energy.com/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('MS','Microsoft','https://azure.microsoft.com/en-gb/services/blockchain-service/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('MC','MultiChain','https://www.multichain.com/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('PL','Powerledger','https://www.powerledger.io/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('QTM','Qtum','https://qtum.org/en');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('QRM','Quorum','https://consensys.net/quorum/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('SIA','Sia','https://sia.tech/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('STJ','Storj','https://www.storj.io/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('TOR','Tor','https://en.bitcoin.it/wiki/Tor');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('WCN','WaltonChain','http://www.waltonchain.org/en/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('IOA','IOTA','https://www.iota.org/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('BDB','BigChainDB','https://www.bigchaindb.com/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('TMT','Tendermint','https://tendermint.com/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('GNT','GRIDNET','https://gridnet.org/');
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('CUS','Custom',' ');	
                                                 INSERT INTO BlockchainPlatforms(bpID,bpName,bpNotes) VALUES ('OTH','Others',' ');");
                cmd = new MySqlCommand(bchains.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //15. Possible Results.
                string bcPRes = string.Format(@"CREATE TABLE `trdatav1`.`ResultsObtained` (`rsID` VARCHAR(3) NOT NULL, `rsName` VARCHAR(150) NOT NULL, `rsNotes` VARCHAR(1500) NOT NULL, PRIMARY KEY (`rsID`));");
                cmd = new MySqlCommand(bcPRes.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                string bcPsRes = string.Format(@"INSERT INTO ResultsObtained(rsID,rsName,rsNotes) VALUES('TUR','Trust - System Users','To Achieve trust among the users of system or application');
                                                 INSERT INTO ResultsObtained(rsID,rsName,rsNotes) VALUES('TDP', 'Trust - Diversified Parties', 'To Achieve trust among the diversified parties');
                                                 INSERT INTO ResultsObtained(rsID,rsName,rsNotes) VALUES('DS', 'Distributed System', 'To Achieve distributed feature to system');
                                                 INSERT INTO ResultsObtained(rsID,rsName,rsNotes) VALUES('SHR', 'Data Store and Sharing', 'To achieve secure distributed data store and sharing');
                                                 INSERT INTO ResultsObtained(rsID,rsName,rsNotes) VALUES('CNF', 'Coin Feature', 'For Implementing Coin System');
                                                 INSERT INTO ResultsObtained(rsID,rsName,rsNotes) VALUES('OTH', 'Others', 'Other Uses');");
                cmd = new MySqlCommand(bcPsRes.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //16. Common Parameters.
                string cparams = string.Format(@"CREATE TABLE `trdatav1`.`CommonParameters` (`pID` INT NOT NULL, `pName` VARCHAR(500) NOT NULL, `pCitation` VARCHAR(150) NOT NULL, `pRef` VARCHAR(5000) NOT NULL, PRIMARY KEY (`pID`));");
                cmd = new MySqlCommand(cparams.ToString(), conn);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                System.Threading.Thread.Sleep(100 * 1);//sleep for 2 ms just to ensure everything is OK..
                cmd = null;

                //17. Training data.
                string trdata = string.Format(@"CREATE TABLE `trdatav1`.`trainingdata`(`pID` INT NOT NULL,  `aaID` VARCHAR(3) NOT NULL, `bcnID` VARCHAR(3) NOT NULL, `bcnpID` VARCHAR(3) NOT NULL, `bccID` VARCHAR(3) NOT NULL, `bcsID` VARCHAR(3) NOT NULL, 
                                                                                        `bclID` VARCHAR(3) NOT NULL, `bcprID` VARCHAR(3) NOT NULL, `bcdaID` VARCHAR(3) NOT NULL, `bcdapID` VARCHAR(3) NOT NULL, `bcdfID` VARCHAR(3) NOT NULL, `asID` VARCHAR(3) NOT NULL, 
                                                                                        `nfrasID` VARCHAR(3) NOT NULL, `dsID` VARCHAR(3) NOT NULL, `bpID` VARCHAR(3) NOT NULL,`rsID` VARCHAR(3) NOT NULL, PRIMARY KEY (`pID`),
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
                                                        ON UPDATE NO ACTION,
                                                    CONSTRAINT `resuid`
                                                        FOREIGN KEY (`rsID`)
                                                        REFERENCES `trdatav1`.`ResultsObtained` (`rsID`)
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

#region OLD Code
/*
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


*/
#endregion