using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace berg8.api.Model
{
    using berg8.api.Model.Enum;

    public class TASK
    {
        public EMPLOYEE REQUESTOR { get; set; }
        [JsonConverter(typeof(StringEnumConverter))] public WIDGET_TYPE WIDGET { get; set; }
        public string STATUS { get; set; }
        public int COUNT { get; set; }
        public static TASK CreateInstance()
        {
            return new TASK();
        }

        public static TASK CreateInstanceMockup(EMPLOYEE empRole, WIDGET_TYPE widget, string status, int count)
        {
            TASK t = new TASK();
            t.REQUESTOR = empRole;
            t.WIDGET = widget;
            t.STATUS = status;
            t.COUNT = count;
            return t;
        }
    }

    public static partial class Extension
    {

        public static IList<TASK> ToTaskMockup(this Request.REQ_TASK request)
        {
            IList<TASK> result = new List<TASK>();

            if (request.WIDGET == WIDGET_TYPE.TASK)
            {
                if (request.OPERATOR.CODE == "REQUESTOR")
                {
                    TASK t0 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Draft", 1);
                    TASK t1 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Waiting Approval 1", 1);
                    TASK t2 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Waiting Approval 2", 2);
                    result.Add(t1);
                    result.Add(t2);
                }
                else if (request.OPERATOR.CODE == "APPROVER")
                {
                    TASK t1 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Waiting Approval 1", 1);
                    TASK t2 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Waiting Approval 1", 2);
                    TASK t3 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Waiting Approval 1", 3);
                    TASK t4 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Waiting Approval 1", 4);
                    result.Add(t1);
                    result.Add(t2);
                    result.Add(t3);
                    result.Add(t4);
                }
            }
            else if (request.WIDGET == WIDGET_TYPE.DOCUMENT)
            {
                if (request.OPERATOR.CODE == "REQUESTOR")
                {
                    TASK t1 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Draft 1", 1);
                    TASK t2 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Waiting Approval 1", 1);
                    TASK t3 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Waiting Approval 2", 1);
                    TASK t4 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Waiting Accountant", 3);
                    TASK t5 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Request Completed", 4);
                    TASK t6 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Claim Completed", 4);
                    TASK t7 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Rejected", 4);
                    result.Add(t1);
                    result.Add(t2);
                    result.Add(t3);
                    result.Add(t4);
                    result.Add(t5);
                    result.Add(t6);
                    result.Add(t7);
                }
                else if (request.OPERATOR.CODE == "APPROVER")
                {
                    TASK t1 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Draft 1", 1);
                    TASK t2 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Waiting Approval 1", 0);
                    TASK t3 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Waiting Approval 2", 0);
                    TASK t4 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Waiting Accountant", 3);
                    TASK t5 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Request Completed", 8);
                    TASK t6 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Claim Completed", 8);
                    TASK t7 = TASK.CreateInstanceMockup(request.OPERATOR, request.WIDGET, "Rejected", 8);
                    result.Add(t1);
                    result.Add(t2);
                    result.Add(t3);
                    result.Add(t4);
                    result.Add(t5);
                    result.Add(t6);
                    result.Add(t7);
                }
            }



            return result;
        }
    }

}
