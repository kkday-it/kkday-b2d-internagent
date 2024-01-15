using System;
using System.Collections.Generic;

namespace KKday.B2D.Web.InternAgent.Models.Model
{ 
    /// <summary>
    /// 新版大小分類
    /// </summary>
    public class Tag
    {
        public string id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public List<Sub_Tags> sub_tags { get; set; }
    }
    /// <summary>
    /// 小分類
    /// </summary>
    public class Sub_Tags
    {
        public string id { get; set; }
        public string name { get; set; }
        public string count { get; set; }
    } 
}

