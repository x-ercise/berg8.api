using System;
using System.Collections.Generic;

namespace api.Model.Response
{
    public class RES_COMMAND
    {
        public IList<ACTION> ACTIONS { get; set; }
        public IList<MESSAGER> MESSAGES { get; set; }
    }
}
