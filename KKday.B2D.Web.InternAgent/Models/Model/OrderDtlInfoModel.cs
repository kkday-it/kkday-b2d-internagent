using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    // B2D V4: GET /Order/QueryOrderDtlInfo/{order_no}
    public class OrderDtlInfoRespModel
    {
        public OrderDtlProductSummary product_summary { get; set; }
        public OrderDtlPackageSummary package_summary { get; set; }

        [JsonPropertyName("meeting_point")]
        public MeetingPointInfoContent MeetingPoint { get; set; }
    }

    public class OrderDtlProductSummary
    {
        public string prod_no { get; set; }
        public string prod_name { get; set; }
        public PmdlModel description_module_for_render { get; set; }
    }

    public class OrderDtlPackageSummary
    {
        public string pkg_no { get; set; }
        public string pkg_name { get; set; }
        public PmdlModel description_module_for_render { get; set; }
    }

    #region Meeting Point (Meeting/Pick-up Point) --- start

    public class MeetingPointInfoContent
    {
        [JsonPropertyName("result")] public string Result { get; set; }
        [JsonPropertyName("msg")] public string Msg { get; set; }

        // SHUTTLE | VENUE_LOCATION, null if no data is available
        [JsonPropertyName("type")] public string Type { get; set; }

        // NOT_FILLED | PARTIALLY_FILLED | FILLED
        [JsonPropertyName("meetingPointStatus")] public string MeetingPointStatus { get; set; }

        [JsonPropertyName("shuttle")] public MeetingPointShuttle Shuttle { get; set; }

        [JsonPropertyName("venueLocation")] public MeetingPointVenueLocation VenueLocation { get; set; }
    }

    public class MeetingPointShuttle
    {
        [JsonPropertyName("shuttleDate")] public string ShuttleDate { get; set; }
        [JsonPropertyName("travelerSpecUpdated")] public bool? TravelerSpecUpdated { get; set; }
        [JsonPropertyName("designatedLocation")] public MeetingPointDesignatedLocation DesignatedLocation { get; set; }
        [JsonPropertyName("designatedByCustomer")] public MeetingPointDesignatedByCustomer DesignatedByCustomer { get; set; }
        [JsonPropertyName("charterRoute")] public MeetingPointCharterRoute CharterRoute { get; set; }
    }

    public class MeetingPointDesignatedLocation
    {
        [JsonPropertyName("locationID")] public string LocationId { get; set; }
        [JsonPropertyName("locationName")] public string LocationName { get; set; }
        [JsonPropertyName("locationAddress")] public string LocationAddress { get; set; }
        [JsonPropertyName("latitude")] public double? Latitude { get; set; }
        [JsonPropertyName("longitude")] public double? Longitude { get; set; }
        [JsonPropertyName("pickupStart")] public string PickupStart { get; set; }
        [JsonPropertyName("pickupEnd")] public string PickupEnd { get; set; }
        [JsonPropertyName("photoList")] public List<string> PhotoList { get; set; }
        [JsonPropertyName("placeId")] public string PlaceId { get; set; }
        [JsonPropertyName("arrivalDesc")] public string ArrivalDesc { get; set; }
        [JsonPropertyName("orderProdSetting")] public MeetingPointOrderProdSetting OrderProdSetting { get; set; }
    }

    public class MeetingPointOrderProdSetting
    {
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("locationName")] public string LocationName { get; set; }
        [JsonPropertyName("locationAddress")] public string LocationAddress { get; set; }
        [JsonPropertyName("imageUrl")] public string ImageUrl { get; set; }
        [JsonPropertyName("timeRange")] public MeetingPointTimeRange TimeRange { get; set; }
        [JsonPropertyName("sort")] public int? Sort { get; set; }
    }

    public class MeetingPointTimeRange
    {
        // The structure is not yet finalized
        [JsonPropertyName("from")] public object From { get; set; }
        [JsonPropertyName("to")] public object To { get; set; }
    }

    public class MeetingPointDesignatedByCustomer
    {
        [JsonPropertyName("pickUp")] public MeetingPointPickUp PickUp { get; set; }
        [JsonPropertyName("dropOff")] public MeetingPointDropOff DropOff { get; set; }
    }

    public class MeetingPointPickUp
    {
        [JsonPropertyName("location")] public string Location { get; set; }
        [JsonPropertyName("locationName")] public string LocationName { get; set; }
        [JsonPropertyName("pickupStart")] public string PickupStart { get; set; }
        [JsonPropertyName("pickupEnd")] public string PickupEnd { get; set; }
        [JsonPropertyName("latitude")] public double? Latitude { get; set; }
        [JsonPropertyName("longitude")] public double? Longitude { get; set; }
        [JsonPropertyName("photoList")] public List<string> PhotoList { get; set; }
        [JsonPropertyName("placeId")] public string PlaceId { get; set; }
        [JsonPropertyName("arrivalDesc")] public string ArrivalDesc { get; set; }
        [JsonPropertyName("time")] public MeetingPointPickUpTime Time { get; set; }
    }

    public class MeetingPointPickUpTime
    {
        [JsonPropertyName("timeID")] public string TimeId { get; set; }
        [JsonPropertyName("isCustom")] public bool? IsCustom { get; set; }
        [JsonPropertyName("hour")] public int? Hour { get; set; }
        [JsonPropertyName("minute")] public int? Minute { get; set; }
    }

    public class MeetingPointDropOff
    {
        [JsonPropertyName("location")] public string Location { get; set; }
    }

    public class MeetingPointCharterRoute
    {
        [JsonPropertyName("routesID")] public string RoutesId { get; set; }
    }

    public class MeetingPointVenueLocation
    {
        // D0501 | D0502 | D0503
        [JsonPropertyName("moduleTitleCode")] public string ModuleTitleCode { get; set; }

        // fixed | confirm_after_booking
        [JsonPropertyName("timeType")] public string TimeType { get; set; }

        [JsonPropertyName("list")] public List<MeetingPointVenueLocationItem> List { get; set; }
    }

    public class MeetingPointVenueLocationItem
    {
        [JsonPropertyName("locationID")] public string LocationId { get; set; }
        [JsonPropertyName("location")] public MeetingPointVenueLocationDetail Location { get; set; }
        [JsonPropertyName("photoList")] public List<string> PhotoList { get; set; }
        [JsonPropertyName("gather")] public MeetingPointTimePoint Gather { get; set; }
        [JsonPropertyName("setout")] public MeetingPointTimePoint Setout { get; set; }
        [JsonPropertyName("arrivalDesc")] public string ArrivalDesc { get; set; }
        [JsonPropertyName("pickupStart")] public string PickupStart { get; set; }
        [JsonPropertyName("pickupEnd")] public string PickupEnd { get; set; }
        [JsonPropertyName("photo")] public MeetingPointMedia Photo { get; set; }
        // The structure is not yet finalized
        [JsonPropertyName("video")] public object Video { get; set; }
    }

    public class MeetingPointMedia
    {
        [JsonPropertyName("mediaType")] public string MediaType { get; set; }
        [JsonPropertyName("media")] public List<MeetingPointMediaItem> Media { get; set; }
    }

    public class MeetingPointMediaItem
    {
        [JsonPropertyName("sourceType")] public string SourceType { get; set; }
        [JsonPropertyName("sourceContent")] public string SourceContent { get; set; }
    }

    public class MeetingPointVenueLocationDetail
    {
        [JsonPropertyName("locationName")] public string LocationName { get; set; }
        [JsonPropertyName("queryAddress")] public string QueryAddress { get; set; }
        [JsonPropertyName("latitude")] public double? Latitude { get; set; }
        [JsonPropertyName("longitude")] public double? Longitude { get; set; }
        [JsonPropertyName("mapSnapUrl")] public string MapSnapUrl { get; set; }
        [JsonPropertyName("placeId")] public string PlaceId { get; set; }
    }

    public class MeetingPointTimePoint
    {
        [JsonPropertyName("time")] public string Time { get; set; }
    }

    #endregion Meeting Point (Meeting/Pick-up Point) --- end
}
