using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace berg8.api.Model.Request
{
    using berg8.api.Model.Enum;

    public class REQ_TASK
    {
        public EMPLOYEE OPERATOR { get; set; }
        [JsonConverter(typeof(StringEnumConverter))] public WIDGET_TYPE WIDGET { get; set; }
    }
}
