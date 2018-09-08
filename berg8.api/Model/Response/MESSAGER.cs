
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using api.Model.Enum;

namespace api.Model
{
    public class MESSAGER
    {

        public MESSAGE_TYPE CODE { get; set; }
        public string MESSAGE { get; set; }
        public MESSAGER()
        {
            CODE = MESSAGE_TYPE.WARNING;
            MESSAGE = string.Empty;
        }


    }

}
