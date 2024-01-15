using System;
namespace KKday.B2D.Web.InternAgent.AppCode
{
    public static class LocaleMapHelper
    {
        public static string Convert(string locale)
        {
            // KKday-Locale 轉換對應到 RFC 4646 
            var _culture = "en-US";
            switch (locale)
            {
                case "zh-tw":
                    _culture = "zh-TW"; break;
                case "ja":
                    _culture = "ja-JP"; break;
                case "zh-cn":
                    _culture = "zh-CN"; break;
                case "th":
                    _culture = "th-TH"; break;
                case "vi":
                    _culture = "vi-VN"; break;
                case "ko":
                    _culture = "ko-KR"; break;
                case "zh-hk":
                    _culture = "zh-HK"; break;
                default: break; // 預設是英文
            }
            return _culture;
        }
        /// <summary>
        /// RFC 4646 轉換對應到 KKday-Locale
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static string RfcToKKday(string locale)
        {
            string _culture = "en";
            switch (locale?.ToLower())
            {
                case "zh-tw": _culture = "zh-tw"; break;
                case "ja-jp": _culture = "ja"; break;
                case "th-th": _culture = "th"; break;
                case "vi-vn": _culture = "vi"; break;
                case "ko-kr": _culture = "ko"; break;
                default: break;
            }
            return _culture;
        }

        public static string CultureToDisplay(string culture)
        {
            var display = "";

            switch (culture)
            {
                case "en-US": display = "English"; break;
                case "zh-TW": display = "繁體中文"; break;
                case "ja-JP": display = "日本語"; break;
                case "zh-CN": display = "简体中文"; break;
                case "th-TH": display = "泰文"; break;
                case "vi-VN": display = "越南文"; break;
                case "ko-KR": display = "韓文"; break;
                default: break; // 預設是繁體中文
            }
            return display;
        }
    }
}

