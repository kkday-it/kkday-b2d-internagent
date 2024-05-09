using System;
namespace KKday.B2D.Web.InternAgent.Models.Model
{
    /// <summary>
    /// 前台頁面主要把contact區分好處理
    /// </summary>
    public class B2DBookingEcModel : B2DBookingModel
    {
        public CustomBooking contact { get; set; }
        public CustomBooking send { get; set; }
    }
}

