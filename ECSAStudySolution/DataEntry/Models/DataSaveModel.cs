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
