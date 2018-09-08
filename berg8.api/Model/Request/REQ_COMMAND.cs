using System;
namespace berg8.api.Model.Request
{
    public class REQ_COMMAND
    {
        public EMPLOYEE OPERATOR { get; set; }
        public REQ_COMMAND()
        {
            OPERATOR = EMPLOYEE.CreateInstance();
        }
    }
}
