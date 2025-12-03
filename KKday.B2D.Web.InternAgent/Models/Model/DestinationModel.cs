namespace KKday.B2D.Web.InternAgent.Models.Model;

public class DestinationModel
{
    /// <summary>
    /// Destination Code (e.g., "D-JP-112", "D-JP-3261")
    /// </summary>
    public string code { get; set; }

    /// <summary>
    /// Destination Name (e.g., "Japan", "Tokyo")
    /// </summary>
    public string name { get; set; }

    /// <summary>
    /// The list of sub-destination locations (e.g., cities/counties within a country) may be null or empty.
    /// </summary>
    public List<DestinationModel> children { get; set; }
}