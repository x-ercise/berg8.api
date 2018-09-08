using System;
using System.Collections.Generic;

namespace berg8.api.Model.Response
{
    public class RES_DOCUMENT
    {
        public IList<DOCUMENT> DOCUMENTS { get; set; }
        public IList<MESSAGER> MESSAGES { get; set; }
    }
}
