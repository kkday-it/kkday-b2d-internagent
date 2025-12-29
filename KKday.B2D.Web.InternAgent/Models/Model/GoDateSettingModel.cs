namespace KKday.B2D.Web.InternAgent.Models.Model;

public class GoDateSettingModel
{
    public GoDateSettingDays days { get; set; }
    // 01: Single Day, 02: Start and End Date, 03 & 04: Open Date, 05: Accommodation Check-in and Check-out Dates
    public string type { get; set; }
}

public class GoDateSettingDays
{
    public int? max { get; set; }
    public int? min { get; set; }
}