using System;
namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class ProductReqModel
    {
        public string prod_no { get; set; }
        public string state { get; set; } // 代碼:tw(台灣), cn(中國), hK(香港), jp(日本), kr(韓國), sg(新加坡),my(馬來西亞), th(泰國), vn(越南), ph(菲律賓), id(印尼),kk(其他地區）
        public string locale { get; set; }
    }
}
