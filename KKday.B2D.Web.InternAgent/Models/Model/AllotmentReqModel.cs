using System;
namespace KKday.B2D.Web.InternAgent.Models.Model
{
	public class AllotmentReqModel
    {
	    public Int64 prod_no { get; set; }
        public Int64 pkg_no { get; set; }
        public string locale { get; set; }
        public string state { get; set; }
        public string s_date { get; set; } // format: "yyyy-mm-dd"
    }
}

