using System;
namespace KKday.B2D.Web.InternAgent.Models.Model
{
	public class AllotmentRespModel
	{
        public string result { get; set; }
        public string result_msg { get; set; }
        public IList<AllotmentModel> allotment { get; set; }
    }

    public class AllotmentModel
    {
        public int item_remain_qty { get; set; }
        public IList<SkuRemainQty> sku_remain_qty { get; set; }
        public IList<RemainQty> itemCal_qty { get; set; }
        public IList<SkuCalQty> skuCal_qty { get; set; }
    }

    public class SkuRemainQty
    {
        public string sku_id { get; set; }
        public int remain_qty { get; set; }
    }

    public class SkuCalQty
    {
        public string sku_id { get; set; }
        public IList<RemainQty> sku_cal { get; set; }
    }

    public class RemainQty
    { 
        public string date { get; set; }
        public Dictionary<string, object> remain_qty { get; set; }
    }
}

