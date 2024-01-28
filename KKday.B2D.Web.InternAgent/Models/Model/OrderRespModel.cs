using System;
namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class OrderRespModel : OrderDetailModel
    {
        public string result { get; set; }
        public string result_msg { get; set; }
        //
        public string prod_name { get; set; }
        public string prod_img_url { get; set; }
        public string pkg_name { get; set; }
    }
}
