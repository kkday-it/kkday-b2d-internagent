using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public partial class PmdlModel
    {
        [JsonPropertyName("PMDL_EXCHANGE")]
        public PmdlExchange PmdlExchange { get; set; }

        [JsonPropertyName("PMDL_NOTICE")]
        public PmdlNotice PmdlNotice { get; set; }

        [JsonPropertyName("PMDL_GRAPHIC")]
        public PmdlGraphic PmdlGraphic { get; set; }

        [JsonPropertyName("PMDL_SCHEDULE")]
        public PmdlSchedule PmdlSchedule { get; set; }

        [JsonPropertyName("PMDL_EXTRA_FEE")]
        public PmdlExtraFee PmdlExtraFee { get; set; }

        [JsonPropertyName("PMDL_NATIONALITY")]
        public PmdlNationality PmdlNationality { get; set; }

        [JsonPropertyName("PMDL_HOWTO_SUMMARY")]
        public PmdlSummary PmdlHowtoSummary { get; set; }

        [JsonPropertyName("PMDL_VENUE_LOCATION")]
        public PmdlVenueLocation PmdlVenueLocation { get; set; }

        [JsonPropertyName("PMDL_SUGGESTED_ROUTE")]
        public PmdlSuggestedRoute PmdlSuggestedRoute { get; set; }

        [JsonPropertyName("PMDL_PURCHASE_SUMMARY")]
        public PmdlSummary PmdlPurchaseSummary { get; set; }

        [JsonPropertyName("PMDL_EXCHANGE_LOCATION")]
        public PmdlExchangeLocation PmdlExchangeLocation { get; set; }

        [JsonPropertyName("PMDL_INTRODUCE_SUMMARY")]
        public PmdlSummary PmdlIntroduceSummary { get; set; }

        [JsonPropertyName("PMDL_EXPERIENCE_LOCATION")]
        public PmdlExperienceLocation PmdlExperienceLocation { get; set; }

        ////////

        [JsonPropertyName("PMDL_WIFI")]
        public PmdlWifi PmdlWifi { get; set; }

        [JsonPropertyName("PMDL_INC_NINC")]
        public PmdlIncNinc PmdlIncNinc { get; set; }

        [JsonPropertyName("PMDL_SIM_CARD")]
        public PmdlSimCard PmdlSimCard { get; set; }

        [JsonPropertyName("PMDL_USE_VALID")]
        public PmdlUseValid PmdlUseValid { get; set; }

        [JsonPropertyName("PMDL_PACKAGE_DESC")]
        public PmdlPackageDesc PmdlPackageDesc { get; set; }

        [JsonPropertyName("PMDL_REFUND_POLICY")]
        public PmdlRefundPolicy PmdlRefundPolicy { get; set; }

        [JsonPropertyName("PMDL_EXCHANGE_VALID")]
        public PmdlExchangeValid PmdlExchangeValid { get; set; }
    }

    /////////////

    #region PMDL for product --- start

    public partial class PmdlExchange
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlExchangeContent Content { get; set; }
    }

    public partial class PmdlExchangeContent
    {
        [JsonPropertyName("properties")]
        public PurpleProperties Properties { get; set; }
    }

    public partial class PurpleProperties
    {
        [JsonPropertyName("exchange_type")]
        public ExchangeType ExchangeType { get; set; }

        [JsonPropertyName("description")]
        public ContentElement Description { get; set; }
    }

    public partial class ContentElement
    {
        [JsonPropertyName("desc")]
        public string Desc { get; set; }
    }

    public partial class ExchangeType
    {
        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public partial class PmdlExchangeLocation
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlExchangeLocationContent Content { get; set; }
    }

    public partial class PmdlExchangeLocationContent
    {
        [JsonPropertyName("properties")]
        public FluffyProperties Properties { get; set; }
    }

    public partial class FluffyProperties
    {
        [JsonPropertyName("collect_info")]
        public ExchangeType CollectInfo { get; set; }

        [JsonPropertyName("return_info")]
        public ExchangeType ReturnInfo { get; set; }

        [JsonPropertyName("locations")]
        public Locations Locations { get; set; }
    }

    public partial class Locations
    {
        [JsonPropertyName("list")]
        public LocationsList[] List { get; set; }

        [JsonPropertyName("table_key_langs")]
        public LocationsTableKeyLangs TableKeyLangs { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public partial class LocationsList
    {
        [JsonPropertyName("location_info")]
        public LocationInfo LocationInfo { get; set; }

        [JsonPropertyName("station_list")]
        public StationList StationList { get; set; }
    }

    public partial class LocationInfo
    {
        [JsonPropertyName("properties")]
        public LocationInfoProperties Properties { get; set; }
    }

    public partial class LocationInfoProperties
    {
        [JsonPropertyName("airport_name")]
        public ExchangeType AirportName { get; set; }

        [JsonPropertyName("terminal")]
        public ExchangeType Terminal { get; set; }

        [JsonPropertyName("store_name")]
        public ExchangeType StoreName { get; set; }

        [JsonPropertyName("latlng")]
        public Latlng Latlng { get; set; }
    }

    public partial class Latlng
    {
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }

        [JsonPropertyName("map_snap_url")]
        public string MapSnapUrl { get; set; }

        [JsonPropertyName("zoom_lv")]
        public string ZoomLv { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("place_id")]
        public string PlaceId { get; set; }
    }

    public partial class StationList
    {
        [JsonPropertyName("list")]
        public StationListList[] List { get; set; }

        [JsonPropertyName("table_key_langs")]
        public StationListTableKeyLangs TableKeyLangs { get; set; }
    }

    public partial class StationListList
    {
        [JsonPropertyName("station_desc")]
        public ContentElement StationDesc { get; set; }

        [JsonPropertyName("provide_service")]
        public ContentElement ProvideService { get; set; }

        [JsonPropertyName("active_time")]
        public ActiveTime ActiveTime { get; set; }

        [JsonPropertyName("photo")]
        public Video Photo { get; set; }

        [JsonPropertyName("video")]
        public Video Video { get; set; }

        [JsonPropertyName("active_time_desc")]
        public ContentElement ActiveTimeDesc { get; set; }

        [JsonPropertyName("arrival_desc")]
        public ContentElement ArrivalDesc { get; set; }

        [JsonPropertyName("active_tel_desc")]
        public ContentElement ActiveTelDesc { get; set; }
    }

    public partial class ActiveTime
    {
        [JsonPropertyName("list")]
        public ActiveTimeList[] List { get; set; }

        [JsonPropertyName("table_key_langs")]
        public ActiveTimeTableKeyLangs TableKeyLangs { get; set; }
    }

    public partial class ActiveTimeList
    {
        [JsonPropertyName("week_title")]
        public ContentElement WeekTitle { get; set; }

        [JsonPropertyName("close_desc")]
        public ContentElement CloseDesc { get; set; }

        [JsonPropertyName("start_time")]
        public ContentElement StartTime { get; set; }

        [JsonPropertyName("end_time")]
        public ContentElement EndTime { get; set; }

        [JsonPropertyName("last_admission")]
        public ContentElement LastAdmission { get; set; }
    }

    public partial class ActiveTimeTableKeyLangs
    {
        [JsonPropertyName("week_title")]
        public string WeekTitle { get; set; }

        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }

        [JsonPropertyName("end_time")]
        public string EndTime { get; set; }

        [JsonPropertyName("close_desc")]
        public string CloseDesc { get; set; }

        [JsonPropertyName("last_admission")]
        public string LastAdmission { get; set; }
    }

    public partial class Video
    {
        [JsonPropertyName("media")]
        public Media[] Media { get; set; }
    }

    public partial class Media
    {
        [JsonPropertyName("source_content")]
        public string SourceContent { get; set; }
    }

    public partial class StationListTableKeyLangs
    {
        [JsonPropertyName("station_desc")]
        public string StationDesc { get; set; }

        [JsonPropertyName("provide_service")]
        public string ProvideService { get; set; }

        [JsonPropertyName("arrival_desc")]
        public string ArrivalDesc { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }

        [JsonPropertyName("video")]
        public string Video { get; set; }

        [JsonPropertyName("active_time")]
        public string ActiveTime { get; set; }

        [JsonPropertyName("active_time_desc")]
        public string ActiveTimeDesc { get; set; }

        [JsonPropertyName("active_tel_desc")]
        public string ActiveTelDesc { get; set; }
    }

    public partial class LocationsTableKeyLangs
    {
        [JsonPropertyName("city_info")]
        public string CityInfo { get; set; }

        [JsonPropertyName("location_info")]
        public string LocationInfo { get; set; }

        [JsonPropertyName("station_list")]
        public string StationList { get; set; }
    }

    public partial class PmdlExperienceLocation
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlExperienceLocationContent Content { get; set; }
    }

    public partial class PmdlExperienceLocationContent
    {
        [JsonPropertyName("list")]
        public PurpleList[] List { get; set; }

        [JsonPropertyName("table_key_langs")]
        public PurpleTableKeyLangs TableKeyLangs { get; set; }
    }

    public partial class PurpleList
    {
        [JsonPropertyName("active_time_desc")]
        public ContentElement ActiveTimeDesc { get; set; }

        [JsonPropertyName("arrival_desc")]
        public ContentElement ArrivalDesc { get; set; }

        [JsonPropertyName("active_time")]
        public ActiveTime ActiveTime { get; set; }

        [JsonPropertyName("location_name")]
        public ContentElement LocationName { get; set; }

        [JsonPropertyName("latlng")]
        public Latlng Latlng { get; set; }

        [JsonPropertyName("video")]
        public Video Video { get; set; }
    }

    public partial class PurpleTableKeyLangs
    {
        [JsonPropertyName("location_name")]
        public string LocationName { get; set; }

        [JsonPropertyName("latlng")]
        public string Latlng { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }

        [JsonPropertyName("video")]
        public string Video { get; set; }

        [JsonPropertyName("active_time")]
        public string ActiveTime { get; set; }

        [JsonPropertyName("active_time_desc")]
        public string ActiveTimeDesc { get; set; }

        [JsonPropertyName("arrival_desc")]
        public string ArrivalDesc { get; set; }
    }

    public partial class PmdlExtraFee
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlExtraFeeContent Content { get; set; }
    }

    public partial class PmdlExtraFeeContent
    {
        [JsonPropertyName("list")]
        public ExchangeType[] List { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public partial class PmdlGraphic
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlGraphicContent Content { get; set; }
    }

    public partial class PmdlGraphicContent
    {
        [JsonPropertyName("list")]
        public FluffyList[] List { get; set; }
    }

    public partial class FluffyList
    {
        [JsonPropertyName("media")]
        public Media[] Media { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }
    }

    public partial class PmdlSummary
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public ContentElement Content { get; set; }
    }

    public partial class PmdlNationality
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlNationalityContent Content { get; set; }
    }

    public partial class PmdlNationalityContent
    {
        [JsonPropertyName("properties")]
        public TentacledProperties Properties { get; set; }
    }

    public partial class TentacledProperties
    {
        [JsonPropertyName("nationality_allow")]
        public ExchangeType NationalityAllow { get; set; }

        [JsonPropertyName("notes")]
        public Notes Notes { get; set; }
    }

    public partial class Notes
    {
        [JsonPropertyName("list")]
        public ContentElement[] List { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public partial class PmdlNotice
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlNoticeContent Content { get; set; }
    }

    public partial class PmdlNoticeContent
    {
        [JsonPropertyName("properties")]
        public StickyProperties Properties { get; set; }
    }

    public partial class StickyProperties
    {
        [JsonPropertyName("reminds")]
        public Reminds Reminds { get; set; }

        [JsonPropertyName("cust_reminds")]
        public CustRemindsClass CustReminds { get; set; }

        [JsonPropertyName("cust_reminds_after")]
        public Notes CustRemindsAfter { get; set; }
    }

    public partial class CustRemindsClass
    {
        [JsonPropertyName("list")]
        public ContentElement[] List { get; set; }
    }

    public partial class Reminds
    {
        [JsonPropertyName("list")]
        public ExchangeType[] List { get; set; }
    }

    public partial class PmdlSchedule
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlScheduleContent Content { get; set; }
    }

    public partial class PmdlScheduleContent
    {
        [JsonPropertyName("properties")]
        public IndigoProperties Properties { get; set; }
    }

    public partial class IndigoProperties
    {
        [JsonPropertyName("total_day")]
        public ExchangeType TotalDay { get; set; }

        [JsonPropertyName("schedule_list")]
        public ScheduleList ScheduleList { get; set; }
    }

    public partial class ScheduleList
    {
        [JsonPropertyName("list")]
        public ScheduleListList[] List { get; set; }

        [JsonPropertyName("table_key_langs")]
        public ScheduleListTableKeyLangs TableKeyLangs { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public partial class ScheduleListList
    {
        [JsonPropertyName("daily_title")]
        public ContentElement DailyTitle { get; set; }

        [JsonPropertyName("meals")]
        public CustRemindsClass Meals { get; set; }

        [JsonPropertyName("daily_schedule_list")]
        public DailyScheduleList DailyScheduleList { get; set; }
    }

    public partial class DailyScheduleList
    {
        [JsonPropertyName("table_key_langs")]
        public DailyScheduleListTableKeyLangs TableKeyLangs { get; set; }

        [JsonPropertyName("list")]
        public DailyScheduleListList[] List { get; set; }
    }

    public partial class DailyScheduleListList
    {
        [JsonPropertyName("time")]
        public ContentElement Time { get; set; }

        [JsonPropertyName("content")]
        public ContentElement Content { get; set; }

        [JsonPropertyName("media")]
        public Video Media { get; set; }
    }

    public partial class DailyScheduleListTableKeyLangs
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("media")]
        public string Media { get; set; }
    }

    public partial class ScheduleListTableKeyLangs
    {
        [JsonPropertyName("meals")]
        public string Meals { get; set; }

        [JsonPropertyName("daily_schedule_list")]
        public string DailyScheduleList { get; set; }
    }

    public partial class PmdlSuggestedRoute
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public CustRemindsClass Content { get; set; }
    }

    public partial class PmdlVenueLocation
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlVenueLocationContent Content { get; set; }
    }

    public partial class PmdlVenueLocationContent
    {
        [JsonPropertyName("list")]
        public TentacledList[] List { get; set; }

        [JsonPropertyName("table_key_langs")]
        public FluffyTableKeyLangs TableKeyLangs { get; set; }
    }

    public partial class TentacledList
    {
        [JsonPropertyName("location_name")]
        public ContentElement LocationName { get; set; }

        [JsonPropertyName("latlng")]
        public Latlng Latlng { get; set; }

        [JsonPropertyName("gather")]
        public ContentElement Gather { get; set; }

        [JsonPropertyName("setout")]
        public ContentElement Setout { get; set; }

        [JsonPropertyName("arrival_desc")]
        public ContentElement ArrivalDesc { get; set; } 

        [JsonPropertyName("photo")]
        public Video Photo { get; set; }

        [JsonPropertyName("video")]
        public Video Video { get; set; }
    }

    public partial class FluffyTableKeyLangs
    {
        [JsonPropertyName("location_name")]
        public string LocationName { get; set; }

        [JsonPropertyName("latlng")]
        public string Latlng { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }

        [JsonPropertyName("video")]
        public string Video { get; set; }

        [JsonPropertyName("gather")]
        public string Gather { get; set; }

        [JsonPropertyName("setout")]
        public string Setout { get; set; }

        [JsonPropertyName("arrival_desc")]
        public string ArrivalDesc { get; set; }
    }

    #endregion PMDL for product --- end

    /////////////

    #region PMDL for package --- start

    public partial class PmdlExchangeValid
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlExchangeValidContent Content { get; set; }
    }

    public partial class PmdlExchangeValidContent
    {
        [JsonPropertyName("properties")]
        public PurpleProperties Properties { get; set; }
    }

    public partial class PurpleProperties
    {
        [JsonPropertyName("expired")]
        public Exchange Expired { get; set; }
        
        [JsonPropertyName("exchange")]
        public Exchange Exchange { get; set; }

        [JsonPropertyName("exchange_description")]
        public Exchange ExchangeDescription { get; set; }
    }

    public partial class Exchange
    {
        [JsonPropertyName("desc")]
        public string Desc { get; set; }
    }

    public partial class PmdlIncNinc
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlIncNincContent Content { get; set; }
    }

    public partial class PmdlIncNincContent
    {
        [JsonPropertyName("properties")]
        public FluffyProperties Properties { get; set; }
    }

    public partial class FluffyProperties
    {
        [JsonPropertyName("include_item")]
        public IncludeItem IncludeItem { get; set; }

        [JsonPropertyName("not_include_item")]
        public IncludeItem NotIncludeItem { get; set; }
    }

    public partial class IncludeItem
    {
        [JsonPropertyName("list")]
        public Exchange[] List { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public partial class PmdlPackageDesc
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlPackageDescContent Content { get; set; }
    }

    public partial class PmdlPackageDescContent
    {
        [JsonPropertyName("list")]
        public Exchange[] List { get; set; }
    }

    public partial class PmdlRefundPolicy
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlRefundPolicyContent Content { get; set; }
    }

    public partial class PmdlRefundPolicyContent
    {
        [JsonPropertyName("properties")]
        public TentacledProperties Properties { get; set; }
    }

    public partial class TentacledProperties
    {
        [JsonPropertyName("policy_type")]
        public PolicyType PolicyType { get; set; }

        [JsonPropertyName("partial_refund")]
        public IncludeItem PartialRefund { get; set; }
    }

    public partial class PolicyType
    {
        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public partial class PmdlSimCard
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlSimCardContent Content { get; set; }
    }

    public partial class PmdlSimCardContent
    {
        [JsonPropertyName("properties")]
        public StickyProperties Properties { get; set; }
    }

    public partial class StickyProperties
    {
        [JsonPropertyName("datatraffic")]
        public PolicyType Datatraffic { get; set; }

        [JsonPropertyName("transmission")]
        public PolicyType Transmission { get; set; }

        [JsonPropertyName("region")]
        public PolicyType Region { get; set; }

        [JsonPropertyName("telcom")]
        public PolicyType Telcom { get; set; }

        [JsonPropertyName("simcard_type")]
        public PolicyType SimcardType { get; set; }

        [JsonPropertyName("hotspot")]
        public PolicyType Hotspot { get; set; }

        [JsonPropertyName("band")]
        public PolicyType Band { get; set; }

        [JsonPropertyName("addvalue")]
        public PolicyType Addvalue { get; set; }

        [JsonPropertyName("excludes")]
        public PolicyType Excludes { get; set; }

        [JsonPropertyName("valid_date")]
        public PolicyType ValidDate { get; set; }

        [JsonPropertyName("unsupport")]
        public PolicyType Unsupport { get; set; }

        [JsonPropertyName("notes")]
        public IncludeItem Notes { get; set; }
    }

    public partial class PmdlUseValid
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlUseValidContent Content { get; set; }
    }

    public partial class PmdlUseValidContent
    {
        [JsonPropertyName("properties")]
        public IndigoProperties Properties { get; set; }
    }

    public partial class IndigoProperties
    {
        [JsonPropertyName("exchange")]
        public Exchange Exchange { get; set; }

        [JsonPropertyName("exchange_description")]
        public Exchange ExchangeDescription { get; set; }

        [JsonPropertyName("expired")]
        public Exchange Expired { get; set; }
    }

    public partial class PmdlWifi
    {
        [JsonPropertyName("module_title")]
        public string ModuleTitle { get; set; }

        [JsonPropertyName("content")]
        public PmdlWifiContent Content { get; set; }
    }

    public partial class PmdlWifiContent
    {
        [JsonPropertyName("properties")]
        public IndecentProperties Properties { get; set; }
    }

    public partial class IndecentProperties
    {
        [JsonPropertyName("datatraffic")]
        public PolicyType Datatraffic { get; set; }

        [JsonPropertyName("transmission")]
        public PolicyType Transmission { get; set; }

        [JsonPropertyName("region")]
        public PolicyType Region { get; set; }

        [JsonPropertyName("telcom")]
        public PolicyType Telcom { get; set; }

        [JsonPropertyName("charging_time")]
        public PolicyType ChargingTime { get; set; }

        [JsonPropertyName("power_duration")]
        public PolicyType PowerDuration { get; set; }

        [JsonPropertyName("deposit")]
        public PolicyType Deposit { get; set; }

        [JsonPropertyName("weight")]
        public PolicyType Weight { get; set; }

        [JsonPropertyName("size")]
        public PolicyType Size { get; set; }

        [JsonPropertyName("max_connections")]
        public PolicyType MaxConnections { get; set; }

        [JsonPropertyName("includes")]
        public PolicyType Includes { get; set; }

        [JsonPropertyName("notes")]
        public IncludeItem Notes { get; set; }
    }

    #endregion PMDL for package --- end

    /////////////
     
}
