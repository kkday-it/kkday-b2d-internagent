using System;
namespace KKday.B2D.Web.InternAgent.Models.Model
{
	public class CancelReqModel
	{
		public string order_no { get; set; }
		public string cancel_type { get; set; }
		public string cancel_desc { get; set; }
	}

	public class CancelRespModel
	{
		public string result { get; set; }
		public string result_msg { get; set; }
	}
}

