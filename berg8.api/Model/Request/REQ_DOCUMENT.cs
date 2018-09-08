using System;
using berg8.api.Model.Enum;

namespace berg8.api.Model.Request
{
    public class REQ_DOCUMENT
    {
        public EMPLOYEE OPERATOR { get; set; }
        public FILTER_DOCUMENT FILTER { get; set; }
        public REQ_DOCUMENT()
        {
            OPERATOR = EMPLOYEE.CreateInstance();
            FILTER = new FILTER_DOCUMENT();
        }
    }

    public class FILTER_DOCUMENT : PERIOD
    {
        public TRANS_TYPE[] REQUEST_TYPES { get; set; }
        public TRANS_TYPE[] CLAIM_TYPES { get; set; }
        public string DESCRIPTION { get; set; }
        public string REQUESTOR { get; set; }
        public string PREVIOUS { get; set; }

    }

}


