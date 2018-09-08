using System;
using System.ComponentModel;

namespace api.Model
{
    public class EMPLOYEE
    {
        [DefaultValue(value: "")] public string CODE { get; set; }
        [DefaultValue(value: "")] public string NAME { get; set; }
        [DefaultValue(value: "")] public string EMAIL { get; set; }
        [DefaultValue(value: "")] public string CONTACT_NO { get; internal set; }

        private EMPLOYEE()
        {

        }
        public static EMPLOYEE CreateInstance()
        {
            return new EMPLOYEE();
        }
    }

    public static partial class Extension
    {
        public static EMPLOYEE ToEmployeeMockup(this Request.REQ_DOCUMENT request, bool isGenerateRequestor)
        {
            EMPLOYEE result = EMPLOYEE.CreateInstance();

            result.CODE = Guid.NewGuid().ToString();
            if (isGenerateRequestor) 
                result.NAME = string.IsNullOrEmpty(request.FILTER.REQUESTOR) ? "Ton" : request.FILTER.REQUESTOR;
            else
                result.NAME = string.IsNullOrEmpty(request.FILTER.PREVIOUS) ? "Ton" : request.FILTER.PREVIOUS;
                
            result.CONTACT_NO = "081-919-1998";

            return result;

        }
    }
}
