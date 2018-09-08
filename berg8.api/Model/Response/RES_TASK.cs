using System;
using System.Collections.Generic;

namespace berg8.api.Model.Response
{
    public class RES_TASK
    {
        public IList<TASK> TASKS { get; set; }
        public IList<MESSAGER> MESSAGES { get; set; }

        public RES_TASK()
        {
            TASKS = new List<TASK>();
            MESSAGES = new List<MESSAGER>();
        }
    }
}
