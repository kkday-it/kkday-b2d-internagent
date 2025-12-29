namespace KKday.B2D.Web.InternAgent.Models.Model;

public class CategoryModel
{
    /// <summary>
    /// Category Code (e.g., "CATEGORY_018", "CATEGORY_020")
    /// </summary>
    public string code { get; set; }

    /// <summary>
    /// Category Name (e.g., "Itinerary & Experience", "Half/Day Trip")
    /// </summary>
    public string name { get; set; }

    /// <summary>
    /// The list of subcategories may be null or empty.
    /// </summary>
    public List<CategoryModel> children { get; set; }
}