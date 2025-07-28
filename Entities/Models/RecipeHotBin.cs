namespace Entities.Models;
public class RecipeHotBin
{
    public int RecipeId { get; set; }
    public Recipe? Recipe { get; set; }
    public int HotBinId { get; set; }
    public HotBin? HotBin { get; set; }
    public double Take { get; set; }
}
