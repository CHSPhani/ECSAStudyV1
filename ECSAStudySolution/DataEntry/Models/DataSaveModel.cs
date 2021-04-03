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
}
