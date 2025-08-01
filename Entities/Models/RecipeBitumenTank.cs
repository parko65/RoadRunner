namespace Entities.Models;
public class RecipeBitumenTank
{
    public int RecipeId { get; set; }
    public Recipe? Recipe { get; set; }
    public int BitumenTankId { get; set; }
    public BitumenTank? BitumenTank { get; set; }
    public double Take { get; set; }
}
