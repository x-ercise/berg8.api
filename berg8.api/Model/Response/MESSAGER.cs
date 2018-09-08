using berg8.api.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace berg8.api.Model
{
    public class MESSAGER
    {
        [JsonConverter(typeof(StringEnumConverter))] public MESSAGE_TYPE CODE { get; set; }
        public string MESSAGE { get; set; }
        public MESSAGER()
        {
            CODE = MESSAGE_TYPE.WARNING;
            MESSAGE = string.Empty;
        }


    }

}
