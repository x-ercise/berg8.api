using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model.Enum;

namespace api.Model
{
    public class DOCUMENT
    {
        public string CODE { get; set; }
        public DOCUMENT_TYPE DOC_TYPE { get; set; }
        public TRANS_TYPE TRANS_TYPE { get; set; }
        public string TRANS_DATE { get; set; }
        public string PLAN_BEGIN { get; set; }
        public string PLAN_END { get; set; }
        public string SUBJECT { get; set; }
        public EMPLOYEE REQUESTOR { get; set; }
        public string STATUS { get; set; }

        public static DOCUMENT CreateInstance()
        {
            DOCUMENT result = new DOCUMENT();
            result.REQUESTOR = EMPLOYEE.CreateInstance();
            return result;
        }
    }


    public static partial class Extension
    {
        public static DOCUMENT ToDocumentMockup(this Request.REQ_DOCUMENT request, string code, DOCUMENT_TYPE docType, TRANS_TYPE transType)
        {
            PERIOD period = new PERIOD();
            period.BEGIN = string.IsNullOrEmpty(request.FILTER.BEGIN) ? $"{DateTime.Today:yyyy-MM-dd}" : request.FILTER.BEGIN;
            period.END = string.IsNullOrEmpty(request.FILTER.END) ? $"{new DateTime(9999, 12, 31):yyyy-MM-dd}" : request.FILTER.END;

            DOCUMENT oDocument = DOCUMENT.CreateInstance();
            oDocument.CODE = $"Document {code}";
            oDocument.DOC_TYPE = docType;
            oDocument.TRANS_TYPE = transType;
            oDocument.PLAN_BEGIN = period.BEGIN;
            oDocument.PLAN_END = period.END;
            oDocument.REQUESTOR = request.ToEmployeeMockup(true);
            oDocument.STATUS = "Waiting";
            oDocument.TRANS_DATE = oDocument.PLAN_BEGIN;
            return new DOCUMENT();

        }
    }
}
