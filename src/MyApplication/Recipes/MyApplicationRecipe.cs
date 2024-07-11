using Moryx.AbstractionLayer.Recipes;
using Moryx.ControlSystem.Recipes;

namespace MyApplication.Recipes;

public class MyApplicationRecipe : OrderBasedRecipe
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MyRecipe"/> class.
    /// </summary>
    public MyApplicationRecipe()
    {
    }

    /// <summary>
    /// Create a cloned <see cref="MyRecipe"/>
    /// </summary>
    public MyApplicationRecipe(MyApplicationRecipe source)
        : base(source)
    {
        // Copy properties here
    }

    /// <inheritdoc />
    public override IRecipe Clone()
    {
        return new MyApplicationRecipe(this);
    }
}