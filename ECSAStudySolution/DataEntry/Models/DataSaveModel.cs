using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoB.TD.Models
{
    public class CommonDataSaveModel
    {
        public Int32 PId { get; set; }

        public string PName { get; set; }

        public string PCitation { get; set; }

        public string PRef { get; set; }

        public CommonDataSaveModel()
        {
            PId = 0;
            PName = PCitation = PRef = string.Empty;
        }
    }

    public class TrainingDataModel
    {
        public Int32 PId { get; set; }
        public string AaID { get; set; }
        public string BcnID { get; set; }
        public string BcnpID { get; set; }
        public string BccID { get; set; }
        public string BcsID { get; set; }
        public string BclID { get; set; }
        public string BcprID { get; set; }
        public string BcdaID { get; set; }
        public string BcdapID { get; set; }
        public string bcdfID { get; set; }
        public string AsID { get; set; }
        public string NfrasID { get; set; }
        public string DsID { get; set; }
        public string BpID { get; set; }
        public string RsID { get; set; }

        public TrainingDataModel()
        {
            AaID = BcnID = BcnpID = BccID = BcsID = BclID = BcprID = BcdaID = BcdapID = bcdfID = AsID =  NfrasID = DsID = BpID = RsID = string.Empty;
        }
    }

    public class TrainingDataModelForExcel
    {
        public string PId { get; set; }
        public string AaID { get; set; }
        public string BcnID { get; set; }
        public string BcnpID { get; set; }
        public string BccID { get; set; }
        public string BcsID { get; set; }
        public string BclID { get; set; }
        public string BcprID { get; set; }
        public string BcdaID { get; set; }
        public string BcdapID { get; set; }
        public string bcdfID { get; set; }
        public string AsID { get; set; }
        public string NfrasID { get; set; }
        public string DsID { get; set; }
        public string BpID { get; set; }
        public string RsID { get; set; }

        public TrainingDataModelForExcel()
        {
            AaID = BcnID = BcnpID = BccID = BcsID = BclID = BcprID = BcdaID = BcdapID = bcdfID = AsID = NfrasID = DsID = BpID = RsID = string.Empty;
        }

        public override string ToString()
        {
            return PId + "^" + AaID + "^" + BcnID + "^" + BcnpID + "^" + BccID + "^" + BcsID + "^" + BclID + "^" + BcprID + "^" + BcdaID + "^" + 
                                BcdapID + "^" + bcdfID + "^" + AsID + "^" + NfrasID + "^" + DsID + "^" + BpID + "^" + RsID;
        }
    }

    public class IdToNumericValues
    {
        public static int GetRsId(string rsID)
        {
            switch (rsID)
            {
                case "CNF":
                    {
                        return 1;
                    }
                case "DS":
                    {
                        return 2;
                    }
                case "OTH":
                    {
                        return 3;
                    }
                case "SHR":
                    {
                        return 4;
                    }
                case "TDP":
                    {
                        return 5;
                    }
                case "TUR":
                    {
                        return 6;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int GetDsId(string dsId)
        {
            switch (dsId)
            {
                case "BC":
                    {
                        return 1;
                    }
                case "BD":
                    {
                        return 2;
                    }
                case "BS":
                    {
                        return 3;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int GetNfrasId(string nfrasId)
        {
            switch (nfrasId)
            {
                case "AVI":
                    {
                        return 1;
                    }
                case "CNF":
                    {
                        return 2;
                    }
                case "PRF":
                    {
                        return 3;
                    }
                case "RES":
                    {
                        return 4;
                    }
                case "SCL":
                    {
                        return 5;
                    }
                case "SEC":
                    {
                        return 6;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int GetAsId(string asID)
        {
            switch (asID)
            {
                case "CO":
                    {
                        return 1;
                    }
                case "EDG":
                    {
                        return 2;
                    }
                case "LAY":
                    {
                        return 3;
                    }
                case "MS":
                    {
                        return 4;
                    }
                case "OF":
                    {
                        return 5;
                    }
                case "OS":
                    {
                        return 6;
                    }
                case "SOA":
                    {
                        return 7;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int GetBcdfId(string bcdfId)
        {
            switch (bcdfId)
            {
                case "JSN":
                    {
                        return 1;
                    }
                case "NF":
                    {
                        return 2;
                    }
                case "OTH":
                    {
                        return 3;
                    }
                case "SC":
                    {
                        return 4;
                    }
                case "SM":
                    {
                        return 5;
                    }
                case "TPL":
                    {
                        return 6;
                    }
                case "XML":
                    {
                        return 7;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int GetBcdapId(string bcdapId)
        {
            switch (bcdapId)
            {
                case "KY":
                    {
                        return 1;
                    }
                case "OT":
                    {
                        return 2;
                    }
                case "PB":
                    {
                        return 3;
                    }
                case "SC":
                    {
                        return 4;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int GetBcdaId(string bcdaId)
        {
            switch (bcdaId)
            {
                case "BA":
                    {
                        return 1;
                    }
                case "BC":
                    {
                        return 2;
                    }
                case "BD":
                    {
                        return 3;
                    }
                case "NW":
                    {
                        return 4;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int GetBcprId(string bcprId)
        {
            switch (bcprId)
            {
                case "CGD":
                    {
                        return 1;
                    }
                case "DGD":
                    {
                        return 2;
                    }
                case "HHW":
                    {
                        return 3;
                    }
                case "LLW":
                    {
                        return 4;
                    }
                case "OTH":
                    {
                        return 5;
                    }
                case "TTP":
                    {
                        return 6;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int GetBclId(string bclCode)
        {
            switch (bclCode)
            {
                case "NL":
                    {
                        return 1;
                    }
                case "OT":
                    {
                        return 2;
                    }
                case "RL":
                    {
                        return 3;
                    }
                case "TL":
                    {
                        return 4;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int GetBcsId(string bcsCode)
        {
            switch (bcsCode)
            {
                case "AC":
                    {
                        return 1;
                    }
                case "AD":
                    {
                        return 2;
                    }
                case "AO":
                    {
                        return 3;
                    }
                case "NC":
                    {
                        return 4;
                    }
                case "PS":
                    {
                        return 5;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int GetBccId(string bccCode)
        {
            switch (bccCode)
            {
                case "CST":
                    {
                        return 1;
                    }
                case "NEW":
                    {
                        return 2;
                    }
                case "STD":
                    {
                        return 3;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int GetBcnpId(string bcnpCode)
        {
            switch (bcnpCode)
            {
                case "CRI":
                    {
                        return 1;
                    }
                case "OPN":
                    {
                        return 2;
                    }
                case "OTH":
                    {
                        return 3;
                    }
                case "PRM":
                    {
                        return 4;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int GetBcnID(string bcnCode)
        {
            switch (bcnCode)
            {
                case "CCN":
                    {
                        return 1;
                    }
                case "CON":
                    {
                        return 2;
                    }
                case "CPI":
                    {
                        return 3;
                    }
                case "CPO":
                    {
                        return 4;
                    }
                case "FED":
                    {
                        return 5;
                    }
                case "NEW":
                    {
                        return 6;
                    }
                case "OTH":
                    {
                        return 7;
                    }
                case "PRI":
                    {
                        return 8;
                    }
                case "PRO":
                    {
                        return 9;
                    }
                case "PUB":
                    {
                        return 10;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int GetAAID(string aaCode)
        {
            switch (aaCode)
            {
                case "CPS":
                    {
                        return 1;
                    }
                case "HC":
                    {
                        return 2;
                    }
                case "LM":
                    {
                        return 3;
                    }
                case "SC":
                    {
                        return 4;
                    }
                case "STR":
                    {
                        return 5;
                    }
                case "VM":
                    {
                        return 6;
                    }
                default:
                    {
                        return - 1;
                    }
            }
        }
        public static int GetNumericValuesForBPId(string bpCode)
        { 
            switch (bpCode)
            {
                case "BTC":
                    {
                        return 1;

                    }
                case "CHL":
                    {
                        return 2;

                    }

                case "CCD":
                    {
                        return 3;

                    }
                case "CRD":
                    {
                        return 4;

                    }
                case "ECN":
                    {
                        return 5;

                    }
                case "EWF":
                    {
                        return 6;

                    }
                case "ETH":
                    {
                        return 7;

                    }
                case "FCN":
                    {
                        return 8;

                    }
                case "GRD":
                    {
                        return 9;

                    }
                case "HGH":
                    {
                        return 10;

                    }
                case "IBM":
                    {
                        return 11;

                    }
                case "IOT":
                    {
                        return 12;

                    }
                case "LO3":
                    {
                        return 13;

                    }
                case "MS":
                    {
                        return 14;

                    }
                case "MC":
                    {
                        return 15;

                    }
                case "PL":
                    {
                        return 16;

                    }
                case "QTM":
                    {
                        return 17;

                    }
                case "QRM":
                    {
                        return 18;

                    }
                case "SIA":
                    {
                        return 19;

                    }
                case "STJ":
                    {
                        return 20;

                    }

                case "TOR":
                    {
                        return 21;

                    }
                case "WCN":
                    {
                        return 22;

                    }
                case "IOA":
                    {
                        return 23;

                    }
                case "BDB":
                    {
                        return 24;

                    }
                case "TMT":
                    {
                        return 25;

                    }
                case "GNT":
                    {
                        return 26;

                    }
                case "TRN":
                    {
                        return 27;

                    }
                case "CUS":
                    {
                        return 28;

                    }
                case "OTH":
                    {
                        return 29;

                    }
                default:
                    {
                        return 29;
                    }
            }
        }
    }
}
