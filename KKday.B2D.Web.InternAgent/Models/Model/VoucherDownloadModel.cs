using System;
namespace KKday.B2D.Web.InternAgent.Models.Model
{
	public class VoucherDownloadReqModel
	{
		public string? order_no { get; set; }
		public string? order_file_id { get; set; }
    }

    public class VoucherDownloadRespModel
    {
        public string? result { get; set; }
        public string? result_msg { get; set; }
        public string? pincode { get; set; }
        public string? token_url { get; set; }
        public VoucherDownloadFileModel? file { get; set; }
    }

    public class VoucherDownloadFileModel
    {
        public string? order_file_id { get; set; }
        public string? file_name { get; set; }
        public string? file_intro { get; set; }
        public string? content_type { get; set; }
        public string? encode_str { get; set; }
        public VoucherFileLastModified? last_modified { get; set; }
    }
}

