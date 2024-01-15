using System;
using System.Collections.Generic;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class EventBackupReqModel
    {
        public Int64 pkg_no { get; set; }
        public string go_date { get; set; }
        public string event_time { get; set; }
        public List<EventBackupSkuModel> skus { get; set; }
    }

    public partial class EventBackupSkuModel
    {
        public string sku_id { get; set; }
        public int qty { get; set; }
    }
}
