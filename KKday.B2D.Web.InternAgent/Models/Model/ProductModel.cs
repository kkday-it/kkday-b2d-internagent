using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using InternAgent.AppCode;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class ProductModel
    {
        public bool is_tour { get; set; }
        public bool is_cancel_free { get; set; }
        public Int64 prod_no { get; set; }
        public Int64 prod_url_no { get; set; }
        public string prod_name { get; set; }
        public string prod_type { get; set; }
        public List<string> tag { get; set; }
        public double b2c_min_price { get; set; }
        public double b2b_min_price { get; set; }
        public string prod_currency { get; set; }
        public Int16 days { get; set; }
        public Int16 hours { get; set; }
        public Int16 duration { get; set; }
        public string introduction { get; set; }
        public string timezone { get; set; }
        public List<string> guide_lang_list { get; set; }
        public List<string> voice_guide_lang { get; set; }
        public bool confirm_order_time { get; set; }
        public string online_s_date { get; set; }
        public string online_e_date { get; set; }
        public List<string> img_list { get; set; }
        public List<string> video_list { get; set; }
        public ProductCommentInfo prod_comment_info { get; set; }
        public ProductGoDateSetting go_date_setting { get; set; }
        public List<CountryCityMapModel> cities { get; set; } 
        public PmdlModel description_module { get; set; }
        public bool? is_translate_complete { get; set; }
        public bool? ihave_translate { get; set; }
        public bool? is_all_sold_out { get; set; }
    }

    public class ProductCommentInfo
    {
        public string avg_scores { get; set; }
        public string total_scores { get; set; }
        public string click_count { get; set; }
        public string comment_record { get; set; }
    }

    public class ProductGoDateSetting
    {       
        public ProductGoDateSettingDays days { get; set; }
        public string type { get; set; }
    }

    public class ProductGoDateSettingDays
    {
        public int max { get; set; }
        public int min { get; set; }
    }
  
}
