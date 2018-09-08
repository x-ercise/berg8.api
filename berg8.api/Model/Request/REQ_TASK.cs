using System;
using System.Collections.Generic;
using api.Model.Enum;

namespace api.Model.Request
{
    public class REQ_TASK
    {
        public EMPLOYEE OPERATOR { get; set; }
        public WIDGET_TYPE WIDGET { get; set; }
    }
}
