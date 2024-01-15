using System;
namespace KKday.B2D.Web.InternAgent.Models.Model
{
	public class MemberModel
	{
		public Int64 xid { get; set; }
		public string email { get; set; }
		public string nickname { get; set; }
		public string name_first { get; set; }
		public string name_last { get; set; }
		public string ename_first { get; set; }
		public string ename_last { get; set; }
		public string gender { get; set; }
		public DateTime birth { get; set; }
		public string phone_no { get; set; }
		public string address { get; set; } 
		public DateTime create_time { get; set; }
		public string creator { get; set; }
		public DateTime? update_time { get; set; }
		public string updater { get; set; }
		public string uuid { get; set; }
		public string locale { get; set; }
		public int utc_offset { get; set; }
		public string currency { get; set; }
		public string timezone_id { get; set; }
	}
}
