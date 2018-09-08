using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace api.Model
{
    public class ACTION
    {

        [DefaultValue(value: "")] public string CODE { get; set; }
        [DefaultValue(value: "")] public string TEXT { get; set; }
        [DefaultValue(value: false)] public bool ENABLED { get; set; }
        [DefaultValue(value: false)] public bool VISIBLED { get; set; }

        public ACTION()
        {
            ENABLED = true;
            VISIBLED = true;
        }

        public ACTION(string code, string text)
        {
            CODE = code;
            TEXT = text;
            ENABLED = false;
            VISIBLED = false;
        }
    }


    public static partial class Extension
    {
        public static IList<ACTION> ToActionMockup(this Request.REQ_COMMAND request)
        {
            List<ACTION> result = new List<ACTION>();
            ACTION amend = new ACTION("AMEND", "แก้ไข");
            ACTION approval = new ACTION("APPROVE", "อนุมัติ");
            ACTION reject = new ACTION("REJECT", "ไม่อนุมัติ");
            ACTION sndback = new ACTION("SNDBACK", "ส่งกลับ");
            ACTION callback = new ACTION("CALLBACK", "ส่งกลับ");

            if (request.OPERATOR.CODE == "REQUESTOR")
            {
                amend.ENABLED = true;
                callback.ENABLED = true;

                amend.VISIBLED = true;
                approval.VISIBLED = true;
                reject.VISIBLED = true;
                callback.VISIBLED = true;
            }
            else if (request.OPERATOR.CODE == "APPROVER")
            {
                amend.ENABLED = true;
                approval.ENABLED = true;
                reject.ENABLED = true;
                sndback.ENABLED = true;

                amend.VISIBLED = true;
                approval.VISIBLED = true;
                reject.VISIBLED = true;
                sndback.VISIBLED = true;
            }
            else
            {
                amend.VISIBLED = true;
                approval.VISIBLED = true;
                reject.VISIBLED = true;
            }

            return result;

        }
    }

}