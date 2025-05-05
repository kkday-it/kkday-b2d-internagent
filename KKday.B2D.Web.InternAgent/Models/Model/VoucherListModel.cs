using System;
namespace KKday.B2D.Web.InternAgent.Models.Model
{
	public class VoucherListReqModel
	{
		 public string? order_no { get; set; } // When QueryOrderDtl with kkday_voucher_mode='SWIPE',this will be empty
    }

    public class VoucherListRespModel
    {
        public string? result { get; set; }
        public string? result_msg { get; set; }
        public List<VoucherListRespFileModel>? file { get; set; }
    }

    public class VoucherListRespFileModel
    {
        public string? order_file_id { get; set; }
        public string? file_name { get; set; }
        public string? file_intro { get; set; }
        public string? file_source { get; set; }
        public string? kk_ticket_oid { get; set; }
        public string? uploader { get; set; }
        public VoucherFileLastModified? last_modified { get; set; }
    }
}

