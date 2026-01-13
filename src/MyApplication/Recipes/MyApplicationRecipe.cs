// Copyright (c) 2026, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using Moryx.AbstractionLayer.Recipes;
using Moryx.ControlSystem.Recipes;

namespace MyApplication.Recipes;

public class MyApplicationRecipe : OrderBasedRecipe
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MyApplicationRecipe"/> class.
    /// </summary>
    public MyApplicationRecipe()
    {
    }

    /// <summary>
    /// Create a cloned <see cref="MyApplicationRecipe"/>
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
