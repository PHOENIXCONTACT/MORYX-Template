// Copyright (c) 2026, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using Moryx.ControlSystem.Cells;

namespace MyApplication.ControlSystem.CellSelector;

public class MyCellSelectorConfig : CellSelectorConfig
{
    public override string PluginName
    {
        get => nameof(MyCellSelector);
        set { }
    }
}
