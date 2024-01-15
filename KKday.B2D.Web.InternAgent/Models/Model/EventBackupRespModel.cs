using System;
using System.Collections.Generic;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class EventBackupRespModel
    {
        public string result { get; set; }
        public string result_msg { get; set; }
        public Dictionary<string, List<string>> backupevent  { get; set; }
    }
}
