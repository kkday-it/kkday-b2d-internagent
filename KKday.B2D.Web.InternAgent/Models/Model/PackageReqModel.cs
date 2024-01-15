using System;
namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class PackageReqModel
    {
        public Int64 prod_no { get; set; } // 產品編號
        public Int64 pkg_no { get; set; } // 套餐編號
        public string s_date { get; set; } // 出發日（yyyy-mm-dd）
        public string locale { get; set; } // 語系(預設為分銷商建立帳號時所設 定的語系)例:zh-tw, en
        public string state { get; set; }
    }

    public class QueryPackageModel : PackageReqModel
    {
        public string currency { get; set; }
    }

    public class PackageMoreReqModel : PackageReqModel
    {
        public string encrypt { get; set; }
    }
}
